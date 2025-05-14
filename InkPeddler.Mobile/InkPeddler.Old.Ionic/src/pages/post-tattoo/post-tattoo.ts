import { Component } from '@angular/core';
import {
  IonicPage,
  NavController,
  NavParams,
  ToastController,
  LoadingController,
  ActionSheetController,
  ViewController,
  Loading
} from 'ionic-angular';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Camera } from '@ionic-native/camera';
import { WebApi } from '../../api/webapi';
import { AwsS3Provider } from '../../providers/aws-s3/aws-s3';
import { TattooModel, TattooResponse, TattooImageModel, Tattoo } from '../../models/TattooModels';
import { BaseResponseModel } from '../../models/_BaseModels';
import { DataStorageProvider } from '../../providers/data-storage/data-storage';
import { BusinessesResponse, BusinessResponse } from '../../models/BusinessModels';
import {
  LocationService,
} from '@ionic-native/google-maps';
import { BusinessApiProvider } from '../../providers/business-api/business-api';

@IonicPage()
@Component({
  selector: 'page-post-tattoo',
  templateUrl: 'post-tattoo.html',
  providers: [Camera],
})
export class PostTattooPage {

  tattoo: Tattoo;
  loading: Loading;
  hideSave: boolean = false;
  editedTattooImage: boolean = false;
  tattooModel: TattooModel = new TattooModel();
  tattooImage: string = '';
  businessesResponse: BusinessesResponse = new BusinessesResponse();
  businessResponse: BusinessResponse = new BusinessResponse();

  shopSelectOptions = {
    title: 'Shops',
    subTitle: 'Select the location where this tattoo was completed.'
  };
  artistSelectOptions = {
    title: 'Artists',
    subTitle: 'Select the artist/s who finished this tattoo.'
  };

  constructor(
    public navCtrl: NavController,
    public viewCtrl: ViewController,
    public sanitizer: DomSanitizer,
    public navParams: NavParams,
    private camera: Camera,
    private toastCtrl: ToastController,
    private webApi: WebApi,
    public loadingCtrl: LoadingController,
    public actionSheetCtrl: ActionSheetController,
    private awsS3Provider: AwsS3Provider,
    private businessApi: BusinessApiProvider,
    private storage: DataStorageProvider) {
      this.laodEditableTattoo(navParams.get('tattoo'));
  }

  async ionViewDidEnter() {
    this.loadNearbyShops();
  }

  laodEditableTattoo(tattooParam){
    if (!tattooParam) return;

    // Load tattoo detains and image content
    this.tattooModel.tattoo = tattooParam;
    this.tattooImage = this.tattooModel.tattoo.MainImageUrl;

    // Load shops and artists
    if(!this.tattooModel.tattoo.BusinessId) return;
    this.getArtists(this.tattooModel.tattoo.BusinessId);
  }

  async loadNearbyShops() {
    // Load businesses within 50 miles
    let location = await LocationService.getMyLocation();
    let tempBusinessesResponse: BusinessesResponse = await this.businessApi.getBusinessListFromLatLong(location.latLng, 50);
    if (!tempBusinessesResponse || !tempBusinessesResponse.Businesses) return;
    tempBusinessesResponse.Businesses.sort(this.sortBusinesses);
    this.businessesResponse = tempBusinessesResponse;
  }

  async selectImage() {
    let actionSheet = this.actionSheetCtrl.create({
      title: 'Choose Method',
      buttons: [
        {
          text: 'Camera',
          role: 'camera',
          handler: () => {
            this.camera.getPicture({
              destinationType: this.camera.DestinationType.DATA_URL,
              quality: 100,
              targetWidth: 500,
              targetHeight: 500,
              allowEdit: true,
              correctOrientation: true,
            }).then((imageData) => {
              this.tattooImage = "data:image/jpeg;base64," + imageData;
              this.editedTattooImage = true;
            }, (err) => {
              console.error(err);
            });
          }
        }, {
          text: 'Gallery',
          role: 'gallery',
          handler: () => {
            this.camera.getPicture({
              destinationType: this.camera.DestinationType.DATA_URL,
              quality: 100,
              targetWidth: 500,
              targetHeight: 500,
              allowEdit: true,
              correctOrientation: true,
              sourceType: this.camera.PictureSourceType.SAVEDPHOTOALBUM
            }).then((imageData) => {
              this.tattooImage = "data:image/jpeg;base64," + imageData;
              this.editedTattooImage = true;
            }, (err) => {
              console.error(err);
            });
          }
        }, {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
          }
        }
      ]
    });
    actionSheet.present();
  }

  async saveTattoo() {

    // Missing Tattoo Image
    if (!this.tattooImage || this.tattooImage.length == 0) {
      this.displayErrorToast("Please select a tattoo image to upload");
      return;
    }

    // Missing Tattoo name
    if (!this.tattooModel.tattoo.Name || this.tattooModel.tattoo.Name.length == 0) {
      this.displayErrorToast("Please provide a name for this tattoo");
      return;
    }

    this.hideSave = true;
    this.showLoadingSpinner();

    // Save to DB
    this.tattooModel.tattoo.UploadedByAccountId = await this.storage.getAccountId();
    let tattooResponse: TattooResponse = await this.webApi.SaveTattoo(this.tattooModel);

    if (!tattooResponse.IsSuccess) {
      this.displayErrorToast(tattooResponse.ErrorMessage);
      this.loading.dismiss();
      return;
    }

    if (this.editedTattooImage) {
      // Assemble TattooImageModel
      let tattooImageModel: TattooImageModel = new TattooImageModel();
      tattooImageModel.tattooImage.tattooId = tattooResponse.TattooId;

      // Save image to S3
      // TODO : Handle errors and present any to the user
      tattooImageModel.tattooImage.awsImageId = await this.awsS3Provider.uploadTattooImage(this.tattooImage);

      // Save image uuid to DB
      let tattoImageResponse: BaseResponseModel = await this.webApi.SaveTattooImage(tattooImageModel);
      if (!tattoImageResponse.IsSuccess) {
        this.loading.dismiss();
        this.displayErrorToast(tattoImageResponse.ErrorMessage);
        return;
      }
    }
    this.loading.dismiss();
    this.viewCtrl.dismiss();
  }

  async getArtists(businessId: string) {
    // Get artists tied to this business Id
    let tmpBusinessResponse: BusinessResponse = await this.businessApi.getBusinessDetails(businessId);
    if (!tmpBusinessResponse || !tmpBusinessResponse.Accounts) return;
    tmpBusinessResponse.Accounts.sort(this.sortArtists);
    this.businessResponse = tmpBusinessResponse;
  }

  displayErrorToast(content: string) {
    let toast = this.toastCtrl.create({
      message: content,
      position: 'middle',
      showCloseButton: true,
      dismissOnPageChange: true,
      closeButtonText: 'Ok'
    });
    toast.present();
    toast.onDidDismiss(() => {
      this.hideSave = false;
    });
  }

  showLoadingSpinner() {
    this.loading = this.loadingCtrl.create({
      spinner: 'hide'
    });
    this.loading.data.content = this.sanitizer.bypassSecurityTrustHtml('<div class="loading-diag" ><div class="lds-hourglass"><p style="text-align: center; color: black;">Saving...</p></div></div>');
    this.loading.present();
  }

  set clickOption(business: any) {
    // TODO : Clear artists if shop changes
    if (!business || !business.Id) return;
    // Clear previously selected artist ID
    this.tattooModel.tattoo.ArtistAccountId = '';
    this.getArtists(business.Id);
  }

  sortBusinesses(a, b) {
    if (a.Name < b.Name)
      return -1;
    if (a.Name > b.Name)
      return 1;
    return 0;
  }

  sortArtists(a, b) {
    if (a.FullName < b.FullName)
      return -1;
    if (a.FullName > b.FullName)
      return 1;
    return 0;
  }

  getImgContent(): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(this.tattooImage);
  }

}

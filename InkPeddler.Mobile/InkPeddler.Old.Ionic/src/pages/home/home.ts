import { Component } from '@angular/core';
import { NavController, NavParams, ModalController, AlertController } from 'ionic-angular';
import { WebApi } from '../../api/webapi';
import { TattooArrayResponse, AllTattoosRequest, AllTattoosSearchRequest, TattooSylesRequest, TattooStylesResponse, Tattoo } from '../../models/TattooModels';
import { CONFIG } from '../../providers/app-config';
import { AccountProvider } from '../../providers/account/account';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})

export class HomePage {

  EMPTY_UUID = "00000000-0000-0000-0000-000000000000";

  page: number = 1;
  staggerFlag: boolean = false;
  showNoResultAlert: boolean = false;
  hideNoResultAlertDiv: boolean = true;
  hideNoResultTimeout: any;
  hideNoResultDivTimeout: any;
  searchTerm: string;
  tattooStyleId: string = this.EMPTY_UUID;
  tattooStyleData: TattooStylesResponse = new TattooStylesResponse();
  tattoo1Array: TattooArrayResponse = new TattooArrayResponse();
  tattoo2Array: TattooArrayResponse = new TattooArrayResponse();

  constructor(
    public navCtrl: NavController,
    private webApi: WebApi,
    public navParams: NavParams,
    public modalCtrl: ModalController,
    private alertCtrl: AlertController,
    private account: AccountProvider
  ) {
  }

  ionViewDidEnter() {
    this.fetchAndPopulate(null);
    this.fetchStyles();
  }

  async fetchAndPopulate(infiniteScroll: any, emptySearch?: boolean) {
    let tmpTattooArray: TattooArrayResponse;
    if (this.searchTerm && !emptySearch) {
      let tattoosRequest: AllTattoosSearchRequest = new AllTattoosSearchRequest(this.page, this.searchTerm);
      tmpTattooArray = await this.webApi.GetTattoosPerPageBySearchValue(tattoosRequest);
      tmpTattooArray.Tattoos = tmpTattooArray.Tattoos.filter(tattoo => tattoo.IsActive == true); // TODO : Move this to provider and make DRY
    } else {
      let tattoosRequest: AllTattoosRequest = new AllTattoosRequest(this.page, this.tattooStyleId);
      tmpTattooArray = await this.webApi.GetTattoosPerPageWithMainImage(tattoosRequest);
      tmpTattooArray.Tattoos = tmpTattooArray.Tattoos.filter(tattoo => tattoo.IsActive == true); // TODO : Move this to provider and make DRY
    }

    if ((!tmpTattooArray.Tattoos || tmpTattooArray.Tattoos.length == 0) && this.page == 1) {
      this.showNoResultAlert = true;
      this.hideNoResultAlertDiv = false;

      // Clear timeouts so we dont get any weird jitters
      clearTimeout(this.hideNoResultTimeout);
      clearTimeout(this.hideNoResultDivTimeout);
      this.hideNoResultTimeout = setTimeout(() => {
        this.showNoResultAlert = false;
        this.hideNoResultDivTimeout = setTimeout(() => {
          this.hideNoResultAlertDiv = true;
        }, 2000);
      }, 2000);
      if (!infiniteScroll) return;
      infiniteScroll.complete();
      return;
    }

    tmpTattooArray.Tattoos.forEach(tattoo => {
      if (!tattoo.AWSImageId || tattoo.AWSImageId == this.EMPTY_UUID) return;
      tattoo.MainImageUrl = CONFIG.S3BaseUrl + CONFIG.S3BucketName + '/' + CONFIG.S3EnvKey() + CONFIG.S3TattooImageKey + tattoo.AWSImageId;
      this.staggerFlag = !this.staggerFlag;
      if (this.staggerFlag) {
        this.tattoo1Array.Tattoos.push(tattoo);
        return;
      }
      this.tattoo2Array.Tattoos.push(tattoo);
    });

    this.page++;
    if (!infiniteScroll) return;
    infiniteScroll.complete();
  }

  fetchByStyle() {
    // Clear page, tattos, and style id
    this.page = 1;
    this.tattoo1Array.Tattoos = [];
    this.tattoo2Array.Tattoos = [];
    this.searchTerm = undefined;
    this.fetchAndPopulate(null);
  }

  fetchByTerm(event: any) {
    let term = event.target.value;

    // Clear page, tattos, and style id
    this.page = 1;
    this.tattoo1Array.Tattoos = [];
    this.tattoo2Array.Tattoos = [];
    this.tattooStyleId = this.EMPTY_UUID;
    this.searchTerm = term;
    this.fetchAndPopulate(null, (!term || term.trim() == ''));
  }

  async fetchStyles() {
    let stylesRequest: TattooSylesRequest = new TattooSylesRequest();
    this.tattooStyleData = await this.webApi.GetTattooStyles(stylesRequest);
  }

  clearStyleId() {
    this.tattooStyleId = this.EMPTY_UUID;
    this.fetchByStyle();
  }

  async showModal(tattoo: Tattoo) {
    let loggedIn = await this.account.getLoginStatus();
    if (!loggedIn) {
      this.presentLoginAlert();
      return;
    }
    let myModal = this.modalCtrl.create('TattooPreviewPage', { 'tattoo': tattoo });
    myModal.present();
  }

  presentLoginAlert() {
    let alert = this.alertCtrl.create({
      title: 'You need to Login',
      message: 'Do you want to login to your existing account or create a new one?',
      buttons: [
        {
          text: 'Nah',
        },
        {
          text: 'Lets Do It',
          handler: () => {
            this.navCtrl.push('SignInPage');
          }
        }
      ]
    });
    alert.present();
  }

  refresh(refresher) {

    // Clear page, tattos, and style id
    this.page = 1;
    this.staggerFlag = false;
    this.tattoo1Array.Tattoos = [];
    this.tattoo2Array.Tattoos = [];
    this.tattooStyleId = this.EMPTY_UUID;
    this.fetchAndPopulate(null);
    refresher.complete();

  }

}

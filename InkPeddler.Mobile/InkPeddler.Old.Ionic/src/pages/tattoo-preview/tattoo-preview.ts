import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ViewController, AlertController } from 'ionic-angular';
import { WebApi } from '../../api/webapi';
import { 
  TattooCommentsRequest,
  TattooCommentsResponse,
  TattooComment,
  TattooCommentSaveRequest,
  TattooTatItRequest,
  TattooIsTattedRequest,
  TattooTatItResponse
} from '../../models/TattooModels';
import { DataStorageProvider } from '../../providers/data-storage/data-storage';

@IonicPage()
@Component({
  selector: 'page-tattoo-preview',
  templateUrl: 'tattoo-preview.html',
})
export class TattooPreviewPage {

  tatted: boolean = false;
  tattoo: any;
  commentsResponse: TattooCommentsResponse = new TattooCommentsResponse();

  constructor(
    public viewCtrl: ViewController,
    public navCtrl: NavController,
    private webApi: WebApi,
    private alertCtrl: AlertController,
    public navParams: NavParams,
    private storage: DataStorageProvider) {
    this.tattoo = navParams.get('tattoo');
  }

  async ionViewDidEnter() {
    this.loadComments();
    this.getTatted();
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }

  async getTatted() {
    // TODO : Should really be in the tattoo provider
    let tattooIsTattedRequest: TattooIsTattedRequest = new TattooIsTattedRequest(this.tattoo.Id, await this.storage.getAccountId());
    let tattedResponse: TattooTatItResponse = await this.webApi.GetTattooTattedStatus(tattooIsTattedRequest);
    this.tatted = tattedResponse.IsTatted;
  }

  async loadComments() {
    // TODO : Should really be in the tattoo provider
    let tattooCommentRequest = new TattooCommentsRequest(this.tattoo.Id);
    this.commentsResponse = await this.webApi.GetTattooComments(tattooCommentRequest);
  }

  async saveComment(comment: string) {

    // TODO : Tell user to put something in the comment before saving
    if (!comment || comment.trim().length == 0) return;

    // TODO : Should really be in the tattoo provider
    let tattooComment: TattooComment = new TattooComment();
    tattooComment.AccountId = await this.storage.getAccountId();
    tattooComment.TattooId = this.tattoo.Id;
    tattooComment.Comment = comment;
    let tattooCommentRequest: TattooCommentSaveRequest = new TattooCommentSaveRequest(tattooComment);
    await this.webApi.SaveTattooComment(tattooCommentRequest);
  }

  async tatIt() {
    if (this.tatted) return;
    // TODO : Should really be in the tattoo provider
    let tatItRequest: TattooTatItRequest = new TattooTatItRequest(this.tattoo.Id, await this.storage.getAccountId());
    await this.webApi.SaveTattooTatIt(tatItRequest);
    // TODO : Error handling
    this.tatted = true;
  }

  showCommentDialog() {
    let alert = this.alertCtrl.create({
      title: 'Comment',
      inputs: [
        {
          name: 'comment',
          placeholder: 'Comment'
        }
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: data => {
          }
        },
        {
          text: 'Save',
          handler: data => {
            this.saveComment(data.comment).then(() => {
              this.loadComments();
            });
          }
        }
      ]
    });
    alert.present();
  }

  viewBusiness() {
    if (!this.tattoo.BusinessId) return;
    this.navCtrl.push('BusinessProfilePage', { businessId: this.tattoo.BusinessId });
  }

  viewArtist() {
    if (!this.tattoo.ArtistAccountId) return;
    this.navCtrl.push('ArtistProfilePage', { artistAccountId: this.tattoo.ArtistAccountId });
  }

}

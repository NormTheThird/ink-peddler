import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { WebApi } from '../../../api/webapi';
import { EmailModel } from '../../../models/SecurityModels';
import { MessageModel } from '../../../models/_BaseModels';
import { Http } from '@angular/http';


@IonicPage()
@Component({ selector: 'page-forgot-password', templateUrl: 'forgot-password.html' })

export class ForgotPasswordPage {

  EmailModel: EmailModel;
  MessageModel: MessageModel;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public http: Http,
    private webApi: WebApi) {
    this.EmailModel = new EmailModel();
    this.MessageModel = new MessageModel("");
  }

  Submit = function () {
    this.webApi.PasswordReset(this.EmailModel).then(response => {
      if (!response.IsSuccess) {
        this.MessageModel = new MessageModel(response.ErrorMessage, true);
        return;
      }
      this.MessageModel = new MessageModel("A reset link has been sent to your email!", false);
      setTimeout(() => {
        this.navCtrl.pop();
      }, 1000);
    });
  }
}
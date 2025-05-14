import { Component } from '@angular/core';
import {
  IonicPage,
  NavController,
  NavParams,
  LoadingController,
  Loading,
  Events
} from 'ionic-angular';
import { LoginModel } from '../../../models/SecurityModels';
import { MessageModel } from '../../../models/_BaseModels';
import { DomSanitizer } from '@angular/platform-browser';
import { WebApi } from '../../../api/webapi';
import { TabsPage } from '../../tabs/tabs';

@IonicPage()
@Component({ selector: 'page-sign-in', templateUrl: 'sign-in.html' })

export class SignInPage {

  Login: LoginModel;
  MessageModel: MessageModel;
  loading: Loading;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    public events: Events,
    public sanitizer: DomSanitizer,
    private webApi: WebApi) {
    this.Login = new LoginModel();
    this.MessageModel = new MessageModel("");
  }

  SignUp = function () {
    this.navCtrl.push('SignUpPage');
  }

  async SignIn() {
    this.showLoadingSpinner();
    let response = await this.webApi.Login(this.Login);
    this.loading.dismiss();
    if (!response.IsSuccess) {
      this.MessageModel = new MessageModel(response.ErrorMessage, true);
      return;
    }
    this.events.publish('login:evaluate');
    this.navCtrl.setRoot(TabsPage);
  }

  ForgotPassword = function () {
    this.navCtrl.push('ForgotPasswordPage');
  }

  showLoadingSpinner() {
    this.loading = this.loadingCtrl.create({
      spinner: 'hide'
    });
    this.loading.data.content = this.sanitizer.bypassSecurityTrustHtml('<div class="loading-diag" ><div class="lds-hourglass"><p style="text-align: center; color: black;">Logging in...</p></div></div>');
    this.loading.present();
  }

}
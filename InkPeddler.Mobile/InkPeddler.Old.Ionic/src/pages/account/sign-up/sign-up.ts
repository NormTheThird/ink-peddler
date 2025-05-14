import { Component } from '@angular/core';
import {
  IonicPage,
  NavController,
  NavParams,
  LoadingController,
  Loading,
  Events
} from 'ionic-angular';
import { EmailModel, RegisterModel, LoginModel } from '../../../models/SecurityModels';
import { WebApi } from '../../../api/webapi';
import { trigger, state, style } from '@angular/animations';
import { MessageModel } from '../../../models/_BaseModels';
import { Http } from '@angular/http';
import { DomSanitizer } from '@angular/platform-browser';
import { TabsPage } from '../../tabs/tabs';

@IonicPage()
@Component({
  selector: 'page-sign-up',
  templateUrl: 'sign-up.html',
  animations: [
    trigger('checkVisibility', [
      state('notChecking', style({ opacity: 1 })),
      state('checking', style({ opacity: 0 })),
      state('valid', style({ opacity: 0 })),
      state('invalid', style({ opacity: 0 }))
    ])
  ]
})

export class SignUpPage {

  Register: RegisterModel;
  Login: LoginModel;
  EmailIsValid: boolean;
  MessageModel: MessageModel;
  loading: Loading;

  emailCheckVisibility = 'notChecking';

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public http: Http,
    public loadingCtrl: LoadingController,
    public sanitizer: DomSanitizer,
    public events: Events,
    private webApi: WebApi) {
    this.Register = new RegisterModel();
    this.MessageModel = new MessageModel("");
    this.EmailIsValid = false;
  }

  GetEmailAvailability = async function () {
    this.MessageModel = new MessageModel("");
    let data = new EmailModel();
    data.Email = this.Register.Email;
    let response = await this.webApi.GetEmailAvailability(data);
    if (!response.IsSuccess) {
      this.MessageModel = new MessageModel(response.ErrorMessage, true);
      return;
    }
    this.EmailIsValid = true;
  }

  RegisterUser = function () { this.RegisterAccount(false); }
  RegisterArtist = function () { this.RegisterAccount(true); }
  RegisterAccount = async function (isArtist: boolean) {
    if (!this.EmailIsValid) {
      this.MessageModel = new MessageModel("Please enter a valid email", true);
      return;
    }
    this.Register.isArtist = isArtist;

    this.showLoadingSpinner();

    let response = await this.webApi.Register(this.Register);
    if (!response.IsSuccess) {
      this.MessageModel = new MessageModel(response.ErrorMessage, true);
      this.loading.dismiss();
      return;
    }

    // Log the user in right after a successful registration call
    let login = new LoginModel();
    login.Login = this.Register.Email;
    login.Password = this.Register.Password;
    response = await this.webApi.Login(login);

    this.loading.dismiss();
    if (!response.IsSuccess) {
      this.MessageModel = new MessageModel(response.ErrorMessage, true);
      return;
    }
    this.events.publish('login:evaluate');
    this.navCtrl.setRoot(TabsPage);
  }

  showLoadingSpinner() {
    this.loading = this.loadingCtrl.create({
      spinner: 'hide'
    });
    this.loading.data.content = this.sanitizer.bypassSecurityTrustHtml('<div class="loading-diag" ><div class="lds-hourglass"><p style="text-align: center; color: black;">registering...</p></div></div>');
    this.loading.present();
  }

}
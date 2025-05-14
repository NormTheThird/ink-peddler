import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, ModalController } from 'ionic-angular';
import { AccountModel } from '../../models/SecurityModels';
import { TattooArrayResponse, Tattoo } from '../../models/TattooModels';
import { TattooProvider } from '../../providers/tattoo/tattoo';
import { AccountProvider } from '../../providers/account/account';

@IonicPage()
@Component({
  selector: 'page-user-profile',
  templateUrl: 'user-profile.html'
})
export class UserProfilePage {

  debounceTimeout: NodeJS.Timeout;
  tattooArray: TattooArrayResponse = new TattooArrayResponse();
  details: string = "tattoos";
  account: AccountModel = new AccountModel('');
  maskedPhoneNumber: string;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private alertCtrl: AlertController,
    public modalCtrl: ModalController,
    private tattooProvider: TattooProvider,
    private accountProvider: AccountProvider, ) {
  }

  async ionViewDidEnter() {
    this.fetchAccountInfo();
    this.fetchUserTattoos();
  }

  async fetchAccountInfo() {
    this.account = await this.accountProvider.fetchUserAccountInfo();
    this.maskPhoneNumber(this.account.PhoneNumber);
  }

  async fetchUserTattoos() {
    this.tattooArray = await this.tattooProvider.fetchUserTattoos();
  }

  async dataModified(event) {
    // Debounce
    clearTimeout(this.debounceTimeout);
    // TODO : May be an issue here if a valid save is triggered an they backspace a bunch of charaters. This will pickup an invalid PN
    this.debounceTimeout = setTimeout(() => {
      // Automatically save data
      // TODO : Cient validation
      this.accountProvider.saveUserAccount(this.account);
    }, 1000);
  }

  phoneNumberModified(event) {
    if (!/^\d+$/.test(event.key) && event.keyCode != 8) return false;
    let newNumber;
    if (event.keyCode == 8) {
      newNumber = this.maskedPhoneNumber.slice(0, this.maskedPhoneNumber.length - 1);
    } else {
      newNumber = this.maskedPhoneNumber + event.key;
    }
    this.maskPhoneNumber(newNumber);
    return false;
  }

  maskPhoneNumber(phoneNumber: string) {
    let validNumber: boolean = false;
    let group: any = phoneNumber.replace(/\D/g, '').match(/(\d{0,3})?(\d{0,3})?(\d{0,4})?/);
    let areaCode = typeof group[1] !== 'undefined' ? group[1] : '';
    let prefix = typeof group[2] !== 'undefined' ? group[2] : '';
    let lineNumber = typeof group[3] !== 'undefined' ? group[3] : '';

    if (lineNumber.length > 0) {
      this.maskedPhoneNumber = '(' + areaCode + ') ' + prefix + '-' + lineNumber;
      if (lineNumber.length == 4) {
        validNumber = true;
      }
    } else if (prefix.length > 0) {
      this.maskedPhoneNumber = '(' + areaCode + ') ' + prefix
    } else if (areaCode.length > 0) {
      this.maskedPhoneNumber = '(' + areaCode
    } else {
      this.maskedPhoneNumber = '';
    }
    this.account.PhoneNumber = this.maskedPhoneNumber.replace(/\D/g, '');
    if (!validNumber) return;
    this.dataModified(null);
  }

  async deleteTattoo(tattoo: Tattoo) {
    let alert = this.alertCtrl.create({
      title: 'Confirm Delete',
      message: 'Are you sure you want to delete this tattoo?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'Delete',
          handler: () => {
            this.tattooProvider.deleteTattoo(tattoo).then((result) => {
              this.fetchUserTattoos();
            });
          }
        }
      ]
    });
    alert.present();
  }

  async editTattoo(tattoo: Tattoo) {
    let myModal = this.modalCtrl.create('PostTattooPage', { tattoo: tattoo });
    myModal.present();
  }

  addNewTattoo() {
    let myModal = this.modalCtrl.create('PostTattooPage');
    myModal.present();
  }

}

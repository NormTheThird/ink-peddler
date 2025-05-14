import { Component, ViewChild } from '@angular/core';
import {
  MenuController,
  Events,
  Tabs,
  NavController,
  AlertController
} from 'ionic-angular';
import { HomePage } from '../home/home';
import { UserProfilePage } from '../user-profile/user-profile';
import { MapPage } from '../map/map';
import { AccountProvider } from '../../providers/account/account';

@Component({
  selector: 'page-tabs',
  templateUrl: 'tabs.html'
})

export class TabsPage {
  @ViewChild('navTabs') tabRef: Tabs;

  loggedIn: boolean = false;
  tab1Root = HomePage;
  tab2Root = MapPage;
  tab3Root = UserProfilePage;
  tab4Root = MapPage;

  constructor(
    public menuCtrl: MenuController,
    public events: Events,
    public navCtrl: NavController,
    public alertCtrl: AlertController,
    private account: AccountProvider) {
    this.account.getLoginStatus().then(
      (result) => this.evaluateLogin(result)
    );

    this.events.subscribe('login:evaluate', () => {
      this.account.getLoginStatus().then(
        (result) => this.evaluateLogin(result)
      )
    });
  }

  evaluateLogin(status?: boolean) {
    this.loggedIn = status;
    if (status === undefined || status == false) {
      this.tabRef.select(0);
    }
  }

  async loginout() {
    if (!this.loggedIn) {
      this.navCtrl.push('SignInPage');
      return;
    }
    const logoutAlert = this.alertCtrl.create({
      title: 'Sign Out',
      subTitle: 'Are you sure you want to sign out?',
      buttons: [
        {
          text: 'Cancel',
        },
        {
          text: 'Yes',
          handler: data => {
            this.account.logOut().then(() => {
              this.loggedIn = false;
              this.evaluateLogin();
            });
          }
        }
      ]
    });
    logoutAlert.present();
  }

}

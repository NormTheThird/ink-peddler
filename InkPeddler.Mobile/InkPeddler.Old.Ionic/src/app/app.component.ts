import { Component, ViewChild } from '@angular/core';
import {
  Nav,
  Platform,
  MenuController,
  Events
} from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { AccountProvider } from '../providers/account/account';
import { WebApi } from '../api/webapi';
import { TabsPage } from '../pages/tabs/tabs';

@Component({
  templateUrl: 'app.html'
})

export class MyApp {
  @ViewChild(Nav) nav: Nav;

  REFRESH_INTERVAL: number = 480000; // 8 Minutes

  rootPage: any;

  constructor(
    public platform: Platform,
    public statusBar: StatusBar,
    public splashScreen: SplashScreen,
    public menuCtrl: MenuController,
    public events: Events,
    private webApi: WebApi,
    private account: AccountProvider) {
    this.initializeApp();
  }

  async initializeApp() {
    this.rootPage = TabsPage;
    this.platformReady();

    await this.checkAccess();

    setInterval(() => {
      this.checkAccess();
    }, this.REFRESH_INTERVAL);

  }

  async checkAccess() {
    let success = await this.webApi.RenewToken();
    if (success) return;
    // Logout user if refresh token failed
    await this.account.logOut();
    this.events.publish('login:evaluate');
  }

  async platformReady() {
    await this.platform.ready();
    if (this.platform.is('ios')) {
      this.statusBar.overlaysWebView(false);
    }
    this.statusBar.backgroundColorByHexString('#202020');
    this.splashScreen.hide();
  }

}

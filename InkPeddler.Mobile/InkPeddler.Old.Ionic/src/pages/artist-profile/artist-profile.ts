import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AccountProvider } from '../../providers/account/account';
import { TattooArrayResponse, ArtistTattoosRequest } from '../../models/TattooModels';
import { AccountModel } from '../../models/SecurityModels';
import { TattooProvider } from '../../providers/tattoo/tattoo';

@IonicPage()
@Component({
  selector: 'page-artist-profile',
  templateUrl: 'artist-profile.html',
})
export class ArtistProfilePage {

  account: AccountModel = new AccountModel('');
  staggerFlag: boolean = false;
  details: string = 'portfolio';
  artistAccounId: string;
  tattoo1Array: TattooArrayResponse = new TattooArrayResponse();
  tattoo2Array: TattooArrayResponse = new TattooArrayResponse();

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private accountProvider: AccountProvider,
    private tattooProvider: TattooProvider) {
    this.artistAccounId = navParams.get('artistAccountId');
  }

  async ionViewDidEnter() {
    this.fetchArtistInfo(this.artistAccounId);
    this.fetchTattoos(this.artistAccounId);
  }

  async fetchArtistInfo(accountId: string) {
    this.account = await this.accountProvider.fetchAccountInfo(accountId);
  }

  async fetchTattoos(accountId: string) {
    let tmpTattooArray = await this.tattooProvider.fetchAccountTattoos(accountId);
    tmpTattooArray.Tattoos.forEach(tattoo => {
      this.staggerFlag = !this.staggerFlag;
      if (this.staggerFlag) {
        this.tattoo1Array.Tattoos.push(tattoo);
        return;
      }
      this.tattoo2Array.Tattoos.push(tattoo);
    });
  }

}

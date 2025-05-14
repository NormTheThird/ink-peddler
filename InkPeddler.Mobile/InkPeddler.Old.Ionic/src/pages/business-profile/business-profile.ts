import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { BusinessResponse, Account } from '../../models/BusinessModels';
import { BusinessApiProvider } from '../../providers/business-api/business-api';

@IonicPage()
@Component({
  selector: 'page-business-profile',
  templateUrl: 'business-profile.html',
})
export class BusinessProfilePage {

  businessId: string = '';
  businessModel: BusinessResponse = new BusinessResponse();
  details: string = "artists";
  artistResult: string = "";

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private businessApi: BusinessApiProvider) {
    this.businessId = navParams.get('businessId');
    this.loadBusinessDetails();
  }

  async loadBusinessDetails() {

    let artistCount = 0;
    this.businessModel = await this.businessApi.getBusinessDetails(this.businessId);
    this.businessModel.Accounts.forEach((account) => {
      if (!account.IsArtist) return;
      artistCount++;
    });

    if (artistCount === 1) {
      this.artistResult = '1 Artist available';
    } else {
      this.artistResult = artistCount + ' Artists available';
    }

  }

  goToArtistProfile(account: Account) {
    this.navCtrl.push('ArtistProfilePage', { artistAccountId: account.AccountId });
  }

}

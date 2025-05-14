import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { ArtistProfilePage } from './artist-profile';

@NgModule({
  declarations: [
    ArtistProfilePage,
  ],
  imports: [
    IonicPageModule.forChild(ArtistProfilePage),
  ],
})
export class ArtistProfilePageModule {}

import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { TattooPreviewPage } from './tattoo-preview';

@NgModule({
  declarations: [
    TattooPreviewPage,
  ],
  imports: [
    IonicPageModule.forChild(TattooPreviewPage),
  ],
})
export class TattooPreviewPageModule {}

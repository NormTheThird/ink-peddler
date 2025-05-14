import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { PostTattooPage } from './post-tattoo';

@NgModule({
  declarations: [
    PostTattooPage,
  ],
  imports: [
    IonicPageModule.forChild(PostTattooPage),
  ],
})
export class PostTattooPageModule {}

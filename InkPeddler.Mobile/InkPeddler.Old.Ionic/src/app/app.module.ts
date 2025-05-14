import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { IonicStorageModule } from '@ionic/storage';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { SignInPage } from '../pages/account/sign-in/sign-in';
import { SignInPageModule } from '../pages/account/sign-in/sign-in.module';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { DataStorageProvider } from '../providers/data-storage/data-storage';
import { HomePageModule } from '../pages/home/home.module';
import { AccountProvider } from '../providers/account/account';
import { WebApi } from '../api/webapi';
import { BusinessApiProvider } from '../providers/business-api/business-api';
import { AwsS3Provider } from '../providers/aws-s3/aws-s3';
import { TattooProvider } from '../providers/tattoo/tattoo';
import { TabsPageModule } from '../pages/tabs/tabs.module';
import { TabsPage } from '../pages/tabs/tabs';
import { UserProfilePage } from '../pages/user-profile/user-profile';
import { UserProfilePageModule } from '../pages/user-profile/user-profile.module';
import { MapPageModule } from '../pages/map/map.module';
import { MapPage } from '../pages/map/map';

@NgModule({
  declarations: [
    MyApp,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    IonicModule.forRoot(MyApp, {
      mode: 'md',
    }),
    IonicStorageModule.forRoot({
      name: '__inkpeddler',
      driverOrder: ['sqlite', 'indexeddb', 'websql']
    }),
    SignInPageModule,
    HomePageModule,
    UserProfilePageModule,
    MapPageModule,
    TabsPageModule,
    HttpModule,
    HttpClientModule,
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    SignInPage,
    HomePage,
    TabsPage,
    MapPage,
    UserProfilePage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    DataStorageProvider,
    AccountProvider,
    WebApi,
    BusinessApiProvider,
    AwsS3Provider,
    TattooProvider
  ]
})
export class AppModule { }

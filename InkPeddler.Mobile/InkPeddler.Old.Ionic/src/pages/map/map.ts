import {
  GoogleMaps,
  GoogleMap,
  GoogleMapOptions,
  LocationService,
  Environment,
  GoogleMapsEvent,
  GoogleMapsMapTypeId,
  Marker,
  Circle,
  LatLng,
} from '@ionic-native/google-maps';
import { Component, } from '@angular/core';
import { IonicPage, NavController, AlertController } from 'ionic-angular';
import { BusinessApiProvider } from '../../providers/business-api/business-api';
import { BusinessesResponse } from '../../models/BusinessModels';

@IonicPage()
@Component({
  selector: 'page-map',
  templateUrl: 'map.html',
})

export class MapPage {

  map: GoogleMap;
  selectedRadiusMi: number = 10;
  currentLocationMarker: Marker;
  radiusCircle: Circle;
  radiusSelectOpen: boolean = false;
  searchResult: string = '';
  showResultAlert: boolean = false;
  hideNoResultAlertDiv: boolean = true;
  currentLocation: LatLng;
  hideNoResultTimeout: any;
  hideNoResultDivTimeout: any;

  constructor(
    public navCtrl: NavController,
    private businessApi: BusinessApiProvider,
    public alertCtrl: AlertController) {
    this.loadMap();
  }

  async loadMap() {

    Environment.setEnv({
      'API_KEY_FOR_BROWSER_RELEASE': 'AIzaSyDP_V1Z5KLORWgKTdhZOecQLGRPZqrf5xU',
      'API_KEY_FOR_BROWSER_DEBUG': 'AIzaSyDP_V1Z5KLORWgKTdhZOecQLGRPZqrf5xU'
    });

    // Get user's location
    let mapOptions: GoogleMapOptions = {
      mapType: GoogleMapsMapTypeId.NORMAL,
      controls: {
        compass: false,
        myLocationButton: false,
        mapToolbar: false,
        myLocation: false,
        indoorPicker: false,
        zoom: false
      }
    };

    this.map = GoogleMaps.create('map_canvas', mapOptions);

    this.findMyLocation();

  }

  async findMyLocation() {
    let location = await LocationService.getMyLocation();
    this.currentLocation = location.latLng;
    this.refreshMap(this.currentLocation);
  }

  async refreshMap(location: LatLng) {
    this.map.clear();

    this.currentLocationMarker = this.map.addMarkerSync({
      title: 'My location',
      icon: '#9E00B2',
      animation: 'DROP',
      position: {
        lat: location.lat,
        lng: location.lng
      }
    });

    this.radiusCircle = await this.map.addCircle({
      center: this.currentLocationMarker.getPosition(),
      radius: this.businessApi.toMeters(this.selectedRadiusMi),
      strokeWidth: 0,
      fillColor: "rgba(159, 225, 56, 0.2)",
      strokeColor: "rgba(159, 225, 56, 0.0)",
    });

    this.map.moveCamera({
      target: this.radiusCircle.getBounds()
    });

    this.populateShops(location, this.selectedRadiusMi);
  }

  async populateShops(currentLocation: LatLng, searchRadius: number) {
    let result: BusinessesResponse = await this.businessApi.getBusinessListFromLatLong(currentLocation, searchRadius);
    result.Businesses.forEach(business => {
      let marker: Marker = this.map.addMarkerSync({
        businessId: business.Id,
        title: business.Name,
        icon: '#ea4335',
        animation: 'DROP',
        position: {
          lat: business.Latitude,
          lng: business.Longitude
        }
      });
      marker.on(GoogleMapsEvent.MARKER_CLICK).subscribe((parameters) => {
        let marker: Marker = <Marker>parameters[1];
        let businessId: string = marker.get('businessId');
        this.navCtrl.push('BusinessProfilePage', { businessId: businessId });
      });
    });

    this.showResultAlert = true;
    this.hideNoResultAlertDiv = false;

    if (result.Businesses.length === 0) {
      this.searchResult = 'Sorry, no shops found.';
    } else if (result.Businesses.length === 1) {
      this.searchResult = 'We found 1 shop nearby!';
    } else if (result.Businesses.length > 1) {
      this.searchResult = 'We found ' + result.Businesses.length + ' shops in your area!';
    }

    clearTimeout(this.hideNoResultTimeout);
    clearTimeout(this.hideNoResultDivTimeout);
    this.hideNoResultTimeout = setTimeout(() => {
      this.showResultAlert = false;
      this.hideNoResultDivTimeout = setTimeout(() => {
        this.hideNoResultAlertDiv = true;
      }, 3000);
    }, 3000);

  }

  changeRadius() {
    let alert = this.alertCtrl.create();
    alert.setTitle('Search Radius');
    alert.addInput({
      type: 'radio',
      label: '1 mile',
      value: '1',
      checked: this.selectedRadiusMi === 1 ? true : false
    });
    alert.addInput({
      type: 'radio',
      label: '5 miles',
      value: '5',
      checked: this.selectedRadiusMi === 5 ? true : false
    });
    alert.addInput({
      type: 'radio',
      label: '10 miles',
      value: '10',
      checked: this.selectedRadiusMi === 10 ? true : false
    });
    alert.addInput({
      type: 'radio',
      label: '25 miles',
      value: '25',
      checked: this.selectedRadiusMi === 25 ? true : false
    });
    alert.addInput({
      type: 'radio',
      label: '50 miles',
      value: '50',
      checked: this.selectedRadiusMi === 50 ? true : false
    });
    alert.addButton('Cancel');
    alert.addButton({
      text: 'Ok',
      handler: (data: any) => {
        this.selectedRadiusMi = Number(data);
        this.refreshMap(this.currentLocation);
      }
    });

    alert.present();
  }

}

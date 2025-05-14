import { LatLng } from '@ionic-native/google-maps';
import { Injectable } from '@angular/core';
import { WebApi } from '../../api/webapi';
import { GetBusinessesForLocationRequest, GetBusinessAndAccountsRequest, BusinessesResponse, BusinessResponse } from '../../models/BusinessModels';

@Injectable()
export class BusinessApiProvider {

  constructor(private webApi: WebApi) { }

  toMeters(miles: number) {
    return Math.ceil(miles * 1609.34);
  }

  async getBusinessListFromLatLong(currentLocation: LatLng, searchRadius: number): Promise<BusinessesResponse> {

    if (currentLocation === undefined) {
      throw new Error('Current location is undefined');
    }

    if (searchRadius === undefined || searchRadius < 1) {
      throw new Error('Search radius undefined or less than 1');
    }

    let locationRequestModel = new GetBusinessesForLocationRequest();
    locationRequestModel.Latitude = currentLocation.lat;
    locationRequestModel.Longitude = currentLocation.lng;
    locationRequestModel.Radius = searchRadius;

    try {
      let businesses: BusinessesResponse = new BusinessesResponse();
      businesses = await this.webApi.GetBusinessesForLocation(locationRequestModel);
      return businesses;
    } catch (e) {
      throw e;
    }

  }

  async getBusinessDetails(businessId: string): Promise<BusinessResponse> {

    if (businessId === undefined) {
      throw new Error('Business Id is undefined');
    }

    let businessRequestModel = new GetBusinessAndAccountsRequest();
    businessRequestModel.BusinessId = businessId;

    try {
      let business: BusinessResponse = new BusinessResponse();
      business = await this.webApi.GetBusinessAndAccounts(businessRequestModel);
      return business;
    } catch (e) {
      throw e;
    }

  }

}

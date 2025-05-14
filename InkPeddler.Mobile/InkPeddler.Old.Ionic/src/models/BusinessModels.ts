import { BaseResponseModel } from "./_BaseModels";

export class GetBusinessesRequest {

  getActiveAndInactive: boolean;

  constructor() {
    this.getActiveAndInactive = false;
  }

}

export class GetBusinessesForLocationRequest {

  Latitude: number;
  Longitude: number;
  Radius: number;

  constructor() {
    this.Latitude = 0;
    this.Longitude = 0;
    this.Radius = 0;
  }

}

export class GetBusinessAndAccountsRequest {

  BusinessId: string;

  constructor() {
    this.BusinessId = "";
  }

}

export class Account {

  AccountId: string;
  FullName: string;
  PhoneNumber: string;
  IsOwner: boolean;
  IsManager: boolean;
  IsArtist: boolean;

  constructor() {
    this.AccountId = "";
    this.FullName = "";
    this.PhoneNumber = "";
    this.IsOwner = false;
    this.IsManager = false;
    this.IsArtist = false;
  }

}

export class Business {

  Id: string;
  Name: string;
  PhoneNumber: string;
  FullAddress: string;
  Latitude: number;
  Longitude: number;

  constructor() {
    this.Id = "";
    this.Name = "";
    this.PhoneNumber = "";
    this.FullAddress = "";
    this.Latitude = 0;
    this.Longitude = 0;
  }

}

export class BusinessesResponse extends BaseResponseModel {
  Businesses: Business[];
  constructor() {
    super();
    this.Businesses = [];
  }
}

export class BusinessResponse extends BaseResponseModel {

  Business: Business;
  Accounts: Account[];

  constructor() {
    super();
    this.Business = new Business();
    this.Accounts = [];
  }
}
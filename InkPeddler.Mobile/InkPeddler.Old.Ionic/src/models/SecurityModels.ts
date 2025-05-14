import { ActiveModel, BaseResponseModel } from "./_BaseModels";

export class EmailModel {
  Email: string;

  constructor() {
    this.Email = "";
  }
}

export class RegisterModel {
  Password: string;
  IsArtist: boolean;
  Email: string;

  constructor() {
    this.Email = "";
    this.Password = "";
    this.IsArtist = false;
  }
}

export class TokenModel {
  refresh_token: string;
  grant_type: string;
  constructor(refreshToken) {
    this.refresh_token = refreshToken;
    this.grant_type = "refresh_token";
  }
}

export class LoginModel {
  Password: string;
  Login: string;

  constructor() {
    this.Password = "";
    this.Login = "";
  }
}

export class AccountModel extends ActiveModel {
  AWSProfileImageId: string;
  FirstName: string;
  LastName: string;
  Email: string;
  PhoneNumber: string;
  ProfileImageUrl: string;
  IsArtist: boolean;

  constructor(data: any) {
    super(data);
    this.AWSProfileImageId = (data ? data.AWSProfileImageId : "");
    this.FirstName = (data ? data.FirstName : "");
    this.LastName = (data ? data.LastName : "");
    this.Email = (data ? data.Email : "");
    this.PhoneNumber = (data ? data.PhoneNumber : "");
    this.ProfileImageUrl = (data ? data.ProfileImageUrl : "");
    this.IsArtist = (data ? data.IsArtist : false);
  }

  get Name() {
    return this.FirstName + ' ' + this.LastName;
  }
}

export class AccountSaveRequestModel {
  Account: AccountModel;
  constructor(data) {
    this.Account = data;
  }
}

export class AccountRequestModel {
  accountId: string;
  constructor(data: string) {
    this.accountId = (data ? data : "");
  }
}

export class AccountResponseModel extends BaseResponseModel {
  Account: AccountModel;
  constructor(data: any) {
    super();
    this.Account = new AccountModel(data);
  }
}

export class ArtistModel extends AccountModel {

  constructor(data: any) {
    super(data);

  }
}
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { BaseResponseModel } from '../models/_BaseModels';
import { EmailModel, RegisterModel, LoginModel, AccountRequestModel, AccountSaveRequestModel, TokenModel } from '../models/SecurityModels';
import { GetBusinessesForLocationRequest, GetBusinessAndAccountsRequest, GetBusinessesRequest } from '../models/BusinessModels';
import { DataStorageProvider } from '../providers/data-storage/data-storage';
import {
  TattooModel,
  TattooImageModel,
  UserTattoosRequest,
  ArtistTattoosRequest,
  AllTattoosRequest,
  AllTattoosSearchRequest,
  TattooSylesRequest,
  TattooCommentsRequest,
  ChangeTattooStatusRequest,
  TattooCommentSaveRequest,
  TattooTatItRequest,
  TattooIsTattedRequest,
} from '../models/TattooModels';
import { CONFIG } from '../providers/app-config';

@Injectable()
export class WebApi {

  constructor(private http: Http, private storage: DataStorageProvider) {
  }

  async RenewServiceCall(url: string): Promise<boolean> {

    let baseResponse = new BaseResponseModel();
    let refreshToken: string = await this.storage.getRefreshToken();
    if (!refreshToken || refreshToken.length == 0) return true;

    let headers = new Headers();
    headers.append('Accept', 'application/json');
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    headers.append('account_id', await this.storage.getAccountId());

    let options = new RequestOptions({ headers: headers });

    let requestModel: TokenModel = new TokenModel(refreshToken);
    let requestString: string = "grant_type=" + requestModel.grant_type + "&refresh_token=" + requestModel.refresh_token;

    try {
      let response = await this.http.post(CONFIG.BaseUrl() + url, requestString, options).toPromise();
      let accessToken: string = JSON.parse(response['_body']).access_token;
      let newRefreshToken = JSON.parse(response['_body']).refresh_token;
      if (accessToken === undefined || accessToken.length === 0) {
        baseResponse.ErrorMessage = 'access_token returned empty or null';
        return false;
      }
      if (newRefreshToken === undefined || newRefreshToken.length === 0) {
        baseResponse.ErrorMessage = 'refresh_token returned empty or null';
        return false;
      }
      baseResponse.IsSuccess = true;
      this.storage.setRefreshToken(newRefreshToken);
      this.storage.setApiToken(accessToken);
      return true;
    } catch (e) {
      // Ignore error
    }
  }

  async LoginServiceCall(url: string, data?: any): Promise<any> {

    let headers = new Headers();
    headers.append('Accept', 'application/json');
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    headers.append('Login', data.Login);
    headers.append('Password', data.Password);

    let baseResponse = new BaseResponseModel();
    let options = new RequestOptions({ headers: headers });

    try {
      let response = await this.http.post(CONFIG.BaseUrl() + url, "grant_type=password", options).toPromise();
      let body = JSON.parse(response['_body']);
      let accessToken: string = body.access_token;
      let refreshToken = body.refresh_token;
      let accountId: string = body['as:account_id'];
      if (accessToken === undefined || accessToken.length === 0) {
        baseResponse.ErrorMessage = 'access_token returned empty or null';
        return baseResponse;
      }
      baseResponse.IsSuccess = true;
      this.storage.setRefreshToken(refreshToken);
      this.storage.setAccountId(accountId);
      this.storage.setApiToken(accessToken);
      return baseResponse;
    } catch (e) {
      console.error(e);
      // TODO : Handle errors with UI
      baseResponse.ErrorMessage = e['_body'];
      return baseResponse;
    }
  }
  
  async ServiceCall (url: string, data?: any) {
    let apiKey = await this.storage.getApiToken();
    return new Promise((response) => {
      let headers = new Headers();
      headers.append('Accept', 'application/json');
      headers.append('Content-Type', 'application/json');
      headers.append('Access-Control-Allow-Origin', '*');
      headers.append('Authorization', 'Bearer ' + apiKey);
      let options = new RequestOptions({ headers: headers });

      let jsonData = JSON.stringify(data);

      this.http.post(CONFIG.BaseUrl() + url, jsonData, options)
        .subscribe(data => {
          response(JSON.parse(data['_body']));
        }, error => {
          console.error(error);
          var baseResponse = new BaseResponseModel();
          baseResponse.ErrorMessage = error['_body'];
          response(baseResponse);
        });
    });
  }

  // Security
  GetEmailAvailability = function (data: EmailModel) { return this.ServiceCall('/Security/GetEmailAvailability', data); }
  Register = function (data: RegisterModel) { return this.ServiceCall('/Security/Register', data); }
  PasswordReset = function (data: EmailModel) { return this.ServiceCall('/Security/PasswordReset', data); }
  Login = function (data: LoginModel) { return this.LoginServiceCall('/Security/Token', data); }
  RenewToken = function () { return this.RenewServiceCall('/Security/Token'); }

  // Account
  GetAccount = function (data: AccountRequestModel) { return this.ServiceCall('/Account/GetAccount', data); }
  SaveAccount = function (data: AccountSaveRequestModel) { return this.ServiceCall('/Account/SaveAccount', data); }

  // Business
  GetBusinesses = function (data?: GetBusinessesRequest) { return this.ServiceCall('/Business/GetBusinesses', data); }
  GetBusinessesForLocation = function (data: GetBusinessesForLocationRequest) { return this.ServiceCall('/Business/GetBusinessesForLocation', data); }
  GetBusinessAndAccounts = function (data: GetBusinessAndAccountsRequest) { return this.ServiceCall('/Business/GetBusinessAndAccounts', data); }

  // Tattoo
  SaveTattoo = function (data: TattooModel) { return this.ServiceCall('/Tattoo/SaveTattoo', data); }
  SaveTattooTatIt = function (data: TattooTatItRequest) { return this.ServiceCall('/Tattoo/SaveTattooTat', data); }
  SaveTattooImage = function (data: TattooImageModel) { return this.ServiceCall('/Tattoo/SaveTattooImage', data); }
  SaveTattooComment = function (data: TattooCommentSaveRequest) { return this.ServiceCall('/Tattoo/SaveTattooComment', data); }
  GetTattooStyles = function (data: TattooSylesRequest) { return this.ServiceCall('/Tattoo/GetStyles', data); }
  GetTattooComments = function (data: TattooCommentsRequest) { return this.ServiceCall('/Tattoo/GetTattooComments', data); }
  ChangeTattooStatus = function (data: ChangeTattooStatusRequest) { return this.ServiceCall('/Tattoo/ChangeTattooStatus', data); }
  GetUserTattoosWithMainImage = function (data: UserTattoosRequest) { return this.ServiceCall('/Tattoo/GetUserTattoosWithMainImage', data); }
  GetArtistTattoosWithMainImage = function (data: ArtistTattoosRequest) { return this.ServiceCall('/Tattoo/GetArtistTattoosWithMainImage', data); }
  GetTattoosPerPageWithMainImage = function (data: AllTattoosRequest) { return this.ServiceCall('/Tattoo/GetTattoosPerPageWithMainImage', data); }
  GetTattoosPerPageBySearchValue = function (data: AllTattoosSearchRequest) { return this.ServiceCall('/Tattoo/GetTattoosPerPageBySearchValue', data); }
  GetTattooTattedStatus = function (data: TattooIsTattedRequest) { return this.ServiceCall('/Tattoo/GetTattooTattedStatus', data); }

}
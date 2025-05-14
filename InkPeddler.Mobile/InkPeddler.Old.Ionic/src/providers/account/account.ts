import { Injectable } from '@angular/core';
import { DataStorageProvider } from '../data-storage/data-storage';
import { AccountRequestModel, AccountResponseModel, AccountModel, AccountSaveRequestModel } from '../../models/SecurityModels';
import { WebApi } from '../../api/webapi';

@Injectable()
export class AccountProvider {

  constructor(private storage: DataStorageProvider, private webApi: WebApi) {
  }

  async getLoginStatus(): Promise<boolean> {
    let token: string = await this.storage.getApiToken();
    return token !== null && token.length > 0;
  }

  async logOut(): Promise<boolean> {
    return await this.storage.flushDb();
  }

  async saveUserAccount(account: AccountModel) {
    // TODO : Handle save errors

    account.PhoneNumber = account.PhoneNumber.replace(/(\(|\)|\ |-)/g, '');

    let accountRequest: AccountSaveRequestModel = new AccountSaveRequestModel(account);
    await this.webApi.SaveAccount(accountRequest);
  }

  async fetchUserAccountInfo(): Promise<AccountModel> {
    return await this.fetchAccountInfo(await this.storage.getAccountId());
  }

  async fetchAccountInfo(accountId: string): Promise<AccountModel> {

    // TODO : Provide better error handling
    if (!accountId || accountId.length == 0) return null;

    let accountResponse: AccountResponseModel = await this.webApi.GetAccount(new AccountRequestModel(accountId));

    // TODO : Provide better error handling
    if (!accountResponse || !accountResponse.IsSuccess) return null;
    return accountResponse.Account;
  }

}

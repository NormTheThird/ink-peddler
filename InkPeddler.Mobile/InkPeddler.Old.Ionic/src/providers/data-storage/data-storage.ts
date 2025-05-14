import { Storage } from '@ionic/storage';
import { Injectable } from '@angular/core';

@Injectable()
export class DataStorageProvider {

  REFRESH_TOKEN: string = 'REFRESH_TOKEN';
  API_TOKEN: string = 'API_TOKEN';
  ACCOUNT_ID: string = 'ACCOUNT_ID';

  constructor(private storage: Storage) { }

  async getRefreshToken() {
    return await this.storage.get(this.REFRESH_TOKEN);
  }

  async getApiToken() {
    return await this.storage.get(this.API_TOKEN);
  }

  async getAccountId() {
    return await this.storage.get(this.ACCOUNT_ID);
  }

  async setRefreshToken(token: string): Promise<boolean> {
    if (token === undefined || token.length === 0) return false;
    let result = await this.storage.set(this.REFRESH_TOKEN, token);
    return result === token;
  }

  async setApiToken(token: string): Promise<boolean> {
    if (token === undefined || token.length === 0) return false;
    let result = await this.storage.set(this.API_TOKEN, token);
    return result === token;
  }

  async setAccountId(id: string): Promise<boolean> {
    if (id === undefined || id.length === 0) return false;
    let result = await this.storage.set(this.ACCOUNT_ID, id);
    return result === id;
  }

  async flushDb(): Promise<boolean> {
    // TODO: Make sure that DB is cleard
    await this.storage.clear();
    return true;
  }

}

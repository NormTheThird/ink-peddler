import { Injectable } from '@angular/core';
import { CONFIG } from '../../providers/app-config';
import { 
  TattooArrayResponse,
  UserTattoosRequest,
  ArtistTattoosRequest,
  Tattoo,
  ChangeTattooStatusRequest,
  TattooIsTattedRequest,
  TattooTatItResponse
} from '../../models/TattooModels';
import { DataStorageProvider } from '../../providers/data-storage/data-storage';
import { WebApi } from '../../api/webapi';

@Injectable()
export class TattooProvider {

  constructor(private storage: DataStorageProvider, private webApi: WebApi) {
  }

  async fetchUserTattoos(): Promise<TattooArrayResponse> {
    let tattoosRequest: UserTattoosRequest = new UserTattoosRequest(await this.storage.getAccountId());
    let tmpTattooArray: TattooArrayResponse = await this.webApi.GetUserTattoosWithMainImage(tattoosRequest);
    tmpTattooArray.Tattoos = tmpTattooArray.Tattoos.filter(tattoo => tattoo.IsActive == true);
    return this.addImageLink(tmpTattooArray);
  }

  async fetchAccountTattoos(accountId: string): Promise<TattooArrayResponse> {

    // TODO : Handle bad account Id
    if (!accountId || accountId.length == 0) return null;

    let tattoosRequest: ArtistTattoosRequest = new ArtistTattoosRequest(accountId);
    let tmpTattooArray: TattooArrayResponse = await this.webApi.GetArtistTattoosWithMainImage(tattoosRequest);
    tmpTattooArray.Tattoos = tmpTattooArray.Tattoos.filter(tattoo => tattoo.IsActive == true);
    return this.addImageLink(tmpTattooArray);
  }

  addImageLink(tattooArray: TattooArrayResponse): TattooArrayResponse {
    tattooArray.Tattoos.forEach(tattoo => {
      tattoo.MainImageUrl = CONFIG.S3BaseUrl + CONFIG.S3BucketName + '/' + CONFIG.S3EnvKey() + CONFIG.S3TattooImageKey + tattoo.AWSImageId;
    });
    return tattooArray;
  }

  async deleteTattoo(tattoo: Tattoo) {
    
    // TODO : Handle bad tattoo Id
    if (!tattoo || !tattoo.Id || tattoo.Id.length == 0) return;

    let tattooStatusRequest: ChangeTattooStatusRequest = new ChangeTattooStatusRequest(tattoo.Id);
    return await this.webApi.ChangeTattooStatus(tattooStatusRequest);
  }

  async getTatted (tattoo: Tattoo): Promise<boolean> {

        // TODO : Handle bad tattoo Id
        if (!tattoo || !tattoo.Id || tattoo.Id.length == 0) return;

        let tattooIsTattedRequest: TattooIsTattedRequest = new TattooIsTattedRequest(tattoo.Id, await this.storage.getAccountId());
        let tattedResponse: TattooTatItResponse = await this.webApi.GetTattooTattedStatus(tattooIsTattedRequest);
        return tattedResponse.IsTatted;
  }

}

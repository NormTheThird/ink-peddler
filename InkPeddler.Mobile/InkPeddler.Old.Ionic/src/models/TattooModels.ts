import { BaseResponseModel, ActiveModel } from "./_BaseModels";
import { stringList } from "aws-sdk/clients/datapipeline";

export class Tattoo extends ActiveModel {
  UploadedByAccountId: string;
  CanvasAccountId: string;
  ArtistAccountId: string;
  BusinessId: string;
  Name: string;
  Description: string;
  DateCompleted: string;
  MainImageUrl: string;

  constructor(data?: any) {
    super(data);
    this.IsActive = true;
    this.UploadedByAccountId = "";
    this.CanvasAccountId = "";
    this.ArtistAccountId;
    this.BusinessId = "";
    this.Name = "";
    this.Description = "";
    this.DateCompleted = "";
    this.MainImageUrl = "";
  }
}

export class TattooModel {
  tattoo: Tattoo;

  constructor() {
    this.tattoo = new Tattoo();
  }
}

export class TattooIsTattedRequest {
  tattooId: string;
  accountId: string;
  constructor(tattooId: string, accountId: string) {
    this.tattooId = tattooId;
    this.accountId = accountId;
  }
}

export class TattooCommentsRequest {
  tattooId: string;
  getActiveAndInactive: boolean;

  constructor(tattooId: string, getActiveOnly?: boolean) {
    this.tattooId = tattooId;
    this.getActiveAndInactive = (getActiveOnly ? getActiveOnly : false);
  }
}

export class TattooSylesRequest {
  getActiveAndInactive: boolean;

  constructor(getActiveOnly?: boolean) {
    this.getActiveAndInactive = (getActiveOnly ? getActiveOnly : false);
  }
}

export class UserTattoosRequest {
  uploadedByAccountId: string;

  constructor(id: string) {
    this.uploadedByAccountId = (id ? id : "");
  }
}

export class ArtistTattoosRequest {
  artistAccountId: string;

  constructor(id: string) {
    this.artistAccountId = (id ? id : "");
  }
}

export class AllTattoosRequest {
  pageNumber: number;
  styleId: string;

  constructor(pageNumber: number, styleId?: string) {
    this.pageNumber = (pageNumber ? pageNumber : 1);
    this.styleId = (styleId ? styleId : "00000000-0000-0000-0000-000000000000");
  }
}

export class AllTattoosSearchRequest {
  pageNumber: number;
  searchValue: string;

  constructor(pageNumber: number, searchValue: string) {
    this.pageNumber = (pageNumber ? pageNumber : 1);
    this.searchValue = (searchValue ? searchValue : "");
  }
}

export class TattooCommentSaveRequest {
  TattooComment: TattooComment;

  constructor(data: TattooComment) {
    this.TattooComment = data;
  }
}

export class ChangeTattooStatusRequest {
  tattooId: string;

  constructor(id: string) {
    this.tattooId = id;
  }
}

export class TattooTatItRequest {
  tattooId: string;
  accountId: string;

  constructor(tattooId: string, accountId: string) {
    this.tattooId = tattooId;
    this.accountId = accountId;
  }
}

export class TattooTatItResponse extends BaseResponseModel {
  IsTatted: boolean;

  constructor() {
    super();
    this.IsTatted = false;
  }
}

export class TattooResponse extends BaseResponseModel {
  TattooId: string;

  constructor() {
    super();
    this.TattooId = "";
  }
}

export class TattooResponseWithImage extends ActiveModel {
  UploadedByAccountId: string;
  AWSImageId: string;
  MainImageUrl: string;
  CanvasAccountId: string;
  ArtistAccountId: string;
  BusinessId: string;
  Name: string;
  Description: string;

  constructor(data?: any) {
    super(data);
    this.UploadedByAccountId = "";
    this.AWSImageId = "";
    this.CanvasAccountId;
    this.ArtistAccountId = "";
    this.Name = "";
    this.Description = "";
  }
}

export class TattooArrayResponse extends BaseResponseModel {
  Tattoos: TattooResponseWithImage[];

  constructor() {
    super();
    this.Tattoos = [];
  }
}

export class TattooStylesResponse extends BaseResponseModel {
  Styles: TattooStyle[];

  constructor() {
    super();
    this.Styles = [];
  }
}

export class TattooCommentsResponse extends BaseResponseModel {
  TattooComments: TattooComment[];

  constructor() {
    super();
    this.TattooComments = [];
  }
}

export class TattooComment extends ActiveModel {
  AccountId: string;
  Comment: string;
  TattooId: string

  constructor(data?: any) {
    super(data);
    this.IsActive = true;
  }
}

export class TattooStyle extends ActiveModel {
  Name: string;
  Description: string;

  constructor(data?: any) {
    super(data);
  }
}

export class TattooImage extends ActiveModel {
  tattooId: string;
  awsImageId: string;
  isMainImage: boolean;

  constructor(data?: any) {
    super(data);
    this.tattooId = "";
    this.awsImageId = "";
    this.isMainImage = true;
  }
}

export class TattooImageModel {

  tattooImage: TattooImage;

  constructor(data?: any) {
    this.tattooImage = new TattooImage(data);
    this.tattooImage.IsActive = true;
  }
}
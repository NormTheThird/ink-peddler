
function ToDate(date: any) {
  try {
    if (date) {
      if (date instanceof Date) { return date }
      var d = new Date(date);
      if (d instanceof Date && d.getDate() > 0) {
        return d;
      }
      return new Date(parseInt((date.match(/\d+/) || 0)));
    }
  }
  catch (ex) {
    console.error('Date parse Failed', date);
  }
}

export class BaseModel {
  Id: string;
  DateCreated: Date;

  constructor(data: any) {
    this.Id = (data ? data.Id : "");
    this.DateCreated = ToDate(data ? data.DateCreated : 0);
  }
}

export class ActiveModel extends BaseModel {
  IsActive: boolean;

  constructor(data: any) {
    super(data);
    this.IsActive = (data ? data.IsActive : false);
  }

}

export class MessageModel {
  IsVisible: boolean;
  IsError: boolean;
  Text: string;
  TextColor: string;

  constructor(msg: string, isError: boolean = false) {
    this.IsError = isError;
    this.Text = msg;

    if (this.Text == "") { this.IsVisible = false }
    else { this.IsVisible = true }

    if (this.IsError) { this.TextColor = "danger" }
    else { this.TextColor = "primary" }
  }
}

export class BaseResponseModel {
  IsSuccess: boolean;
  ErrorMessage: string;

  constructor() {
    this.IsSuccess = false;
    this.ErrorMessage = "";
  }
}
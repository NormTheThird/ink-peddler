function BaseDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.Id = ko.observable(data.Id || Base.Guid.Empty);
    self.DateCreated = ko.observable(Base.ToDate(data.DateCreated) || false);
}

function ActiveDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new BaseDataModel(data));

    self.IsActive = ko.observable(data.IsActive || false);
}

function AccountDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.AddressId = ko.observable(data.AddressId || Base.Guid.Empty);
    self.Address = ko.observable(new AddressDataModel(data.Address));
    self.FirstName = ko.observable(data.FirstName || "");
    self.LastName = ko.observable(data.LastName || "");
    self.Email = ko.observable(data.Email || "");
    self.PhoneNumber = ko.observable(data.PhoneNumber || "");
    self.AllowedOrigin = ko.observable(data.AllowedOrigin || "");
    self.RefreshTokenLifeTimeMinutes = ko.observable(data.RefreshTokenLifeTimeMinutes || "");
    self.AWSProfileImageId = ko.observable(data.AWSProfileImageId || Base.Guid.Empty);
    self.DateOfBirth = ko.observable(Base.ToDate(data.DateOfBirth) || false);
    self.IsArtist = ko.observable(data.IsArtist || false);

    self.FullName = ko.computed(function () {
        var first = ko.unwrap(self.FirstName);
        var last = ko.unwrap(self.LastName);
        return first + " " + last;
    });

    self.ProfileImage = ko.computed(function () {
        if (self.AWSProfileImageId() === Base.Guid.Empty) { return ""; }
        return Base.AmazonS3Path("profile") + self.AWSProfileImageId();
    });
}

function AccountRefreshTokenDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.Id = ko.observable(data.Id || Base.Guid.Empty);
    self.RefreshToken = ko.observable(data.RefreshToken || "");
    self.DateIssued = ko.observable(Base.ToDate(data.DateIssued) || false);
    self.DateExpired = ko.observable(Base.ToDate(data.DateExpired) || false);
}

function AccountNotTiedToBusinessDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.AccountId = ko.observable(data.AccountId || Base.Guid.Empty);
    self.Name = ko.observable(data.Name || "");
    self.Email = ko.observable(data.Email || "");

    self.NameAndEmail = ko.computed(function () {
        return self.Name() + ' : ' + self.Email();
    });
}

function AccountUploadedTattooDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.Id = ko.observable(data.Id || Base.Guid.Empty);
    self.Name = ko.observable(data.Name || "");
    self.Description = ko.observable(data.Description || "");
    self.AWSImageId = ko.observable(data.AWSImageId || Base.Guid.Empty);

    self.ImagePath = ko.computed(function () {
        if (self.AWSImageId() === Base.Guid.Empty) { return ""; }
        return Base.AmazonS3Path("tattoo") + self.AWSImageId();
    });
}

function AccountActivityDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new BaseDataModel(data));

    self.AccountId = ko.observable(data.AccountId || Base.Guid.Empty);
    self.ActivityType = ko.observable(data.ActivityType || "");
}

function AddressDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new BaseDataModel(data));

    self.Address1 = ko.observable(data.Address1 || "");
    self.Address2 = ko.observable(data.Address2 || "");
    self.City = ko.observable(data.City || "");
    self.State = ko.observable(data.State || "");
    self.ZipCode = ko.observable(data.ZipCode || "");
    self.Latitude = ko.observable(data.Latitude || 0);
    self.Longitude = ko.observable(data.Longitude || 0);

    self.FullAddress = ko.computed(function () {
        var retval = (self.Address1() + " " + self.Address2()).trim();
        if (retval !== "")
            retval += ", ";
        retval += self.City() + ", " + self.State() + " " + self.ZipCode();
        if (self.City() === "")
            retval = self.State() + " " + self.ZipCode();
        return retval.trim();
    });

    self.CityStateZipDisplay = ko.computed(function () {
        var retval = self.City() + ", " + self.State() + " " + self.ZipCode();
        if (self.City() === "")
            retval = self.State() + " " + self.ZipCode();
        return retval.trim();
    });
}

function BusinessDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.Name = ko.observable(data.Name || "");
    self.RegistrationCode = ko.observable(data.RegistrationCode || "");
    self.GoogleMapId = ko.observable(data.GoogleMapId || "");
    self.GoogleMapPlaceId = ko.observable(data.GoogleMapPlaceId || "");
    self.AzureMapsSearchType = ko.observable(data.AzureMapsSearchType || "");
    self.AzureMapsSearchId = ko.observable(data.AzureMapsSearchId || "");
    self.PhoneNumber = ko.observable(data.PhoneNumber || "");
    self.FacebookUrl = ko.observable(data.FacebookUrl || "");
    self.TwitterUrl = ko.observable(data.TwitterUrl || "");
    self.InstagramUrl = ko.observable(data.InstagramUrl || "");
    self.WebsiteUrl = ko.observable(data.WebsiteUrl || "");
    self.AWSProfileImageId = ko.observable(data.AWSProfileImageId || Base.Guid.Empty);
    self.Address = ko.observable(new AddressDataModel(data.Address));
    self.ValidatedBy = ko.observable(data.ValidatedBy || "");
    self.DateLastValidated = ko.observable(Base.ToDate(data.DateLastValidated) || false);

    self.ProfileImage = ko.computed(function () {
        if (self.AWSProfileImageId() === Base.Guid.Empty) { return ""; }
        return Base.AmazonS3Path("profile") + self.AWSProfileImageId();
    });
}

function BaseBusinessAccountDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.BusinessId = ko.observable(data.BusinessId || Base.Guid.Empty);
    self.AccountId = ko.observable(data.AccountId || Base.Guid.Empty);
    self.IsOwner = ko.observable(data.IsOwner || false);
    self.IsManager = ko.observable(data.IsManager || false);
}

function BusinessAccountDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new BaseBusinessAccountDataModel(data));

    self.FirstName = ko.observable(data.FirstName || "");
    self.LastName = ko.observable(data.LastName || "");
    self.Email = ko.observable(data.Email || "");
    self.FullName = ko.observable(data.FullName || "");
    self.PhoneNumber = ko.observable(data.PhoneNumber || "");
    self.ProfileImage = ko.observable(data.ProfileImage || "");
    self.IsActive = ko.observable(data.IsActive || false);
    self.IsArtist = ko.observable(data.IsArtist || false);
}

function BusinessListDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.Id = ko.observable(data.Id || Base.Guid.Empty);
    self.Name = ko.observable(data.Name || "");
    self.CityState = ko.observable(data.CityState || "");

    self.NameWithCityState = ko.computed(function () {
        return self.Name() + (self.CityState() === ", " ? "" : " - " + self.CityState());
    });
}

function ErrorDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new BaseDataModel(data));

    self.Source = ko.observable(data.Source || "");
    self.ExceptionType = ko.observable(data.ExceptionType || "");
    self.ExceptionMessage = ko.observable(data.ExceptionMessage || "");
    self.InnerExceptionMessage = ko.observable(data.InnerExceptionMessage || "");
    self.StackTrace = ko.observable(data.StackTrace || "");
    self.IsReviewed = ko.observable(data.IsReviewed || false);
    self.ReviewedBy = ko.observable(data.ReviewedBy || "");
    self.DateReviewed = ko.observable(Base.ToDate(data.DateReviewed) || "");
}

function TattooQuickDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.Name = ko.observable(data.Name || "");
    self.NumberOfComments = ko.observable(data.NumberOfComments || 0);
    self.NumberOfTats = ko.observable(data.NumberOfTats || 0);
    self.NumberOfViews = ko.observable(data.NumberOfViews || 0);
}

function TattooDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.UploadedByAccountId = ko.observable(data.UploadedByAccountId || Base.Guid.Empty);
    self.ArtistAccountId = ko.observable(data.ArtistAccountId || Base.Guid.Empty);
    self.CanvasAccountId = ko.observable(data.CanvasAccountId || Base.Guid.Empty);
    self.BusinessId = ko.observable(data.BusinessId || Base.Guid.Empty);
    self.Name = ko.observable(data.Name || "");
    self.Description = ko.observable(data.Description || "");
}

function TattooImageDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.TattooId = ko.observable(data.TattooId || Base.Guid.Empty);
    self.AWSImageId = ko.observable(data.AWSImageId || Base.Guid.Empty);
    self.IsMainImage = ko.observable(data.IsMainImage || false);

    self.ImagePath = ko.computed(function () {
        if (self.AWSImageId() === Base.Guid.Empty) { return ""; }
        return Base.AmazonS3Path("tattoo") + self.AWSImageId();
    });
}

function StyleDataModel(data) {
    var self = this;
    if (!data) data = {};
    $.extend(self, new ActiveDataModel(data));

    self.Name = ko.observable(data.Name || "");
    self.Description = ko.observable(data.Description || "");
}
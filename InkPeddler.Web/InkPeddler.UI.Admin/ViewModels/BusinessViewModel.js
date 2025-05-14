function BusinessViewModel(parent) {
    var self = this;
    self.Parent = parent;

    self.Business = ko.observable(new BusinessDataModel());
    self.NewBusinessAccount = ko.observable(new BaseBusinessAccountDataModel());
    self.Businesses = ko.observableArray();
    self.BusinessAccounts = ko.observableArray();
    self.AccountsNotTiedToABusiness = ko.observableArray();

    self.BusinessesFilter = ko.observable();
    self.BusinessesFiltered = ko.computed(function () {
        var expr = new RegExp(self.BusinessesFilter(), "i");
        return $.map(self.Businesses(), function (business) {
            var searchfield = business.Name() + " " + business.PhoneNumber() + " " + business.Address().City();
            if (searchfield.match(expr)) return business;
        });
    });
    self.BusinessesPaging = ko.observable(new PaginationVM(self.BusinessesFiltered));

    self.Loading = function (isLoading) {

    };

    self.GetBusinesses = function () {
        Base.ServiceCall("/Business/GetBusinesses", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Businesses(response.Businesses.map(function (business) {
                    return new BusinessDataModel(business);
                }));
                $("#business-list").show();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetBusiness = function (id) {
        var data = { BusinessId: id };
        Base.ServiceCall("/Business/GetBusiness", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Business(new BusinessDataModel(response.Business));
                $("#business-list").show();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetBusinessAccounts = function () {
        try {
            self.Loading(true);
            var data = { BusinessId: ko.toJS(self.Business().Id()) };
            Base.ServiceCall("/Business/GetBusinessAccounts", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    self.BusinessAccounts(response.BusinessAccounts.map(function (businessAccount) {
                        return new BusinessAccountDataModel(businessAccount);
                    }));
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally { self.Loading(false); }
            });
        } catch (ex) {
            Base.Log(ex);
            self.Loading(false);
        }
    };

    self.GetAccountsNotTiedToABusiness = function () {
        try {
            self.Loading(true);
            Base.ServiceCall("/Business/GetAccountsNotTiedToABusiness", "post", null, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    self.AccountsNotTiedToABusiness(response.Accounts.map(function (account) {
                        return new AccountNotTiedToBusinessDataModel(account);
                    }));
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally { self.Loading(false); }
            });
        } catch (ex) {
            Base.Log(ex);
            self.Loading(false);
        }
    };

    self.AddBusinessAccount = function () {
        try {
            self.Loading(true);
            var data = { BusinessAccount: ko.toJS(self.NewBusinessAccount()) };
            Base.ServiceCall("/Business/AddBusinessAccount", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    self.GetBusinessAccounts();
                    self.GetAccountsNotTiedToABusiness();
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally { self.Loading(false); }
            });
        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.SaveImage = function (image) {
        AWS.config.region = Base.AmazonS3Config.region;
        AWS.config.accessKeyId = Base.AmazonS3Config.accessKeyId;
        AWS.config.secretAccessKey = Base.AmazonS3Config.secretAccessKey;
        var s3 = new AWS.S3();
        var imageKey = image.upload.uuid;

        s3.upload({
            Key: imageKey,
            Body: image,
            Bucket: Base.AmazonS3Bucket("profile"),
            ContentType: image.type
        }, function (err) {
            if (err) { console.error(err); }

            var data = { BusinessId: self.Business().Id(), AWSProfileImageId: imageKey };
            Base.ServiceCall("/Business/SaveBusinessImage", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    Base.Message("Business image saved successfully.", Base.MessageLevels.Success);
                    self.GetBusiness(self.Business().Id());
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
            });
        });
    };

    self.RemoveBusinessAccount = function (account) {
        try {
            self.Loading(true);
            var data = { BusinessId: account.BusinessId, AccountId: account.AccountId };
            Base.ServiceCall("/Business/RemoveBusinessAccount", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    self.GetBusinessAccounts();
                    self.GetAccountsNotTiedToABusiness();
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally { self.Loading(false); }
            });
        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.GoToAccountProfile = function () {
        try {
            Base.Message("This is not yet implemented", Base.MessageLevels.Error);

        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.EditBusiness = function (business) {
        self.Business(business);
        self.GetBusinessAccounts();
        self.GetAccountsNotTiedToABusiness();
        self.NewBusinessAccount(new BaseBusinessAccountDataModel());
        self.NewBusinessAccount().BusinessId(self.Business().Id());
        self.ShowHide("edit", "list");
    };

    self.SaveBusiness = function () {
        try {
            self.Loading(true);
            var data = { Business: ko.toJS(self.Business()) };
            Base.ServiceCall("/Business/SaveBusiness", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    Base.Message("Business saved successfully.", Base.MessageLevels.Success);
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally { self.Loading(false); }
            });
        } catch (ex) {
            Base.Log(ex);
            self.Loading(false);
        }
    };

    self.SaveNewBusiness = function () {
        try {
            Base.Message("This feature is not implemented yet", Base.MessageLevels.Error);
        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.GoBackToAccounts = function () {
        self.ShowHide("list", "edit");
    };

    self.ChangeBusinesstatus = function (business) {
        try {
            Base.Message("This is not yet implemented", Base.MessageLevels.Error);

        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.Cancel = function () {
        self.Business(new BusinessDataModel());
    };

    self.ShowHide = function (show, hide) {
        $("#business-" + show).show();
        $("#business-" + hide).hide();
    };

    self.Load = function () {
        self.GetBusinesses();
        self.AccountsNotTiedToABusiness().push(self.NewBusinessAccount());
    };
}
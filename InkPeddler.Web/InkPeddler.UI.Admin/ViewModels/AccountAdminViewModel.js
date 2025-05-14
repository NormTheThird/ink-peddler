function NewAccountDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.Email = ko.observable(data.Email || "");
    self.Password = ko.observable(data.Username || "");
    self.IsArtist = ko.observable(data.IsArtist || false);
}

function AccountAdminViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.CurrentPage = ko.observable("");

    self.Account = ko.observable(new AccountDataModel());
    self.AccountRefreshToken = ko.observable(new AccountRefreshTokenDataModel());
    self.NewAccount = ko.observable(new NewAccountDataModel());
    self.Accounts = ko.observableArray();
    self.AccountTypeFilter = ko.observable();
    self.AccountsFilter = ko.observable();
    self.Password = ko.observable("");

    self.SendEmail = ko.computed(function () {
        try {
            return "mailto:" + self.Account().Email();
        }
        catch (ex) {
            console.log(ex);
            return "mailto:" + self.Account().Email;
        }
    });

    self.AccountTypeFiltered = ko.computed(function () {
        if (self.AccountTypeFilter() === "all") return self.Accounts();
        return $.map(self.Accounts(), function (account) {
            console.log(account.IsArtist());
            if (account.IsArtist() === eval(self.AccountTypeFilter())) {
                return account;
            }
        });
    });
    self.AccountsFiltered = ko.computed(function () {
        var expr = new RegExp(self.AccountsFilter(), "i");
        return $.map(self.AccountTypeFiltered(), function (account) {
            var searchfield = account.FirstName() + " " + account.LastName() + " "
                + account.Email() + " " + account.PhoneNumber();
            if (searchfield.match(expr)) return account;
        });
    });
    self.AccountsPaging = ko.observable(new PaginationVM(self.AccountsFiltered));

    self.Tattoos = ko.observableArray([]);
    self.TattoosPaging = ko.observable(new PaginationVM(self.Tattoos));

    self.Activity = ko.observableArray([]);
    self.ActivityPaging = ko.observable(new PaginationVM(self.Activity));

    self.Loading = function (isLoading) {

    };

    self.GetAccounts = function () {
        Base.ServiceCall("/AccountAdmin/GetAccounts", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Accounts(response.Accounts.map(function (account) {
                    return new AccountDataModel(account);
                }));
                self.Show("list");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetAccount = function () {
        var data = { AccountId: self.Account().Id() };
        Base.ServiceCall("/AccountAdmin/GetAccount", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Account(new AccountDataModel(response.Account));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetAccountActivity = function (id) {
        var data = { AccountId: id };
        Base.ServiceCall("/AccountAdmin/GetAccountActivity", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Activity(response.AccountActivity.map(function (activity) {
                    return new AccountActivityDataModel(activity);
                }));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.EditAccount = function (account) {
        self.Account(account);
        self.GetUserUploadedTattoos(account.Id);
        self.GetAccountActivity(account.Id);
        self.Show("edit");
    };

    self.GoBackToAccounts = function () {
        self.Show("list");
    };

    self.SaveAccount = function () {
        var data = { Account: ko.toJS(self.Account()) };
        Base.ServiceCall("/AccountAdmin/SaveAccount", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                Base.Message("Account saved successfully.", Base.MessageLevels.Success);
                self.GetAccount();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.RemoveImage = function () {
        self.Account().AWSProfileImageId(Base.Guid.Empty);
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

            var data = { AccountId: self.Account().Id(), AWSProfileImageId: imageKey };
            Base.ServiceCall("/AccountAdmin/SaveAccountProfileImage", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    Base.Message("Your profile image saved successfully.", Base.MessageLevels.Success);
                    self.GetAccount();
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
            });
        });
    };

    self.SaveNewAccount = function () {
        var data = {
            Email: self.NewAccount().Email(),
            Password: self.NewAccount().Password(),
            IsArtist: self.NewAccount().IsArtist()
        };
        Base.ServiceCall("/AccountAdmin/SaveNewAccount", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.NewAccount(new NewAccountDataModel());
                self.GetAccounts();
                Base.Message("New account has been created", Base.MessageLevels.Success);
                self.Password("");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.ChangeAccountStatus = function (account) {
        var data = { AccountId: account.Id };
        Base.ServiceCall("/AccountAdmin/ChangeAccountStatus", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                ko.utils.arrayFirst(self.AccountsFiltered(), function (acct) {
                    if (acct.Id() === account.Id()) {
                        acct.IsActive(!acct.IsActive());
                    }
                });
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.DeleteAccount = function (account) {
        var data = { AccountId: account.Id };
        Base.ServiceCall("/AccountAdmin/DeleteAccount", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.GetAccounts();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.SaveNewPassword = function () {
        if (self.Password() === "") {
            Base.Message("Please enter a password", Base.MessageLevels.Error);
            return;
        }

        var data = { AccountId: self.Account().Id(), Password: self.Password() };
        Base.ServiceCall("/AccountAdmin/SaveNewPassword", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                Base.Message("Password has been successfully changed", Base.MessageLevels.Success);
                self.Password("");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.ResetPassword = function () {
        var data = { Email: self.Account().Email };
        Base.ServiceCall("/AccountAdmin/PasswordReset", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage };
                Base.Message("The password has been reset and a link has been emailed.", Base.MessageLevels.Success);
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetUserUploadedTattoos = function (userId) {
        var data = { UploadedByAccountId: userId };
        Base.ServiceCall("/AccountAdmin/GetUserUploadedTattoos", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Tattoos(response.Tattoos.map(function (tattoo) {
                    return new AccountUploadedTattooDataModel(tattoo);
                }));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.Show = function (page) {
        $("#accountadmin-" + self.CurrentPage()).hide();
        $("#accountadmin-" + page).show();
        self.CurrentPage(page);
    };

    self.Load = function () {
        self.GetAccounts();
    };
}
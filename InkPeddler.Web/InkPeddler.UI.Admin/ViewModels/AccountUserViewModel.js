function AccountUserViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.CurrentPage = ko.observable("");

    self.Account = ko.observable(new AccountDataModel());
    self.Password = ko.observable("");
    self.ConfirmPassword = ko.observable("");
    self.PasswordUpdated = ko.observable(false);

    self.GetAccount = function () {
        Base.ServiceCall("/AccountUser/GetAccount", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Account(new AccountDataModel(response.Account));
                self.Show("edit");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.SaveAccount = function () {
        var data = { Account: ko.toJS(self.Account()) };
        Base.ServiceCall("/AccountUser/SaveAccount", "post", data, true, function (response) {
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

    self.SaveProfileImage = function (image) {
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
            else {
                var data = { AccountId: self.Account().Id(), AWSProfileImageId: imageKey };
                Base.ServiceCall("/AccountUser/SaveAccountProfileImage", "post", data, true, function (response) {
                    try {
                        if (!response.IsSuccess) { throw response.ErrorMessage; }
                        Base.Message("Your profile image saved successfully.", Base.MessageLevels.Success);
                        self.GetAccount();
                    } catch (ex) {
                        Base.Message("Error: " + ex, Base.MessageLevels.Error);
                        Base.Log(ex);
                    }
                });
            }
        });
    };

    self.SaveNewPassword = function () {
        if (self.Password() === "") {
            Base.Message("Please enter a password", Base.MessageLevels.Error);
            return;
        }

        if (self.Password() !== self.ConfirmPassword()) {
            Base.Message("Passwords must match", Base.MessageLevels.Error);
            return;
        }

        var data = { AccountId: self.Account().Id(), Password: self.Password() };
        Base.ServiceCall("/AccountUser/SaveNewPassword", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.PasswordUpdated(true);
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.NewPassword = function () {
        self.PasswordUpdated(false);
        self.Password("");
        self.ConfirmPassword("");
    };

    self.Show = function (page) {
        $("#accountuser-" + self.CurrentPage()).hide();
        $("#accountuser-" + page).show();
        self.CurrentPage(page);
    };

    self.Load = function () {
        self.GetAccount();
    };
}
function SecurityViewModel() {
    var self = this;
    self.CurrentPage = ko.observable("");

    self.FirstName = ko.observable("").extend({ required: { message: "First Name is required." } });
    self.LastName = ko.observable("").extend({ required: { message: "Last Name is required." } });
    self.Email = ko.observable("").extend({ required: { message: "Email is required." } });
    self.Password = ko.observable("").extend({ required: { message: "Password is required." } });
    self.ConfirmPassword = ko.observable("");
    self.ResetId = ko.observable("");
    self.ErrorMessage = ko.observable("");
    self.Agrees = ko.observable(false);
    self.RememberMe = ko.observable(false);
    self.IsResetPassword = ko.observable(false);
    self.IsLoading = ko.observable(false);

    self.ShowRegisterAccount = function () {
        self.Show("register");
    };

    self.ShowLogin = function () {
        self.Show("login");
    };

    self.ShowResetPassword = function () {
        self.IsResetPassword(false);
        self.Show("reset-password");
    };

    self.RegisterAccount = function () {
        if (!self.IsValid()) { return; }

        self.ErrorMessage("");
        if (!self.Agrees()) {
            self.ErrorMessage("* Please agree to the terms to sign up.");
            return;
        }

        var data = { FirstName: self.FirstName(), LastName: self.LastName(), Email: self.Email(), Password: self.Password() };
        BaseModel.ServiceCall("/Security/Register", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                window.location = "/Campaign";
            }
            catch (ex) {
                self.ErrorMessage("* " + ex);
            }
        });
    };

    self.ValidateAccount = function () {
        // TEST DATA
        self.Email("WilliamRNorman@Hotmail.com");
        self.Password("password");


        self.ErrorMessage("");
        if (self.Email() === "" || self.Password() === "") {
            self.ErrorMessage("Please enter your email and password");
            return;
        }

        self.IsLoading(true);
        var data = { Email: self.Email, Password: self.Password };
        Base.Authenticate(data, function (response) {
            console.log(response);
            if (response.isSuccess) {
                window.location = "/Dashboard/Index";
            } else {
                self.ErrorMessage(response.errorMessage);
            }
            self.IsLoading(false);
        });
    };

    self.ForgotPassword = function () {
        self.ErrorMessage("");
        var data = { Email: self.Email() };
        BaseModel.ServiceCall("/Security/ForgotPassword", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.IsResetPassword(true);
            }
            catch (ex) {
                self.ErrorMessage("* " + ex);
            }
        });
    };

    self.ResetPassword = function () {
        self.ErrorMessage("");
        if (self.Password() !== self.ConfirmPassword()) {
            self.ErrorMessage("* Passwords do not match!");
            return;
        }

        var data = { ResetId: self.ResetId(), NewPassword: self.Password() };
        BaseModel.ServiceCall('/Security/ResetPassword', "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
            }
            catch (ex) {
                self.ErrorMessage("* " + ex);
            }
        });
    };

    self.Show = function (page) {
        self.ErrorMessage("");
        $("#security-" + self.CurrentPage()).hide();
        $("#security-" + page).show();
        self.CurrentPage(page);
    };

    self.IsValid = function () {
        self.Errors.showAllMessages();
        return self.Errors().length === 0;
    };

    self.Errors = ko.validation.group(self);

    self.Load = function (resetId) {
        if (resetId !== "") {
            self.ResetId(resetId);
            self.Show("reset-password");
        }
        else {
            self.Show("login");
        }
    };
}
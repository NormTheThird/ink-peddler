function SecurityViewModel(parent) {
    var self = this;
    self.Content = ko.observable({ name: "security-login" });

    self.Email = ko.observable("");
    self.Password = ko.observable("");
    self.ErrorMessage = ko.observable("");

    self.Loading = ko.observable({ Page: ko.observable(true), ValidateAccount: ko.observable(false) });
    self.IsLoading = ko.computed(function () {
        for (var i in self.Loading()) { if (self.Loading()[i]()) { return true; } }
        return false;
    });

    self.ValidateAccount = function () {
        self.ErrorMessage("");
        self.Loading().ValidateAccount(true);
        var data = { Email: self.Email, Password: self.Password };
        Base.ServiceCall("/Security/ValidateAccount", "post", data, true, function (response) {
            try {
                if (response.IsSuccess) {
                    if (response.SecurityModel.IsSystemAdmin) { window.location = "/Dashboard/Index"; }
                    else { window.location = "/AccountUser/Index"; }
                } else {
                    self.ErrorMessage(response.ErrorMessage);
                }
            } catch (ex) {
                window.location = "/Security/Index";
                Base.Log(ex);
            }
            finally { self.Loading().ValidateAccount(false); }
        });
    };

    self.Load = function (resetId) {
        if (resetId !== "") {
            self.ResetId(resetId);
            self.Content({ name: "security-change-password" });
        }

        self.Loading().Page(false);
    };
}
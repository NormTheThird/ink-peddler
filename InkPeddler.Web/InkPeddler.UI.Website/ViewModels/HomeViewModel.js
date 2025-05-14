function HomeViewModel(parent) {
    var self = this;
    self.Parent = parent;

    self.Name = ko.observable("");
    self.Email = ko.observable("");
    self.Message = ko.observable("");
    self.IsMessageSent = ko.observable(false);

    self.SendContactUsEmail = function () {

        if (self.Name() === "") return;
        if (self.Email() === "") return;
        if (self.Message() === "") return;

        var data = { Name: self.Name(), Email: self.Email(), Message: self.Message() };
        Base.ServiceCall("/Home/SendContactUsEmail", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.IsMessageSent(true);
            } catch (ex) {
                Base.Log(ex);
            }
        });
    };

    self.Load = function() {
        self.IsMessageSent(false);
    };
}
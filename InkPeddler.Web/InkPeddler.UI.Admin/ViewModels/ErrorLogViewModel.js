function ErrorLogViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.CurrentPage = ko.observable("");

    self.Errors = ko.observableArray([]);
    self.ErrorsPaging = ko.observable(new PaginationVM(self.Errors));

    self.GetErrors = function () {
        Base.ServiceCall("/ErrorLog/GetErrors", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Errors(response.Errors.map(function (error) {
                    return new ErrorDataModel(error);
                }));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetError = function (id) {

    };

    self.EditError = function (error) {
        Base.Message("This feature has not been implemented!", Base.MessageLevels.Error);
        //self.GetError(tattoo.Id);
        //self.Show("edit");
    };

    self.DeleteError = function (error) {
        var data = { ErrorId: error.Id };
        Base.ServiceCall("/ErrorLog/DeleteError", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.GetErrors();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.Show = function (page) {
        $("#error-" + self.CurrentPage()).hide();
        $("#error-" + page).show();
        self.CurrentPage(page);
    };

    self.Load = function () {
        self.GetErrors();
        self.Show("list");
    };
}
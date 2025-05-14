function StyleViewModel(parent) {
    var self = this;
    self.Parent = parent;

    self.Style = ko.observable(new StyleDataModel());
    self.Styles = ko.observableArray();

    self.StylesFilter = ko.observable();
    self.StylesFiltered = ko.computed(function () {
        var expr = new RegExp(self.StylesFilter(), "i");
        return $.map(self.Styles(), function (style) {
            var searchfield = style.Name() + " " + style.Description();
            if (searchfield.match(expr)) return style;
        });
    });
    self.StylesPaging = ko.observable(new PaginationVM(self.StylesFiltered));

    self.Loading = function (isLoading) {

    };

    self.GetTattooStyles = function () {
        try {
            self.Loading(true);
            Base.ServiceCall("/Style/GetStyles", "post", null, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    self.Styles(response.Styles.map(function (style) {
                        return new StyleDataModel(style);
                    }));
                    $("#style-list").show();
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally {
                    self.Loading(false);
                }
            });
        } catch (ex) {
            Base.Log(ex);
            self.Loading(false);
        }
    };

    self.ChangeStyleStatus = function (style) {
        try {
            var data = { StyleId: style.Id };
            Base.ServiceCall("/Style/ChangeStyleStatus", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    ko.utils.arrayFirst(self.StylesFiltered(), function (_style) {
                        if (_style.Id() === style.Id()) {
                            _style.IsActive(!_style.IsActive());
                        }
                    });
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
            });
        } catch (ex) {
            Base.Log(ex);
        }
    };

    self.AddStyle = function () {
        self.Style(new StyleDataModel());
    };

    self.EditStyle = function (style) {
        self.Style(style);
    };

    

    self.SaveStyle = function () {
        try {
            self.Loading(true);
            var data = { Style: ko.toJS(self.Style()) };
            Base.ServiceCall("/Style/SaveStyle", "post", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage; }
                    Base.Message("Style saved successfully.", Base.MessageLevels.Success);
                    self.GetTattooStyles();
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
                finally {
                    self.Loading(false);
                }
            });
        } catch (ex) {
            Base.Log(ex);
            self.Loading(false);
        }
    };

    self.Load = function () {
        self.GetTattooStyles();
    };
}
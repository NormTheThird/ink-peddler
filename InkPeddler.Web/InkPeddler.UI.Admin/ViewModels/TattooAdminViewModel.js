function TattooAdminViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.CurrentPage = ko.observable("");

    self.Tattoo = ko.observable(new TattooDataModel());
    self.Tattoos = ko.observableArray();

    self.TattooImage = ko.observable(new TattooImageDataModel());
    self.TattooImages = ko.observableArray([]);

    self.TattoosFilter = ko.observable();
    self.TattoosFiltered = ko.computed(function () {
        var expr = new RegExp(self.TattoosFilter(), "i");
        return $.map(self.Tattoos(), function (tattoo) {
            var searchfield = tattoo.Name();
            if (searchfield.match(expr)) return tattoo;
        });
    });
    self.TattoosPaging = ko.observable(new PaginationVM(self.TattoosFiltered));

    self.GetAllTattoos = function () {
        Base.ServiceCall("/TattooAdmin/GetAllTattoos", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Tattoos(response.Tattoos.map(function (tattoo) {
                    return new TattooQuickDataModel(tattoo);
                }));
                $("#tattoo-list").show();
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetTattoo = function (id) {
        var data = { TattooId: id };
        Base.ServiceCall("/TattooAdmin/GetTattoo", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Tattoo(new TattooDataModel(response.Tattoo));
                self.Show("edit");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetTattooImages = function (id) {
        var data = { TattooId: id };
        Base.ServiceCall("/TattooAdmin/GetTattooImages", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.TattooImages(response.TattooImages.map(function (image) {
                    if (image.IsMainImage) {
                        self.TattooImage(new TattooImageDataModel(image));
                    }
                    return new TattooImageDataModel(image);
                }));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.ChangeTattooStatus = function (tattoo) {
        var data = { TattooId: tattoo.Id };
        Base.ServiceCall("/TattooAdmin/ChangeTattooStatus", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                ko.utils.arrayFirst(self.TattoosFiltered(), function (_tattoo) {
                    if (_tattoo.Id() === tattoo.Id()) {
                        _tattoo.IsActive(!_tattoo.IsActive());
                    }
                });
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.EditTattoo = function (tattoo) {
        self.GetTattoo(tattoo.Id);
        self.GetTattooImages(tattoo.Id);
    };

    self.SaveNewTattoo = function () {

    };

    self.SaveTattooImage = function (image) {
        AWS.config.region = Base.AmazonS3Config.region;
        AWS.config.accessKeyId = Base.AmazonS3Config.accessKeyId;
        AWS.config.secretAccessKey = Base.AmazonS3Config.secretAccessKey;
        var s3 = new AWS.S3();
        var imageKey = image.upload.uuid;

        s3.upload({
            Key: imageKey,
            Body: image,
            Bucket: Base.AmazonS3Bucket("tattoo"),
            ContentType: image.type
        }, function (err) {
            if (err) { console.error(err); }
            else {
                self.TattooImage().TattooId(self.Tattoo().Id());
                self.TattooImage().AWSImageId(imageKey);

                var data = { TattooImage: ko.toJS(self.TattooImage()) };
                Base.ServiceCall("/TattooAdmin/SaveTattooImage", "post", data, true, function (response) {
                    try {
                        if (!response.IsSuccess) { throw response.ErrorMessage; }
                        Base.Message("Tattoo image saved successfully.", Base.MessageLevels.Success);
                        self.GetTattooImages(self.Tattoo().Id());
                    } catch (ex) {
                        Base.Message("Error: " + ex, Base.MessageLevels.Error);
                        Base.Log(ex);
                    }
                });
            }
        });
    };

    self.SaveTattoo = function () {
        var data = { Tattoo: ko.toJS(self.Tattoo()) };
        Base.ServiceCall("/TattooAdmin/SaveTattoo", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                Base.Message("Tattoo saved successfully.", Base.MessageLevels.Success);
                self.Show("list");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GoBackToTattoos = function () {
        self.Show("list");
    };

    self.Show = function (page) {
        $("#tattooadmin-" + self.CurrentPage()).hide();
        $("#tattooadmin-" + page).show();
        self.CurrentPage(page);
    };

    self.Load = function () {
        self.GetAllTattoos();
        self.Show("list");
    };
}
function TattooUserViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.CurrentPage = ko.observable("");

    self.Tattoo = ko.observable(new TattooDataModel());
    self.Tattoos = ko.observableArray();
    self.Businesses = ko.observableArray([]);

    self.TattooImage = ko.observable(new TattooImageDataModel());
    self.TattooMainImage = ko.observable(new TattooImageDataModel());
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

    self.GetUploadedTattoos = function () {
        Base.ServiceCall("/TattooUser/GetUploadedTattoos", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Tattoos(response.Tattoos.map(function (tattoo) {
                    return new TattooQuickDataModel(tattoo);
                }));
                self.Show("list");
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetBusinessList = function () {
        Base.ServiceCall("/TattooUser/GetBusinessList", "post", null, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.Businesses(response.Businesses.map(function (business) {
                    return new BusinessListDataModel(business);
                }));
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.GetTattoo = function (id) {
        var data = { TattooId: id };
        Base.ServiceCall("/TattooUser/GetTattoo", "post", data, true, function (response) {
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
        self.TattooImages([]);
        var data = { TattooId: id };
        Base.ServiceCall("/TattooUser/GetTattooImages", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.TattooMainImage(new TattooImageDataModel());
                self.TattooImages(response.TattooImages.map(function (image) {
                    if (image.IsMainImage) { self.TattooMainImage(new TattooImageDataModel(image)); }
                    return new TattooImageDataModel(image);
                }));
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

    self.AddTattoo = function () {
        self.Tattoo(new TattooDataModel());
        self.Tattoo().IsActive(true);
        self.Show("edit");
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
                Base.ServiceCall("/TattooUser/SaveTattooImage", "post", data, true, function (response) {
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

    self.SaveAsTattooMainImage = function (image) {
        var data = { TattooImageId: image.Id };
        Base.ServiceCall("/TattooUser/SaveAsTattooMainImage", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.GetTattooImages(self.Tattoo().Id());
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.DeleteTattooImage = function (image) {
        var data = { TattooImageId: image.Id };
        Base.ServiceCall("/TattooUser/DeleteTattooImage", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.GetTattooImages(self.Tattoo().Id());
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.SaveTattoo = function () {
        var data = { Tattoo: ko.toJS(self.Tattoo()) };
        Base.ServiceCall("/TattooUser/SaveTattoo", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                Base.Message("Tattoo saved successfully.", Base.MessageLevels.Success);
                self.Tattoo().Id(response.TattooId);
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.DeleteTattoo = function (tattoo) {
        var data = { TattooId: tattoo.Id };
        Base.ServiceCall("/TattooUser/ChangeTattooStatus", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage; }
                self.GetUploadedTattoos();
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
        $("#tattoouser-" + self.CurrentPage()).hide();
        $("#tattoouser-" + page).show();
        self.CurrentPage(page);
    };

    self.Load = function () {
        self.GetUploadedTattoos();
        self.GetBusinessList();
    };
}
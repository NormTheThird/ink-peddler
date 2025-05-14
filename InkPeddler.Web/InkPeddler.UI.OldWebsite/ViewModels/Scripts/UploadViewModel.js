var UploadViewModel = function () {
    var self = this;

    self.Styles = ko.observableArray();
    self.SelectedStyles = ko.observableArray();
    self.StyleFilter = ko.observable("");
    self.Files = ko.observableArray();
    self.CanvasInput = ko.observable("");
    self.ArtistInput = ko.observable("");
    self.User = ko.observable(new AccountDataModel());

    self.Tattoo = ko.observable(new TattooDataModel());

    self.Tattoo().UploadedByAccount(self.User());
    self.NewImages = ko.observableArray();
    self.DeletedImages = ko.observableArray();
    self.IsCanvas = ko.observable();
    self.IsArtist = ko.observable();

    self.SearchedStyles = ko.computed(function () {
        if (self.StyleFilter() == "") return;
        var limit = 6;
        var expr = new RegExp(self.StyleFilter(), "ig");

        var searched = [];
        for (i in self.Styles()) {
            var style = self.Styles()[i];
            if (self.Tattoo().Styles.indexOf(style) >= 0) continue;
            if (style.Name().match(expr) && searched.length < limit) searched.push(style);
        }
        return searched;
    })

    self.Load = function () {
        self.BindValidation();
        self.LoadTattoo();
        self.LoadStyles();
        self.LoadUserInfo();
    }

    self.LoadTattoo = function () {

    }

    self.LoadUserInfo = function () {
        var data = { Username: "" }; // Gets current user
        Base.ApiCall("User/Get", "get", data, true, function (response) {
            if (response.IsSuccess) {
                self.User(new AccountDataModel(response.User));
            }
            else {
                Base.Message("Could not load user Info", "error");
            }
        })
    }

    self.LoadStyles = function () {
        self.Styles(Base.GetStyles());
    }

    self.SaveTattoo = function () {
        if (!$("#NewTattooForm").valid()) return;
        var data = {
            Tattoo: ko.toJS(self.Tattoo),
            UploadedAccountId: ko.toJS(self.User().Id()),
            ArtistAccountId: null,
            CanvasAccountId: null,
            NewImages: ko.toJS(self.Tattoo().Images()),
            DeletedImages: ko.toJS(self.DeletedImages())
        };
        data.Tattoo.UploadedByAccount = ko.toJS(self.User());
        if (self.IsCanvas()) data.CanvasAccountId = self.User().Id();
        if (self.IsArtist()) data.ArtistAccountId = self.User().Id();
        console.log(data);

        Base.ApiCall("Tattoo/Save", "post", data, true, function (response) {
            if (response.IsSuccess) {
                Base.Message("Saved Tattoo", "success");
            }
            else {
                Base.Message(response.ErrorMessage, "error");
            }
        })
    }

    self.RemoveImage = function (_img) {
        self.Tattoo().Images.remove(_img);
    }

    self.RemoveStyle = function (_style) {
        self.Tattoo().Styles.remove(_style);
    }

    self.AddStyle = function (_style) {
        self.Tattoo().Styles.push(_style);
        self.StyleFilter("");
    }

    self.AddStyleKey = function (vm, evt) {
        if (evt.key == "Tab" || evt.key == "Enter") {
            if (self.SearchedStyles() != null && self.SearchedStyles().length > 0) {
                var style = self.SearchedStyles()[0];
                self.AddStyle(style);
            }
            return false;
        }
        return true;
    }

    self.FileUploadEvent = function (vm, evt) {
        var files = evt.target.files;
        function readAndPreview(file) {
            self.NewImages.push(file);
            var reader = new FileReader();

            reader.onload = function () {
                // re-add file reader
                self.Tattoo().Images.push({
                    Id: Base.EmptyGuid,
                    FileName: file.name,
                    MimeType: file.type,
                    Url: window.URL.createObjectURL(file),
                    IsActive: ko.observable(true),
                    IsNew: true,
                    Attachment: reader.result.split(',')[1],
                        // TODO Pass in file to servers
                });
            }
            reader.readAsDataURL(file);
        }
        var i = 0;
        while (i < files.length) {
            file = files[i];
            if (typeof file !== undefined) {
                var isFound = false;
                for (var j = 0; j < self.Tattoo().Images().length; ++j) {
                    var img = self.Tattoo().Images()[j];
                    if (img.FileName == file.name && img.IsActive())
                        isFound = true;
                };
                i++;
                if (!isFound) readAndPreview(file);
                else {
                    //Base.Message({ title: "Unable to upload file", text: file.name + " already exists. Please remove the old file or rename the new file.", type: "error" });
                    break;
                }
            }
        }
    }

    self.BindValidation = function () {
        $("#NewTattooForm").validate({
            rules: {
                "TattooName": "required",
            },
            messages: {
                "TattooName": "Tattoo name is required.",
            }
        })
    }

}

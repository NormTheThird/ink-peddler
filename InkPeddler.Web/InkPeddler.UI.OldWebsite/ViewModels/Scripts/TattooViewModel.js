var TattooViewModel = function () {
    var self = this;

    self.Tattoo = ko.observable(new TattooDataModel());
    self.Artist = ko.observable(new ArtistDataModel());
    self.Canvas = ko.observable(new AccountDataModel());

    self.ArtistClaim = ko.observable({ name: 'ClaimTattoo' });
    self.CanvasClaim = ko.observable({ name: 'ClaimTattoo' })

    self.MainImg = ko.observable();
    self.CommentsComponent = ko.observable({ name: 'TattooComments' });

    self.Load = function () {
        id = window.location.pathname.split('/')[2];
        if (id != null) {
            self.LoadTattoo(id);
        }
        else {
            self.LoadTattoo("");
        }
    }

    self.Tattoo.subscribe(function (newVal) {
        self.CommentsComponent({
            name: 'TattooComments',
            params: {
                TattooId: newVal.Id()
            }
        });
        // Tattoo View hit
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var data = {
                    TattooId: newVal.Id(),
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude
                }
                Base.ApiCall("Tattoo/SaveTattooView", "post", data, true, function (response) {
                    if (!response.IsSuccess) {
                        console.warn("Could not log view");
                    }
                })
            });
        }
        else { //Browser does not support geolocation   
            var data = {
                AccountId: Base.EmptyGuid,
                TattooId: newVal.Id(),
                longitude: 0,
                latitude: 0
            };
        }
        //Base.ApiCall("Tattoo")

        // Load Claim components
        self.ArtistClaim({ name: 'ClaimTattoo', params: { Type: 'Artist', TattooId: newVal.Id() } })
        self.CanvasClaim({ name: 'ClaimTattoo', params: { Type: 'Canvas', TattooId: newVal.Id() } })
        
    });

    self.LoadTattoo = function (_id) {
        var data = {
            TattooName: _id,
        };

        Base.ApiCall("Tattoo/Get", "get", data, true, function (response) {
            if (response.IsSuccess) {
                self.Tattoo(new TattooDataModel(response.Tattoo));
                self.Canvas(new AccountDataModel(response.Tattoo.Canvas));
                self.Artist(new ArtistDataModel(response.Tattoo.Artist));
                if (window.location.hash === "") {
                    if (self.Tattoo().Images().length > 0) {
                        history.replaceState("", "Tattoo", "/Tattoo/" + self.Tattoo().Name() + "#1");
                        self.MainImg(self.Tattoo().Images()[0].StoragePath);
                    }
                }
                else {
                    var imgIndex = window.location.hash.split("#")[1] - 1;
                    if (self.Tattoo().Images()[imgIndex] != null) {
                        self.MainImg(self.Tattoo().Images()[imgIndex].StoragePath);
                    }
                    else {
                        //TODO What should we do if there are no images?
                    }
                }
            }
            else {
                Base.Message("Failed to get Tattoo", "error");
            }
        })
    }

    self.FlagInappropriate = function () {
        // Get reason?
        var data = {
            TattooId: self.Tattoo().Id()
        }
        Base.ApiCall("Tattoo/Report", "post", data, true, function (response) {
            if (response.IsSuccess) {
                Base.Message("We have received your report, thank you.", "success");
            }
            else {
                Base.Message("Could not report tattoo, please refresh, or try again", "error")
            }
        });
    }

    self.TatIt = function () {
        var data = {
            TattooId: self.Tattoo().Id()
        }
        Base.ApiCall("Tattoo/Tat", "post", data, true, function (response) {
            if (response.IsSuccess) {
                if (!self.Tattoo().Tatted()) {
                    Base.Message("Tat'd it!", "success");
                }
                else {
                    Base.Message("Removed Tat", "success");
                }
                self.Tattoo().Tatted(!self.Tattoo().Tatted());
            }
            else {
                Base.Message("Could not tat tattoo, please refresh, or try again", "error")
            }
        });
    }

    self.ChangeImage = function (_img, evt) {
        var context = ko.contextFor(evt.target);
        history.replaceState("", "Tattoo", "/Tattoo/" + self.Tattoo().Name() + "#" + (context.$index() + 1));
        self.MainImg(_img.StoragePath);
    }

    self.CopyUrlToClipboard = function () {
        var url = window.location.href + "/" + encodeURI(self.Tattoo().Name()) +
            window.prompt("Copy to clipboard: Ctrl+C, Enter", url);
    }

}


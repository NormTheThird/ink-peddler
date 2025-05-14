function ArtistShortDataModel(data) {
    var self = this;

    if (data == null) data = {
        "Id": "",
        "FirstName": "",
        "LastName": "",
        "ShopId": "",
        "ShopName": "",
        "Address": "",
        "PhoneNumber": "",
        "ProfileImageUrl": "",
        "FacebookUrl": "",
        "TwitterUrl": "",
        "InstagramUrl": "",
        "PinterestUrl": "",
    }
    self.Id = ko.observable(data.Id);
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.ShopId = ko.observable(data.ShopId);
    self.ShopName = ko.observable(data.ShopName);
    self.Address = ko.observable(new AddressDataModel(data.Address));
    self.PhoneNumber = ko.observable(data.PhoneNumber);
    self.ProfileImageUrl = ko.observable(data.ProfileImageUrl);
    self.FacebookUrl = ko.observable(data.FacebookUrl);
    self.TwitterUrl = ko.observable(data.TwitterUrl);
    self.InstagramUrl = ko.observable(data.InstagramUrl);
    self.PinterestUrl = ko.observable(data.PinterestUrl);

    self.FullName = ko.computed(function () {
        return ko.unwrap(self.FirstName) + " " + ko.unwrap(self.LastName);
    })

}

var ArtistProfileViewModel = function () {
    var self = this;

    self.Content = ko.observable({ name: "" });

    self.Artist = ko.observable(new ArtistDataModel());
    self.Tattoos = ko.observableArray();
    self.Tatted = ko.observable({ name: 'TattooGallery' })
    self.Uploaded = ko.observable({ name: 'TattooGallery' })
    self.Canvased = ko.observable({ name: 'TattooGallery' })
    self.Worked = ko.observable({ name: 'TattooGallery' })

    self.Gallery = ko.observable({
        name: 'TattooGallery',
        params: { Tattoos: self.Tattoos() }
    });

    self.Artist.subscribe(function (newVal) {
        var Id = newVal.Id();
        self.Canvased({
            name: 'TattooGallery',
            params: {
                Api: 'Artist/GetCanvased',
                ApiData: { UserId: Id },
                Header: 'On Me',
                PerRow: 4,
                PerPage: 4,
            }
        })
        self.Uploaded({
            name: 'TattooGallery',
            params: {
                Api: 'Artist/GetUploaded',
                ApiData: { UserId: Id },
                Header: 'My Uploaded',
                PerRow: 4,
                PerPage: 4,
            }
        })
        self.Tatted({
            name: 'TattooGallery',
            params: {
                Api: 'Artist/GetTatted',
                ApiData: { UserId: Id },
                Header: 'My Tatted',
                PerRow: 4,
                PerPage: 4,
            }
        })
        self.Worked({
            name: 'TattooGallery',
            params: {
                Api: 'Artist/GetGallery',
                ApiData: { ArtistId: Id },
                Header: 'My Art',
                PerRow: 4,
                PerPage: 4,
            }
        })
    })

    self.Load = function () {
        id = window.location.pathname.split('/')[2];
        if (id != null) {
            self.LoadArtist(id);
        }
        else {
            self.LoadArtist("");
        }
        self.ShowViewProfile();
    }

    self.LoadArtist = function (_username) {
        var data = { ArtistUsername: _username };
        Base.ServiceCall("Artist/Get", "get", data, "true", function (response) {
            if (response.IsSuccess) {
                self.Artist(new ArtistDataModel(response.Artist));
            }
            else {
                Base.Message("Could not get artist info.", "error");
            }
        })
    }

    self.ShowEditProfile = function () {
        self.Content({ name: "ArtistSettingsTemplate" });
    }

    self.ShowViewProfile = function () {
        self.Content({ name: "ArtistProfileTemplate" });
    }

    self.StylesModal = function () {
        $('#Artist-Styles-Modal').modal('show');
    }

    self.SearchFilter = ko.observable();
    self.OrderBy = ko.observable();

    self.SaveImages = function () {
        // What save to do
        console.log("Saving Images");
    }

    self.Save = function () {

    }

    self.NewTattoo = function () {

    }

};
var HomeGalleryViewModel = function () {
    var self = this;
    self.Tattoos = ko.observableArray();
    self.Loading = ko.observable(false);
    self.OrderBy = ko.observable();

    self.MouseIn = function (vm, event) {
        var element = event.currentTarget.childNodes[3];

        element.classList.add("fadeInDown");
        element.classList.remove("fadeOutUp")
    };

    self.MouseOut = function (vm, event) {
        var element = event.currentTarget.childNodes[3];

        element.classList.add("fadeOutUp");
        element.classList.remove("fadeInDown");
    };

    self.Load = function () {
        self.LoadImages(0);
        self.BindScroll();
    }

    self.LoadImages = function () {
        if (self.Loading()) return;
        self.Loading(true);
        $(".wait-container").show();
        var data = { ImageCount: self.Tattoos().length }
        Base.ApiCall("Tattoo/GetNewest", "get", data, true, function (response) {
            if (response.IsSuccess) {
                for (i in response.Tattoos) {
                    self.Tattoos.push(new TattooDataModel(response.Tattoos[i]));
                }
            }
            else {
                Base.Message(response.ErrorMessage, "error", false);
            }
            self.Loading(false);
            $(".wait-container").hide();
        });
    };

    self.RefinedTattoos = ko.computed(function () {
        var tattoos = self.Tattoos().slice();

        if (self.OrderBy() === "Newest") {
            tattoos.sort(function (a, b) {
                if (a.DateCreated() > b.DateCreated()) return -1;
                if (a.DateCreated() < b.DateCreated()) return 1;
                return 0;

            })
        }
        if (self.OrderBy() === "Viewed") {
            tattoos.sort(function (a, b) {
                console.log(ko.toJS(a), ko.toJS(b));
                if (a.NumberOfViews() > b.NumberOfViews()) return -1;
                if (a.NumberOfViews() < b.NumberOfViews()) return 1;
                return 0;
            })
        }

        return tattoos;

    })

    self.BindScroll = function () {
        window.addEventListener('scroll', function (e) {
            var scroll = window.innerHeight + window.scrollY;
            var total = document.body.scrollHeight;
            if (scroll / total > .90) self.LoadImages();
        })
    }
};

var ImageDetailViewModel = function () {
    var self = this;

};
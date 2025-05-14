function ShopDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "Accounts": "",
        "Addresses": "",
        "Name": "",
        "PhoneNumber": "",
    }
    self.Accounts = ko.observable(data.Accounts);
    self.Name = ko.observable(data.Name);
    self.PhoneNumber = ko.observable(data.PhoneNumber);
    self.Address = ko.observable(new AddressDataModel());
    self.Addresses = ko.observableArray();
    for (i in data.Addresses) {
        var addr = new AddressDataModel(data.Addresses[i]);
        if (addr.AddressType() === 2) self.Address(addr);
        self.Addresses.push(addr);
    }
    self.Owners = ko.observableArray();
    self.Managers = ko.observableArray();
    self.Artists = ko.observableArray();

    for (i in data.Accounts) {
        var acct = new EmployeeDataModel(data.Accounts[i]);
        if (acct.IsOwner()) self.Owners.push(acct);
        else if (acct.IsManager()) self.Managers.push(acct);
        else self.Artists.push(acct);
    }
}

function EmployeeDataModel(data) {
    var self = this;

    $.extend(self, new AccountDataModel(data));

    if (data == null || data === "") data = {
        "RoleId": "",
        "IsManager": "",
        "IsOwner": "",
        "Addresses": "",
    }
    self.RoleId = ko.observable(data.RoleId);
    self.IsManager = ko.observable(data.IsManager);
    self.IsOwner = ko.observable(data.IsOwner);
    self.Addresses = ko.observableArray();
    for (i in data.Addresses) {
        self.Addresses.push(new AddressDataModel(data.Addresses[i]));
    }
}

function ArtistDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "FirstName": "",
        "LastName": "",
        "Bio": "",
        "ShopId": "",
        "ShopName": "",
        "Address": "",
        "PhoneNumber": "",
        "ProfileImageUrl": "",
        "Website": "",
        "WebsiteUrl": "",
        "FacebookUrl": "",
        "TwitterUrl": "",
        "InstagramUrl": "",
        "PinterestUrl": "",
        "OldPassword": "",
        "NewPassword": "",
        "ConfirmPassword": "",
        "Styles": "",
        "Username": "",
    }
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.Bio = ko.observable(data.Bio);
    self.ShopId = ko.observable(data.ShopId);
    self.ShopName = ko.observable(data.ShopName);
    self.Address = ko.observable(new AddressDataModel(data.Address));
    self.PhoneNumber = ko.observable(data.PhoneNumber);
    self.ProfileImageUrl = ko.observable(data.ProfileImageUrl);
    self.Website = ko.observable(data.Website);
    self.WebsiteUrl = ko.observable(data.WebsiteUrl);
    self.FacebookUrl = ko.observable(data.FacebookUrl);
    self.TwitterUrl = ko.observable(data.TwitterUrl);
    self.InstagramUrl = ko.observable(data.InstagramUrl);
    self.PinterestUrl = ko.observable(data.PinterestUrl);
    self.Styles = ko.observableArray(data.Styles);
    self.Username = ko.observable(data.Username);

    self.FullName = ko.computed(function () {
        return ko.unwrap(self.FirstName) + " " + ko.unwrap(self.LastName);
    })

}

function AccountDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "FirstName": "",
        "LastName": "",
        "Email": "",
        "Username": "",
        "PhoneNumber": "",
        "ProfileImageUrl": "",
    }
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.Email = ko.observable(data.Email);
    self.Username = ko.observable(data.Username);
    self.PhoneNumber = ko.observable(data.PhoneNumber);
    self.Address = ko.observable(new AddressDataModel(data.Address));
    self.FullName = ko.computed(function () {
        var first = ko.unwrap(self.FirstName);
        var last = ko.unwrap(self.LastName);
        return first + " " + last;
    });
    self.ProfileImageUrl = ko.observable(data.ProfileImageUrl);
}

function StyleDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "Id": "",
        "Name": "",
        "Description": "",
        "IsActive": "",
        "DateCreated": "",
    }
    self.Name = ko.observable(data.Name);
    self.Description = ko.observable(data.Description);
    self.IsActive = ko.observable(data.IsActive);
}

function TattooDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "UploadedByAccount ": "",
        "ArtistAccount": "",
        "CanvasAccount": "",
        "Name": "",
        "Description": "",
        "Styles": "",
        "Images": "",
        "Comments": "",
        "NumberOfComments": 0,
        "NumberOfViews": 0,
        "NumberOfTats": 0,
        "IsActive": "",
        "Tatted": false,
    }
    self.UploadedByAccount = ko.observable(new AccountDataModel(data.UploadedByAccount));
    self.ArtistAccount = ko.observable(new AccountDataModel(data.ArtistAccount));
    self.CanvasAccount = ko.observable(new AccountDataModel(data.CanvasAccount));
    self.Name = ko.observable(data.Name);
    self.Description = ko.observable(data.Description);
    self.Styles = ko.observableArray();
    for (i in data.Styles) {
        self.Styles.push(new StyleDataModel(data.Styles[i]));
    }

    self.Images = ko.observableArray();
    for (i in data.Images) {
        var img = data.Images[i];
        self.Images.push({ Id: img.Id, StoragePath: img.Path });
    }

    self.Comments = ko.observableArray();
    for (i in data.Comments) {
        self.Comments.push(new CommentDataModel(data.Comments[i]));
    }

    self.NumberOfComments = ko.observable(data.NumberOfComments);
    self.NumberOfViews = ko.observable(data.NumberOfViews);
    self.NumberOfTats = ko.observable(data.NumberOfTats);
    self.IsActive = ko.observable(data.IsActive);
    self.Tatted = ko.observable(data.Tatted);
}

function CommentDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "TattooId": "",
        "Author": "",
        "Comment": "",
        "IsActive": "",
    }
    self.TattooId = ko.observable(data.TattooId);
    self.Author = ko.observable(new AccountDataModel(data.Author));
    self.Comment = ko.observable(data.Comment);
    self.IsActive = ko.observable(data.IsActive);
}

function ImageDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null) data = {
        "Path": ""
    };
    self.Path = ko.observable(data.Path);
};

function AddressDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null || data == "") data = {
        "Address1": "",
        "Address2": "",
        "City": "",
        "State": "",
        "ZipCode": "",
        "AddressType": "",
    };
    self.Address1 = ko.observable(data.Address1);
    self.Address2 = ko.observable(data.Address2);
    self.City = ko.observable(data.City);
    self.State = ko.observable(data.State);
    self.ZipCode = ko.observable(data.ZipCode);
    self.AddressType = ko.observable(data.AddressType);

    self.AddressDisplay = ko.computed(function () {

        var out = "";
        if (self.Address1() != "") out = ko.unwrap(self.Address1);
        if (self.Address2() != "") out = out + "<br>\n" + ko.unwrap(self.Address2)
        if (self.City() != "") {
            out = out + "<br>\n" + ko.unwrap(self.City);
            if (self.State) out = out + ", ";
        }
        if (self.State) out = out + ko.unwrap(self.State) + " "
        if (self.ZipCode) out = out + ko.unwrap(self.ZipCode);
        return out;
    });

    self.CityStateZipDisplay = ko.computed(function () {
        return self.City() + ", " + self.State() + " " + self.ZipCode();
    });
};

function AttachmentDataModel(data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null) data = {
        "LinkedToId": "",
        "FileName": "",
        "IsActive": "",
        "MimeType": "",
        "FileExtension": "",
        "FileSizeInBytes": "",
        "Prefix": "",
        "Attachment": [],
        "StoragePath": "",
        "CategoryType": "",
        "DateCreated": ""
    }

    self.LinkedToId = ko.observable(data.LinkedToId);
    self.FileName = ko.observable(data.FileName);
    self.IsActive = ko.observable(data.IsActive);
    self.MimeType = ko.observable(data.MimeType);
    self.FileExtension = ko.observable(data.FileExtension);
    self.FileSizeInBytes = ko.observable(data.FileSizeInBytes);
    self.Prefix = ko.observable(data.Prefix);
    self.Attachment = ko.observable(data.Attachment);
    self.StoragePath = ko.observable(data.StoragePath);
    self.CategoryType = ko.observable(data.CategoryType);
}

function BaseDataModel(data) {
    var self = this;
    // Syntax to use this model:
    //    $.extend(self, new BaseDataModel(data));

    if (data == null || data === "") data = {
        "Id": Base.EmptyGuid,
        "DateCreated": ""
    }
    self.Id = ko.observable(data.Id);
    self.DateCreated = ko.observable(Base.ToJavaScriptDate(data.DateCreated));
}

var BaseViewModel = function () {
    var self = this;

    //self.RootUrl = "http://localhost:5551/Api/";
    self.RootUrl = (window.location.origin.replace(/5550/, "5551") + "/Api/").replace(/inkpeddlertest/,"inkpeddlerapitest");
    self.EmptyGuid = "00000000-0000-0000-0000-000000000000";

    self.ImageGalleryVM = ko.observable();
    self.UserVM = ko.observable();
    self.ArtistProfileVM = ko.observable();
    self.UploadVM = ko.observable();
    self.TattooVM = ko.observable();
    self.SearchVM = ko.observable();
    self.ShopVM = ko.observable();

    self.StateList = ko.observableArray([
        { Name: "Alabama", Id: "AL" },
        { Name: "Alaska", Id: "AK" },
        { Name: "Arizona", Id: "AZ" },
        { Name: "Arkansas", Id: "AR" },
        { Name: "California", Id: "CA" },
        { Name: "Colorado", Id: "CO" },
        { Name: "Connecticut", Id: "CT" },
        { Name: "Delaware", Id: "DE" },
        { Name: "Florida", Id: "FL" },
        { Name: "Georgia", Id: "GA" },
        { Name: "Hawaii", Id: "HI" },
        { Name: "Idaho", Id: "ID" },
        { Name: "Illinois", Id: "IL" },
        { Name: "Indiana", Id: "IN" },
        { Name: "Iowa", Id: "IA" },
        { Name: "Kansas", Id: "KS" },
        { Name: "Kentucky", Id: "KY" },
        { Name: "Louisiana", Id: "LA" },
        { Name: "Maine", Id: "ME" },
        { Name: "Maryland", Id: "MD" },
        { Name: "Massachusetts", Id: "MA" },
        { Name: "Michigan", Id: "MI" },
        { Name: "Minnesota", Id: "MN" },
        { Name: "Mississippi", Id: "MS" },
        { Name: "Missouri", Id: "MO" },
        { Name: "Montana", Id: "MT" },
        { Name: "Nebraska", Id: "NE" },
        { Name: "Nevada", Id: "NV" },
        { Name: "New Hampshire", Id: "NH" },
        { Name: "New Jersey", Id: "NJ" },
        { Name: "New Mexico", Id: "NM" },
        { Name: "New York", Id: "NY" },
        { Name: "North Carolina", Id: "NC" },
        { Name: "North Dakota", Id: "ND" },
        { Name: "Ohio", Id: "OH" },
        { Name: "Oklahoma", Id: "OK" },
        { Name: "Oregon", Id: "OR" },
        { Name: "Pennsylvania", Id: "PA" },
        { Name: "Rhode Island", Id: "RI" },
        { Name: "South Carolina", Id: "SC" },
        { Name: "South Dakota", Id: "SD" },
        { Name: "Tennessee", Id: "TN" },
        { Name: "Texas", Id: "TX" },
        { Name: "Utah", Id: "UT" },
        { Name: "Vermont", Id: "VT" },
        { Name: "Virginia", Id: "VA" },
        { Name: "Washington", Id: "WA" },
        { Name: "West Virginia", Id: "WV" },
        { Name: "Wisconsin", Id: "WI" },
        { Name: "Wyoming", Id: "WY" }
    ]);

    self.ApiCall = function (url, type, data, async, callback) {
        function createCORSRequest(method, url, data) {
            if (method.toLowerCase() === "get") {
                url = url + "?";
                var getData = [];
                for (i in data) {
                    getData.push(i + "=" + data[i]);
                }
                url = url + getData.join("&");
            }
            var xhr = new XMLHttpRequest();
            if ("withCredentials" in xhr) xhr.open(method, url, true);
            else if (typeof XDomainRequest != "undefined") {
                xhr = new XDomainRequest();

                xhr.open(method, url);
            }
            else return null;

            xhr.setRequestHeader("Content-type", "application/json");
            return xhr;
        }
        if (data == null) data = {};
        data.UserToken = $.cookie("UserToken");
        var request = createCORSRequest(type, Base.RootUrl + url, data);
        if (request) {
            request.onload = function () {
                var response = JSON.parse(request.responseText);
                callback(response);
            };
            request.send(JSON.stringify(data));
        }
        else {
            return "CORS not supported by browser!";
        }
    }

    self.ServiceCall = function (url, type, data, async, callback) {
        if (callback == undefined || url == undefined) {
            var badcall = { Success: false, FailureInformation: "Call must provide callback and url!" };
            callback(badcall);
        }
        if (type == undefined || type.length == 0) { type = "get"; }
        if (async == undefined || async.length == 0) { async = true; }
        if (data == undefined || data.length == 0) { data = {}; }

        data.UserToken = $.cookie("UserToken");

        $.ajax({
            type: type,
            url: self.RootUrl + url,
            data: data,
            cache: false,
            async: async,
            success: function (response) { callback(response); },
            error: function (xhr2, status2, error2) {
                var message = status2 + " / " + error2;
                if (xhr2 != undefined && xhr2.responseText != undefined) {
                    var s = xhr2.responseText.indexOf("<title>");
                    var e = xhr2.responseText.indexOf("</title>");
                    if (s > 0 && e > s) {
                        var l = e - s;
                        message = xhr2.responseText.substr(s + 7, l - 7);
                    }
                }
                var response = { Success: false, FailureInformation: "Error :" + message };
                callback(response);
            }
        });
    }

    self.ToJavaScriptDate = function (value) {
        if (value == null || value == "") return;
        var dt = new Date(value);
        if (dt === "Invalid Date") {
            try {
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var dt = new Date(parseFloat(results[1]));
            }
            catch (e) {
                console.warn("ToJavaScriptDate: ", e);
            }
        }
        return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
    }

    self.Message = function (message, level, autoDismiss) {
        if (level == 'success') return toastr.success(message);
        if (level == 'error') return toastr.error(message, "", { closeButton: true, timeOut: 0, extendedTimeOut: 0 });
        console.log(message);
    }

    self.GetClientRole = function (value) {
        if (value == 0) return '';
        else if (value == 1) return 'Admin';
        else if (value == 2) return 'User';
    };

    self.SaveByteArray = (function () {
        var a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";
        return function (data, name) {
            var blob = new Blob(data, { type: "octet/stream" }),
                url = window.URL.createObjectURL(blob);
            a.href = url;
            a.download = name;
            a.click();
            window.URL.revokeObjectURL(url);
        };
    }());

    self.Base64ToArrayBuffer = function (base64) {
        var binaryString = window.atob(base64);
        var binaryLen = binaryString.length;
        var bytes = new Uint8Array(binaryLen);
        for (var i = 0; i < binaryLen; i++) {
            var ascii = binaryString.charCodeAt(i);
            bytes[i] = ascii;
        }
        return bytes;
    }

    self.GetStyles = function () {
        if (!localStorage.Styles) {
            var styles = [];
            Base.ApiCall("Style/Get", "get", null, true, function (response) {
                if (response.IsSuccess) {
                    for (i in response.Styles) {
                        styles.push(new StyleDataModel(response.Styles[i]));
                    }
                    localStorage.Styles = JSON.stringify(ko.toJS(styles));
                }
                else {
                    self.Message("Could not get styles", "error");
                }
            });
        }
        styles = JSON.parse(localStorage.Styles);
        var out = []
        for (i in styles) {
            out.push(new StyleDataModel(styles[i]));
        }
        return out;

    }
}

function PhoneMask() {
    return ko.computed({
        read: function () {
            var phoneNumber = this() ? this() : "";
            if (phoneNumber.length < 1) return;
            var out = "";
            out = out + "(" + phoneNumber.substring(0, 3);
            if (phoneNumber.length > 3) out = out + ") " + phoneNumber.substring(3, 6);
            if (phoneNumber.length > 6) out = out + "-" + phoneNumber.substring(6, 10);
            return out;
        },
        write: function (_phoneNumber) {
            var phoneNumber = _phoneNumber.replace(/[^\.\d]/g, "");
            this(phoneNumber);
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}
ko.subscribable.fn.PhoneMask = PhoneMask;

function ToAmount() {
    return ko.computed({
        read: function () {
            var num = ko.unwrap(this);
            return this() ? "$" + num.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",") : "$0.00";
        },
        write: function (_amount) {
            this(_amount);
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}
ko.subscribable.fn.ToAmount = ToAmount;

var TattooGalleryViewModel = function (params) {
    var self = this;

    self.Page = ko.observable();
    self.PerPage = ko.observable(4);
    self.Gallery = ko.observableArray();
    self.Tattoos = ko.observableArray();
    self.PerRow = ko.observable(0)
    self.Header = ko.observable("");

    self.RefinedTattooList = ko.computed(function () {
        var refined = [];
        for (i in self.Tattoos()) {
            // if blah blah 
            var tat = self.Tattoos()[i];
            refined.push(tat);
        }
        return refined;
    })

    self.VisibleTattoos = ko.computed(function () {
        var perPage = parseInt(self.PerPage());
        var first = (self.Page() * perPage) - perPage;
        return self.RefinedTattooList().slice(first, first + perPage);
    })

    self.PageTotal = ko.computed(function () {
        var count = self.RefinedTattooList().length;
        var total = Math.ceil(self.RefinedTattooList().length / self.PerPage());
        if (self.Page() > total && total > 0) self.Page(total);
        if (total == 0) self.Page(1);
        return total;
    })

    self.ChangePage = function (offset) {
        return function () {
            if (offset === 'first') self.Page(1);
            else if (offset === 'last') self.Page(self.PageTotal());
            else {
                var current = self.Page();
                self.Page(current + offset);
            }
        };
    }

    self.Load = function () {
        // Parse Possible params
        self.LoadGallery();

        var perPage = params ? parseInt(params.PerPage) : 0;
        var perRow = params ? parseInt(params.PerRow) : 0;
        var header = params ? params.Header : "Tattoos";

        self.Header(header);

        if (perPage < 1 || isNaN(perPage)) {
            perPage = 4;
        }

        self.PerPage(perPage);

        if (perRow < 1 || perRow > 4 || isNaN(perRow)) {
            perRow = 4;
        }

        self.PerRow(perRow);
    }

    self.LoadGallery = function () {
        if (params == null) return;
        Base.ServiceCall(params.Api, "get", params.ApiData, "true", function (response) {
            if (response.IsSuccess) {
                for (i in response.Tattoos) {
                    var tat = response.Tattoos[i];
                    self.Tattoos.push(new TattooDataModel(tat));
                }
            }
        })
    }

    self.mouseHover = function (vm, event) {
        console.log(vm, event);
    };

    self.Load();
}

ko.components.register('TattooGallery', {
    viewModel: TattooGalleryViewModel,
    template: { element: 'TattooGalleryTemplate' }
})

var TattooCommentsViewModel = function (params) {
    var self = this;

    self.IsLoaded = ko.observable(false);
    self.TattooId = ko.observable("");
    self.Comment = ko.observable("");
    self.Comments = ko.observableArray();

    self.Load = function () {
        self.BindValidation();
        if (params == null || params.TattooId == null) return;
        self.LoadComments();
        // Define defaults
        // Need tattoo ID
    }

    self.LoadComments = function () {
        var data = { TattooId: params.TattooId };
        Base.ServiceCall("Tattoo/GetComments", "get", data, "true", function (response) {
            if (response.IsSuccess) {
                for (i in response.Comments) {
                    self.Comments.push(new CommentDataModel(response.Comments[i]));
                }
            }
        })
    }

    self.SaveComment = function () {
        var data = {
            Comment: {
                AuthorId: '3E16ED76-64BA-4257-ACDE-1CBFB33BCA9D', // TODO Fix Account Id
                TattooId: params.TattooId,
                Comment: self.Comment(),
                IsActive: true
            }
        }
        Base.ApiCall("Tattoo/SaveComment", "post", data, true, function (response) {
            if (response.IsSuccess) {
                Base.Message("Comment Saved!", "success");
                self.Comments.removeAll();
                self.LoadComments();
                self.Comment("");
            }
        })
    }

    self.BindValidation = function () {
        $("#NewCommentForm").validate({
            rules: {
                "Comment": "required"
            },
            Messages: {
                "Comment": "A comment is required!",
            }
        })
    }
    self.Load();
}

ko.components.register('TattooComments', {
    viewModel: TattooCommentsViewModel,
    template: { element: 'TattooCommentsTemplate' }
})

var ClaimViewModel = function (params) {
    var self = this;

    self.Type = ko.observable("");
    self.TattooId = ko.observable("");

    self.Load = function () {
        if (params == null) {
            // Default config
            self.Type("");
            return;
        }
        else {
            self.Type(params.Type);
            self.TattooId(params.TattooId);
        }
    }

    self.Claim = function () {
        var data = {
            TattooId: self.TattooId(),
            ClaimType: self.Type(),
        }

        console.log(data);

        Base.ApiCall("Tattoo/Claim", "get", data, null, function (response) {
            if (response.IsSuccess) {
                Base.Message("Thanks! We'll be in touch", "success");
            }
            else {
                Base.Message("Couldn't claim tattoo, Please try again later");
            }
        })

    }

    self.Load();
}

ko.components.register('ClaimTattoo', {
    viewModel: ClaimViewModel,
    template: { element: 'ClaimTemplate' }
});

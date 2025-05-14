var SiteConfig = {
    AvailableCountries: ["USA", "Canada"],
    MaxDurationInDays: 45,
    MinDurationInDays: 15,
    MinNumberOfSquares: 50,
    MaxNumberOfSquares: 250,
    VideoAutoCloseInSeconds: 22,
    StripeKey: function () {
        if (window.location.hostname.match("giveCENSORED.com") || window.location.hostname.match('CENSORED.azurewebsites')) {
            // Stripe live publishable key
            return "";
        }
        else {
            // Stripe test publishable key
            return "";
        }
    },
    SecondsBetweenImages: 5 * 1000,
    SecondsToRestartCarousel: 15 * 1000,
};

var Base = {
    ServiceCall: function (url, type, data, async, callback) {
        if (callback === undefined || url === undefined) {
            var badcall = { IsSuccess: false, ErrorMessage: "Call must provide callback and url!", IsTokenBad: false };
            callback(badcall);
        }
        if (type == undefined || type.length == 0) { type = "get"; }
        if (async == undefined || async.length == 0) { async = true; }
        if (data == undefined || data.length == 0) { data = {}; }
        $.ajax({
            type: type,
            url: url,
            data: data,
            cache: false,
            async: async,
            success: function (response) {
                console.log("ServiceCall: " + response)
                response["IsSuccess"] = true;
                callback(response);
            },
            error: function (xhr2) {
                console.log("ServiceCall Error: " + xhr2)
                response = xhr2.responseJSON;
                response["IsSuccess"] = false;
                callback(response);
            }
        });
    },
    ApiServiceCall: function (url, type, data, async, callback) {
        if (callback === undefined || url === undefined) {
            var badcall = { IsSuccess: false, ErrorMessage: "Call must provide callback and url!", IsTokenBad: false };
            callback(badcall);
        }

        var jwtToken = Base.GetCookie('jwtToken');
        console.log(jwtToken)
        debugger;
        if (type == undefined || type.length == 0) { type = "get"; }
        if (async == undefined || async.length == 0) { async = true; }
        if (data == undefined || data.length == 0) { data = {}; }
        $.ajax({
            type: type,
            url: "https://localhost:44398/api" + url,
            headers: { 'Authorization': 'Bearer ' + jwtToken },
            data: data,
            cache: false,
            async: async,
            success: function (response) {
                console.log("ApiServiceCall: " + response)
                callback(response);
            },
            error: function (xhr) {
                console.log("ApiServiceCall Error: " + xhr)
                if (xhr.status === 401) {
                    Base.Refresh(function (response) {
                        if (response.IsSuccess) { Base.ApiServiceCall(url, type, data, async, callback); }
                        else { window.location = "/Security/Logout"; }
                    });
                }
                else {
                    var response = xhr.responseJSON;
                    response["IsSuccess"] = false;
                    response["ErrorMessage"] = response.message;
                    callback(response);
                }
            }
        });
    },
    Authenticate: function (data, callback) {
        $.ajax({
            type: "POST",
            url: "/Security/Authenticate",
            dataType: "json",
            data: data,
            cache: false,
            async: false,
            success: function (response) {
                response["isSuccess"] = true;
                callback(response);
            },
            error: function (xhr) {
                var response = xhr.responseJSON;
                response["isSuccess"] = false;
                callback(response);
            }
        });
    },
    Refresh: function (callback) {
        $.ajax({
            type: "POST",
            url: "/Security/ApiRefreshServiceCall",
            dataType: "json",
            data: null,
            cache: false,
            async: false,
            success: function (response) {
                response["isSuccess"] = true;
                callback(response);
            },
            error: function (xhr) {
                var response = xhr.responseJSON;
                response["isSuccess"] = false;
                callback(response);
            }
        });
    },
    PromiseCall: function (url, type, data) {
        return new Promise(function (resolve, reject) {
            BaseModel.ServiceCall(url, type, data, true, function (response) {
                if (response.IsSuccess) { resolve(response); }
                else { reject(response); }
            });
        });
    },
    Message: function (message, level) {
        if (level === undefined) { level = BaseModel.MessageLevels.Success; }
        Swal.fire({
            type: level.type,
            title: level.title,
            text: message
            // footer: '<a href>Why do I have this issue?</a>' TODO: can be used to give people more information about what went wrong
        });
    },
    MessageLevels: {
        Success: { type: "success", title: "Success", color: "green" },
        Info: { type: "info", title: "Info", color: "blue" },
        Warning: { type: "warning", title: "Warning", color: "yellow" },
        Error: { type: "error", title: "Error", color: "red" }
    },
    LogError: function (exception, showMessage) {
        console.error("ERROR: " + exception);
        if (showMessage) { BaseModel.Message(exception, BaseModel.MessageLevels.Error); }
    },
    Cookies: function (cookie, newVal) {
        var cookies = document.cookie.split(";");
        var allCookies = {};
        for (i in cookies) {
            var cookieParts = cookies[i].split('=');
            var key = cookieParts.shift();
            var value = cookieParts.join("=");
            if (key && value) allCookies[key.toLowerCase().trim()] = value.trim();
        }

        if (cookie) {
            if (newVal) {
                var newCookie = cookie + "=" + newVal + "; path=/";
                document.cookie = newCookie;
                return allCookies[cookie.toLowerCase()] = newVal;
            }
            else {
                return allCookies[cookie.toLowerCase()];
            }
        }
        return allCookies;
    },
    GetUrlQuery: function (query) {
        var args = window.location.href.split('?');
        var params = {};
        if (args.length <= 1) { return null; }
        var url = args[1].split('#')[0].split("&");
        for (i in url) {
            param = url[i].split("=");
            params[param[0].toLowerCase()] = param[1];
        }
        if (query) {
            return params[query];
        }
        return params;
    },
    Guid: {
        Empty: '00000000-0000-0000-0000-000000000000',
        New: function () {
            function s4() {
                return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
            }
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
        }
    },
    ToDate: function (date, format) {
        try {
            if (date) {
                if (date instanceof Date) { return date; }
                var newDate = new Date(parseInt(date.match(/\d+/) || 0));
                if (format === "mm/dd/yyyy") return newDate.toLocaleDateString();
                if (format === "yyyy-dd-mm") return newDate.toISOString().split('T')[0];
                return newDate;
            }
        }
        catch (ex) {
            console.error("Date parse Failed", date);
        }
    },
    ToTime: function (date) {
        try {
            if (date) {
                if (date instanceof Date) { return date; }
                var newDate = new Date(parseInt(date.match(/\d+/) || 0));
                var minutes = newDate.getMinutes();
                if (minutes < 10)
                    minutes = "0" + minutes;
                var hour = newDate.getHours();
                if (hour > 12)
                    return (hour - 12) + ":" + minutes + " PM";
                else if (hour === 12)
                    return hour + ":" + minutes + " PM";
                else
                    return hour + ":" + minutes + " AM";
            }
        }
        catch (ex) {
            console.log("Date parse Failed: " + ex);
        }
    },
    States: [
        { Name: "Alabama", ShortName: "AL" },
        { Name: "Alaska", ShortName: "AK" },
        { Name: "Arizona", ShortName: "AZ" },
        { Name: "Arkansas", ShortName: "AR" },
        { Name: "California", ShortName: "CA" },
        { Name: "Colorado", ShortName: "CO" },
        { Name: "Connecticut", ShortName: "CT" },
        { Name: "Delaware", ShortName: "DE" },
        { Name: "District of Columbia", ShortName: "DC" },
        { Name: "Florida", ShortName: "FL" },
        { Name: "Georgia", ShortName: "GA" },
        { Name: "Hawaii", ShortName: "HI" },
        { Name: "Idaho", ShortName: "ID" },
        { Name: "Illinois", ShortName: "IL" },
        { Name: "Indiana", ShortName: "IN" },
        { Name: "Iowa", ShortName: "IA" },
        { Name: "Kansas", ShortName: "KS" },
        { Name: "Kentucky", ShortName: "KY" },
        { Name: "Louisiana", ShortName: "LA" },
        { Name: "Maine", ShortName: "ME" },
        { Name: "Maryland", ShortName: "MD" },
        { Name: "Massachusetts", ShortName: "MA" },
        { Name: "Michigan", ShortName: "MI" },
        { Name: "Minnesota", ShortName: "MN" },
        { Name: "Mississippi", ShortName: "MS" },
        { Name: "Missouri", ShortName: "MO" },
        { Name: "Montana", ShortName: "MT" },
        { Name: "Nebraska", ShortName: "NE" },
        { Name: "Nevada", ShortName: "NV" },
        { Name: "New Hampshire", ShortName: "NH" },
        { Name: "New Jersey", ShortName: "NJ" },
        { Name: "New Mexico", ShortName: "NM" },
        { Name: "New York", ShortName: "NY" },
        { Name: "North Carolina", ShortName: "NC" },
        { Name: "North Dakota", ShortName: "ND" },
        { Name: "Ohio", ShortName: "OH" },
        { Name: "Oklahoma", ShortName: "OK" },
        { Name: "Oregon", ShortName: "OR" },
        { Name: "Pennsylvania", ShortName: "PA" },
        { Name: "Rhode Island", ShortName: "RI" },
        { Name: "South Carolina", ShortName: "SC" },
        { Name: "South Dakota", ShortName: "SD" },
        { Name: "Tennessee", ShortName: "TN" },
        { Name: "Texas", ShortName: "TX" },
        { Name: "Utah", ShortName: "UT" },
        { Name: "Vermont", ShortName: "VT" },
        { Name: "Virginia", ShortName: "VA" },
        { Name: "Washington", ShortName: "WA" },
        { Name: "West Virginia", ShortName: "WV" },
        { Name: "Wisconsin", ShortName: "WI" },
        { Name: "Wyoming", ShortName: "WY" },
    ],
    CellStatus: {
        Unknown: 0,
        Open: 1,
        Locked: 2,
        Paid: 3
    },
    Environment: function () {
        var baseUrl = window.location.hostname;
        if (baseUrl.match("hoie.azurewebsites.net")) { return "PROD"; }
        else if (baseUrl.match("hoie.io")) { return "PROD"; }
        else if (baseUrl.match("hoie-test.azurewebsites.net")) { return "TEST"; }
        else { return "DEV"; }
    },
    AzureStorageConfig: {
        StorageAccountUri: "https://hoie.blob.core.windows.net",
        SasToken: '',
        MaxChunkSize: 45000,
        ChunkSize: function (sizeInB) {
            var sizeInGb = Math.floor(sizeInB / 1024 / 1024 / 1024);
            return sizeInGb > 4 ? sizeInB / UploaderConfig.MaxChunkSize : 1 * 1024 * 1024;
        },
        Container: function () {
            if (window.location.hostname.includes("hoie.io")) { return "production"; }
            else if (window.location.hostname.includes("hoie.azurewebsites.net")) { return "production"; }
            else if (window.location.hostname.includes("hoie-test.azurewebsites.net")) { return "test"; }
            else { return "development"; }
        }
    },
    StripeKey: function () {
        if (window.location.hostname.match("giveCENSORED.com") || window.location.hostname.match('CENSORED.azurewebsites')) {
            // Stripe live publishable key
            return "";
        }
        else {
            // Stripe test publishable key
            return "";
        }
    },
    GetSecurityModel: function () {
        try {
            var rtn;
            $.ajax({
                type: "post",
                url: "Security/GetSecurityModel",
                data: null,
                cache: false,
                async: false,
                success: function (securityModel) {
                    rtn = securityModel;
                },
                error: function (err) {
                    BaseModel.LogError(err);
                }
            });
            return rtn;
        }
        catch (ex) {
            BaseModel.LogError("Get security model failed", date);
        }
    }

};

function MainViewModel() {
    var self = this;

    //self.HeaderVM = ko.observable(new HeaderViewModel(self));
    //self.FooterVM = ko.observable(new FooterViewModel(self));
    self.CurrentVM = ko.observable();
}

ko.bindingHandlers.fadeVisible = {
    init: function (_elem, _value) {
        var value = _value();
        $(_elem).toggle(ko.unwrap(value));
    },
    update: function (_elem, _value) {
        var value = _value();
        ko.unwrap(value) ? $(_elem).slideDown() : $(_elem).slideUp();
    }
};

ko.bindingHandlers.delayVisible = {
    init: function (_elem, _value) {
        var value = _value();
        $(_elem).toggle(ko.unwrap(value));
    },
    update: function (_elem, _value) {
        var value = _value();
        ko.unwrap(value) ? $(_elem).show(1000) : $(_elem).hide(1000);
    }
};

ko.subscribable.fn.PhoneMask = PhoneMask;
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

ko.subscribable.fn.ToAmount = ToAmount;
function ToAmount() {
    return ko.computed({
        read: function () {
            var num = ko.unwrap(this);
            return this() ? "$" + num.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",") : "$0.00";
        },
        write: function (_amount) {
            var amount = (_amount.match(/\d+\.?/g) || [0]).join("");
            this(parseFloat(amount));
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

ko.subscribable.fn.ToShortAmount = ToShortAmount;
function ToShortAmount() {
    return ko.computed({
        read: function () {
            var num = ko.unwrap(this);
            return this() ? "$" + num.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") : "$0";
        },
        write: function (_amount) {
            this(_amount);
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

ko.subscribable.fn.OnlyPositive = OnlyPositive;
function OnlyPositive() {
    return ko.computed({
        read: function () {
            return this();
        },
        write: function (_amount) {
            this(Math.abs(_amount));
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

ko.subscribable.fn.ToShortDate = ToShortDate;
function ToShortDate() {
    return ko.computed({
        read: function () {
            if (this() instanceof Date) {
                return this().toLocaleDateString('en-US', { month: 'numeric', day: 'numeric', year: 'numeric' });
            }
        },
        write: function (date) {
            if (date) {
                this(new Date(date));
            }
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

ko.subscribable.fn.ToDaysAgo = ToDaysAgo;
function ToDaysAgo() {
    return ko.computed({
        read: function () {
            if (this() instanceof Date) {
                var today = new Date();
                return Math.floor((today - this()) / 1000 / 60 / 60 / 24);
            }
        },
        write: function (date) {
            if (date) {
                this(new Date(date));
            }
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

ko.subscribable.fn.ToEin = ToEin;
function ToEin() {
    return ko.computed({
        read: function () {
            var ein = this() ? this() : "";
            if (ein.length < 3) return ein;
            var out = "";
            if (ein.length > 2) {
                out = ein.substr(0, 2) + "-" + ein.substr(2, 7);
            }
            return out;
        },
        write: function (_ein) {
            var ein = _ein.replace(/[^\.\d]/g, "");
            this(ein);
            this.notifySubscribers();
        },
        owner: this,
    }).extend({ notify: 'always' });
}

function dataURItoBlob(dataURI) {
    // convert base64 to raw binary data held in a string
    // doesn't handle URLEncoded DataURIs - see SO answer #6850276 for code that does this
    var byteString = atob(dataURI.split(',')[1]);

    // separate out the mime component
    var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0]

    // write the bytes of the string to an ArrayBuffer
    var ab = new ArrayBuffer(byteString.length);

    // create a view into the buffer
    var ia = new Uint8Array(ab);

    // set the bytes of the buffer to the correct values
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }

    // write the ArrayBuffer to a blob, and you're done
    var blob = new Blob([ab], { type: mimeString });
    return blob;
}
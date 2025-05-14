var UserDataModel = function (data) {
    var self = this;
    $.extend(self, new BaseDataModel(data));

    if (data == null) data = {
        "Username": "",
        "FirstName": "",
        "LastName": "",
        "PhoneNumber": "",
        "Email": "",
        "ProfileImage": "",
        "Addresses": []
    };
    self.Id = ko.observable(data.Id);
    self.Username = ko.observable(data.Username);
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.PhoneNumber = ko.observable(data.PhoneNumber);
    self.Email = ko.observable(data.Email);
    self.ProfileImage = ko.observable(data.ProfileImage);
    self.DateCreated = ko.observable(Base.ToJavaScriptDate(data.DateCreated));
    self.Address = ko.observable(new AddressDataModel());
    for (i in data.Addresses) {
        if (data.Addresses[i].AddressType == 0) {
            self.Address(new AddressDataModel(data.Addresses[i]));
        }
    }

    self.NameDisplay = ko.computed(function () {
        if (self.Username() != "") return self.Username();
        if (self.Email() != "") return self.Email();
        return "No Username";
    });

    self.SinceDateDisplay = ko.computed(function () {
        return self.DateCreated();
    });
};

var UserViewModel = function () {
    var self = this;
    self.User = ko.observable(new UserDataModel());
    self.UpdatedUserInfo = ko.observable(new UserDataModel());
    self.Content = ko.observable({ name: 'UserViewTemplate' });
    self.CanEdit = ko.observable(false);
    self.Tatted = ko.observable({ name: 'TattooGallery' })
    self.Uploaded = ko.observable({ name: 'TattooGallery' })
    self.Canvased = ko.observable({ name: 'TattooGallery' })

    self.OldPassword = ko.observable("");
    self.NewPassword = ko.observable("");
    self.ConfirmPassword = ko.observable("");

    self.PasswordMatch = ko.computed(function () {
        if (self.OldPassword() == "") return false;
        if (self.NewPassword() == "") return false;
        if (self.NewPassword() === self.ConfirmPassword())
            return true;
        return false;
    })


    self.Load = function () {
        // If no user, load self
        // else look for ...
        id = window.location.pathname.split('/')[2];
        if (id != null) {
            self.LoadUserInfo(id);
        }
        else {
            self.LoadUserInfo("");
        }        
    };

    self.LoadUserInfo = function (_username) {
        var data = { Username: _username };
        Base.ApiCall("User/Get", "get", data, true, function (response) {
            if (response.IsSuccess) {
                self.User(new UserDataModel(response.User));
                self.CanEdit(response.CanEdit);
                self.Canvased({
                    name: 'TattooGallery',
                    params: {
                        Api: 'User/GetCanvased',
                        ApiData: { UserId: self.User().Id() },
                        Header: 'On Me',
                        PerRow: 3,
                        PerPage: 6,
                    }
                })
                self.Uploaded({
                    name: 'TattooGallery',
                    params: {
                        Api: 'User/GetUploaded',
                        ApiData: { UserId: self.User().Id() },
                        Header: 'My Uploaded',
                        PerRow: 4,
                        PerPage: 4,
                    }
                })
                self.Tatted({
                    name: 'TattooGallery',
                    params: {
                        Api: 'User/GetTatted',
                        ApiData: { UserId: self.User().Id() },
                        Header: 'My Tatted',
                        PerRow: 3,
                        PerPage: 6,
                    }
                })
                self.UpdatedUserInfo(new UserDataModel(ko.toJS(self.User)));
                self.UpdatedUserInfo().Address(ko.toJS(self.User().Address()));
            } else {
                Base.Message(response.ErrorMessage, "error", false);
            }
            $(".wait-container").hide();
        });
    }

    self.EditProfile = function () {
        if (!self.CanEdit()) return;
        self.Content({ name: 'UserEditTemplate' });
        self.BindValidations();
    };

    self.OnProfileImageChange = function (vm, evt) {
        var file = evt.target.files[0];
        var reader = new FileReader();
        reader.onload = function () {
            var attachment = {
                LinkedToId: vm.User().Id(),
                FileName: file.name,
                MimeType: file.type,
                FileSizeInBytes: file.size,
                Attachment: reader.result.split(',')[1]
            };
            var data = { ProfileImage: attachment };
            Base.ServiceCall("/Data/SaveProfileImage", "post", data, true, function (response) {
                if (response.IsSuccess) {
                    Base.Message("Profile image updated successfully", "success", false);
                    self.User().ProfileImage(reader.result);
                } else {
                    Base.Message(response.ErrorMessage, "error", false);
                }
            });
        };
        reader.readAsDataURL(file);
    };

    self.Save = function () {
        if (!self.CanEdit()) return;
        $('#user-edit-tab-content').validate();
        if (!$('#user-edit-tab-content').valid()) {
            Base.Message("Please fix errors on page then try and save again.", "danger", true);
            return;
        }

        $(".wait-container").show();
        var data = { User: ko.toJS(self.UpdatedUserInfo()) };
        data.User.Addresses = [ko.toJS(self.UpdatedUserInfo().Address)];
        Base.ServiceCall("User/Save", "post", data, true, function (response) {
            if (response.IsSuccess) {
                self.Close();
                Base.Message("User profile updated successfully", "success", true);
            } else {
                Base.Message(response.ErrorMessage, "error", false);
            }
            $(".wait-container").hide();
        });
    };

    self.UpdatePassword = function () {
        if (!self.CanEdit()) return;
        // TODO Password update service call
    }

    self.Close = function () {
        self.Content({ name: 'UserViewTemplate' });
    };

    self.BindValidations = function () {
        $("input:text").focus(function () { $(this).select(); });
        $('#user-edit-tab-content').on('change keyup keydown', 'input, textarea, select', function (e) {
            $(this).addClass('changed-input');
        });
        $('#user-edit-tab-content').validate({
            rules: {
                "OldPassword": "required",
                "NewPassword": "required",
                "ConfirmPassword": "required"
            },
            messages: {
                "OldPassword": "Prior password is required.",
                "NewPassword": "New password is required.",
                "ConfirmPassword": "Please confirm new password."
            }
        });
    };

    self.BindPasswordValidation = function () {

    }
};
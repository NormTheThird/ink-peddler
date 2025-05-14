var ShopViewModel = function () {
    var self = this;

    self.Shop = ko.observable(new ShopDataModel());
    self.Content = ko.observable({ name: "ShopProfileTemplate" });
    self.EmployeeList = ko.observableArray();
    self.EmployeeFilter = ko.observable("");
    self.EmployeeSort = ko.observable(0);
    self.Page = ko.observable(1);
    self.PerPage = ko.observable(10);

    self.Employee = ko.observable(new EmployeeDataModel());
    self.AddressType = ko.observable(0);

    self.Load = function () {
        id = window.location.pathname.split('/')[2];
        if (id != null) {
            self.LoadBusiness(id);
        }
        else {
            self.LoadBusiness("");
        }
    }

    self.ShowProfileEdit = function () {
        self.Content({ name: 'ShopProfileEditTemplate' });
    }

    self.ShowProfileView = function () {
        self.Content({ name: 'ShopProfileTemplate' });
    }

    self.ShowEditEmployee = function (_employee) {
        self.Content({ name: 'ManageEmployeesEditTemplate' });
    }

    self.ShowViewEmployees = function () {
        self.Content({ name: 'ManageEmployeesViewTemplate' });
    }

    self.LoadBusiness = function (_businessName) {
        var data = { BusinessName: _businessName };
        Base.ApiCall("Business/GetBusiness", "get", data, true, function (response) {
            if (response.IsSuccess) {
                self.Shop(new ShopDataModel(response.Business));
                for (i in response.Business.Accounts) {
                    var emp = response.Business.Accounts[i];
                    self.EmployeeList.push(new EmployeeDataModel(emp));
                }                
            }
            else {
                Base.Message("Could not get Business Info. " + response.ErrorMessage, "error");
            }
        })
    }

    self.RefinedEmployeeList = ko.computed(function () {
        var sort = []
        if (self.EmployeeFilter() === "") sort = self.EmployeeList();
        else {
            var expr = new RegExp(self.EmployeeFilter(), "i");
            for (i in self.EmployeeList()) {
                var emp = self.EmployeeList()[i];
                var searchable = emp.FullName() + " " + emp.Username();
                if (searchable.match(expr)) sort.push(emp);
            }
        }

        var sortBy = self.EmployeeSort();
        // Sort by Name
        if (sortBy === 0) {
            sort.sort(function (a, b) {
                if (a.FullName() > b.FullName()) return 1;
                if (a.FullName() < b.FullName()) return -1;
                return 0;
            })
        }
        if (sortBy === 1) {
            sort.sort(function (a, b) {
                if (a.FullName() > b.FullName()) return -1;
                if (a.FullName() < b.FullName()) return 1;
                return 0;
            })
        }
        // Sort by Username
        if (sortBy === 2) {
            sort.sort(function (a, b) {
                if (a.Username() > b.Username()) return 1;
                if (a.Username() < b.Username()) return -1;
                return 0;
            })
        }
        if (sortBy === 3) {
            sort.sort(function (a, b) {
                if (a.Username() > b.Username()) return -1;
                if (a.Username() < b.Username()) return 1;
                return 0;
            })
        }
        // Sort by Manager
        if (sortBy === 4) {
            sort.sort(function (a, b) {
                if (a.IsManager() > b.IsManager()) return 1;
                if (a.IsManager() < b.IsManager()) return -1;
                return 0;
            })
        }
        if (sortBy === 5) {
            sort.sort(function (a, b) {
                if (a.IsManager() > b.IsManager()) return -1;
                if (a.IsManager() < b.IsManager()) return 1;
                return 0;
            })
        }
        // Sort by Owner
        if (sortBy === 6) {
            sort.sort(function (a, b) {
                if (a.IsOwner() > b.IsOwner()) return 1;
                if (a.IsOwner() < b.IsOwner()) return -1;
                return 0;
            })
        }
        if (sortBy === 7) {
            sort.sort(function (a, b) {
                if (a.IsOwner() > b.IsOwner()) return -1;
                if (a.IsOwner() < b.IsOwner()) return 1;
                return 0;
            })
        }
        // Sort by Role
        if (sortBy === 8) {
            sort.sort(function (a, b) {
                if (a.RoleId() > b.RoleId()) return 1;
                if (a.RoleId() < b.RoleId()) return -1;
                return 0;
            })
        }
        if (sortBy === 9) {
            sort.sort(function (a, b) {
                if (a.RoleId() > b.RoleId()) return -1;
                if (a.RoleId() < b.RoleId()) return 1;
                return 0;
            })
        }
        return sort;
    })

    self.VisibleEmployeeList = ko.computed(function () {
        var perPage = parseInt(self.PerPage());
        var first = (self.Page() * perPage) - perPage;
        return self.RefinedEmployeeList().slice(first, first + perPage);
    })

    self.PageTotal = ko.computed(function () {
        var total = Math.ceil(self.RefinedEmployeeList().length / self.PerPage());
        if (self.Page() > total && total > 0) self.Page(total);
        if (total == 0) self.Page(1);
        return total;
    })

    self.ChangePage = function (_offset) {
        return function () {
            if (_offset === 'first') { self.Page(1); }
            else if (_offset === 'last') { self.Page(self.PageTotal()); }
            else {
                var current = self.Page();
                self.Page(current + _offset);
            }
        };
    }

    self.ChangeSort = function (_initial) {
        return function () {
            if (self.EmployeeSort() === _initial) self.EmployeeSort(_initial + 1);
            else self.EmployeeSort(_initial);
        }
    }

    self.SortByName = self.ChangeSort(1);
    self.SortByUsername = self.ChangeSort(3);
    self.SortByManager = self.ChangeSort(5);
    self.SortByOwner = self.ChangeSort(7);
    self.SortByRole = self.ChangeSort(9);

    self.ChangeAddress = function (_type) {
        return function () {
            self.AddressType(_type);
        }
    }

    self.ShowHome = self.ChangeAddress(1);

    self.ShowWork = self.ChangeAddress(2);

    self.BindValidation = function () {
        // TODO Employee validation
        $('#EmployeeEditForm').validate({
            rules: {

            },
            messages: {

            }
        })
    }

    self.Save = function () {
        // TODO Save employee Updates
    }
}

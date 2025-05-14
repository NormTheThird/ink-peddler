function DashboardTotalsDataModel(data) {
    var self = this;
    if (!data) data = {};

    self.ActiveUserCount = ko.observable(data.ActiveUserCount || 0);
    self.InActiveUserCount = ko.observable(data.InActiveUserCount || 0);
    self.ActiveArtistCount = ko.observable(data.ActiveArtistCount || 0);
    self.InActiveArtistCount = ko.observable(data.InActiveArtistCount || 0);
    self.ActiveBusinessCount = ko.observable(data.ActiveBusinessCount || 0);
    self.InActiveBusinessCount = ko.observable(data.InActiveBusinessCount || 0);
    self.TattooCount = ko.observable(data.TattooCount || 0);
}

function DashboardViewModel(parent) {
    var self = this;
    self.Parent = parent;
    self.DashboardTotals = ko.observable(new DashboardTotalsDataModel());

    self.Loading = ko.observable({ Page: ko.observable(true), GetDashboardTotals: ko.observable(false) });
    self.IsLoading = ko.computed(function () {
        for (var i in self.Loading()) { if (self.Loading()[i]()) { return true; } }
        return false;
    });

    self.GetDashboardTotals = function () {
        try {
            self.Loading().GetDashboardTotals(true);
            var data = {};
            Base.ServiceCall("/Dashboard/GetDashboardTotals", "get", data, true, function (response) {
                try {
                    if (!response.IsSuccess) { throw response.ErrorMessage };
                    self.DashboardTotals(new DashboardTotalsDataModel(response.DashboardTotals));
                } catch (ex) {
                    Base.Message("Error: " + ex, Base.MessageLevels.Error);
                    Base.Log(ex);
                }
            });
        } catch (ex) { Base.Log(ex); }
        finally { self.Loading().GetDashboardTotals(false); }
    };

    self.GetBusinessLocations = function () {
        var data = {};
        Base.ServiceCall("/Dashboard/GetBusinessLocations", "post", data, true, function (response) {
            try {
                if (!response.IsSuccess) { throw response.ErrorMessage };
                var markers = [];
                response.BusinessLocations.forEach(function (location) {
                    markers.push({ latLng: [location.Latitude, location.Longitude], name: location.Name });
                });
                self.LoadMap(markers);
            } catch (ex) {
                Base.Message("Error: " + ex, Base.MessageLevels.Error);
                Base.Log(ex);
            }
        });
    };

    self.LoadMap = function (markers) {
        $(function () {
            $('#map').vectorMap({
                map: 'us_aea_en',
                backgroundColor: 'transparent',
                regionStyle: {
                    initial: {
                        fill: '#3bafda'
                    }
                },
                markerStyle: {
                    initial: {
                        fill: '#f76397',
                        stroke: '#000000'
                    }
                },
                markers: markers,
                labels: {
                    regions: {
                        render: function (code) {
                            var doNotShow = ['US-RI', 'US-DC', 'US-DE', 'US-MD'];

                            if (doNotShow.indexOf(code) === -1) {
                                return code.split('-')[1];
                            }
                        },
                        offsets: function (code) {
                            return {
                                'CA': [-10, 10],
                                'ID': [0, 40],
                                'OK': [25, 0],
                                'LA': [-20, 0],
                                'FL': [45, 0],
                                'KY': [10, 5],
                                'VA': [15, 5],
                                'MI': [30, 30],
                                'AK': [50, -25],
                                'HI': [25, 50]
                            }[code.split('-')[1]];
                        }
                    }
                }
            });
        });
    }

    self.Load = function () {
        self.GetDashboardTotals();
        self.GetBusinessLocations();
        self.Loading().Page(false);
    };
}
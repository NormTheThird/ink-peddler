function TattooReviewLogViewModel(parent) {
    var self = this;
    self.Parent = parent;

    self.Loading = ko.observable({ Page: ko.observable(true) });
    self.IsLoading = ko.computed(function () {
        for (let i in self.Loading()) { if (self.Loading()[i]()) { return true; } }
        return false;
    });

    self.Load = function () {
        self.Loading().Page(false);
    };

    self.Load();
}
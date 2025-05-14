using InkPeddler.Mobile.PageModels.Base;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.PageModels
{
    public class MainPageModel : PageModelBase
    {
        public MainPageModel(HomePageModel homePageModel, MapPageModel mapPageModel, ProfilePageModel profilePageModel)
        {
            this.HomePageModel = homePageModel;
            this.MapPageModel = mapPageModel;
            this.ProfilePageModel = profilePageModel;
        }

        private HomePageModel _homePageModel;
        public HomePageModel HomePageModel
        {
            get => _homePageModel;
            set => SetProperty(ref _homePageModel, value);
        }

        private MapPageModel _mapPageModel;
        public MapPageModel MapPageModel
        {
            get => _mapPageModel;
            set => SetProperty(ref _mapPageModel, value);
        }

        private ProfilePageModel _profilePageModel;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePageModel;
            set => SetProperty(ref _profilePageModel, value);
        }

        public override Task InitializeAsync(object navigationData) => 
            Task.WhenAny(base.InitializeAsync(navigationData), HomePageModel.InitializeAsync(null), MapPageModel.InitializeAsync(null), ProfilePageModel.InitializeAsync(null));
    }
}
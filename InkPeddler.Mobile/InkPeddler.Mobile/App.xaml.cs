using InkPeddler.Mobile.Services;
using InkPeddler.Mobile.PageModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using InkPeddler.Mobile.PageModels.Base;
using InkPeddler.Mobile.Helpers;
using InkPeddler.Mobile.RequestAndResponses;

namespace InkPeddler.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private Task InitNavigation()
        {
            var navigationService = PageModelLocator.Resolve<INavigationService>();
            var securityService = PageModelLocator.Resolve<ISecurityService>();

            if (!string.IsNullOrEmpty(Settings.RefreshToken))
            {
                var refreshAuthenticationRequest = new RefreshAuthenticationRequest { RefreshToken = Settings.RefreshToken };
                var refreshAuthenticationResponse = securityService.RefreshAuthenticationAsync(refreshAuthenticationRequest).Result;
                if (refreshAuthenticationResponse.IsSuccess)
                {
                    Settings.AccessToken = refreshAuthenticationResponse.JwtToken;
                    Settings.RefreshToken = refreshAuthenticationResponse.RefreshToken;
                    return navigationService.NavigateToAsync<MainPageModel>(setRoot: true);
                }
            }

            return navigationService.NavigateToAsync<SecurityPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

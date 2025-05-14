using InkPeddler.Mobile.Helpers;
using InkPeddler.Mobile.PageModels.Base;
using InkPeddler.Mobile.Services;
using InkPeddler.Mobile.ViewModels.Buttons;
using System;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.PageModels
{
    public class ProfilePageModel : PageModelBase
    {
        private IAccountService _accountService;
        private INavigationService _navigationService;

        public ProfilePageModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService ?? throw new NullReferenceException(nameof(accountService));
            _navigationService = navigationService ?? throw new NullReferenceException(nameof(navigationService));

            this.SaveButton = new ButtonModel("Save", async () => await Save());
            this.SignOutButton = new ButtonModel("Sign Out", async () => await SignOut());
        }

        private ButtonModel _saveButton;
        public ButtonModel SaveButton
        {
            get => _saveButton;
            set => SetProperty(ref _saveButton, value);
        }

        private ButtonModel _signOutButton;
        public ButtonModel SignOutButton
        {
            get => _signOutButton;
            set => SetProperty(ref _signOutButton, value);
        }

        private async Task Save()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SignOut()
        {
            try
            {
                Settings.AccessToken = "";
                Settings.RefreshToken = "";
                await _navigationService.NavigateToAsync<SecurityPageModel>(setRoot: true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
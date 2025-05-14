using InkPeddler.Mobile.Helpers;
using InkPeddler.Mobile.PageModels.Base;
using InkPeddler.Mobile.RequestAndResponses;
using InkPeddler.Mobile.Services;
using InkPeddler.Mobile.ViewModels.Buttons;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InkPeddler.Mobile.PageModels
{
    public class SecurityPageModel : PageModelBase
    {
        private IAccountService _accountService;
        private INavigationService _navigationService;
        private ISecurityService _securityService;

        public SecurityPageModel(IAccountService accountService, INavigationService navigationService, ISecurityService securityService)
        {
            _accountService = accountService ?? throw new NullReferenceException(nameof(accountService));
            _navigationService = navigationService ?? throw new NullReferenceException(nameof(navigationService));
            _securityService = securityService ?? throw new NullReferenceException(nameof(securityService));

            this.LoginButton = new ButtonModel("Log In", async () => await Login());
            this.RegisterButton = new ButtonModel("Register", () => ShowQuestion());
            this.RegisterArtistButton = new ButtonModel("Yes", async () => await RegisterArtist());
            this.RegisterUserButton = new ButtonModel("No", async () => await RegisterUser());
            this.ResetPasswordButton = new ButtonModel("Reset Password", async () => await ResetPassword());

            this.Email = Settings.Email;

            ShowLogin();
        }

        #region Properties

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastMame;
        public string LastName
        {
            get => _lastMame;
            set => SetProperty(ref _lastMame, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _isShowLogin;
        public bool IsShowLogin
        {
            get => _isShowLogin;
            set => SetProperty(ref _isShowLogin, value);

        }

        private bool _isShowRegister;
        public bool IsShowRegister
        {
            get => _isShowRegister;
            set => SetProperty(ref _isShowRegister, value);
        }

        private bool _isShowQuestion;
        public bool IsShowQuestion
        {
            get => _isShowQuestion;
            set => SetProperty(ref _isShowQuestion, value);
        }

        private bool _isShowResetPassword;
        public bool IsShowResetPassword
        {
            get => _isShowResetPassword;
            set => SetProperty(ref _isShowResetPassword, value);
        }

        private bool _isShowResetEmailSent;
        public bool IsShowResetEmailSent
        {
            get => _isShowResetEmailSent;
            set => SetProperty(ref _isShowResetEmailSent, value);
        }

        private ButtonModel _loginButton;
        public ButtonModel LoginButton
        {
            get => _loginButton;
            set => SetProperty(ref _loginButton, value);
        }

        private ButtonModel _registerButton;
        public ButtonModel RegisterButton
        {
            get => _registerButton;
            set => SetProperty(ref _registerButton, value);
        }

        private ButtonModel _registerArtistButton;
        public ButtonModel RegisterArtistButton
        {
            get => _registerArtistButton;
            set => SetProperty(ref _registerArtistButton, value);
        }

        private ButtonModel _registerUserButton;
        public ButtonModel RegisterUserButton
        {
            get => _registerUserButton;
            set => SetProperty(ref _registerUserButton, value);
        }

        private ButtonModel _resetPasswordButton;
        public ButtonModel ResetPasswordButton
        {
            get => _resetPasswordButton;
            set => SetProperty(ref _resetPasswordButton, value);
        }

        #endregion

        public ICommand ShowLoginCommand => new Command(ShowLogin);
        private void ShowLogin()
        {
            CloseAllViews();
            IsShowLogin = true;
        }

        public ICommand ShowRegisterCommand => new Command(ShowRegister);
        private void ShowRegister()
        {
            CloseAllViews();
            IsShowRegister = true;
        }
        private void ShowQuestion()
        {
            CloseAllViews();
            IsShowQuestion = true;
        }

        public ICommand ShowResetPasswordCommand => new Command(ShowResetPassword);
        private void ShowResetPassword()
        {
            CloseAllViews();
            IsShowResetPassword = true;
        }
        private void ShowResetEmailSent()
        {
            CloseAllViews();
            IsShowResetEmailSent = true;
        }

        private async Task Login()
        {
            try
            {
                var authenticateRequest = new AuthenticateRequest { Email = this.Email, Password = this.Password };
                var authenticateResponse = await _securityService.AuthenticateAsync(authenticateRequest);
                if (!authenticateResponse.IsSuccess)
                {
                    // TODO: WHAT TO DO HERE?
                    new AuthenticationException("Unable to authenticate");
                }

                Settings.Email = this.Email;
                Settings.AccessToken = authenticateResponse.JwtToken;
                Settings.RefreshToken = authenticateResponse.RefreshToken;
                await _navigationService.NavigateToAsync<MainPageModel>(setRoot: true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task RegisterArtist() => await this.Register(true);
        private async Task RegisterUser() => await this.Register(false);
        private async Task Register(bool isArtist)
        {
            try
            {
                var createAccountRequest = new CreateAccountRequest { };
                var createAccountResponse = await _accountService.CreateAccountAsync(createAccountRequest);
                if (!createAccountResponse.IsSuccess)
                {
                    // TODO: WHAT TO DO HERE?
                    new AuthenticationException("Unable to create account");
                }

                await _navigationService.NavigateToAsync<MainPageModel>(setRoot: true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task ResetPassword()
        {
            try
            {
                // TODO: ADD RESET PASSWORD CODE
                ShowResetEmailSent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        private void CloseAllViews()
        {
            IsShowLogin = false;
            IsShowRegister = false;
            IsShowQuestion = false;
            IsShowResetPassword = false;
            IsShowResetEmailSent = false;
        }
    }
}
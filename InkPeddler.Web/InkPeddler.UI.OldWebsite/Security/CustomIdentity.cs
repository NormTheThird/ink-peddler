using System;
using System.Linq;
using System.Security.Principal;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Common.Enums;
using InkPeddler.UI.Website.Controllers;

namespace InkPeddler.UI.Website.Security
{
    public class CustomIdentity : IIdentity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return this.Username; } }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsArtist { get; set; }
        public string UserToken { get; set; }
        public string AuthenticationType { get; set; }

        public CustomIdentity(string _login, string _password)
        { 
            PopulateFromService(_login, _password);
        }

        public CustomIdentity(string userTokenEncrypted, bool decrypt = true)
        {
            UserToken = userTokenEncrypted;
            DecryptEncryptedTokenStrings();
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(this.Email); }
        }

        private void DecryptEncryptedTokenStrings()
        {
            var decryptedUserToken = Common.Helpers.Security.DecryptUserTokenToString(UserToken);
            DoPopulateUserToken(decryptedUserToken);
        }

        private void DoPopulateUserToken(string unEncryptedUserToken)
        {
            var userArray = unEncryptedUserToken.Split('|');
            foreach (var item in userArray)
            {
                var iArray = item.Split(':');
                if (!iArray.Any()) continue;
                if (iArray[0] == "Id") { this.Id = Guid.Parse(iArray[1]); continue; }
                if (iArray[0] == "FirstName") { this.FirstName = iArray[1]; continue; }
                if (iArray[0] == "LastName") { this.LastName = iArray[1]; continue; }
                if (iArray[0] == "Email") { this.Email = iArray[1]; continue; }
                if (iArray[0] == "Username") { this.Username = iArray[1]; continue; }
                if (iArray[0] == "IsArtist") { this.IsArtist = Convert.ToBoolean(iArray[1]); continue; }
            }
        }

        private void DoPopulateFilterToken(string unEncryptedFilterToken)
        {
            var filterTokenArray = unEncryptedFilterToken.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in filterTokenArray)
            {
                var iArray = item.Split(':');
                if (!iArray.Any()) continue;
            }
        }

        private void PopulateFromService(string _login, string _password)
        {
            var response = new GetSecurityModelResponse();
            if (response.IsSuccess)
            {
                this.Id = response.SecurityModel.Id;
                this.FirstName = response.SecurityModel.FirstName;
                this.LastName = response.SecurityModel.LastName;
                this.Email = response.SecurityModel.Email;
                this.Username = response.SecurityModel.Username;
                this.IsArtist = response.SecurityModel.IsArtist;
                this.UserToken = response.UserToken;
            }
        }

    }
}
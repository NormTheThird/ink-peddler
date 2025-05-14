using System;
using System.Security.Principal;

namespace InkPeddler.UI.Admin.SecurityModels
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return false;
        }

        public CustomPrincipal(CustomIdentity identity)
        {
            this.Identity = identity;
        }

        public bool IsSystemAdmin()
        {
            try
            {
                var customIdentity = (CustomIdentity)this.Identity;
                return customIdentity.SecurityModel.IsSystemAdmin;
            }
            catch (Exception) { return false; }
        }

        public bool IsBusinessOwner()
        {
            try
            {
                var isBusinessOwner = false;
                return isBusinessOwner;
            }
            catch (Exception) { return false; }
        }
    }
}
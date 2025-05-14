using System.Security.Principal;

namespace InkPeddler.UI.Website.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public CustomPrincipal(CustomIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
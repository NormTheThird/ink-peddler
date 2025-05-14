using InkPeddler.Mobile.RequestAndResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.Services
{
    public interface ISecurityService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
        Task<AuthenticateResponse> RefreshAuthenticationAsync(RefreshAuthenticationRequest request);
    }

    public class SecurityService : BaseService, ISecurityService
    {
        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            try
            {
                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", request.Email),
                    new KeyValuePair<string, string>("password", request.Password),
                };

                var retval = await HttpPost("security/token", keyValues);
                var jwt = JsonConvert.DeserializeObject<dynamic>(retval);
                return null; //new AuthenticateResponse { IsSuccess = true, JwtToken = jwt.Value<string>(""), RefreshToken = jwt.Value<string>("") };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<AuthenticateResponse> RefreshAuthenticationAsync(RefreshAuthenticationRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class SecurityServiceMock : BaseService, ISecurityService
    {
        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            return new AuthenticateResponse { IsSuccess = true, JwtToken = "NEW ACCESS TOKEN", RefreshToken = "NEW REFRESH TOKEN" };
        }

        public async Task<AuthenticateResponse> RefreshAuthenticationAsync(RefreshAuthenticationRequest request)
        {
            return new AuthenticateResponse { IsSuccess = true, JwtToken = "NEW ACCESS TOKEN", RefreshToken = "NEW REFRESH TOKEN" };
        }
    }
}
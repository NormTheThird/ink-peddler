using InkPeddler.Mobile.RequestAndResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.Services
{
    public interface IAccountService
    {
        Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request);
    }

    public class AccountService : BaseService, IAccountService
    {
        public async Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request)
        {
            try
            {
                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("FirstName", request.FirstName),
                    new KeyValuePair<string, string>("LastName", request.LastName),
                    new KeyValuePair<string, string>("Email", request.Email),
                    new KeyValuePair<string, string>("Password", request.Password)
                };

                var retval = await HttpPost("Security/Register", keyValues);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
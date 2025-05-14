using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data;
using System;
using System.Linq;

namespace InkPeddler.Services
{
    public interface IAccountService : IBaseService
    {
        GetAccountsResponse GetAccounts(GetAccountsRequest request);
        GetAccountResponse GetAccount(GetAccountRequest request);
        SaveAccountResponse SaveAccount(SaveAccountRequest request);
        SaveAccountProfileImageResponse SaveAccountProfileImage(SaveAccountProfileImageRequest request);
        ChangeAccountStatusResponse ChangeAccountStatus(ChangeAccountStatusRequest request);
        DeleteAccountResponse DeleteAccount(DeleteAccountRequest request);
        GetAccountsNotTiedToABusinessResponse GetAccountsNotTiedToABusiness(GetAccountsNotTiedToABusinessRequest request);
        GetAccountActivityResponse GetAccountActivity(GetAccountActivityRequest request);
    }

    public class AccountService : BaseService, IAccountService
    {
        public GetAccountsResponse GetAccounts(GetAccountsRequest request)
        {
            try
            {
                var response = new GetAccountsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var accounts = context.Accounts.AsNoTracking().Where(a => request.GetActiveAndInactive ? (a.IsActive || !a.IsActive) : a.IsActive)
                                                   .Select(a => new AccountModel
                                                   {
                                                       Id = a.Id,
                                                       AddressId = a.AddressId,
                                                       AWSProfileImageId = a.AWSProfileImageId,
                                                       Address = new AddressModel
                                                       {
                                                           Id = a.Address.Id,
                                                           Address1 = a.Address.Address1,
                                                           Address2 = a.Address.Address2,
                                                           City = a.Address.City,
                                                           State = a.Address.State,
                                                           ZipCode = a.Address.ZipCode,
                                                           Latitude = a.Address.Latitude,
                                                           Longitude = a.Address.Longitude,
                                                           DateCreated = a.DateCreated
                                                       },
                                                       FirstName = a.FirstName,
                                                       LastName = a.LastName,
                                                       Email = a.Email,
                                                       PhoneNumber = a.PhoneNumber,
                                                       AllowedOrigin = a.AllowedOrigin,
                                                       RefreshTokenLifeTimeMinutes = a.RefreshTokenLifeTimeMinutes,
                                                       IsArtist = a.IsArtist,
                                                       IsActive = a.IsActive,
                                                       DateOfBirth = a.DateOfBirth,
                                                       DateCreated = a.DateCreated
                                                   });
                    response.Accounts = accounts.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetAccountsResponse { ErrorMessage = "Unable to get accounta." };
            }
        }

        public GetAccountResponse GetAccount(GetAccountRequest request)
        {
            try
            {
                var response = new GetAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.AsNoTracking().FirstOrDefault(a => a.Id.Equals(request.AccountId));
                    if (account == null) throw new ApplicationException("Account does not exist for id " + request.AccountId);
                    response.Account = MapperService.Map<Account, AccountModel>(account);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetAccountResponse { ErrorMessage = "Unable to get account." };
            }
        }

        public SaveAccountResponse SaveAccount(SaveAccountRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Id.Equals(request.Account.Id));
                    if (account == null) return new SaveAccountResponse { ErrorMessage = "Unable to find account id " + request.Account.Id };

                    //var addressData = MapperService.Map<AddressModel, AddressData>(request.Account.Address);
                    //var apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
                    //var points = new GoogleLocationService(apiKey).GetLatLongFromAddress(addressData);
                    //request.Account.Address.Latitude = Math.Round(Convert.ToDecimal(points.Latitude), 6, MidpointRounding.ToEven);
                    //request.Account.Address.Longitude = Math.Round(Convert.ToDecimal(points.Longitude), 6, MidpointRounding.ToEven);

                    MapperService.Map(request.Account, account);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveAccountResponse { ErrorMessage = "Unable to save account." };
            }
        }

        public SaveAccountProfileImageResponse SaveAccountProfileImage(SaveAccountProfileImageRequest request)
        {
            try
            {
                var response = new SaveAccountProfileImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(b => b.Id.Equals(request.AccountId));
                    if (account == null) throw new ApplicationException($"Unable to find account id {request.AccountId}");
                    account.AWSProfileImageId = request.AWSProfileImageId;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveAccountProfileImageResponse() { ErrorMessage = "Unable to save account profile image." };
            }
        }

        public ChangeAccountStatusResponse ChangeAccountStatus(ChangeAccountStatusRequest request)
        {
            try
            {
                var response = new ChangeAccountStatusResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Id.Equals(request.AccountId));
                    if (account == null) throw new ApplicationException($"Account does not exist for id {request.AccountId}");
                    account.IsActive = !account.IsActive;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ChangeAccountStatusResponse { ErrorMessage = "Unable to get account." };
            }
        }

        public DeleteAccountResponse DeleteAccount(DeleteAccountRequest request)
        {
            try
            {
                var response = new DeleteAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var retval = context.DeleteAccount(request.AccountId);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new DeleteAccountResponse { ErrorMessage = "Unable to get account." };
            }
        }

        public GetAccountsNotTiedToABusinessResponse GetAccountsNotTiedToABusiness(GetAccountsNotTiedToABusinessRequest request)
        {
            try
            {
                var response = new GetAccountsNotTiedToABusinessResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var accounts = context.GetAccountsNotTiedToABusiness().Select(a => new AccountNotTiedToBusinessModel
                    {
                        AccountId = a.Id,
                        Name = a.Name,
                        Email = a.Email
                    });
                    response.Accounts = accounts.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetAccountsNotTiedToABusinessResponse { ErrorMessage = "Unable to get accounts not tied to a business." };
            }
        }

        public GetAccountActivityResponse GetAccountActivity(GetAccountActivityRequest request)
        {
            try
            {
                var response = new GetAccountActivityResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var activity = context.ActivityLogs.AsNoTracking()
                                          .Where(a => a.AccountId.Equals(request.AccountId))
                                          .Select(a => new AccountActivityModel
                                          {
                                              Id = a.Id,
                                              AccountId = a.AccountId,
                                              ActivityType = a.ActivityType,
                                              DateCreated = a.DateCreated
                                          });
                    response.AccountActivity = activity.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetAccountActivityResponse { ErrorMessage = "Unable to get account activity." };
            }
        }
    }
}
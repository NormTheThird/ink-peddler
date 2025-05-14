using System;
using System.Linq;
using System.Text.RegularExpressions;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Common.Helpers;
using InkPeddler.Common.Models;
using InkPeddler.Data;
using InkPeddler.Common.Enums;

namespace InkPeddler.Services
{
    public interface ISecurityService : IBaseService
    {
        GetEmailAvailabilityResponse GetEmailAvailability(GetEmailAvailabilityRequest request);
        RegisterAccountResponse RegisterAccount(RegisterAccountRequest request);
        ValidateAccountResponse ValidateAccount(ValidateAccountRequest request);
        PasswordResetResponse PasswordReset(PasswordResetRequest request);
        ValidatePasswordResetResponse ValidatePasswordReset(ValidatePasswordResetRequest request);
        GetSecurityModelResponse GetSecurityModel(GetSecurityModelRequest request);
        SaveNewPasswordResponse SaveNewPassword(SaveNewPasswordRequest request);

        GetRefreshTokenResponse GetRefreshToken(GetRefreshTokenRequest request);
        SaveRefreshTokenResponse SaveRefreshToken(SaveRefreshTokenRequest request);
        DeleteRefreshTokenResponse DeleteRefreshToken(DeleteRefreshTokenRequest request);
    }

    public class SecurityService : BaseService, ISecurityService
    {
        public GetEmailAvailabilityResponse GetEmailAvailability(GetEmailAvailabilityRequest request)
        {
            try
            {
                var response = new GetEmailAvailabilityResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.AsNoTracking().FirstOrDefault(a => a.Email.Equals(request.Email, StringComparison.CurrentCultureIgnoreCase));
                    if (account != null) throw new ApplicationException("Email is already taken " + request.Email);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetEmailAvailabilityResponse { ErrorMessage = "Email is un-available." };
            }
        }

        public RegisterAccountResponse RegisterAccount(RegisterAccountRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email)) return new RegisterAccountResponse { ErrorMessage = "The register account email is empty." };
                if (string.IsNullOrEmpty(request.Password)) return new RegisterAccountResponse { ErrorMessage = "The register account password is empty." };
                var isEmail = Regex.IsMatch(request.Email.Trim(),
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase);
                if(!isEmail)
                    return new RegisterAccountResponse { ErrorMessage = "The register account email is not a valid email." };

                var now = DateTimeConvert.GetTimeZoneDateTime(TimeZoneInfoId.CentralStandardTime);
                var response = new RegisterAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Email.Trim().Equals(request.Email.Trim(), StringComparison.CurrentCultureIgnoreCase));
                    if (account != null) return new RegisterAccountResponse { ErrorMessage = "This email already exists." };
                    account = new Account
                    {
                        Id = Guid.NewGuid(),
                        AWSProfileImageId = null,
                        Address = new Address
                        {
                            Id = Guid.NewGuid(),
                            Address1 = "",
                            Address2 = "",
                            City = "",
                            State = "",
                            ZipCode = "",
                            Latitude = 0.0m,
                            Longitude = 0.0m,
                            DateCreated = now
                        },
                        FirstName = "",
                        LastName = "",
                        Email = request.Email.ToLower(),
                        PhoneNumber = "",
                        WebsiteUrl = "",
                        FacebookUrl = "",
                        InstagramUrl = "",
                        TwitterUrl = "",
                        AllowedOrigin = "*",
                        RefreshTokenLifeTimeMinutes = 525600,
                        Password = Security.Hash(request.Password),
                        IsSystemAdmin = false,
                        IsActive = true,
                        IsArtist = request.IsArtist,
                        DateOfBirth = null,
                        DateCreated = now
                    };

                    context.Accounts.Add(account);
                    context.SaveChanges();
                    response.Account = MapperService.Map<Account, AccountModel>(account);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new RegisterAccountResponse { ErrorMessage = "Unable to register new user, please contact us at support@inkpeddler.com" };
            }
        }

        public ValidateAccountResponse ValidateAccount(ValidateAccountRequest request)
        {
            try
            {
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Email.Trim().Equals(request.Email.Trim(), StringComparison.CurrentCultureIgnoreCase));
                    if (account == null) return new ValidateAccountResponse { ErrorMessage = "Oops! Sorry that user cannot be found." };
                    if (!account.IsActive) return new ValidateAccountResponse { ErrorMessage = "Account is inactive, please contact support@inkpeddler.com for help." };
                    if (!Security.Validate(request.Password.Trim(), account.Password)) return new ValidateAccountResponse { ErrorMessage = "Invalid login for this account." };
                    var securityModel = new SecurityModel
                    {
                        Id = account.Id,
                        Email = account.Email,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        AllowedOrigin = account.AllowedOrigin,
                        RefreshTokenLifeTimeMinutes = account.RefreshTokenLifeTimeMinutes,
                        IsActive = account.IsActive,
                        IsSystemAdmin = account.IsSystemAdmin
                    };
                    return new ValidateAccountResponse { IsSuccess = true, SecurityModel = securityModel };
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ValidateAccountResponse { ErrorMessage = "Unable to validate user, please contact us at support@inkpeddler.com" };
            }
        }

        public PasswordResetResponse PasswordReset(PasswordResetRequest request)
        {
            try
            {
                var now = DateTimeConvert.GetTimeZoneDateTime(TimeZoneInfoId.CentralStandardTime);
                var response = new PasswordResetResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Email.Trim().Equals(request.Email.Trim(), StringComparison.InvariantCultureIgnoreCase));
                    if (account == null) return new PasswordResetResponse { ErrorMessage = "Oops!  Sorry that email cannot be found." };
                    if (!account.IsActive) return new PasswordResetResponse { ErrorMessage = "Account is inactive, please contact support@inkpeddler.com for help." };
                    var resets = account.PasswordResets.Where(r => r.IsActive);
                    foreach (var reset in resets)
                    {
                        reset.IsActive = false;
                    }

                    response.ResetId = Guid.NewGuid();
                    var newReset = new PasswordReset
                    {
                        Id = response.ResetId,
                        AccountId = account.Id,
                        IsActive = true,
                        DateCreated = now
                    };
                    context.PasswordResets.Add(newReset);
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new PasswordResetResponse { ErrorMessage = "Unable to reset password, please contact us at support@inkpeddler.com" };
            }
        }

        public ValidatePasswordResetResponse ValidatePasswordReset(ValidatePasswordResetRequest request)
        {
            try
            {
                var response = new ValidatePasswordResetResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var expired = DateTime.Now.AddMinutes(-15);
                    var reset = context.PasswordResets.FirstOrDefault(r => r.Id == request.ResetId && r.IsActive && r.DateCreated > expired);
                    if (reset == null) throw new ApplicationException("The time for this link has expired for id: " + request.ResetId);
                    reset.IsActive = false;
                    var account = context.Accounts.FirstOrDefault(a => a.Id == reset.AccountId);
                    if (account == null) throw new ApplicationException("Account does not exist for reset id");
                    account.Password = Security.Hash(request.NewPassword.Trim());
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ValidatePasswordResetResponse { ErrorMessage = "Unable to reset password. Please contact us at info@campbellsupply.net" };
            }
        }

        public GetSecurityModelResponse GetSecurityModel(GetSecurityModelRequest request)
        {
            try
            {
                var response = new GetSecurityModelResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.AsNoTracking().FirstOrDefault(a => a.Id == request.AccountId);
                    if (account == null) return new GetSecurityModelResponse { ErrorMessage = "Account does not exist" };
                    if (!account.IsActive) return new GetSecurityModelResponse { ErrorMessage = "Account does not exist" };

                    response.SecurityModel = new SecurityModel
                    {
                        Id = account.Id,
                        Email = account.Email,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        AllowedOrigin = account.AllowedOrigin,
                        RefreshTokenLifeTimeMinutes = account.RefreshTokenLifeTimeMinutes,
                        IsSystemAdmin = account.IsSystemAdmin,
                        IsActive = account.IsActive
                    };

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetSecurityModelResponse { ErrorMessage = "Unable to get account." };
            }
        }

        public SaveNewPasswordResponse SaveNewPassword(SaveNewPasswordRequest request)
        {
            try
            {
                var response = new SaveNewPasswordResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var account = context.Accounts.FirstOrDefault(a => a.Id.Equals(request.AccountId));
                    if (account == null) throw new ApplicationException("Account does not exist for id " + request.AccountId);
                    account.Password = Security.Hash(request.Password);
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveNewPasswordResponse { ErrorMessage = "Unable to save new password" };
            }
        }


        public GetRefreshTokenResponse GetRefreshToken(GetRefreshTokenRequest request)
        {
            try
            {
                var response = new GetRefreshTokenResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var refreshToken = context.AccountRefreshTokens.AsNoTracking().FirstOrDefault(t => t.RefreshToken.Equals(request.RefreshToken));
                    if(refreshToken != null)
                        response.RefreshToken = MapperService.Map<AccountRefreshToken, RefreshTokenModel>(refreshToken);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetRefreshTokenResponse { ErrorMessage = "Unable to get refresh token" };
            }
        }

        public SaveRefreshTokenResponse SaveRefreshToken(SaveRefreshTokenRequest request)
        {
            try
            {
                var response = new SaveRefreshTokenResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var refreshToken = context.AccountRefreshTokens.FirstOrDefault(a => a.AccountId.Equals(request.RefreshToken.AccountId));
                    if (refreshToken == null)
                    {
                        refreshToken = new AccountRefreshToken { Id = Guid.NewGuid(), AccountId = request.RefreshToken.AccountId };
                        context.AccountRefreshTokens.Add(refreshToken);
                    }

                    refreshToken.RefreshToken = request.RefreshToken.RefreshToken;
                    refreshToken.ProtectedTicket = request.RefreshToken.ProtectedTicket;
                    refreshToken.DateIssued = request.RefreshToken.DateIssued;
                    refreshToken.DateExpired = request.RefreshToken.DateExpired;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveRefreshTokenResponse { ErrorMessage = "Unable to save refresh token" };
            }
        }

        public DeleteRefreshTokenResponse DeleteRefreshToken(DeleteRefreshTokenRequest request)
        {
            try
            {
                var response = new DeleteRefreshTokenResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var refreshToken = context.AccountRefreshTokens.FirstOrDefault(a => a.Id.Equals(request.RefreshTokenId));
                    if(refreshToken.Id != null)
                    {
                        context.AccountRefreshTokens.Remove(refreshToken);
                        context.SaveChanges();
                    }

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new DeleteRefreshTokenResponse { ErrorMessage = "Unable to delete refresh token" };
            }
        }
    }
}
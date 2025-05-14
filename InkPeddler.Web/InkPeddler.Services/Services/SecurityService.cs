using InkPeddler.Common.Configurations;
using InkPeddler.Common.Interfaces;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data.Context;
using InkPeddler.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InkPeddler.Services.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly JwtConfig _jwtConfig;
        private readonly InkPeddlerDbContext _context;

        public SecurityService(IOptionsMonitor<JwtConfig> optionsMonitor, InkPeddlerDbContext context)
        {
            _jwtConfig = optionsMonitor.CurrentValue ?? throw new ArgumentNullException(nameof(optionsMonitor));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<RegisterUserResponse> RegisterUserWithDeviceTokenAsync(RegisterUserWithDeviceTokenRequest request)
        {
            try
            {
                var response = new RegisterUserResponse();
                if (request.DeviceToken != "p0sVwHxb-nXXF$Mkk_e)1qJPW3dMY7PnD4v8xYOTJLdW7nV9Y13_14dmO_.R*m8L")
                    throw new ApplicationException("Not Authorized");

                var user = CreateDefaultUser();
                user.UserRole = new UserRole { UserId = user.Id };
                _context.Users.Add(user);

                // Generate new token
                var token = GenerateJwtToken(user.Id, "", new List<string> { "User" });
                var refreshToken = GenerateRefreshToken();
                var userRefreshToken = new UserRefreshToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    // TODO: TREY: 4/28/2021 Hash the refresh token before it is stored
                    RefreshToken = refreshToken,
                    TokenType = "Mobile",
                    // TODO: TREY: 4/28/2021 I dont think i need this anymore
                    ProtectedTicket = "",
                    // TODO: TREY: 4/28/2021 When should refresh tokens expire. 1 Month, 3 Months, 6 Months?
                    //             All this means is if the user has not accessed the app in this amount of time they need to re-enter their password.
                    //             Store life time minutes in application settings
                    DateExpired = GetUtcNowInCST().AddMinutes(131400),
                    DateIssued = GetUtcNowInCST()
                };
                _context.UserRefreshTokens.Add(userRefreshToken);
                await _context.SaveChangesAsync();

                response.UserId = user.Id;
                response.Success = true;
                response.JwtToken = token;
                response.RefreshToken = refreshToken;
                return response;
            }
            catch (Exception ex)
            {
                // TODO: TREY: Add Logging
                return new RegisterUserResponse { ErrorMessage = ex.Message };
            }
        }

        public async Task<RegisterUserResponse> RegisterUserWithEmailAsync(RegisterUserWithEmailRequest request)
        {
            try
            {
                var response = new RegisterUserResponse();
                var user = _context.Users.Include(_ => _.UserRefreshTokens).FirstOrDefault(_ => _.Id.Equals(request.UserId));
                if (user == null)
                {
                    user = CreateDefaultUser();
                    user.UserRole = new UserRole { UserId = user.Id };
                    _context.Users.Add(user);
                }

                // validate email
                var emailTaken = _context.Users.Any(_ => _.Email.Equals(request.Email) && !_.Id.Equals(request.UserId));
                if (emailTaken)
                    return new RegisterUserResponse { ErrorMessage = "Unable to use this email" };
                user.Email = request.Email;

                // Generate salt and password hash
                var salt = GenerateSalt();
                user.Salt = salt;
                user.Password = GenerateSHA256Hash(request.Password, salt);

                // Generate new token
                var token = GenerateJwtToken(user.Id, "", new List<string> { "User" });
                var refreshToken = GenerateRefreshToken();

                _context.UserRefreshTokens.RemoveRange(user.UserRefreshTokens);
                var userRefreshToken = new UserRefreshToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    // TODO: TREY: 4/28/2021 Hash the refresh token before it is stored
                    RefreshToken = refreshToken,
                    // TODO: TREY: 4/28/2021 Figure out token type
                    TokenType = "Mobile",
                    // TODO: TREY: 4/28/2021 I dont think i need this anymore
                    ProtectedTicket = "",
                    // TODO: TREY: 4/28/2021 When should refresh tokens expire. 1 Month, 3 Months, 6 Months?
                    //             All this means is if the user has not accessed the app in this amount of time they need to re-enter their password.
                    //             Store life time minutes in application settings
                    DateExpired = GetUtcNowInCST().AddMinutes(131400),
                    DateIssued = GetUtcNowInCST()
                };
                _context.UserRefreshTokens.Add(userRefreshToken);
                await _context.SaveChangesAsync();

                response.UserId = user.Id;
                response.Success = true;
                response.JwtToken = token;
                response.RefreshToken = refreshToken;
                return response;
            }
            catch (Exception ex)
            {
                // TODO: TREY: Add Logging
                return new RegisterUserResponse { ErrorMessage = ex.Message };
            }
        }

        public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request)
        {
            try
            {
                //var user = _context.fi
                //if (user == null || !user.IsActive)
                //    return new AuthenticateUserResponse { ErrorMessage = "Unable to authenticate user." };

                //// TODO: TREY: 4/12/2020 Can we add a foriegn key for app user id in user password?
                //var userPassword = _ptpDbContext.UserPasswords.FirstOrDefault(_ => _.AppUserId.Equals(user.Id));
                //if (userPassword == null)
                //    return new AuthenticateUserResponse { ErrorMessage = "Unable to authenticate user." };

                //var hash = GenerateSHA256Hash(request.Password, userPassword.Salt);
                //if (!CompareHash(hash, userPassword.HashedPassword))
                //    return new AuthenticateUserResponse { ErrorMessage = "Unable to authenticate user." };

                //// Delete old account refresh tokens generate new token
                //var token = GenerateJwtToken(user.Id, user.EmailAddress);
                //var refreshToken = GenerateRefreshToken();
                //var userRefreshTokens = _ptpDbContext.UserRefreshTokens.Where(_ => _.AppUserId.Equals(user.Id));
                //_ptpDbContext.UserRefreshTokens.RemoveRange(userRefreshTokens);
                //var userRefreshToken = new UserRefreshToken
                //{
                //    Id = Guid.NewGuid(),
                //    AppUserId = user.Id,
                //    // TODO: TREY: 4/10/2021 Hash the refresh token before it is stored
                //    RefreshToken = refreshToken,
                //    // TODO: TREY: Ask about when should refresh tokens expire. 1 Month, 3 Months, 6 Months?
                //    //             All this means is if the user has not accessed the app in this amount of time they need to re-enter their password.
                //    DateExpired = DateTime.UtcNow.AddMinutes(user.RefreshTokenLifeTimeMinutes ?? 131400),
                //    DateIssued = DateTime.UtcNow
                //};
                //_ptpDbContext.UserRefreshTokens.Add(userRefreshToken);
                //_ptpDbContext.SaveChanges();
                //return new AuthenticateUserResponse { Success = true, JwtToken = token, RefreshToken = refreshToken };
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                // TODO: TREY: Add Logging
                return new AuthenticateUserResponse { ErrorMessage = ex.Message };
            }
        }

        public async Task<RefreshUserAuthenticationResponse> RefreshUserAuthenticationAsync(RefreshUserAuthenticationRequest request)
        {
            try
            {
                var response = new RefreshUserAuthenticationResponse();
                var userRefreshToken = _context.UserRefreshTokens.Include(_ => _.User).FirstOrDefault(_ => _.RefreshToken.Equals(request.RefreshToken));
                if (userRefreshToken == null || userRefreshToken.DateExpired < DateTime.Now)
                    return new RefreshUserAuthenticationResponse { ErrorMessage = "Unable to authenticate user." };

                // Get user roles
                var roles = new List<string> { "User" };
                var userRoles = _context.UserRoles.AsNoTracking().FirstOrDefault(_ => _.UserId.Equals(userRefreshToken.UserId));
                if (userRoles.IsAdmin) roles.Add("Admin");
                if (userRoles.IsArtist) roles.Add("Artist");

                // Generate new tokens
                var token = GenerateJwtToken(userRefreshToken.User.Id, userRefreshToken.User.Email, roles);
                var refreshToken = GenerateRefreshToken();

                // Update old account refresh token
                // TODO: TREY: 4/28/2021 Hash the refresh token before it is stored
                userRefreshToken.RefreshToken = refreshToken;

                // TODO: TREY: 4/28/2021 When should refresh tokens expire. 1 Month, 3 Months, 6 Months?
                //             All this means is if the user has not accessed the app in this amount of time they need to re-enter their password.
                //             Store life time minutes in application settings
                userRefreshToken.DateExpired = GetUtcNowInCST().AddMinutes(131400);
                userRefreshToken.DateIssued = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                response.Success = true;
                response.JwtToken = token;
                response.RefreshToken = refreshToken;
                return response;
            }
            catch (Exception ex)
            {
                // TODO: TREY: Add Logging
                return new RefreshUserAuthenticationResponse { ErrorMessage = ex.Message };
            }
        }



        private string GenerateJwtToken(Guid Id, string Email, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var claims = new List<Claim>
            {
                   new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Id.ToString())
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        private static string GenerateSalt()
        {
            var randomNumberGenerator = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            randomNumberGenerator.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        private static byte[] GenerateSHA256Hash(string input, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var sha256HastString = new SHA256Managed();
            return sha256HastString.ComputeHash(bytes);
        }

        private static bool CompareHash(byte[] a, byte[] b)
        {
            try
            {
                uint diff = (uint)a.Length ^ (uint)b.Length;
                for (int i = 0; i < a.Length && i < b.Length; i++)
                    diff |= (uint)(a[i] ^ b[i]);
                return diff == 0;
            }
            catch (Exception) { return false; }
        }

        private static User CreateDefaultUser() => new User
        {
            Id = Guid.NewGuid(),
            FirstName = "",
            LastName = "",
            Email = "",
            PhoneNumber = "",
            Password = null,
            Salt = "",
            IsActive = true,
            IsDeleted = false,
            DateOfBirth = null,
            DateCreated = GetUtcNowInCST()
        };

        private static DateTime GetUtcNowInCST()
        {
            var cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var now = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeToUtc(now, cst);
        }
    }
}
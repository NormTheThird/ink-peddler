using System;
using System.ComponentModel.DataAnnotations;

namespace InkPeddler.Common.RequestAndResponses
{
    public class RegisterUserWithDeviceTokenRequest
    {
        [Required] public string DeviceToken { get; set; } = string.Empty;
    }
    public class RegisterUserWithEmailRequest
    {
        public Guid UserId { get; set; } = Guid.Empty;
        [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }
    public class RegisterUserResponse : BaseResponse
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class AuthenticateUserRequest
    {
        [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }
    public class AuthenticateUserResponse : BaseResponse
    {
        public string JwtToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshUserAuthenticationRequest
    {
        [Required] public string RefreshToken { get; set; } = string.Empty;
    }
    public class RefreshUserAuthenticationResponse : BaseResponse
    {
        public string JwtToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
namespace InkPeddler.Mobile.RequestAndResponses
{
    public class AuthenticateRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RefreshAuthenticationRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class AuthenticateResponse : BaseResponse
    {
        public string JwtToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
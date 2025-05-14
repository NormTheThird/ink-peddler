namespace InkPeddler.Mobile.RequestAndResponses
{
    public class CreateAccountRequest : BaseRequest
    {
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class CreateAccountResponse : BaseResponse
    {

    }
}
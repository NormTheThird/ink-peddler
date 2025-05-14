namespace InkPeddler.Mobile.RequestAndResponses
{
    public class BaseRequest { }

    public class BaseActiveRequest : BaseRequest
    {
        public bool GetActiveAndInactive { get; set; } = false;
    }

    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
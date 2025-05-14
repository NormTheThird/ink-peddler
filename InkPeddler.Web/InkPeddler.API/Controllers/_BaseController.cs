using Microsoft.AspNetCore.Mvc;

namespace InkPeddler.API.Controllers
{
    public class BaseController : ControllerBase
    {
    }

    //public class BaseApiController : ApiController
    //{
    //    public IAccountService AccountService { get; set; } = new AccountService();
    //    public IBusinessService BusinessService { get; set; } = new BusinessService();
    //    public ILoggingService LoggingService { get; set; } = new LoggingService();
    //    public IMessagingService MessagingService { get; set; } = new MessagingService();
    //    public ISecurityService SecurityService { get; set; } = new SecurityService();
    //    public IStyleService StyleService { get; set; } = new StyleService();
    //    public ITattooService TattooService { get; set; } = new TattooService();

    //    internal bool LogActivity(Guid accountId, ActivityType activityType)
    //    {
    //        var logActivityRequest = new LogActivityRequest { AccountId = accountId, ActivityType = activityType };
    //        var logActivityResponse = this.LoggingService.LogActivity(logActivityRequest);
    //        return logActivityResponse.IsSuccess;
    //    }

    //    internal string GetAccountRegistrationEmailHtmlString(bool isArtist, string email)
    //    {
    //        try
    //        {
    //            string url = $"https://admin.inkpeddler.com/EmailTemplate/GetRegisterAccountTemplate?isArtist=" + isArtist + "&email=" + email;
    //            using (var client = new HttpClient())
    //            using (var response = client.GetAsync(url).Result)
    //            using (var content = response.Content)
    //                return content.ReadAsStringAsync().Result;
    //        }
    //        catch (System.Exception)
    //        {
    //            return string.Empty;
    //        }
    //    }

    //}
}
using System;
using System.Collections.Generic;
using SendGrid;
using InkPeddler.Common.RequestAndResponses;
using System.Configuration;
using SendGrid.Helpers.Mail;

namespace InkPeddler.Services
{
    public interface IMessagingService : IBaseService
    {
        //SendEmailResponse SendEmail(SendEmailRequest request);
        SendEmailResponse SendResetEmail(SendResetEmailRequest request);
        SendEmailResponse SendContactUsEmail(SendPlainTextEmailRequest request);
        SendEmailResponse SendAccountRegistrationEmail(SendHtmlEmailRequest request);
    }

    public class MessagingService : BaseService, IMessagingService
    {
        //    public SendEmailResponse SendEmail(SendEmailRequest request)
        //    {
        //        try
        //        {
        //            var response = new SendEmailResponse();
        //            ////TODO: TREY: 02/02/2019 Change to new api
        //            //var sendGridMessage = new SendGridMessage();
        //            //sendGridMessage.From = new MailAddress(request.From);
        //            //sendGridMessage.AddTo(request.Recipients);
        //            //sendGridMessage.Subject = request.Subject;
        //            //sendGridMessage.Text = request.Body;

        //            //var transportWeb = new Web(GetCredentials());
        //            //transportWeb.Deliver(sendGridMessage);
        //            response.IsSuccess = true;
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            LoggingService.LogError(new LogErrorRequest { ex = ex });
        //            return new SendEmailResponse { ErrorMessage = ex.Message };
        //        }
        //    }

        public SendEmailResponse SendResetEmail(SendResetEmailRequest request)
        {
            try
            {
                var response = new SendEmailResponse();
                ////TODO: TREY: 02/02/2019 Change to new api
                //var sendGridMessage = new SendGridMessage();
                //sendGridMessage.From = new MailAddress("no-reply@inkpeddler.com");
                //sendGridMessage.AddTo(request.Recipient);
                //sendGridMessage.Subject = "Password reset link";
                //sendGridMessage.Text = request.Url;

                //var transportWeb = new Web(GetCredentials());
                //transportWeb.Deliver(sendGridMessage);
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SendEmailResponse { ErrorMessage = ex.Message };
            }
        }

        public SendEmailResponse SendContactUsEmail(SendPlainTextEmailRequest request)
        {
            try
            {
                var response = new SendEmailResponse();
                var client = GetClient();
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(request.RecipientEmail, request.RecipientName),
                    Subject = $"Website email from {request.RecipientName}",
                    PlainTextContent = request.PlainText
                };
                msg.AddTo(new EmailAddress("info@InkPeddler.com", "Ink Peddler Support"));
                var sendEmailResponse = client.SendEmailAsync(msg).Result;
                if (sendEmailResponse.StatusCode != System.Net.HttpStatusCode.Accepted)
                    throw new ApplicationException(sendEmailResponse.StatusCode.ToString());
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SendEmailResponse { ErrorMessage = ex.Message };
            }
        }

        public SendEmailResponse SendAccountRegistrationEmail(SendHtmlEmailRequest request)
        {
            try
            {
                var response = new SendEmailResponse();
                var client = GetClient();
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("no-reply@inkpeddler.com", "Ink Peddler"),
                    Subject = "Thank you for registering with Ink Peddler",
                    HtmlContent = request.Html
                };
                msg.AddTo(new EmailAddress(request.RecipientEmail, request.RecipientName));
                var sendEmailResponse = client.SendEmailAsync(msg).Result;
                if (sendEmailResponse.StatusCode != System.Net.HttpStatusCode.Accepted)
                    throw new ApplicationException(sendEmailResponse.StatusCode.ToString());
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SendEmailResponse { ErrorMessage = ex.Message };
            }
        }

        private static SendGridClient GetClient()
        {
            var apiKey = ConfigurationManager.AppSettings["SendGrid_ApiKey_MailSend"];
            return new SendGridClient(apiKey);
        }
    }
}
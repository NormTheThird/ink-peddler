using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkPeddler.Common.RequestAndResponses
{
    public class BaseSendEmailRequest
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class SendVerifyCodeEmailRequest : BaseSendEmailRequest
    {
        public string VerifyCode { get; set; } = string.Empty;
    }

    public class SendVerifyCodeEmailResponse : BaseResponse { }

    public class SendResetPasswordEmailRequest : BaseSendEmailRequest { }

    public class SendResetPasswordEmailResponse : BaseResponse { }
}

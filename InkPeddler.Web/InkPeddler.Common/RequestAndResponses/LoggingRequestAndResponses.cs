using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InkPeddler.Common.Enums;
using InkPeddler.Common.Models;

namespace InkPeddler.Common.RequestAndResponses
{
    public class LogErrorRequest : BaseRequest
    {
        public LogErrorRequest()
        {
            this.ex = null;
        }

        [DataMember(IsRequired = true)]
        public Exception ex { get; set; }
    }

    public class LogErrorResponse : BaseResponse { }

    public class GetErrorsRequest : BaseRequest { }

    public class GetErrorsResponse : BaseResponse
    {
        public GetErrorsResponse()
        {
            this.Errors = new List<ErrorLogModel>();
        }

        [DataMember(IsRequired = true)]
        public List<ErrorLogModel> Errors { get; set; }
    }

    public class DeleteErrorRequest : BaseRequest
    {
        public DeleteErrorRequest()
        {
            this.ErrorId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid ErrorId { get; set; }
    }

    public class DeleteErrorResponse : BaseResponse { }

    public class LogActivityRequest : BaseRequest
    {
        public LogActivityRequest()
        {
            this.AccountId = Guid.Empty;
            this.ActivityType = ActivityType.Unknown;
        }

        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public ActivityType ActivityType { get; set; }
    }

    public class LogActivityResponse : BaseResponse { }
}
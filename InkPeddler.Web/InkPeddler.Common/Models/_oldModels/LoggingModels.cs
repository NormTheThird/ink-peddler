using InkPeddler.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class ErrorLogModel : BaseModel
    {
        public ErrorLogModel()
        {

            this.HResult = 0;
            this.Source = string.Empty;
            this.ExceptionType = string.Empty;
            this.ExceptionMessage = string.Empty;
            this.InnerExceptionMessage = string.Empty;
            this.StackTrace = string.Empty;
            this.Parameters = string.Empty;
            this.IsReviewed = false;
            this.ReviewedBy = string.Empty;
            this.ReviewedComments = string.Empty;
            this.DateReviewed = null;
        }

        [DataMember(IsRequired = true)]
        public int HResult { get; set; }
        [DataMember(IsRequired = true)]
        public string Source { get; set; }
        [DataMember(IsRequired = true)]
        public string ExceptionType { get; set; }
        [DataMember(IsRequired = true)]
        public string ExceptionMessage { get; set; }
        [DataMember(IsRequired = true)]
        public string InnerExceptionMessage { get; set; }
        [DataMember(IsRequired = true)]
        public string StackTrace { get; set; }
        [DataMember(IsRequired = true)]
        public string Parameters { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsReviewed { get; set; }
        [DataMember(IsRequired = true)]
        public string ReviewedBy { get; set; }
        [DataMember(IsRequired = true)]
        public string ReviewedComments { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset? DateReviewed { get; set; }
    }

    [DataContract]
    public class ActivityLogModel : BaseModel
    {
        public ActivityLogModel()
        {
            this.AccountId = Guid.Empty;
            this.ActivityType = ActivityType.Unknown;
        }

        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public ActivityType ActivityType { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class ErrorLog
    {
        public Guid Id { get; set; }
        public int Hresult { get; set; }
        public string Source { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string Parameters { get; set; }
        public bool IsReviewed { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedComments { get; set; }
        public DateTimeOffset? DateReviwed { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

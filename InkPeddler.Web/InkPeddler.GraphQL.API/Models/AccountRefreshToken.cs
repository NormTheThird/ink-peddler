using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class AccountRefreshToken
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string RefreshToken { get; set; }
        public string ProtectedTicket { get; set; }
        public DateTimeOffset DateIssued { get; set; }
        public DateTimeOffset DateExpired { get; set; }

        public Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class PasswordReset
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class BusinessAccountCrossLink
    {
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public Guid AccountId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsManager { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Account Account { get; set; }
        public Business Business { get; set; }
    }
}

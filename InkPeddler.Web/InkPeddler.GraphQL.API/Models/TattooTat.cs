using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class TattooTat
    {
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid AccountId { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Account Account { get; set; }
        public Tattoo Tattoo { get; set; }
    }
}

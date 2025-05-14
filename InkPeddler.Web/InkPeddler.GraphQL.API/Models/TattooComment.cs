using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class TattooComment
    {
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid AccountId { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Account Account { get; set; }
        public Tattoo Tattoo { get; set; }
    }
}

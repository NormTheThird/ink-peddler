using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class TattooStyleCrossLink
    {
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid StyleId { get; set; }

        public Style Style { get; set; }
        public Tattoo Tattoo { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class Style
    {
        public Style()
        {
            TattooStyleCrossLink = new HashSet<TattooStyleCrossLink>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public ICollection<TattooStyleCrossLink> TattooStyleCrossLink { get; set; }
    }
}

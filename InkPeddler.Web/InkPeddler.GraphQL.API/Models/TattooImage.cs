using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class TattooImage
    {
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid AwsimageId { get; set; }
        public bool IsMainImage { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Tattoo Tattoo { get; set; }
    }
}

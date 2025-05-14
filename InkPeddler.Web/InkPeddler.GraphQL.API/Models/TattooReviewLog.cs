using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class TattooReviewLog
    {
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid FlaggedByAccountId { get; set; }
        public int TattooReviewLogTypeId { get; set; }
        public bool IsReviewed { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedComment { get; set; }
        public DateTimeOffset? DateReviewed { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Account FlaggedByAccount { get; set; }
        public Tattoo Tattoo { get; set; }
    }
}

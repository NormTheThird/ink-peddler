using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class Tattoo
    {
        public Tattoo()
        {
            TattooComment = new HashSet<TattooComment>();
            TattooImage = new HashSet<TattooImage>();
            TattooReviewLog = new HashSet<TattooReviewLog>();
            TattooStyleCrossLink = new HashSet<TattooStyleCrossLink>();
            TattooTat = new HashSet<TattooTat>();
            TattooView = new HashSet<TattooView>();
        }

        public Guid Id { get; set; }
        public Guid UploadedByAccountId { get; set; }
        public Guid? CanvasAccountId { get; set; }
        public Guid? ArtistAccountId { get; set; }
        public Guid? BusinessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Account ArtistAccount { get; set; }
        public Business Business { get; set; }
        public Account CanvasAccount { get; set; }
        public Account UploadedByAccount { get; set; }
        public ICollection<TattooComment> TattooComment { get; set; }
        public ICollection<TattooImage> TattooImage { get; set; }
        public ICollection<TattooReviewLog> TattooReviewLog { get; set; }
        public ICollection<TattooStyleCrossLink> TattooStyleCrossLink { get; set; }
        public ICollection<TattooTat> TattooTat { get; set; }
        public ICollection<TattooView> TattooView { get; set; }
    }
}

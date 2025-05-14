using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Tattoo")]
    public partial class Tattoo
    {
        public Tattoo()
        {
            TattooComments = new HashSet<TattooComment>();
            TattooImages = new HashSet<TattooImage>();
            TattooReviewLogs = new HashSet<TattooReviewLog>();
            TattooStyleCrossLinks = new HashSet<TattooStyleCrossLink>();
            TattooTats = new HashSet<TattooTat>();
            TattooViews = new HashSet<TattooView>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid UploadedByAccountId { get; set; }
        public Guid? CanvasAccountId { get; set; }
        public Guid? ArtistAccountId { get; set; }
        public Guid? BusinessId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(ArtistAccountId))]
        [InverseProperty(nameof(Account.TattooArtistAccounts))]
        public virtual Account ArtistAccount { get; set; }
        [ForeignKey(nameof(BusinessId))]
        [InverseProperty("Tattoos")]
        public virtual Business Business { get; set; }
        [ForeignKey(nameof(CanvasAccountId))]
        [InverseProperty(nameof(Account.TattooCanvasAccounts))]
        public virtual Account CanvasAccount { get; set; }
        [ForeignKey(nameof(UploadedByAccountId))]
        [InverseProperty(nameof(Account.TattooUploadedByAccounts))]
        public virtual Account UploadedByAccount { get; set; }
        [InverseProperty(nameof(TattooComment.Tattoo))]
        public virtual ICollection<TattooComment> TattooComments { get; set; }
        [InverseProperty(nameof(TattooImage.Tattoo))]
        public virtual ICollection<TattooImage> TattooImages { get; set; }
        [InverseProperty(nameof(TattooReviewLog.Tattoo))]
        public virtual ICollection<TattooReviewLog> TattooReviewLogs { get; set; }
        [InverseProperty(nameof(TattooStyleCrossLink.Tattoo))]
        public virtual ICollection<TattooStyleCrossLink> TattooStyleCrossLinks { get; set; }
        [InverseProperty(nameof(TattooTat.Tattoo))]
        public virtual ICollection<TattooTat> TattooTats { get; set; }
        [InverseProperty(nameof(TattooView.Tattoo))]
        public virtual ICollection<TattooView> TattooViews { get; set; }
    }
}

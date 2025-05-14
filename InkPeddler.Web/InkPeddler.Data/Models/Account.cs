using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            BusinessAccountCrossLinks = new HashSet<BusinessAccountCrossLink>();
            Invoices = new HashSet<Invoice>();
            TattooArtistAccounts = new HashSet<Tattoo>();
            TattooCanvasAccounts = new HashSet<Tattoo>();
            TattooComments = new HashSet<TattooComment>();
            TattooReviewLogs = new HashSet<TattooReviewLog>();
            TattooTats = new HashSet<TattooTat>();
            TattooUploadedByAccounts = new HashSet<Tattoo>();
            TattooViews = new HashSet<TattooView>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string AllowedOrigin { get; set; }
        [MaxLength(64)]
        public byte[] Password { get; set; }
        public int RefreshTokenLifeTimeMinutes { get; set; }
        public bool IsActive { get; set; }
        public bool IsArtist { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [InverseProperty(nameof(ActivityLog.Account))]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        [InverseProperty(nameof(BusinessAccountCrossLink.Account))]
        public virtual ICollection<BusinessAccountCrossLink> BusinessAccountCrossLinks { get; set; }
        [InverseProperty(nameof(Invoice.InvoicedAccount))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(Tattoo.ArtistAccount))]
        public virtual ICollection<Tattoo> TattooArtistAccounts { get; set; }
        [InverseProperty(nameof(Tattoo.CanvasAccount))]
        public virtual ICollection<Tattoo> TattooCanvasAccounts { get; set; }
        [InverseProperty(nameof(TattooComment.Account))]
        public virtual ICollection<TattooComment> TattooComments { get; set; }
        [InverseProperty(nameof(TattooReviewLog.FlaggedByAccount))]
        public virtual ICollection<TattooReviewLog> TattooReviewLogs { get; set; }
        [InverseProperty(nameof(TattooTat.Account))]
        public virtual ICollection<TattooTat> TattooTats { get; set; }
        [InverseProperty(nameof(Tattoo.UploadedByAccount))]
        public virtual ICollection<Tattoo> TattooUploadedByAccounts { get; set; }
        [InverseProperty(nameof(TattooView.Account))]
        public virtual ICollection<TattooView> TattooViews { get; set; }
    }
}

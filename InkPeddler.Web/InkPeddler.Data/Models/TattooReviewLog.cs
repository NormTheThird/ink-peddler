using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("TattooReviewLog")]
    public partial class TattooReviewLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid FlaggedByAccountId { get; set; }
        public int TattooReviewLogTypeId { get; set; }
        public bool IsReviewed { get; set; }
        [Required]
        [StringLength(50)]
        public string ReviewedBy { get; set; }
        [Required]
        [StringLength(255)]
        public string ReviewedComment { get; set; }
        public DateTimeOffset? DateReviewed { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(FlaggedByAccountId))]
        [InverseProperty(nameof(Account.TattooReviewLogs))]
        public virtual Account FlaggedByAccount { get; set; }
        [ForeignKey(nameof(TattooId))]
        [InverseProperty("TattooReviewLogs")]
        public virtual Tattoo Tattoo { get; set; }
    }
}

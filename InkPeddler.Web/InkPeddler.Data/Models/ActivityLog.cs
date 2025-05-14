using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("ActivityLog")]
    public partial class ActivityLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        [Required]
        [StringLength(50)]
        public string ActivityType { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("ActivityLogs")]
        public virtual Account Account { get; set; }
    }
}

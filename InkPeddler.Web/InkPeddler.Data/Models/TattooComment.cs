using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("TattooComment")]
    public partial class TattooComment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid AccountId { get; set; }
        [Required]
        [StringLength(255)]
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("TattooComments")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(TattooId))]
        [InverseProperty("TattooComments")]
        public virtual Tattoo Tattoo { get; set; }
    }
}

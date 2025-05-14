using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Style")]
    public partial class Style
    {
        public Style()
        {
            TattooStyleCrossLinks = new HashSet<TattooStyleCrossLink>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [InverseProperty(nameof(TattooStyleCrossLink.Style))]
        public virtual ICollection<TattooStyleCrossLink> TattooStyleCrossLinks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("TattooStyleCrossLink")]
    public partial class TattooStyleCrossLink
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid StyleId { get; set; }

        [ForeignKey(nameof(StyleId))]
        [InverseProperty("TattooStyleCrossLinks")]
        public virtual Style Style { get; set; }
        [ForeignKey(nameof(TattooId))]
        [InverseProperty("TattooStyleCrossLinks")]
        public virtual Tattoo Tattoo { get; set; }
    }
}

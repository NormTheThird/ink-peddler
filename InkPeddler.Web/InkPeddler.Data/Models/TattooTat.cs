using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("TattooTat")]
    public partial class TattooTat
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        public Guid AccountId { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("TattooTats")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(TattooId))]
        [InverseProperty("TattooTats")]
        public virtual Tattoo Tattoo { get; set; }
    }
}

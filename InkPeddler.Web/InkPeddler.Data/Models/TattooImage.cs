using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("TattooImage")]
    public partial class TattooImage
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TattooId { get; set; }
        [Column("AWSImageId")]
        public Guid AwsimageId { get; set; }
        public bool IsMainImage { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(TattooId))]
        [InverseProperty("TattooImages")]
        public virtual Tattoo Tattoo { get; set; }
    }
}

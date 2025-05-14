using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Businesses = new HashSet<Business>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }
        [Required]
        [StringLength(255)]
        public string Address2 { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string State { get; set; }
        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [InverseProperty(nameof(Business.Address))]
        public virtual ICollection<Business> Businesses { get; set; }
    }
}

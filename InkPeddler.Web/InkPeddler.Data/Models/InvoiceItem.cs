using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("InvoiceItem")]
    public partial class InvoiceItem
    {
        public InvoiceItem()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemCost { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [InverseProperty(nameof(InvoiceDetail.InvoiceItem))]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}

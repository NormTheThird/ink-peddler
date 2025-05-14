using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceDetails")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(InvoiceItemId))]
        [InverseProperty("InvoiceDetails")]
        public virtual InvoiceItem InvoiceItem { get; set; }
    }
}

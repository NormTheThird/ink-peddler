using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("InvoicePayment")]
    public partial class InvoicePayment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentResponseId { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoicePayments")]
        public virtual Invoice Invoice { get; set; }
    }
}

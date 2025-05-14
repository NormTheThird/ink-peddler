using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            InvoicePayments = new HashSet<InvoicePayment>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid InvoicedAccountId { get; set; }
        [Required]
        [StringLength(10)]
        public string DiscountCode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotalAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        public DateTimeOffset? DatePaid { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(InvoicedAccountId))]
        [InverseProperty(nameof(Account.Invoices))]
        public virtual Account InvoicedAccount { get; set; }
        [InverseProperty(nameof(InvoiceDetail.Invoice))]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        [InverseProperty(nameof(InvoicePayment.Invoice))]
        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }
    }
}

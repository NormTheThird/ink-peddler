using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            InvoicePayment = new HashSet<InvoicePayment>();
        }

        public Guid Id { get; set; }
        public Guid InvoicedAccountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset? DatePaid { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Account InvoicedAccount { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<InvoicePayment> InvoicePayment { get; set; }
    }
}

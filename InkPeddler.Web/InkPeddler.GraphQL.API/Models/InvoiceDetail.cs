using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class InvoiceDetail
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Invoice Invoice { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
    }
}

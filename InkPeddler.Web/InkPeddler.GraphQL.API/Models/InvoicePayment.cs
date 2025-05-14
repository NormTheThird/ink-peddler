using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class InvoicePayment
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public string PaymentResponseId { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Invoice Invoice { get; set; }
    }
}

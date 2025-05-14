using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class InvoiceItem
    {
        public InvoiceItem()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ItemCost { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}

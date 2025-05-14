using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("BusinessAccountCrossLink")]
    public partial class BusinessAccountCrossLink
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public Guid AccountId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsManager { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("BusinessAccountCrossLinks")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(BusinessId))]
        [InverseProperty("BusinessAccountCrossLinks")]
        public virtual Business Business { get; set; }
    }
}

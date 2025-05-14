using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("UserPasswordReset")]
    public partial class UserPasswordReset
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPasswordResets")]
        public virtual User User { get; set; }
    }
}

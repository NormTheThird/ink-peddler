using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("UserRefreshToken")]
    public partial class UserRefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(500)]
        public string RefreshToken { get; set; }
        [Required]
        [StringLength(500)]
        public string ProtectedTicket { get; set; }
        [Required]
        [StringLength(50)]
        public string TokenType { get; set; }
        public DateTimeOffset DateIssued { get; set; }
        public DateTimeOffset DateExpired { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserRefreshTokens")]
        public virtual User User { get; set; }
    }
}

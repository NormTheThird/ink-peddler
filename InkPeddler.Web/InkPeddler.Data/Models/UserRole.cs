using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    public partial class UserRole
    {
        [Key]
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsArtist { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserRole")]
        public virtual User User { get; set; }
    }
}

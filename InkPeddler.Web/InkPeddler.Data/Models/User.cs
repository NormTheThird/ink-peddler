using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            UserPasswordResets = new HashSet<UserPasswordReset>();
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Salt { get; set; }
        [MaxLength(64)]
        public byte[] Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [InverseProperty("User")]
        public virtual UserRole UserRole { get; set; }
        [InverseProperty(nameof(UserPasswordReset.User))]
        public virtual ICollection<UserPasswordReset> UserPasswordResets { get; set; }
        [InverseProperty(nameof(UserRefreshToken.User))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}

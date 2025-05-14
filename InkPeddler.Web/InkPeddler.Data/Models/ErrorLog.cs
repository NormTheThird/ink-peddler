using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("ErrorLog")]
    public partial class ErrorLog
    {
        [Key]
        public Guid Id { get; set; }
        [Column("HResult")]
        public int Hresult { get; set; }
        [Required]
        [StringLength(50)]
        public string Source { get; set; }
        [Required]
        [StringLength(50)]
        public string ExceptionType { get; set; }
        [Required]
        [StringLength(3000)]
        public string ExceptionMessage { get; set; }
        [Required]
        [StringLength(3000)]
        public string InnerExceptionMessage { get; set; }
        [Required]
        [StringLength(3000)]
        public string StackTrace { get; set; }
        [Required]
        [StringLength(3000)]
        public string Parameters { get; set; }
        public bool IsReviewed { get; set; }
        [Required]
        [StringLength(50)]
        public string ReviewedBy { get; set; }
        [Required]
        [StringLength(3000)]
        public string ReviewedComments { get; set; }
        public DateTimeOffset? DateReviwed { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

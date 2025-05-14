using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InkPeddler.Data.Models
{
    [Table("Business")]
    public partial class Business
    {
        public Business()
        {
            BusinessAccountCrossLinks = new HashSet<BusinessAccountCrossLink>();
            Tattoos = new HashSet<Tattoo>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        [Column("AWSProfileImageId")]
        public Guid? AwsprofileImageId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(6)]
        public string RegistrationCode { get; set; }
        [Required]
        [StringLength(255)]
        public string GoogleMapId { get; set; }
        [Required]
        [StringLength(255)]
        public string GoogleMapPlaceId { get; set; }
        [Required]
        [StringLength(50)]
        public string AzureMapsSearchType { get; set; }
        [Required]
        [StringLength(255)]
        public string AzureMapsSearchId { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string WebsiteUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string FacebookUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string InstagramUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string TwitterUrl { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(100)]
        public string ValidatedBy { get; set; }
        public DateTimeOffset? DateLastValidated { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Businesses")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(BusinessAccountCrossLink.Business))]
        public virtual ICollection<BusinessAccountCrossLink> BusinessAccountCrossLinks { get; set; }
        [InverseProperty(nameof(Tattoo.Business))]
        public virtual ICollection<Tattoo> Tattoos { get; set; }
    }
}

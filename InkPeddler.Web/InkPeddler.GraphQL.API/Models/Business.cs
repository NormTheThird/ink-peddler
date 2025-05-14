using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class Business
    {
        public Business()
        {
            BusinessAccountCrossLink = new HashSet<BusinessAccountCrossLink>();
            Tattoo = new HashSet<Tattoo>();
        }

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid? AwsprofileImageId { get; set; }
        public string Name { get; set; }
        public string RegistrationCode { get; set; }
        public string GoogleMapId { get; set; }
        public string GoogleMapPlaceId { get; set; }
        public string AzureMapsSearchType { get; set; }
        public string AzureMapsSearchId { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string ValidatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? DateLastValidated { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Address Address { get; set; }
        public ICollection<BusinessAccountCrossLink> BusinessAccountCrossLink { get; set; }
        public ICollection<Tattoo> Tattoo { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class QuickBusinessModel
    {
        public QuickBusinessModel()
        {
            this.Id = Guid.Empty;
            this.Name = string.Empty;
            this.PhoneNumber = string.Empty;
            this.FullAddress = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }
        [DataMember(IsRequired = true)]
        public string FullAddress { get; set; }
    }

    [DataContract]
    public class BusinessModel : ActiveModel
    {
        public BusinessModel()
        {
            this.AddressId = Guid.Empty;
            this.AWSProfileImageId = null;
            this.Address = new AddressModel();
            this.Name = string.Empty;
            this.RegistrationCode = string.Empty;
            this.GoogleMapId = string.Empty;
            this.GoogleMapPlaceId = string.Empty;
            this.AzureMapsSearchType = string.Empty;
            this.AzureMapsSearchId = string.Empty;
            this.PhoneNumber = string.Empty;
            this.FacebookUrl = string.Empty;
            this.TwitterUrl = string.Empty;
            this.InstagramUrl = string.Empty;
            this.WebsiteUrl = string.Empty;
            this.ValidatedBy = string.Empty;
            this.DateLastValidated = null;
        }

        [DataMember(IsRequired = true)]
        public Guid AddressId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? AWSProfileImageId { get; set; }
        [DataMember(IsRequired = true)]
        public AddressModel Address { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string RegistrationCode { get; set; }
        [DataMember(IsRequired = true)]
        public string GoogleMapId { get; set; }
        [DataMember(IsRequired = true)]
        public string GoogleMapPlaceId { get; set; }
        [DataMember(IsRequired = true)]
        public string AzureMapsSearchType { get; set; }
        [DataMember(IsRequired = true)]
        public string AzureMapsSearchId { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }
        [DataMember(IsRequired = true)]
        public string FacebookUrl { get; set; }
        [DataMember(IsRequired = true)]
        public string TwitterUrl { get; set; }
        [DataMember(IsRequired = true)]
        public string InstagramUrl { get; set; }
        [DataMember(IsRequired = true)]
        public string WebsiteUrl { get; set; }
        [DataMember(IsRequired = true)]
        public string ValidatedBy { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset? DateLastValidated { get; set; }
    }

    [DataContract]
    public class BusinessLocationModel
    {
        public BusinessLocationModel()
        {
            this.Id = Guid.Empty;
            this.Name = string.Empty;
            this.Latitude = 0.0m;
            this.Longitude = 0.0m;
        }

        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public decimal Latitude { get; set; }
        [DataMember(IsRequired = true)]
        public decimal Longitude { get; set; }
    }

    [DataContract]
    public class BaseBusinessAccountModel
    {
        public BaseBusinessAccountModel()
        {
            this.BusinessId = Guid.Empty;
            this.AccountId = Guid.Empty;
            this.IsOwner = false;
            this.IsManager = false;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsOwner { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsManager { get; set; }
    }

    [DataContract]
    public class QuickBusinessAccountModel : BaseBusinessAccountModel
    {
        public QuickBusinessAccountModel()
        {
            this.FullName = string.Empty;
            this.PhoneNumber = string.Empty;
            this.IsArtist = false;
        }

        [DataMember(IsRequired = true)]
        public string FullName { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsArtist { get; set; }
    }

    [DataContract]
    public class BusinessAccountModel : QuickBusinessAccountModel
    {
        public BusinessAccountModel()
        {
            this.Email = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.IsActive = false;
        }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class BusinessListModel
    {
        public BusinessListModel()
        {
            this.Id = Guid.Empty;
            this.Name = string.Empty;
            this.RegistrationCode = string.Empty;
            this.CityState = string.Empty;
            this.DateLastValidated = null;
        }

        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string RegistrationCode { get; set; }
        [DataMember(IsRequired = true)]
        public string CityState { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset? DateLastValidated { get; set; }
    }
}
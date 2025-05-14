using InkPeddler.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class AccountModel : ActiveModel
    {
        public AccountModel()
        {
            this.AddressId = Guid.Empty;
            this.AWSProfileImageId = null;
            this.Address = new AddressModel();
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.PhoneNumber = string.Empty;
            this.AllowedOrigin = string.Empty;
            this.RefreshTokenLifeTimeMinutes = 0;
            this.DateOfBirth = null;
            this.IsArtist = false;
        }

        [DataMember(IsRequired = true)]
        public Guid AddressId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? AWSProfileImageId { get; set; }
        [DataMember(IsRequired = true)]
        public AddressModel Address { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }
        [DataMember(IsRequired = true)]
        public string AllowedOrigin { get; set; }
        [DataMember(IsRequired = true)]
        public int RefreshTokenLifeTimeMinutes { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime? DateOfBirth { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsArtist { get; set; }
    }

    [DataContract]
    public class AccountNotTiedToBusinessModel
    {
        public AccountNotTiedToBusinessModel()
        {
            this.AccountId = Guid.Empty;
            this.Name = string.Empty;
            this.Email = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }

    [DataContract]
    public class AccountActivityModel : BaseModel
    {
        public AccountActivityModel()
        {
            this.AccountId = Guid.Empty;
            this.ActivityType = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public string ActivityType { get; set; }
    }
}
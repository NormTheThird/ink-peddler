using System;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class SecurityModel
    {
        public SecurityModel()
        {
            this.Id = Guid.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.AllowedOrigin = string.Empty;
            this.RefreshTokenLifeTimeMinutes = 0;
            this.IsSystemAdmin = false;
            this.IsActive = false;
        }

        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
        [DataMember(IsRequired = true)]
        public string AllowedOrigin { get; set; }
        [DataMember(IsRequired = true)]
        public int RefreshTokenLifeTimeMinutes { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsSystemAdmin { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class RefreshTokenModel
    {
        public RefreshTokenModel()
        {
            this.Id = Guid.Empty;
            this.AccountId = Guid.Empty;
            this.RefreshToken = string.Empty;
            this.ProtectedTicket = string.Empty;
            this.DateIssued = DateTimeOffset.MinValue;
            this.DateExpired = DateTimeOffset.MinValue;
        }

        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public string RefreshToken { get; set; }
        [DataMember(IsRequired = true)]
        public string ProtectedTicket { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset DateIssued { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset DateExpired { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRefreshToken = new HashSet<AccountRefreshToken>();
            ActivityLog = new HashSet<ActivityLog>();
            BusinessAccountCrossLink = new HashSet<BusinessAccountCrossLink>();
            Invoice = new HashSet<Invoice>();
            PasswordReset = new HashSet<PasswordReset>();
            TattooArtistAccount = new HashSet<Tattoo>();
            TattooCanvasAccount = new HashSet<Tattoo>();
            TattooComment = new HashSet<TattooComment>();
            TattooReviewLog = new HashSet<TattooReviewLog>();
            TattooTat = new HashSet<TattooTat>();
            TattooUploadedByAccount = new HashSet<Tattoo>();
            TattooView = new HashSet<TattooView>();
        }

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid? AwsprofileImageId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string AllowedOrigin { get; set; }
        public int RefreshTokenLifeTimeMinutes { get; set; }
        public byte[] Password { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsArtist { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public Address Address { get; set; }
        public ICollection<AccountRefreshToken> AccountRefreshToken { get; set; }
        public ICollection<ActivityLog> ActivityLog { get; set; }
        public ICollection<BusinessAccountCrossLink> BusinessAccountCrossLink { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<PasswordReset> PasswordReset { get; set; }
        public ICollection<Tattoo> TattooArtistAccount { get; set; }
        public ICollection<Tattoo> TattooCanvasAccount { get; set; }
        public ICollection<TattooComment> TattooComment { get; set; }
        public ICollection<TattooReviewLog> TattooReviewLog { get; set; }
        public ICollection<TattooTat> TattooTat { get; set; }
        public ICollection<Tattoo> TattooUploadedByAccount { get; set; }
        public ICollection<TattooView> TattooView { get; set; }
    }
}

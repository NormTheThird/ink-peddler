using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class TattooQuickModel : ActiveModel
    {
        public TattooQuickModel()
        {
            this.Name = string.Empty;
            this.NumberOfViews = 0;
            this.NumberOfTats = 0;
            this.NumberOfComments = 0;
            this.Styles = new List<StyleModel>();
        }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public int NumberOfViews { get; set; }
        [DataMember(IsRequired = true)]
        public int NumberOfTats { get; set; }
        [DataMember(IsRequired = true)]
        public int NumberOfComments { get; set; }
        [DataMember(IsRequired = true)]
        public List<StyleModel> Styles { get; set; }
    }

    [DataContract]
    public class TattooModel : ActiveModel
    {
        public TattooModel()
        {
            this.UploadedByAccountId = Guid.Empty;
            this.CanvasAccountId = Guid.Empty;
            this.ArtistAccountId = Guid.Empty;
            this.BusinessId = Guid.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.DateCompleted = null;
        }

        [DataMember(IsRequired = true)]
        public Guid UploadedByAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid CanvasAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid ArtistAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime? DateCompleted { get; set; }
    }

    [DataContract]
    public class TattooCommentModel : ActiveModel
    {
        public TattooCommentModel()
        {
            this.TattooId = Guid.Empty;
            this.AccountId = Guid.Empty;
            this.Comment = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public string Comment { get; set; }
    }

    [DataContract]
    public class TattooImageModel : ActiveModel
    {
        public TattooImageModel()
        {
            this.TattooId = Guid.Empty;
            this.AWSImageId = Guid.Empty;
            this.IsMainImage = false;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AWSImageId { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsMainImage { get; set; }
    }

    [DataContract]
    public class TattooWithMainImageModel : ActiveModel
    {
        public TattooWithMainImageModel()
        {
            this.UploadedByAccountId = Guid.Empty;
            this.AWSImageId = null;
            this.CanvasAccountId = Guid.Empty;
            this.ArtistAccountId = Guid.Empty;
            this.BusinessId = Guid.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid UploadedByAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? AWSImageId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? CanvasAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? ArtistAccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid? BusinessId { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
    }
}
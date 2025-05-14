using InkPeddler.Common.Enums;
using InkPeddler.Common.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InkPeddler.Common.RequestAndResponses
{
    [DataContract]
    public class GetTattoosPerPageWithMainImageRequest : BaseRequest
    {
        public GetTattoosPerPageWithMainImageRequest()
        {
            this.PageNumber = 0;
            this.StyleId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public int PageNumber { get; set; }
        [DataMember(IsRequired = true)]
        public Guid StyleId { get; set; }
    }

    [DataContract]
    public class GetTattoosPerPageWithMainImageResponse : BaseResponse
    {
        public GetTattoosPerPageWithMainImageResponse()
        {
            this.Tattoos = new List<TattooWithMainImageModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooWithMainImageModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetTattoosPerPageBySearchValueRequest : BaseRequest
    {
        public GetTattoosPerPageBySearchValueRequest()
        {
            this.PageNumber = 0;
            this.SearchValue = string.Empty;
        }

        [DataMember(IsRequired = true)]
        public int PageNumber { get; set; }
        [DataMember(IsRequired = true)]
        public string SearchValue { get; set; }
    }

    [DataContract]
    public class GetTattoosPerPageBySearchValueResponse : BaseResponse
    {
        public GetTattoosPerPageBySearchValueResponse()
        {
            this.Tattoos = new List<TattooWithMainImageModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooWithMainImageModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetArtistTattoosWithMainImageRequest : BaseRequest
    {
        public GetArtistTattoosWithMainImageRequest()
        {
            this.ArtistAccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid ArtistAccountId { get; set; }
    }

    [DataContract]
    public class GetArtistTattoosWithMainImageResponse : BaseResponse
    {
        public GetArtistTattoosWithMainImageResponse()
        {
            this.Tattoos = new List<TattooWithMainImageModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooWithMainImageModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetUserTattoosWithMainImageRequest : BaseRequest
    {
        public GetUserTattoosWithMainImageRequest()
        {
            this.UploadedByAccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid UploadedByAccountId { get; set; }
    }

    [DataContract]
    public class GetUserTattoosWithMainImageResponse : BaseResponse
    {
        public GetUserTattoosWithMainImageResponse()
        {
            this.Tattoos = new List<TattooWithMainImageModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooWithMainImageModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetAllTattoosRequest : BaseRequest {  }

    [DataContract]
    public class GetAllTattoosResponse : BaseResponse
    {
        public GetAllTattoosResponse()
        {
            this.Tattoos = new List<TattooQuickModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooQuickModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetUploadedTattoosRequest : BaseRequest
    {
        public GetUploadedTattoosRequest()
        {
            this.UploadedAccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid UploadedAccountId { get; set; }
    }

    [DataContract]
    public class GetUploadedTattoosResponse : BaseResponse
    {
        public GetUploadedTattoosResponse()
        {
            this.Tattoos = new List<TattooQuickModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooQuickModel> Tattoos { get; set; }
    }

    [DataContract]
    public class GetTattooRequest : BaseRequest
    {
        public GetTattooRequest()
        {
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class GetTattooResponse : BaseResponse
    {
        public GetTattooResponse()
        {
            this.Tattoo = new TattooModel();
        }

        [DataMember(IsRequired = true)]
        public TattooModel Tattoo { get; set; }
    }

    [DataContract]
    public class GetTattooImagesRequest : BaseRequest
    {
        public GetTattooImagesRequest()
        {
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class GetTattooImagesResponse : BaseResponse
    {
        public GetTattooImagesResponse()
        {
            this.TattooImages = new List<TattooImageModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooImageModel> TattooImages { get; set; }
    }

    [DataContract]
    public class SaveTattooRequest : BaseRequest
    {
        public SaveTattooRequest()
        {
            this.Tattoo = new TattooModel();
        }

        [DataMember(IsRequired = true)]
        public TattooModel Tattoo { get; set; }
    }

    [DataContract]
    public class SaveTattooResponse : BaseResponse
    {
        public SaveTattooResponse()
        {
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class SaveTattooImageRequest : BaseRequest
    {
        public SaveTattooImageRequest()
        {
            this.TattooImage = new TattooImageModel();
        }

        [DataMember(IsRequired = true)]
        public TattooImageModel TattooImage { get; set; }
    }

    [DataContract]
    public class SaveTattooImageResponse : BaseResponse { }

    [DataContract]
    public class SaveAsTattooMainImageRequest : BaseRequest
    {
        public SaveAsTattooMainImageRequest()
        {
            this.TattooImageId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooImageId { get; set; }
    }

    [DataContract]
    public class SaveAsTattooMainImageResponse : BaseResponse { }

    [DataContract]
    public class DeleteTattooImageRequest : BaseRequest
    {
        public DeleteTattooImageRequest()
        {
            this.TattooImageId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooImageId { get; set; }
    }

    [DataContract]
    public class DeleteTattooImageResponse : BaseResponse { }

    [DataContract]
    public class SaveTattooTatRequest : BaseRequest
    {
        public SaveTattooTatRequest()
        {
            this.TattooId = Guid.Empty;
            this.AccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
    }

    [DataContract]
    public class SaveTattooTatResponse : BaseResponse { }

    [DataContract]
    public class GetTattooCommentsRequest : BaseActiveRequest
    {
        public GetTattooCommentsRequest()
        {
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class GetTattooCommentsResponse : BaseResponse
    {
        public GetTattooCommentsResponse()
        {
            this.TattooComments = new List<TattooCommentModel>();
        }

        [DataMember(IsRequired = true)]
        public List<TattooCommentModel> TattooComments { get; set; }
    }

    [DataContract]
    public class GetTattooCommentRequest : BaseRequest
    {
        public GetTattooCommentRequest()
        {
            this.TattooCommentId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooCommentId { get; set; }
    }

    [DataContract]
    public class GetTattooCommentResponse : BaseResponse
    {
        public GetTattooCommentResponse()
        {
            this.TattooComment = new TattooCommentModel();
        }

        [DataMember(IsRequired = true)]
        public TattooCommentModel TattooComment { get; set; }
    }

    [DataContract]
    public class SaveTattooCommentRequest : BaseRequest
    {
        public SaveTattooCommentRequest()
        {
            this.TattooComment = new TattooCommentModel();
        }

        [DataMember(IsRequired = true)]
        public TattooCommentModel TattooComment { get; set; }
    }

    [DataContract]
    public class SaveTattooCommentResponse : BaseResponse { }

    [DataContract]
    public class SaveTattooViewRequest : BaseRequest
    {
        public SaveTattooViewRequest()
        {
            this.TattooId = Guid.Empty;
            this.AccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
    }

    [DataContract]
    public class SaveTattooViewResponse : BaseResponse { }

    [DataContract]
    public class ChangeTattooStatusRequest : BaseRequest
    {
        public ChangeTattooStatusRequest()
        {
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class ChangeTattooStatusResponse : BaseResponse { }

    [DataContract]
    public class ChangeTattooImageStatusRequest : BaseRequest
    {
        public ChangeTattooImageStatusRequest()
        {
            this.TattooImageId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid TattooImageId { get; set; }
    }

    [DataContract]
    public class ChangeTattooImageStatusResponse : BaseResponse { }


    [DataContract]
    public class GetTattooTattedStatusRequest : BaseRequest
    {
        public GetTattooTattedStatusRequest()
        {
            this.AccountId = Guid.Empty;
            this.TattooId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid TattooId { get; set; }
    }

    [DataContract]
    public class GetTattooTattedStatusResponse : BaseResponse
    {
        public GetTattooTattedStatusResponse()
        {
            IsTatted = false;
        }

        [DataMember(IsRequired = true)]
        public bool IsTatted { get; set; }
    }
}
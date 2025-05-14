using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InkPeddler.Common.Models;

namespace InkPeddler.Common.RequestAndResponses
{
    [DataContract]
    public class GetBusinessesRequest : BaseActiveRequest { }

    [DataContract]
    public class GetBusinessesResponse : BaseResponse
    {
        public GetBusinessesResponse()
        {
            this.Businesses = new List<BusinessModel>();
        }

        [DataMember(IsRequired = true)]
        public List<BusinessModel> Businesses { get; set; }
    }

    [DataContract]
    public class GetBusinessListRequest : BaseActiveRequest { }

    [DataContract]
    public class GetBusinessListResponse : BaseResponse
    {
        public GetBusinessListResponse()
        {
            this.Businesses = new List<BusinessListModel>();
        }

        [DataMember(IsRequired = true)]
        public List<BusinessListModel> Businesses { get; set; }
    }

    [DataContract]
    public class GetBusinessesForLocationRequest : BaseRequest
    {
        public GetBusinessesForLocationRequest()
        {
            this.Latitude = 0.0m;
            this.Longitude = 0.0m;
            this.Radius = 0;
        }

        [DataMember(IsRequired = true)]
        public decimal Latitude { get; set; }
        [DataMember(IsRequired = true)]
        public decimal Longitude { get; set; }
        [DataMember(IsRequired = true)]
        public int Radius { get; set; }
    }

    [DataContract]
    public class GetBusinessesForLocationResponse : BaseResponse
    {
        public GetBusinessesForLocationResponse()
        {
            this.Businesses = new List<BusinessLocationModel>();
        }

        [DataMember(IsRequired = true)]
        public List<BusinessLocationModel> Businesses { get; set; }
    }

    [DataContract]
    public class GetBusinessLocationsRequest : BaseRequest { }

    [DataContract]
    public class GetBusinessLocationsResponse : BaseResponse
    {
        public GetBusinessLocationsResponse()
        {
            this.BusinessLocations = new List<BusinessLocationModel>();
        }

        [DataMember(IsRequired = true)]
        public List<BusinessLocationModel> BusinessLocations { get; set; }
    }

    [DataContract]
    public class GetBusinessAccountsRequest : BaseRequest
    {
        public GetBusinessAccountsRequest()
        {
            this.BusinessId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
    }

    [DataContract]
    public class GetBusinessAccountsResponse : BaseResponse
    {
        public GetBusinessAccountsResponse()
        {
            this.BusinessAccounts = new List<BusinessAccountModel>();
        }

        [DataMember(IsRequired = true)]
        public List<BusinessAccountModel> BusinessAccounts { get; set; }
    }

    [DataContract]
    public class GetBusinessAndAccountsRequest : BaseRequest
    {
        public GetBusinessAndAccountsRequest()
        {
            this.BusinessId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
    }

    [DataContract]
    public class GetBusinessAndAccountsResponse : BaseResponse
    {
        public GetBusinessAndAccountsResponse()
        {
            this.Business = new QuickBusinessModel();
            this.Accounts = new List<QuickBusinessAccountModel>();
        }

        [DataMember(IsRequired = true)]
        public QuickBusinessModel Business { get; set; }
        [DataMember(IsRequired = true)]
        public List<QuickBusinessAccountModel> Accounts { get; set; }
    }

    [DataContract]
    public class GetBusinessRequest : BaseRequest
    {
        public GetBusinessRequest()
        {
            this.BusinessId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
    }

    [DataContract]
    public class GetBusinessResponse : BaseResponse
    {
        public GetBusinessResponse()
        {
            this.Business = new BusinessModel();
        }

        [DataMember(IsRequired = true)]
        public BusinessModel Business { get; set; }
    }

    [DataContract]
    public class SaveBusinessRequest : BaseRequest
    {
        public SaveBusinessRequest()
        {
            this.Business = new BusinessModel();
        }

        [DataMember(IsRequired = true)]
        public BusinessModel Business { get; set; }
    }

    [DataContract]
    public class SaveBusinessResponse : BaseResponse { }

    [DataContract]
    public class SaveBusinessImageRequest : BaseRequest
    {
        public SaveBusinessImageRequest()
        {
            this.BusinessId = Guid.Empty;
            this.AWSProfileImageId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AWSProfileImageId { get; set; }
    }

    [DataContract]
    public class SaveBusinessImageResponse : BaseResponse { }

    [DataContract]
    public class AddBusinessAccountRequest : BaseRequest
    {
        public AddBusinessAccountRequest()
        {
            this.BusinessAccount = new BaseBusinessAccountModel();
        }

        [DataMember(IsRequired = true)]
        public BaseBusinessAccountModel BusinessAccount { get; set; }
    }

    [DataContract]
    public class AddBusinessAccountResponse : BaseResponse { }

    [DataContract]
    public class RemoveBusinessAccountRequest : BaseRequest
    {
        public RemoveBusinessAccountRequest()
        {
            this.BusinessId = Guid.Empty;
            this.AccountId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid BusinessId { get; set; }
        [DataMember(IsRequired = true)]
        public Guid AccountId { get; set; }
    }

    [DataContract]
    public class RemoveBusinessAccountResponse : BaseResponse { }
}
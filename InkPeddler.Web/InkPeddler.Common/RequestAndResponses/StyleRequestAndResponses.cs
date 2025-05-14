using System;
using InkPeddler.Common.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InkPeddler.Common.RequestAndResponses
{
    [DataContract]
    public class GetStylesRequest : BaseActiveRequest { }

    [DataContract]
    public class GetStylesResponse : BaseResponse
    {
        public GetStylesResponse()
        {
            this.Styles = new List<StyleModel>();
        }

        [DataMember(IsRequired = true)]
        public List<StyleModel> Styles { get; set; }
    }

    [DataContract]
    public class GetStyleRequest : BaseRequest
    {
        public GetStyleRequest()
        {
            this.StyleId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid StyleId { get; set; }
    }

    [DataContract]
    public class GetStyleResponse : BaseResponse
    {
        public GetStyleResponse()
        {
            this.Style = new StyleModel();
        }

        [DataMember(IsRequired = true)]
        public StyleModel Style { get; set; }
    }

    [DataContract]
    public class SaveStyleRequest : BaseRequest
    {
        public SaveStyleRequest()
        {
            this.Style = new StyleModel();
        }

        [DataMember(IsRequired = true)]
        public StyleModel Style { get; set; }
    }

    [DataContract]
    public class SaveStyleResponse : BaseResponse { }

    [DataContract]
    public class ChangeStyleStatusRequest : BaseRequest
    {
        public ChangeStyleStatusRequest()
        {
            this.StyleId = Guid.Empty;
        }

        [DataMember(IsRequired = true)]
        public Guid StyleId { get; set; }
    }

    [DataContract]
    public class ChangeStyleStatusResponse : BaseResponse { }
}
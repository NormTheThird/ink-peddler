using System.Runtime.Serialization;
using InkPeddler.Common.Models;

namespace InkPeddler.Common.RequestAndResponses
{
    [DataContract]
    public class GetDashboardTotalsRequest { }

    [DataContract]
    public class GetDashboardTotalsResponse : BaseResponse
    {
        public GetDashboardTotalsResponse()
        {
            this.DashboardTotals = new DashboardTotalsModel();
        }

        [DataMember(IsRequired = true)]
        public DashboardTotalsModel DashboardTotals { get; set; }
    }
}
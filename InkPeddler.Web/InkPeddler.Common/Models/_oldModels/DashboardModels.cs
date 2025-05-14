using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    public class DashboardTotalsModel
    {
        public DashboardTotalsModel()
        {
            this.ActiveUserCount = 0;
            this.InActiveUserCount = 0;
            this.ActiveArtistCount = 0;
            this.InActiveArtistCount = 0;
            this.ActiveBusinessCount = 0;
            this.InActiveBusinessCount = 0;
            this.TattooCount = 0;
        }

        [DataMember(IsRequired = true)]
        public int ActiveUserCount { get; set; }
        [DataMember(IsRequired = true)]
        public int InActiveUserCount { get; set; }
        [DataMember(IsRequired = true)]
        public int ActiveArtistCount { get; set; }
        [DataMember(IsRequired = true)]
        public int InActiveArtistCount { get; set; }
        [DataMember(IsRequired = true)]
        public int ActiveBusinessCount { get; set; }
        [DataMember(IsRequired = true)]
        public int InActiveBusinessCount { get; set; }
        [DataMember(IsRequired = true)]
        public int TattooCount { get; set; }
    }
}
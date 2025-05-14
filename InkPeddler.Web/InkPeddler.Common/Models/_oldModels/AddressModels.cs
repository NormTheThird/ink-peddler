using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class AddressModel : BaseModel
    {
        public AddressModel()
        {
            this.Address1 = string.Empty;
            this.Address2 = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.ZipCode = string.Empty;
            this.Latitude = 0.0m;
            this.Longitude = 0.0m;
        }

        [DataMember(IsRequired = true)]
        public string Address1 { get; set; }
        [DataMember(IsRequired = true)]
        public string Address2 { get; set; }
        [DataMember(IsRequired = true)]
        public string City { get; set; }
        [DataMember(IsRequired = true)]
        public string State { get; set; }
        [DataMember(IsRequired = true)]
        public string ZipCode { get; set; }
        [DataMember(IsRequired = true)]
        public decimal Latitude { get; set; }
        [DataMember(IsRequired = true)]
        public decimal Longitude { get; set; }
    }
}
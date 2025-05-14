using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class StyleModel : ActiveModel
    {
        public StyleModel()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
        }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
    }
}
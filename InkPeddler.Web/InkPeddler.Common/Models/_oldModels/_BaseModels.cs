using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InkPeddler.Common.Models
{
    [DataContract]
    public class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.Empty;
            this.DateCreated = DateTimeOffset.Now;
        }

        [Key]
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public DateTimeOffset DateCreated { get; set; }
    }

    [DataContract]
    public class ActiveModel : BaseModel
    {
        public ActiveModel()
        {
            this.IsActive = false;
        }

        [DataMember(IsRequired = true)]
        public bool IsActive { get; set; }
    }
}
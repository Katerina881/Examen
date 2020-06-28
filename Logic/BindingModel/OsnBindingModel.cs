using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class OsnBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        public List<DopBindingModel> Dops { get; set; }
    }
}

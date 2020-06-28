using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class DopBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int OsnId { get; set; }

        [DataMember]
        public string DopName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public DateTime DataCreateDop { get; set; }

        [DataMember]
        public string Place { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}

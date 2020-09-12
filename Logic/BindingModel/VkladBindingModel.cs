using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class VkladBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int BankId { get; set; }

        [DataMember]
        public string VkladName { get; set; }

        [DataMember]
        public int Sum { get; set; }

        [DataMember]
        public DateTime DataCreateVklad { get; set; }

        [DataMember]
        public string TypeVal { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}

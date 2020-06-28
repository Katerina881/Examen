using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    [DataContract]
    public class DopViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OsnvId { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string DopName { get; set; }

        [DataMember]
        [DisplayName("Колличество")]
        public int Count { get; set; }

        [DataMember]
        [DisplayName("Дата поставки")]
        public DateTime DataCreateDop { get; set; }

        [DataMember]
        [DisplayName("Место производства")]
        public string Place { get; set; }

        [DataMember]
        [DisplayName("Название блюда")]
        public string Name { get; set; }

        public DateTime DateCreate { get; set; }
    }
}

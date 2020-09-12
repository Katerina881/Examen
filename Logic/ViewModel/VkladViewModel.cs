using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    [DataContract]
    public class VkladViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BankId { get; set; }

        [DataMember]
        [DisplayName("ФИО владельца")]
        public string VkladName { get; set; }

        [DataMember]
        [DisplayName("Размер вклада")]
        public int Sum { get; set; }

        [DataMember]
        [DisplayName("Дата открытия")]
        public DateTime DataCreateVklad { get; set; }

        [DataMember]
        [DisplayName("Тип валюты")]
        public string TypeVal { get; set; }

        [DataMember]
        [DisplayName("Название банка")]
        public string Name { get; set; }

        public DateTime DateCreate { get; set; }
    }
}

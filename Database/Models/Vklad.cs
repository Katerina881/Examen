using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Vklad
    {
        public int Id { get; set; }

        public int BankId { get; set; }

        [Required]
        public string VkladName { get; set; }

        [Required]
        public int Sum { get; set; }

        [Required]
        public DateTime DataCreateVklad { get; set; }

        [Required]
        public string TypeVal { get; set; }

        public virtual Bank Bank { get; set; }
    }
}

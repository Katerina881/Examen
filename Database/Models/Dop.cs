using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Dop
    {
        public int Id { get; set; }

        public int OsnvId { get; set; }

        [Required]
        public string DopName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime DataCreateDop { get; set; }

        [Required]
        public string Place { get; set; }

        public virtual Osnv Osnv { get; set; }
    }
}

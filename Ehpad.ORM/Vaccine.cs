using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marque")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int VaccineTypeId { get; set; }

        [Display(Name = "Type")]
        public VaccineType VaccineType { get; set; }

        public List<Vaccinate> Vaccinates { get; } = new List<Vaccinate>();
    }
}

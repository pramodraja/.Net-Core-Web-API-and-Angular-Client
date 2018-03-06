using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Models
{
    public class Car
    {
        [Key]
        public Guid VinNo { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Year { get; set; }
    }
}

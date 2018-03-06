using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Models
{
    public static class CarDealerContextExtensions
    {
        public static void EnsureSeedDataForContext(this CarDealerContext context)
        {

            if (context.Cars.Count() == 0)
            {
                context.Cars.Add(new Car { Manufacturer = "Ford", Make = "Mustang", Model = "GT", Year = "2005" });
                context.Cars.Add(new Car { Manufacturer = "Toyota", Make = "Camry", Model = "EX", Year = "2015" });
                context.Cars.Add(new Car { Manufacturer = "Honda", Make = "Civic", Model = "LE", Year = "2012" });
                context.Cars.Add(new Car { Manufacturer = "Chevrolet", Make = "Corvette", Model = "Z06", Year = "2018" });
                context.SaveChanges();
            }
        }
        
    }
}

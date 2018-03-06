using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Models
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions<CarDealerContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }

}

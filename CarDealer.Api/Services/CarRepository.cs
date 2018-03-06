using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Api.Models;

namespace CarDealer.Api.Services
{
    public class CarRepository : ICarRepository
    {
        private CarDealerContext _context;

        public CarRepository(CarDealerContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public bool CarExists(Guid vinNo)
        {
            return _context.Cars.Any(a => a.VinNo == vinNo);
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public Car GetCar(Guid vinNo)
        {
            return _context.Cars.FirstOrDefault(a => a.VinNo == vinNo);
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars
                .OrderBy(a => a.Manufacturer)
                .ThenBy(a => a.Make)
                .ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCar(Car car)
        {
            // no code in this implementation
        }
    }
}

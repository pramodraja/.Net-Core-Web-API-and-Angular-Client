using CarDealer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Services
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCar(Guid vinNo);
        void AddCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);
        bool CarExists(Guid vinNo);
        bool Save();
    }
}

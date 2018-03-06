using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Api.Models;
using CarDealer.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Api.Controllers
{
    [Route("api/car")]
    public class CarController : Controller
    {
        private ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetCar(Guid id)
        {
            var car = _carRepository.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Car car)
        {
            if (car == null || car.VinNo != id)
            {
                return BadRequest();
            }

            var carToUpdate = _carRepository.GetCar(id);
            if (carToUpdate == null)
            {
                return NotFound();
            }

            carToUpdate.Manufacturer = car.Manufacturer;
            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            carToUpdate.Year = car.Year;

            _carRepository.UpdateCar(carToUpdate);
            if (!_carRepository.Save())
            {
                throw new Exception($"Updating car {id} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var car = _carRepository.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.DeleteCar(car);
            if (!_carRepository.Save())
            {
                throw new Exception($"Deleting car {id} failed on save.");
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            if (_carRepository.CarExists(car.VinNo))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _carRepository.AddCar(car);

            if (!_carRepository.Save())
            {
                throw new Exception("Creating a car failed on save.");
            }

            return CreatedAtRoute("GetCar", new { id = car.VinNo }, car);
        }
    }
}

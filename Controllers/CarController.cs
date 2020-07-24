using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using ParkingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : AppController
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;

        public CarController(
            ICarRepository carRepository,
            IMapper mapper
        )
        {
            this.carRepository = carRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDetailDTO>> GetCar()
        {
            var car = this.carRepository.GetAll();
            var carDTO = this.mapper.Map<IEnumerable<CarDetailDTO>>(car);
            return Ok(carDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CarDetailDTO> GetCar(long id)
        {
            var car = this.carRepository.GetOne(id);
            var carDTO = this.mapper.Map<CarDetailDTO>(car);
            return Ok(carDTO);
        }

        [HttpPost]
        public ActionResult<CarDetailDTO> CreateCar(CarCreateDTO carDTO)
        {
            var car = this.mapper.Map<Car>(carDTO);
            car = this.carRepository.CreateCar(car);
            return this.mapper.Map<CarDetailDTO>(car);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCar(long id)
        {
            return new { success = this.carRepository.DeleteCar(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CarDetailDTO> UpdateCar(long id, [FromBody] Car updatedCar)
        {
            var car = this.carRepository.UpdateCar(id, updatedCar);
            var carResult = this.mapper.Map<CarDetailDTO>(car);
            return carResult;
        }
    }
}
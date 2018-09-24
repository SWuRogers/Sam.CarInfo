using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sam.CarInfo.Models;
using Sam.CarInfo.Models.DTOs;
using Sam.CarInfo.Repositories;

namespace Sam.CarInfo.Controllers
{
    [Route("car")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarInventoryRepository _repo;
        private readonly IMapper _mapper;

        public CarsController(ICarInventoryRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("default/test")]
        public async Task CreateDefault()
        {
            await this._repo.Test();
        }

        [HttpGet]
        public IEnumerable<CarDisplayDto> GetCars()
        {
            return this._mapper.Map<IEnumerable<Car>, IEnumerable<CarDisplayDto>>(this._repo.GetCars());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = await this._repo.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(this._mapper.Map<CarDisplayDto>(car));
        }

        [HttpPost]
        public async Task<IActionResult> PostCar([FromBody] NewCarEntryDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await this._repo.GetCarModel(entry.CarModelId.Value);
            if (model == null)
            {
                return BadRequest("Car Model not found");
            }

            if (!string.IsNullOrEmpty(entry.ImageBase64))
            {
                var arr = entry.ImageBase64.Split(",");
                if (arr.Length != 2)
                {
                    return BadRequest("Image Base64 string format incorrect");
                }
                byte[] bytes = Convert.FromBase64String(arr[1]);
                if (bytes.Length > 1024 * 1024 * 4)
                {
                    return BadRequest("Image size greater than 4M");
                }
            }

            var created = await this._repo.AddNewCar(new Car()
            {
                CarModel = model,
                Color = entry.Color,
                Year = entry.Year.Value,
                Price = entry.Price.Value,
                ImageBase64 = entry.ImageBase64

            });

            return CreatedAtAction("GetCar", new { id = created.CarId }, new {carId = created.CarId });
        }
    }


}

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
    [EnableCors("MyPolicy")]
    [Route("car/makes")]
    [ApiController]
    public class CarMakeController : ControllerBase
    {
        private readonly ICarInventoryRepository _repo;
        private readonly IMapper _mapper;

        public CarMakeController(ICarInventoryRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CarMakeDto> GetCarMake()
        {
            return this._mapper.Map<IEnumerable<CarMake>, IEnumerable<CarMakeDto>>(this._repo.GetCarMakesWithModels());
        }
    }

}

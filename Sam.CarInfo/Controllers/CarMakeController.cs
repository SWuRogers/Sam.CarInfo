using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public ActionResult<IEnumerable<CarMakeDto>> GetCarMake()
        {
            try
            {

                var result = this._repo.GetCarMakesWithModels().ToList();

                var resp = this._mapper.Map<IEnumerable<CarMake>, IEnumerable<CarMakeDto>>(result);

                // return new JsonResult(new { name = "Sam" });
                return Ok(resp);

            }
            catch (Exception ex)
            {
                Exception currentEx = ex;
                var errMessage = "SamFound: ";
                do
                {
                    errMessage += currentEx.Message + "\n";
                    currentEx = currentEx.InnerException;
                } while (currentEx!= null);

                return new JsonResult(new {ErrorMsg = errMessage });

            }
        }

        [HttpGet("time")]
        public ActionResult<DateTime> GetTime()
        {
            return DateTime.Now;
        }
    }

}

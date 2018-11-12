using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models.DTOs
{
    public class CarMakeDto
    {
        public int CarMakeId { get; set; }
        public string CarMakeName { get; set; }
        public List<CarModelDto> CarModels { get; set; }
    }

}

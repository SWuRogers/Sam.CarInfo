using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models.DTOs
{

    public class CarModelDto
    {
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
        public CarMakeDto CarMake { get; set; }
    }

}

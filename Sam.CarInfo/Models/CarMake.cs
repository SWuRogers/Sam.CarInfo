using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models
{


    [Table("CarMake")]
    public class CarMake
    {
        public int CarMakeId{ get; set; }
        public string CarMakeName { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
  
}


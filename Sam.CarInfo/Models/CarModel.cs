using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models
{

    [Table("CarModel")]
    public class CarModel
    {
        public int CarModelId{ get; set; }
        public string CarModelName{ get; set; }
        public CarMake CarMake { get; set; }
    }
}


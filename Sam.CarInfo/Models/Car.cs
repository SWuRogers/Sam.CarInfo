using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models
{
    [Table("Car")]
    public class Car
    {
        public int CarId { get; set; }
        public CarModel CarModel { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string ImageBase64 { get; set; }
    }
}



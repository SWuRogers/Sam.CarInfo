using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models.DTOs
{
    public class CarDisplayDto
    {
        public int CarId { get; set; }
        public string CarMakeName { get; set; }
        public string CarModelName { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ImageBase64 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Models.DTOs
{
    public class NewCarEntryDto
    {
        public int CarId { get; set; }
        [Required]
        public int? CarModelId { get; set; }
        [Required]
        [Range(1885, 9999)]
        public int? Year { get; set; }
        public string Color { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal? Price { get; set; }
        public string ImageBase64 { get; set; }
    }
}

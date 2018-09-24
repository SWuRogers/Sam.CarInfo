using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sam.CarInfo.Models
{
    public class SamCarInfoContext : DbContext
    {


        public SamCarInfoContext(DbContextOptions<SamCarInfoContext> options)
            : base(options)
        {
        }

        public DbSet<Sam.CarInfo.Models.Car> Cars { get; set; }
        public DbSet<Sam.CarInfo.Models.CarMake> CarMakes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarMake>().HasData(
                new CarMake()
                {
                    CarMakeId = 1,
                    CarMakeName = "Ford",
                },
                new CarMake()
                {
                    CarMakeId = 2,
                    CarMakeName = "Tesla",
                },
                new CarMake()
                {
                    CarMakeId = 3,
                    CarMakeName = "Honda",
                }
           );

            modelBuilder.Entity<CarModel>().HasData(
                new { CarMakeId = 1, CarModelId=  1, CarModelName=  "F-150" },
                new { CarMakeId = 1, CarModelId = 2, CarModelName = "Fusion" },
                new { CarMakeId = 1, CarModelId = 3, CarModelName = "Escape" },
                new { CarMakeId = 2, CarModelId = 4, CarModelName = "Model S" },
                new { CarMakeId = 2, CarModelId = 5, CarModelName = "Model 3" },
                new { CarMakeId = 3, CarModelId = 6, CarModelName = "C-RV" },
                new { CarMakeId = 3, CarModelId = 7, CarModelName = "Explorer" },
                new { CarMakeId = 3, CarModelId = 8, CarModelName = "Accord" }

           );


        }

    }
}

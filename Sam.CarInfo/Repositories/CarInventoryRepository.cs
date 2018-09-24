using Microsoft.EntityFrameworkCore;
using Sam.CarInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo.Repositories
{
    public interface ICarInventoryRepository
    {
        Task<Car> GetCar(int id);
        IEnumerable<Car> GetCars();
        Task<Car> AddNewCar(Car carInfo);

        //SamToDo below should go to another repository, being lazy...
        IEnumerable<CarMake> GetCarMakesWithModels();
        Task<CarModel> GetCarModel(int Id);

        Task Test();
    }

    public class CarInventoryRepository: ICarInventoryRepository
    {
        private readonly SamCarInfoContext _context;

        public CarInventoryRepository(SamCarInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<CarMake> GetCarMakesWithModels()
        {
            return _context.CarMakes.Include(m => m.CarModels).Where(m => m.CarModels.FirstOrDefault() != null);
        }

        public async Task<Car> AddNewCar(Car carInfo)
        {
            _context.Cars.Add(carInfo);
            await _context.SaveChangesAsync();
            return carInfo;
        }

        public async Task<Car> GetCar(int id)
        {
            return await _context.Cars
                .Include(v => v.CarModel)
                .ThenInclude(v => v.CarMake)
                .FirstOrDefaultAsync(v => v.CarId == id);
        }

        public IEnumerable<Car> GetCars()
        {
            return this._context.Cars
                .Include(v => v.CarModel)
                .ThenInclude(v => v.CarMake);
        }

        public async Task Test()
        {
        }

        public async Task<CarModel> GetCarModel(int Id)
        {
            return await this._context.FindAsync<CarModel>(Id);
        }
    }
}

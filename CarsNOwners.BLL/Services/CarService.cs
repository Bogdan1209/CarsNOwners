using System.Collections.Generic;
using System.Threading.Tasks;
using CarsNOwners.BLL.Interfaces;
using CarsNOwners.BLL.DTO;
using CarsNOwners.DAL.Interfaces;
using AutoMapper;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.BLL.Services
{
    public class CarService:ICarSevice
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;
        static object deleteLocker = new object();

        public CarService(IUnitOfWork uow)
        {
            Database = uow;
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<CarDTO, Car>()
             );
            mapper = config.CreateMapper();
        }

        public void CreateCar(CarDTO item) {
            var car = mapper.Map<CarDTO, Car>(item);
            Database.Cars.Create(car);
            Database.Save();
        }

        public void UpdateCar(CarDTO item) {
            var car = mapper.Map<CarDTO, Car>(item);
            Database.Cars.Update(car);
            Database.Save();
        }

        public void DeleteCar(int id)
        {
            lock (deleteLocker)
            {
                Database.Cars.Delete(id);
                Database.Save();
            }
        }

        public IEnumerable<CarDTO> GetAllCars() {
            var cars = Database.Cars.GetAll();
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarAsync(int id) {
            var car = await Database.Cars.GetAsync(id);
            return mapper.Map<Car, CarDTO>(car);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

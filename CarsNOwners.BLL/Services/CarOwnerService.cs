using System.Threading.Tasks;
using System.Collections.Generic;
using CarsNOwners.BLL.Interfaces;
using CarsNOwners.DAL.Interfaces;
using CarsNOwners.DAL.Entities;
using CarsNOwners.BLL.DTO;
using AutoMapper;

namespace CarsNOwners.BLL.Services
{
    public class CarOwnerService:ICarOwnerService
    {

        IUnitOfWork Database { get; set; }
        IMapper mapper;

        public CarOwnerService(IUnitOfWork uow)
        {
            Database = uow;
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<CarDTO, Car>()
             );
            mapper = config.CreateMapper();
        }

        public IEnumerable<CarDTO> GetNotOwnerCars(int ownerId)
        {
            var cars = Database.CarOwners.GetNotOwnerCars(ownerId);
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);
        }

        public IEnumerable<CarDTO> GetOwnerCars(int ownerId)
        {
            var cars = Database.CarOwners.GetOwnerCars(ownerId);
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);
        }

        public async Task SetOwnerToCarAsync(int ownerId, int carId) {
            await Database.CarOwners.SetOwnerToCarAsync(ownerId, carId);
            await Database.SaveAsync();
        }

        public async Task DeleteCarFromOwnerAsync(int ownerId, int carId) {
            await Database.CarOwners.DeleteCarFromOwnerAsync(ownerId, carId);
            await Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CarsNOwners.BLL.DTO;

namespace CarsNOwners.BLL.Interfaces
{
    public interface ICarSevice
    {
        void CreateCar(CarDTO item);
        void UpdateCar(CarDTO item);
        void DeleteCar(int id);
        IEnumerable<CarDTO> GetAllCars();
        Task<CarDTO> GetCarAsync(int id);

    }
}

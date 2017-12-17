using System.Threading.Tasks;
using CarsNOwners.DAL.Entities;
using System.Collections.Generic;
using CarsNOwners.BLL.DTO;

namespace CarsNOwners.BLL.Interfaces
{
    public interface ICarOwnerService
    {
        Task SetOwnerToCarAsync(int ownerId, int carId);
        Task DeleteCarFromOwnerAsync(int ownerId, int carId);
        IEnumerable<CarDTO> GetOwnerCars(int ownerId);
        IEnumerable<CarDTO> GetNotOwnerCars(int ownerId);
    }
}

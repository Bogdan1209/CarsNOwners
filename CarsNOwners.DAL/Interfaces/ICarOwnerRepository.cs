using CarsNOwners.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsNOwners.DAL.Interfaces
{
    public interface ICarOwnerRepository
    {
        IEnumerable<Car> GetOwnerCars(int ownerId);
        IEnumerable<Car> GetNotOwnerCars(int ownerId);
        Task SetOwnerToCarAsync(int ownerId, int carId);
        Task DeleteCarFromOwnerAsync(int ownerId, int carId);
    }
}

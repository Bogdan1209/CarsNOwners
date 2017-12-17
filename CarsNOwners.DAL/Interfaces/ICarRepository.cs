using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.DAL.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Task<Car> GetAsync(int id);
        void Create(Car item);
        void Update(Car item);
        void Delete(int id);
    }
}

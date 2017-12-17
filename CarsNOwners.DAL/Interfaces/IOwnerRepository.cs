using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.DAL.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Task<Owner> GetAsync(int id);
        void Create(Owner item);
        void Update(Owner item);
        void Delete(int id);
    }
}

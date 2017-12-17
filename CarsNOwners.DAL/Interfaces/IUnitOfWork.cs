using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsNOwners.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ICarRepository Cars { get; }
        IOwnerRepository Owners { get; }
        ICarOwnerRepository CarOwners { get; }
        void Save();
        Task SaveAsync();
    }
}

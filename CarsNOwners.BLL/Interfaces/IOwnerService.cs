using System.Collections.Generic;
using System.Threading.Tasks;
using CarsNOwners.BLL.DTO;

namespace CarsNOwners.BLL.Interfaces
{
    public interface IOwnerService
    {
        void CreateOwner(OwnerDTO item);
        void UpdateOwner(OwnerDTO item);
        void DeleteOwner(int id);
        IEnumerable<OwnerDTO> GetAllOwners();
        Task<OwnerDTO> GetOwnerAsync(int id);
        void Dispose();
    }
}

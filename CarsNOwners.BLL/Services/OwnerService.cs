using System.Collections.Generic;
using System.Threading.Tasks;
using CarsNOwners.BLL.Interfaces;
using CarsNOwners.BLL.DTO;
using CarsNOwners.DAL.Interfaces;
using AutoMapper;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.BLL.Services
{
    public class OwnerService: IOwnerService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;

        public OwnerService(IUnitOfWork uow)
        {
            Database = uow;
            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<OwnerDTO,Owner>()
            );
            mapper = config.CreateMapper();
        }

        public void CreateOwner(OwnerDTO item) {
            var owner = mapper.Map<OwnerDTO, Owner>(item);
            Database.Owners.Create(owner);
            Database.Save();
        }

        public void UpdateOwner(OwnerDTO item) {
            var owner = mapper.Map<OwnerDTO, Owner>(item);
            Database.Owners.Update(owner);
            Database.Save();
        }

        public void DeleteOwner(int id) {
            Database.Owners.Delete(id);
            Database.Save();
        }

        public IEnumerable<OwnerDTO> GetAllOwners() {
            
            var owners = Database.Owners.GetAll();
            return mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDTO>>(owners);
        }

        public async Task<OwnerDTO> GetOwnerAsync(int id) {
            var owner = await Database.Owners.GetAsync(id);
            return mapper.Map<Owner, OwnerDTO>(owner);
            
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

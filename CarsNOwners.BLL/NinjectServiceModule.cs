using Ninject.Modules;
using CarsNOwners.DAL.Repositiries;
using CarsNOwners.DAL.Interfaces;

namespace CarsNOwners.BLL
{
    public class ServiceModule: NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}

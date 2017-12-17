using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsNOwners.DAL.Interfaces;

namespace CarsNOwners.DAL.Repositiries
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppContext db;
        private CarRepository carRepository;
        private OwnerRepository ownerRepository;
        private CarOwnerRepository carOwnerRepository;

        public UnitOfWork()
        {
            db = new AppContext();
        }

        public ICarRepository Cars {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public ICarOwnerRepository CarOwners
        {
            get
            {
                if (carOwnerRepository == null)
                    carOwnerRepository = new CarOwnerRepository(db);
                return carOwnerRepository;
            }
        }

        public IOwnerRepository Owners
        {
            get
            {
                if (ownerRepository == null)
                    ownerRepository = new OwnerRepository(db);
                return ownerRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

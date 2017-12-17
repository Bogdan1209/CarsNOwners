using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CarsNOwners.DAL.Entities;
using CarsNOwners.DAL.Interfaces;

namespace CarsNOwners.DAL.Repositiries
{
    public class CarOwnerRepository:ICarOwnerRepository
    {
        private AppContext db;

        public CarOwnerRepository(AppContext appContext)
        {
            this.db = appContext;
        }

        public IEnumerable<Car> GetOwnerCars(int ownerId)
        {
            var owner = db.Owners.Include(co => co.CarOwners.Select(c => c.Car)).FirstOrDefault(o => o.Id == ownerId);
            var cars = owner.CarOwners.Select(c => c.Car).ToList();
            return cars;
        }

        public IEnumerable<Car> GetNotOwnerCars(int ownerId)
        {
            var cars = db.Cars.Where(i => !i.CarOwners.Any(t => t.OwnerId == ownerId)).ToList();
            return cars;
        }

        public async Task SetOwnerToCarAsync(int ownerId, int carId)
        {
            var owner = await db.Owners.FindAsync(ownerId);
            var car = await db.Cars.FindAsync(carId);
            
            if (owner != null && car != null)
            {
                var carOwner = new CarOwner() { OwnerId = ownerId, CarId = carId };
                db.CarOwners.Add(carOwner);
            }

        }

        public async Task DeleteCarFromOwnerAsync(int ownerId, int carId)
        {
            var carOwner = await db.CarOwners.FirstOrDefaultAsync(o => o.CarId == carId && o.OwnerId == ownerId);
            if (carOwner != null)
            {
                db.CarOwners.Remove(carOwner);
            }
        }
    }
}

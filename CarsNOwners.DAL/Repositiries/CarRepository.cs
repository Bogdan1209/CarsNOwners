using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsNOwners.DAL.Interfaces;
using CarsNOwners.DAL.Entities;
using System.Data.Entity;

namespace CarsNOwners.DAL.Repositiries
{
    class CarRepository:ICarRepository
    {
        private AppContext db;

        public CarRepository(AppContext appContext)
        {
            this.db = appContext;
        }

        public IEnumerable<Car> GetAll() {
            return db.Cars;
        }

        public async Task<Car> GetAsync(int id) {
            return await db.Cars.FindAsync(id);
        }

        public void Create(Car item) {
            db.Cars.Add(item);
        }

        public void Update(Car item) {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }
    }
}

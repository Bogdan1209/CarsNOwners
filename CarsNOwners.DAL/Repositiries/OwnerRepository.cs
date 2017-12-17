using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarsNOwners.DAL.Interfaces;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.DAL.Repositiries
{
    public class OwnerRepository:IOwnerRepository
    {
        private AppContext db;
        static object deleteLocker = new object();

        public OwnerRepository(AppContext appContext)
        {
            this.db = appContext;
        }
        public IEnumerable<Owner> GetAll() {
            return db.Owners;
        }

        public async Task<Owner> GetAsync(int id) {
            return await db.Owners.FindAsync(id);
        }
        
        public void Create(Owner item) {
            db.Owners.Add(item);
        }

        public void Update(Owner item) {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            lock (deleteLocker)
            {
                var owner = db.Owners.Find(id);
                if (owner != null)
                {
                    db.Owners.Remove(owner);
                }
            }
        }
    }
}

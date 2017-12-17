using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarsNOwners.DAL.Entities;

namespace CarsNOwners.DAL
{
    public class AppContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOwner>()
                .HasKey(t => new { t.OwnerId, t.CarId });

            modelBuilder.Entity<CarOwner>()
                .HasRequired(sc => sc.Owner)
                .WithMany(s => s.CarOwners)
                .HasForeignKey(sc => sc.OwnerId);

            modelBuilder.Entity<CarOwner>()
                .HasRequired(sc => sc.Car)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.CarId);
        }

        public AppContext() : base("DbConnection"){ }
    }
}

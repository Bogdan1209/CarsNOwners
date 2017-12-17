using System;
using System.Collections.Generic;
using System.Text;

namespace CarsNOwners.DAL.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int YearOfBirth { get; set; }
        public int ExpirienceOfDriving { get; set; }
        public ICollection<CarOwner> CarOwners { get; set; }
        public Owner()
        {
            CarOwners = new List<CarOwner>();
        }
    }
}

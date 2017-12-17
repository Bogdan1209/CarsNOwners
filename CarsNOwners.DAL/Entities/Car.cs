using System;
using System.Collections.Generic;

namespace CarsNOwners.DAL.Entities
{
    public class Car : IEquatable<Car>
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string TypeOfAuto { get; set; }
        public double Price { get; set; }
        public int YearOfIssue { get; set; }
        public ICollection<CarOwner> CarOwners { get; set; }
        public Car()
        {
            CarOwners = new List<CarOwner>();
        }

        public bool Equals(Car other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return Model.Equals(other.Model) &&
                    Brand.Equals(other.Brand) &&
                    TypeOfAuto.Equals(other.TypeOfAuto) &&
                    Price.Equals(other.TypeOfAuto) &&
                    YearOfIssue.Equals(other.YearOfIssue);
        }

        public override int GetHashCode()
        {
            int hashModel = Model == null ? 0 : Model.GetHashCode();
            int hashId = Id.GetHashCode();
            return hashId ^ hashModel;
        }

    }
}

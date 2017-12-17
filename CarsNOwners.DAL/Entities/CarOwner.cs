using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsNOwners.DAL.Entities
{
    public class CarOwner
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}

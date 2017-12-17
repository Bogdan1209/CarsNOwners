using CarsNOwners.BLL.Interfaces;
using CarsNOwners.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsNOwners.Presentation.Utils
{
    public class OwnerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOwnerService>().To<OwnerService>();
            Bind<ICarSevice>().To<CarService>();
            Bind<ICarOwnerService>().To<CarOwnerService>();
        }
    }
}
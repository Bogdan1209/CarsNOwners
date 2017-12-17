using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsNOwners.BLL.Interfaces;
using CarsNOwners.BLL.DTO;
using CarsNOwners.Presentation.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace CarsNOwners.Presentation.Controllers
{
    public class HomeController : Controller
    {
        IOwnerService ownerService;
        ICarOwnerService carOwnerService;
        IMapper mapper;

        public HomeController(IOwnerService ownerService, ICarOwnerService carOwnerService)
        {
            this.carOwnerService = carOwnerService;
            this.ownerService = ownerService;
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<OwnerViewModel, OwnerDTO>()
            );
            mapper = config.CreateMapper();
        }

        public ActionResult Index()
        {
            var ownerDtos = ownerService.GetAllOwners();
            var owners = mapper.Map<IEnumerable<OwnerDTO>, List<OwnerViewModel>>(ownerDtos);
            return View(owners);
        }

        [HttpGet]
        public ActionResult OwnerCars(int id)
        {
            var carDtos = carOwnerService.GetOwnerCars(id);
            var ownerCars = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(carDtos);
            return View(ownerCars);
        }

        [HttpPost]
        public async Task AddCarToOwnerAsync(int carId)
        {
            var ownerIdStr = Request.UrlReferrer.Segments[3];
            int ownerId;
            if (Int32.TryParse(ownerIdStr, out ownerId))
                await carOwnerService.SetOwnerToCarAsync(ownerId, carId);
        }

        [HttpPost]
        public async Task DeleteCarFromOwnerAsync(int carId)
        {
            var ownerIdStr = Request.UrlReferrer.Segments[3];
            int ownerId;
            if (Int32.TryParse(ownerIdStr, out ownerId))
                await carOwnerService.DeleteCarFromOwnerAsync(ownerId, carId);
        }

        [HttpPost]
        public void DeleteOwner(int id)
        {
            ownerService.DeleteOwner(id);
        }

        public ActionResult CarsNotBelongToOwner()
        {
            var ownerIdStr = Request.Url.Segments[3];
            int ownerId;
            if (Int32.TryParse(ownerIdStr, out ownerId))
            {
                var cars = carOwnerService.GetNotOwnerCars(ownerId);
                return PartialView(mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(cars));
            }
            return PartialView();

        }

        [HttpPost]
        public void AddOwner(OwnerViewModel ownerVM)
        {
            var owner = mapper.Map<OwnerViewModel, OwnerDTO>(ownerVM);
            ownerService.CreateOwner(owner);
        }

        [HttpPost]
        public void UpdateOwner(OwnerViewModel ownerVM)
       {
            var owner = mapper.Map<OwnerViewModel, OwnerDTO>(ownerVM);
            ownerService.UpdateOwner(owner);
        }

        protected override void Dispose(bool disposing)
        {
            ownerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
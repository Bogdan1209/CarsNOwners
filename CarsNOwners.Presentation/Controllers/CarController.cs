using AutoMapper;
using CarsNOwners.BLL.DTO;
using CarsNOwners.BLL.Interfaces;
using CarsNOwners.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsNOwners.Presentation.Controllers
{
    public class CarController : Controller
    {
        ICarSevice carService;
        ICarOwnerService carOwnerService;
        IMapper mapper;

        public CarController(ICarSevice carService, ICarOwnerService carOwnerService)
        {
            this.carOwnerService = carOwnerService;
            this.carService = carService;
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<CarViewModel, CarDTO>()
            );
            mapper = config.CreateMapper();
        }

        public ActionResult Cars()
        {
            IEnumerable<CarDTO> carDtos = carService.GetAllCars();
            var cars = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(carDtos);
            return View(cars);
        }

        [HttpPost]
        public void DeleteCar(int id)
        {
            carService.DeleteCar(id);
        }

        [HttpPost]
        public void AddCar(CarViewModel carVM)
        {
            var car = mapper.Map<CarViewModel, CarDTO>(carVM);
            carService.CreateCar(car);
        }

        [HttpPost]
        public void UpdateCar(CarViewModel carVM)
        {
            var car = mapper.Map<CarViewModel, CarDTO>(carVM);
            carService.UpdateCar(car);
        }
    }
}
using System;
using ConfigureServices.Models.CarDto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfigureServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class CarDtoController : ControllerBase
    {
        [HttpGet()]

        public CarDto Get()
        {

            Car car = new()
            {
                Color = CarColor.Black,
                Manufacturer = new Manufacturer(1, "Bosch", "descr"),
                Name = "Name",
                NumberOfSeats = 1,
                Tires = new List<Tire> { new Tire { Id = 1, Description = "Conti" }, new Tire { Id = 2, Description = "Yoko" } }
            };

            throw new NotImplementedException();
            CarDto carDto = CarMapper.MapCarToCarDto(car);
            return carDto;
        }
    }
}

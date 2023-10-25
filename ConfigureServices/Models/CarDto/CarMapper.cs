using global::Riok.Mapperly.Abstractions;
using Riok.Mapperly.Abstractions;
using System.Linq;
using System.Xml;

namespace ConfigureServices.Models.CarDto
{

    // Enums of source and target have different numeric values -> use ByName strategy to map them
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public static partial class CarMapper
    {

        public static  CarDto MapCarToCarDto(Car car)
        {
            // custom before map code...
            CarDto dto = CarToDto(car);

            dto.Tires = car.Tires.Select(tyre => new TireDto { Id = tyre.Id, FullDescription = $"{tyre.Id} {tyre.Description}" }).ToList();
            //foreach (var item in dto.Producer)
            //{
            //    item. = car;
            //}
            return dto;
        }

        [MapProperty(nameof(Car.Manufacturer), nameof(CarDto.Producer))] // Map property with a different name in the target type
        [MapProperty(nameof(Car.NumberOfSeats), nameof(CarDto.NumberOfSeatsAll))]
        [MapperIgnoreSource(nameof(Car.Tires))]
        public static partial CarDto CarToDto(Car car);
    }

    

    
}

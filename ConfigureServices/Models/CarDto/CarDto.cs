using System.Collections.Generic;

namespace ConfigureServices.Models.CarDto
{
    public class CarDto
    {
        public string Name { get; set; } = string.Empty;

        public int NumberOfSeatsAll { get; set; }

        public CarColorDto Color { get; set; }

        public ProducerDto? Producer { get; set; }

        public List<TireDto>? Tires { get; set; }
    }

    // Intentionally use different numeric values for demonstration purposes
    public enum CarColorDto
    {
        Yellow = 1,
        Green = 2,
        Black = 3,
        Blue = 4,
    }

    // The manufacturer, but named differently for demonstration purposes
    public class ProducerDto
    {
        public ProducerDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

      //  public string Description { get; }
    }

    public class TireDto
    {
        public int Id { get; set; }
        //public string Description { get; set; } = string.Empty;
        public string FullDescription { get; set; }

    }
}

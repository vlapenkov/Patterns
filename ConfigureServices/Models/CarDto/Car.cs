using System.Collections.Generic;

namespace ConfigureServices.Models.CarDto
{
    public class Car
    {
        public string Name { get; set; } = string.Empty;

        public int NumberOfSeats { get; set; }

        public CarColor Color { get; set; }

        public Manufacturer? Manufacturer { get; set; }

        public List<Tire> Tires { get; set; } = new List<Tire>();
    }

    public enum CarColor
    {
        Black = 1,
        Blue = 2,
        White = 3,
    }

    public class Manufacturer
    {
        public Manufacturer(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; }

        public string Name { get; }

       public string Description { get; }
    }

    public class Tire
    {
        public int Id { get; init; }
        public string Description { get; set; } = string.Empty;
    }
}

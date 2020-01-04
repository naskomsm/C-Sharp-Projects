namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.Collections.Generic;

    public class Brakes
    {
        public int Id { get; set; }

        public WheelDrive WheelDrive { get; set; }

        public bool ABS { get; set; }

        public string SteeringType { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}

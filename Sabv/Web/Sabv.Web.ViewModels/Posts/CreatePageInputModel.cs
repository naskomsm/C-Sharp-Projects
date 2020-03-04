namespace Sabv.Web.ViewModels.Posts
{
    using Sabv.Data.Models.Enums;

    public class CreatePageInputModel
    {
        public string Category { get; set; }

        public Condition Condition { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Modification { get; set; }

        public EngineType EngineType { get; set; }

        public int Horsepower { get; set; }

        public Eurostandard Eurostandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string VehicleCategory { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string City { get; set; }

        public int Mileage { get; set; }

        public string Descripton { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        // Comfort
        public bool ASS { get; set; }

        public bool Bluetooth { get; set; }

        public bool DVD { get; set; }

        public bool Steptronic { get; set; }

        public bool USB { get; set; }

        public bool Airmatic { get; set; }

        public bool Keyless { get; set; }

        public bool BordComputer { get; set; }

        public bool LightSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool EPS { get; set; }

        public bool Navigation { get; set; }

        public bool SeatHeat { get; set; }

        public bool ACC { get; set; }

        // Safety
        public bool ASC { get; set; }

        public bool AFL { get; set; }

        public bool ABS { get; set; }

        public bool Airbags { get; set; }

        public bool EBD { get; set; }

        public bool ESP { get; set; }

        public bool TPMS { get; set; }

        public bool PDC { get; set; }

        public bool Isofix { get; set; }

        public bool DSA { get; set; }

        public bool ASR { get; set; }

        public bool DBS { get; set; }

        public bool Distronic { get; set; }

        public bool HDC { get; set; }

        public bool BAS { get; set; }

        // Exterior
        public bool LED { get; set; }

        public bool Rims { get; set; }

        public bool Metalic { get; set; }

        public bool FourDoors { get; set; }

        // Others
        public bool AllWheelDrive { get; set; }

        public bool LongBase { get; set; }

        public bool Service { get; set; }
    }
}

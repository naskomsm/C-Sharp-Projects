namespace Sabv.Services.Models.MainInfos
{
    using System;

    public class AddMainInfoModel
    {
        public int EngineType { get; set; }

        public int TransmissionType { get; set; }

        public int Horsepower { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public DateTime VehicleCreatedOn { get; set; }
    }
}

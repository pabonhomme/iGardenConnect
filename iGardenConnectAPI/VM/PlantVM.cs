namespace VM
{
    public class PlantVM
    {
        public int IdPlant { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime? WateringInterval { get; set; }
        public double? OptimalTemperature { get; set; }
        public double? SoilMoisture { get; set; }
        public double? AirMoisture { get; set; }
        public double? Light { get; set; }

    }
}
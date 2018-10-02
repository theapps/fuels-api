namespace api.ViewModels
{
    public class VehicleCreateDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int FuelTypeId { get; set; }
        public string Comments { get; set; }
    }
}
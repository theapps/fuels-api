namespace api.ViewModels
{
    public class VehicleEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int FuelTypeId { get; set; }
        public string Comments { get; set; }
    }
}
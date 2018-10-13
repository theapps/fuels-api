using System;

namespace api.ViewModels
{
    public class VehicleListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string FuelTypeName { get; set; }
        public string Rca { get; set; }
        public string Itp { get; set; }
        public string Comments { get; set; }
    }
}
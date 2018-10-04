using System;

namespace api.ViewModels
{
    public class FuelListItemDto
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string Date { get; set; }
        public decimal Kms { get; set; }
        public decimal Litres { get; set; }
        public decimal Price { get; set; }
        public decimal LitrePrice { get; set; }
        public bool IsPartial { get; set; } = false;

    }
}
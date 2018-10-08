using System;
using System.ComponentModel.DataAnnotations;

namespace api.ViewModels
{
    public class FuelEditDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }   
        public DateTime Date { get; set; }
        public decimal Kms { get; set; }
        public decimal Litres { get; set; }
        public decimal Price { get; set; }
        public bool IsPartial { get; set; } = false;

        [MaxLength(4000)] 
        public string Comments { get; set; }
        public override string ToString()
        {
            return $"{Comments} - {IsPartial}";
        }
    }
}
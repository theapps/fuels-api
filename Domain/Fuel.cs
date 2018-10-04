using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace api.Domain
{
    public class Fuel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }
        public decimal Kms { get; set; }
        public decimal Litres { get; set; }
        public decimal Price { get; set; }
        public decimal LitrePrice { get; set; }
        public bool IsPartial { get; set; } = false;

        [MaxLength(4000)] 
        public string Comments { get; set; }

        public void CalculatePricePerLitre()
        {
            LitrePrice = Math.Round(Price / Litres, 2);;
        }
    }
}
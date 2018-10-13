using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace api.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int? AccountId { get; set; }
        public virtual  Account Account { get; set; }
        public int FuelTypeId { get; set; }
        public virtual FuelType FuelType { get; set; }
        public DateTime? Rca { get; set; }
        public DateTime? Itp { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public IList<Fuel> Fuels { get; set; }

        public Vehicle()
        {
            Fuels = new List<Fuel>();
        }
    }
}
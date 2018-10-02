using System.Collections;
using System.Collections.Generic;

namespace api.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Telephone { get; set; }
        public bool IsBlocked { get; set; }

        public IList<Vehicle> Vehicles { get; set; }

        public Account()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
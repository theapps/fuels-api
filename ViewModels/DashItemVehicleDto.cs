namespace api.ViewModels
{
 
        public class DashItemVehicleDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Rca { get; set; } 
            public bool? RcaExpired { get; set; }
            public string Itp { get; set; }
            public bool? ItpExpired { get; set; }
            
        }
   
}
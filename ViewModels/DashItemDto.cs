using System.Collections.Generic;
using api.ViewModelss;

namespace api.ViewModels
{
       public class DashItemDto
        {
            public DashItemVehicleDto Vehicle { get; set; }

            public List<DashItemFuelsDto> Fuels { get; set; }

            public DashItemDto()
            {
                Fuels = new List<DashItemFuelsDto>();
            }
        }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using api.Database;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private AppDb _db;
        private IUserService _userService;

        public DashboardController(AppDb db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public class DashItemVehicleDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class DashItemFuelsDto
        {
            public string Date { get; set; }
            public decimal Consumption { get; set; }
        }

        public class DashItemDto
        {
            public DashItemVehicleDto Vehicle { get; set; }

            public List<DashItemFuelsDto> Fuels { get; set; }

            public DashItemDto()
            {
                Fuels = new List<DashItemFuelsDto>();
            }
        }


        public ActionResult Get()
        {
            var minDate = DateTime.Now.AddMonths(-4);
            //TODO: Get the vehicles for the guy
            var fuelsGrouped = _db.Fuels.Where(x => x.Vehicle.AccountId == _userService.CurrentUserId
                                                    && x.Date > minDate
                )
                .Include(x => x.Vehicle)
                .OrderBy(x => x.Vehicle.Name)
                .ThenByDescending(x => x.Date)
                .GroupBy(x => x.Vehicle)
                .AsNoTracking()
                .ToList();

            var withFuels = fuelsGrouped.Select(x =>
                new DashItemDto
                {
                    Vehicle = new DashItemVehicleDto {Id = x.Key.Id, Name = x.Key.Name},
                    Fuels = x.Select(v =>
                        new DashItemFuelsDto
                        {
                            Date = v.Date.ToString("yyyy-MM-dd"),
                            Consumption = v.FuelConsumption
                        }).ToList()
                }).ToList();

            var withoutFuels = 
                _db.Vehicles
                    .Where(x => x.AccountId == _userService.CurrentUserId &&
                                x.Fuels.Count == 0)
                    .AsNoTracking()
                    .Select(x => new DashItemDto{
                                Vehicle = new DashItemVehicleDto
                                {
                                    Id = x.Id, 
                                    Name = x.Name
                                }})
                .ToList();

            var model = new
            {
                Items = withFuels.Union(withoutFuels).OrderByDescending(x => x.Fuels.Count),
                Fuels = _db.Fuels.Count(x => x.Vehicle.AccountId == _userService.CurrentUserId),
                Vehicles = _db.Vehicles.Count(x => x.AccountId == _userService.CurrentUserId)
            };
            return Ok(model);
        }
    }
}
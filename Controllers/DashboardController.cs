using System;
using System.Linq;
using api.Database;
using api.Services;
using api.ViewModels;
using api.ViewModelss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public partial class DashboardController : ControllerBase
    {
        private readonly AppDb _db;
        private readonly IUserService _userService;

        public DashboardController(AppDb db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }


        public ActionResult Get()
        {
            var minDate = DateTime.Now.AddMonths(-4);
            //TODO: Get the vehicles for the guy
            var fuelsGrouped = _db.Fuels.Where(x => x.Vehicle.AccountId == _userService.CurrentUserId
                                                    && x.Date > minDate)
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
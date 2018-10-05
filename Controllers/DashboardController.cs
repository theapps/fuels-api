using System;
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

        public ActionResult Get()
        {
            var minDate = DateTime.Now.AddMonths(-4);
            //TODO: Get the vehicles for the guy
            var fuelsGrouped = _db.Fuels.Where(x => x.Vehicle.AccountId == _userService.CurrentUserId 
                                                    //&& x.Date > minDate 
                                                    )
                .Include(x => x.Vehicle)
                .OrderBy(x=>x.Vehicle.Name)
                .ThenByDescending(x => x.Date)
                .GroupBy(x => x.Vehicle)
                .ToList();

            var data = fuelsGrouped.Select(x =>
                new
                {
                    Vehicle = new { Id =  x.Key.Id, Name = x.Key.Name},
                    Fuels = x.Select(v =>
                        new
                        {
                            Date =v.Date.ToString("yyyy-MM-dd"),
                            Consumption = v.FuelConsumption
                        })
                }).ToList();

            //TODO: Get the fuel consumption

            return Ok(data);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using api.Database;
using api.Domain;
using api.Services;
using api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VehiclesController: ControllerBase
    {
        private IMapper _mapper;
        private AppDb _db;
        private IUserService _userService;

        public VehiclesController(AppDb db, IMapper mapper, IUserService userService)
        {
            _db = db;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VehicleCreateDto model)
        {
            var vehicle = _mapper.Map<Vehicle>(model);
            vehicle.AccountId = _userService.CurrentUserId;  
            _db.Add(vehicle);
            _db.SaveChanges();
            return Created("", model);
        }

        public ActionResult<List<Vehicle>> Get()
        {
            var vehicles = _db.Vehicles.Include(x=>x.FuelType).ToList();

            var model = _mapper.Map<List<VehicleDashboardDto>>(vehicles);
            
            return Ok(model);
        }
        
        [HttpPost]
        [Route("{id}/fuels")]
        public ActionResult Post(int id, [FromBody] FuelCreateDto model)
        {
            var fuel = _mapper.Map<Fuel>(model);
            //TODO: validate the vehicle belongs to the current user
            fuel.VehicleId = id;
            fuel.CalculatePricePerLitre();
            _db.Add(fuel);
            _db.SaveChanges();
            return Created("", model);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Del(int id)
        {
            var v = _db.Vehicles.FirstOrDefault(x => x.Id == id && x.AccountId == _userService.CurrentUserId);
            if (v == null) return BadRequest();
            _db.Vehicles.Remove(v);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
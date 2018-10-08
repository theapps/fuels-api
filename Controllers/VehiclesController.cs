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
            var vehicles = _db.Vehicles
                                .Include(x=>x.FuelType)
                                .Where(x=>x.AccountId == _userService.CurrentUserId)
                                .AsNoTracking().ToList();

            var model = _mapper.Map<List<VehicleDashboardDto>>(vehicles);
            
            return Ok(model);
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Vehicle>> Get(int id)
        {
            var vehicle = _db.Vehicles
                                .FirstOrDefault(x=>x.AccountId == _userService.CurrentUserId &&
                                          x.Id == id);
            if (vehicle == null) return BadRequest();
            
            var model = _mapper.Map<VehicleEditDto>(vehicle);
            
            return Ok(model);
        }
        
        [HttpPatch]
        public ActionResult<List<Vehicle>> Patch([FromBody] VehicleEditDto model)
        {
            var vehicle = _db.Vehicles
                .FirstOrDefault(x=>x.AccountId == _userService.CurrentUserId &&
                                   x.Id == model.Id);
            if (vehicle == null) return BadRequest();

            _mapper.Map(model, vehicle);

            _db.SaveChanges();
          //  var model = _mapper.Map<VehicleEditDto>(vehicle);
            
            return NoContent();
        }
        
        

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Del(int id)
        {
            if (_db.Fuels.Any(x => x.VehicleId == id)) return BadRequest();
            var v = _db.Vehicles.FirstOrDefault(x => x.Id == id && x.AccountId == _userService.CurrentUserId);
            if (v == null) return BadRequest();
            _db.Vehicles.Remove(v);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
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
    public class FuelsController: ControllerBase
    {
        private IMapper _mapper;
        private AppDb _db;
        private IUserService _userService;


        public FuelsController(AppDb db, IMapper mapper, IUserService userService)
        {
            _db = db;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<FuelCreateDto>> Gets(int page=1)
        {
            int pageSize = 10;
            
            var fuels = _db.Fuels.Include(x => x.Vehicle)
                            .Where(x=>x.Vehicle.AccountId == _userService.CurrentUserId)
                            .OrderBy(x=>x.Vehicle.Name)
                            .ThenByDescending(x=>x.Date)
                            .Skip(pageSize * (page -1))
                            .Take(pageSize)
                            .ToList();
            var fuelsDtos = _mapper.Map<List<FuelListItemDto>>(fuels);
            return Ok(fuelsDtos);
        }

     

        [Route("{id}")]
        public ActionResult<FuelEditDto> Get(int id)
        {
            var fuel = _db.Fuels.FirstOrDefault(x => x.Vehicle.AccountId == _userService.CurrentUserId && x.Id == id);
            if (fuel == null) return BadRequest();
            return Ok(_mapper.Map<FuelEditDto>(fuel));
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] FuelCreateDto model)
        {
            
            if (!_db.Vehicles.Any(x => x.Id == model.VehicleId && x.Account.Id == _userService.CurrentUserId))
                return BadRequest();

            var fuel = _mapper.Map<Fuel>(model);
            fuel.CalculatePricePerLitre();
            _db.Add(fuel);
            _db.SaveChanges();
            CalculateFuelConsumption(fuel);
            return Created("", model);
        }  
           
        [HttpPatch]
        public ActionResult<FuelEditDto> Patch( [FromBody] FuelEditDto model)
        {            
            var fuel = _db.Fuels.FirstOrDefault(x => x.Vehicle.AccountId == _userService.CurrentUserId && x.Id == model.Id);
            if (fuel == null) return BadRequest();

            _mapper.Map(model, fuel);
            fuel.CalculatePricePerLitre();
            CalculateFuelConsumption(fuel);
            
            _db.SaveChanges();
            return Ok();            
        }
        
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Del(int id) 
        {
            var fuel = _db.Fuels.FirstOrDefault(x => x.Id == id && x.Vehicle.AccountId == _userService.CurrentUserId);
            if (fuel == null) return BadRequest();
            _db.Fuels.Remove(fuel);
            _db.SaveChanges();
            return NoContent();
        }

        
        private void CalculateFuelConsumption(Fuel fuel)
        {
            //get last fuel for the car that is not partial
            var lastFuel = _db.Fuels
                .Where(x => x.VehicleId == fuel.VehicleId &&
                            x.Kms <= fuel.Kms
                            && x.IsPartial == false
                            && x.Id != fuel.Id)
                .OrderByDescending(x => x.Date)
                .Take(1)
                .FirstOrDefault();

            if (lastFuel == null) return;
            
            fuel.CalculateConsumption(lastFuel);
            _db.SaveChanges();
        }

    }
}
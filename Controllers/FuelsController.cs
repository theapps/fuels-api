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

        public ActionResult<List<FuelCreateDto>> Get() 
        {
            var fuels = _db.Fuels.Include(x => x.Vehicle)
                            .Where(x=>x.Vehicle.AccountId == _userService.CurrentUserId)
                            .ToList();
            var fuelsDtos = _mapper.Map<List<FuelListItemDto>>(fuels);
            return Ok(fuelsDtos);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Del(int id) 
        {
            //TODO: check the fuel of a cat of the user
            var fuel = _db.Fuels.FirstOrDefault(x => x.Id == id && x.Vehicle.AccountId == _userService.CurrentUserId);
            if (fuel == null) return BadRequest();
            _db.Fuels.Remove(fuel);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
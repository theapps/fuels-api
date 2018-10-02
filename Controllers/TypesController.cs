using System.Collections.Generic;
using System.Linq;
using api.Database;
using api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly AppDb _db;

        public TypesController(AppDb db) => _db = db;

        public ActionResult<List<FuelType>> Get()
        {
            return Ok(_db.FuelTypes.ToList());
        }
    }
}
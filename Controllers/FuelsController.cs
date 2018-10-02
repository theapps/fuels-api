using api.Database;
using api.Domain;
using api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FuelsController: ControllerBase
    {
        private IMapper _mapper;
        private AppDb _db;

        public FuelsController(AppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

       
    }
}
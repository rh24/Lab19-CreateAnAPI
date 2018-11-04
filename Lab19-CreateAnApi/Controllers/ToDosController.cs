using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab19_CreateAnApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab19_CreateAnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly CreateAnAPIDbContext _context;

        public ToDosController(CreateAnAPIDbContext context)
        {
            _context = context;
        }

        // GET api/ToDos
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _context.ToDos.ToListAsync();
        }
    }
}
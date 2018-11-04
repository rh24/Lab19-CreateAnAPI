using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab19_CreateAnApi.Data;
using Lab19_CreateAnApi.Models;
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
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            return _context.ToDos;
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int? id)
        {
            var todo = _context.ToDos.FirstOrDefault(t => t.ID == id);
            if (todo == null) return NotFound();

            return Ok(todo);
        }
    }
}
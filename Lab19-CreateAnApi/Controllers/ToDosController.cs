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

        // Inject db context
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

        // GET api/ToDos/:id
        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int? id)
        {
            var todo = _context.ToDos.FirstOrDefault(t => t.ID == id);
            if (todo == null) return NotFound();

            return Ok(todo);
        }

        // POST api/ToDos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDo todo)
        {
            await _context.ToDos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Get", new { id = todo.ID });
        }

        // PUT api/ToDos/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDo todo)
        {
            var foundTodo = _context.ToDos.FirstOrDefault(t => t.ID == id);

            if (todo != null) _context.ToDos.Update(todo);
            else await Post(todo);

            return RedirectToAction("Get", new { id = todo.ID });
        }

        // DELETE api/ToDos/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var foundToDo = _context.ToDos.FirstOrDefault(t => t.ID == id);

            if (foundToDo != null) _context.ToDos.Remove(foundToDo);

            return Ok();
        }
    }
}
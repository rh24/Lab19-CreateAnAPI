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
    public class ToDoListsController : ControllerBase
    {
        private readonly CreateAnAPIDbContext _context;

        // Inject db context
        public ToDoListsController(CreateAnAPIDbContext context)
        {
            _context = context;
        }

        // GET api/ToDoLists
        [HttpGet]
        public ActionResult<IEnumerable<ToDoList>> Get()
        {
            return _context.ToDoLists;
        }

        // GET api/ToDoLists/:id
        [HttpGet("{id}")]
        public ActionResult<ToDoList> Get(int? id)
        {
            var list = _context.ToDoLists.FirstOrDefault(t => t.ID == id);
            if (list == null) return NotFound();

            return Ok(list);
        }

        // POST api/ToDoLists
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoList list)
        {
            await _context.ToDoLists.AddAsync(list);
            await _context.SaveChangesAsync();

            return RedirectToAction("Get", new { id = list.ID });
        }

        // PUT api/ToDoLists/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoList list)
        {
            var foundList = _context.ToDoLists.FirstOrDefault(t => t.ID == id);

            if (foundList != null) _context.ToDoLists.Update(list);
            else await Post(list);

            return RedirectToAction("Get", new { id = list.ID });
        }

        // DELETE api/ToDoLists/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var foundList = _context.ToDoLists.FirstOrDefault(t => t.ID == id);

            if (foundList != null) _context.ToDoLists.Remove(foundList);

            return Ok();
        }
    }
}
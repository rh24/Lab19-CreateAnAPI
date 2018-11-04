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
    public class ToDoController : ControllerBase
    {
        private readonly CreateAnAPIDbContext _context;

        public ToDoController(CreateAnAPIDbContext context)
        {
            _context = context;
        }
    }
}
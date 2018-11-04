using Microsoft.EntityFrameworkCore;
using Lab19_CreateAnApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_CreateAnApi.Data
{
    public class CreateAnAPIDbContext : DbContext
    {
        public CreateAnAPIDbContext(DbContextOptions<CreateAnAPIDbContext> options) : base(options)
        {

        }

        DbSet<ToDo> ToDos { get; set; }
        DbSet<ToDoList> ToDoLists { get; set; }
    }
}

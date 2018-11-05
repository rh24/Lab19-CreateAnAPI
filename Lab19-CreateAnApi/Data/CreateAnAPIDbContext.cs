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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                    new ToDo
                    {
                        ID = 2,
                        Name = "Do all the labs",
                        IsComplete = false,
                        ToDoListID = 1
                    },
                    new ToDo
                    {
                        ID = 3,
                        Name = "Buy groceries",
                        IsComplete = true,
                        ToDoListID = 1
                    },
                    new ToDo
                    {
                        ID = 4,
                        Name = "Laundry",
                        IsComplete = true,
                        ToDoListID = 1
                    }
            );
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}

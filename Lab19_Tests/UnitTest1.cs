using System;
using Xunit;
using Lab19_CreateAnApi.Data;
using Microsoft.EntityFrameworkCore;
using Lab19_CreateAnApi.Models;
using System.Linq;

namespace Lab19_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateToDo()
        {
            DbContextOptions<CreateAnAPIDbContext> options = new DbContextOptionsBuilder<CreateAnAPIDbContext>().UseInMemoryDatabase("ToDos").Options;

            using (CreateAnAPIDbContext db = new CreateAnAPIDbContext(options))
            {
                // CREATE
                ToDo td = new ToDo() { Name = "Walk the cat", IsComplete = true };
                db.Add(td);
                db.SaveChanges();

                // READ
                var foundToDo = db.ToDos.FirstOrDefault(todo => todo.ID == td.ID);
                Assert.Equal(td.ID, foundToDo.ID);

                // UPDATE
                foundToDo.Name = "Cook dinner";
                db.Update(foundToDo);
                db.SaveChanges();
                Assert.Equal("Cook dinner", foundToDo.Name);

                // DELETE
                db.Remove(foundToDo);
                db.SaveChanges();
                bool deleted = db.ToDos.FirstOrDefault(t => t.ID == foundToDo.ID) == null;
                Assert.True(deleted);
            }
        }
    }
}

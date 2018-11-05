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
        public void CRUDToDos()
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

        [Fact]
        public void CRUDToDoLists()
        {
            DbContextOptions<CreateAnAPIDbContext> options = new DbContextOptionsBuilder<CreateAnAPIDbContext>().UseInMemoryDatabase("ToDoLists").Options;

            using (CreateAnAPIDbContext db = new CreateAnAPIDbContext(options))
            {
                // CREATE
                ToDoList tdl = new ToDoList() { Name = "Monday errands" };
                db.Add(tdl);
                db.SaveChanges();

                // READ
                var foundToDoList = db.ToDoLists.FirstOrDefault(t => t.ID == tdl.ID);
                Assert.Equal(foundToDoList.ID, tdl.ID);

                // UPDATE
                foundToDoList.Name = "Tuesday errands";
                db.Update(foundToDoList);
                db.SaveChanges();
                Assert.Equal("Tuesday errands", foundToDoList.Name);

                // DELETE
                db.Remove(foundToDoList);
                db.SaveChanges();
                bool deleted = db.ToDoLists.FirstOrDefault(t => t.ID == foundToDoList.ID) == null;
                Assert.True(deleted);
            }
        }

        [Fact]
        public void AddItemsToToDoList()
        {
            ToDoList tdl = new ToDoList() { Name = "Sunday errands" };
            ToDo td = new ToDo() { Name = "Watch tv", IsComplete = false };
            tdl.ToDos.Add(td);
            var foundToDo = tdl.ToDos.First(t => t.Name == td.Name);

            Assert.Equal("Watch tv", foundToDo.Name);
        }

        [Fact]
        public void RemoveItemFromToDoList()
        {
            ToDoList tdl = new ToDoList() { Name = "Sunday errands" };
            ToDo td = new ToDo() { Name = "Watch tv", IsComplete = false };
            td.ToDoList = tdl;
            //tdl.ToDos.Add(td);
            ToDo td2 = new ToDo() { Name = "Feed the cat", IsComplete = true };
            //tdl.ToDos.Remove(td);
            td2.ToDoList = tdl;
            tdl.ToDos.Remove(td);

            var foundToDo = tdl.ToDos.Select(t => t.Name == "Watch tv");
            Assert.Null(foundToDo);
        }
    }
}

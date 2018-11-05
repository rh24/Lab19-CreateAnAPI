using System;
using Xunit;
using Lab19_CreateAnApi.Data;
using Microsoft.EntityFrameworkCore;
using Lab19_CreateAnApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace Lab19_Tests
{
    public class UnitTest1
    {
        /// <summary>
        /// Test CRUD operations on ToDos table.
        /// </summary>
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

        /// <summary>
        /// Test CRUD operations on ToDoLists table and test that ToDos can be added to a ToDoList's ToDo's ICollection, as well as removed from it.
        /// </summary>
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

                // Test Adding to ToDoList
                var foundToDoList = db.ToDoLists.First(t => t.ID == tdl.ID);
                ToDo td = new ToDo() { Name = "Watch tv", IsComplete = false };
                td.ToDoList = foundToDoList;
                foundToDoList.ToDos = new List<ToDo>();
                foundToDoList.ToDos.Add(td);
                var foundToDo = foundToDoList.ToDos.FirstOrDefault(t => t.ID == td.ID);
                Assert.Equal("Watch tv", foundToDo.Name);

                // Test Removing from ToDoList
                foundToDoList.ToDos.Remove(td);
                Assert.Equal(0, foundToDoList.ToDos.Count);

                // READ
                var foundTdl = db.ToDoLists.FirstOrDefault(t => t.ID == tdl.ID);
                Assert.Equal(foundTdl.ID, tdl.ID);

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
    }
}

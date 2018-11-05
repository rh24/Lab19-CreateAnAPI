using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_CreateAnApi.Models
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<ToDo> ToDos { get; set; }
    }
}

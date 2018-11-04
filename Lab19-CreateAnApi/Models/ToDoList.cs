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
        public string DateTime { get; set; } = new DateTime().ToString();

        // Navigation properties
        ICollection<ToDo> ToDos { get; set; }
    }
}

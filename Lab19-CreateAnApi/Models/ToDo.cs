using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_CreateAnApi.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string DateTime { get; set; } = new DateTime().ToString();

        // Navigation Property
        public ToDoList ToDoList { get; set; }
    }
}

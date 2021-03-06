﻿using System;
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
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int ToDoListID { get; set; }

        // Navigation Property
        public ToDoList ToDoList { get; set; }
    }
}

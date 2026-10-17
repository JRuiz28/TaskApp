using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedIn { get; set; }

        public Task()
        {
            ID = 0;
            Name = "";
            Description = "";
            State = "";
            CreatedIn = DateTime.Now;
        }

        public Task(int id, string name, string description, string state)
        {
            ID = id;
            Name = name;
            Description = description;
            State = state;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Models;

namespace TaskApp.Services
{
    public class TaskService
    {

        public List<Task> Select(List<Task> tasks)//(List<Task> tasks, string filter)
        {
            return tasks;
        }

        public Task Create(int ID, string Name, string Descripcion, string State)
        {
            Task newTask = new Task(ID, Name, Descripcion, State);
            return newTask;
        }

        public void Update(Task task)
        {

        }

        public void Delete(int id)
        {

        }
        
    }
}
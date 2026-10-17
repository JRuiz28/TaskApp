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

        public Task SelectByID(List<Task> tasks, int id)
        {
            return tasks.FirstOrDefault(task => task.ID == id);
        }

        public Task Create(int ID, string name, string descripcion, string state)
        {
            Task newTask = new Task(ID, name, descripcion, state);
            return newTask;
        }

        public void Update(List<Task> tasks, int id, string name, string descripcion, string state)
        {
            Task task = tasks.FirstOrDefault(t => t.ID == id);

            if (task != null)
            {
                task.Name = name;
                task.Description = descripcion;
                task.State = state;
            }
        }

        public void Delete(List<Task> tasks, int id)
        {
            
            Task task = tasks.FirstOrDefault(t => t.ID == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
        
    }
}
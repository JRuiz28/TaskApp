using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Models;

namespace TaskApp.Services
{
    public class TaskService
    {

        public List<Task> Select(List<Task> tasks, string filter)
        {
            if (filter == "Pendiente" || filter == "Completado")
            {
                tasks = tasks.FindAll(t => t.State == filter);
            }

            return tasks;
        }

        public Task SelectByID(List<Task> tasks, Guid id)
        {
            return tasks.FirstOrDefault(task => task.ID == id);
        }

        public Task Create(Guid ID, string name, string descripcion, string state)
        {
            Task newTask = new Task(ID, name, descripcion, state);
            return newTask;
        }

        public void Update(List<Task> tasks, Guid id, string name, string descripcion, string state)
        {
            Task task = tasks.FirstOrDefault(t => t.ID == id);

            if (task != null)
            {
                task.Name = name;
                task.Description = descripcion;
                task.State = state;
            }
        }

        public void Delete(List<Task> tasks, Guid id)
        {
            
            Task task = tasks.FirstOrDefault(t => t.ID == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
        
    }
}
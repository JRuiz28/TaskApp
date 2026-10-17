using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.Models;
using TaskApp.Services;

namespace TaskApp.Controllers
{
    public class TasksController : Controller
    {
        private TaskService service = new TaskService();

        private List<Task> GetTasks()
        {
            var tasks = Session["tasks"] as List<Task>;
            if (tasks == null)
            {
                tasks = new List<Task>();
                Session["tasks"] = tasks;
            }
            return tasks;
        }


        // GET: Tasks
        public ActionResult Index()
        {
            var list = service.Select(GetTasks());
            return View(list);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var tasks = GetTasks();
                Task newTask = service.Create(tasks.Count + 1, collection["Name"], collection["Description"], collection["State"]);
                tasks.Add(newTask);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            Task task = service.SelectByID(GetTasks(), id);
            if (task == null) {
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                service.Update(GetTasks(), id, collection["Name"], collection["Description"], collection["State"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            Task task = service.SelectByID(GetTasks(), id);
            if (task == null)
            {
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.Delete(GetTasks(), id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
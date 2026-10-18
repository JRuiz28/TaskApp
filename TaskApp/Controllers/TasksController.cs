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
            return View();
        }

        // Load with Ajax
        public ActionResult List(string filter)
        {
            return PartialView("_table", service.Select(GetTasks(), filter));
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
                Guid id = Guid.NewGuid();
                Task newTask = service.Create(id, collection["Name"], collection["Description"], collection["State"]);
                tasks.Add(newTask);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Default/Edit/5
        public ActionResult Edit(Guid id)
        {
            Task task = service.SelectByID(GetTasks(), id);
            if (task == null) {
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
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
        public ActionResult Delete(Guid id)
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
        public ActionResult Delete(Guid id, FormCollection collection)
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
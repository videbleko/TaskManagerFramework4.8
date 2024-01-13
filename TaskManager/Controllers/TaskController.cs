using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManager.Context;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {

        private TaskDbContext _db = new TaskDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await _db.Tasks.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tasks task)
        {
            if (ModelState.IsValid)
            {
                task.FechaDeCreacion = DateTime.Now;
                _db.Tasks.Add(task);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tasks tasks = _db.Tasks.Find(id);

            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tasks task)
        {
            if (ModelState.IsValid)
            {
                task.FechaDeCreacion = DateTime.Now;
                _db.Entry(task).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
             return RedirectToAction("Index");
            
        }

       
        public async Task<ActionResult> Delete(int id)
        {
            Tasks task = _db.Tasks.Find(id);
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
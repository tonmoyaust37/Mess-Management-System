using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mess_Management_System.Models;

namespace Mess_Management_System.Controllers
{
    public class managersController : Controller
    {
        private messEntities db = new messEntities();

        // GET: managers
        public ActionResult Index()
        {
            var managers = db.managers.Include(m => m.mess_member);
            return View(managers.ToList());
        }

        // GET: managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: managers/Create
        public ActionResult Create()
        {
            ViewBag.managerId = new SelectList(db.mess_member, "userId", "userName");
            return View();
        }

        // POST: managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "managerId")] manager manager)
        {
            if (ModelState.IsValid)
            {
                db.managers.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerId = new SelectList(db.mess_member, "userId", "userName", manager.managerId);
            return View(manager);
        }

        // GET: managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.mess_member, "userId", "userName", manager.managerId);
            return View(manager);
        }

        // POST: managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "managerId")] manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.mess_member, "userId", "userName", manager.managerId);
            return View(manager);
        }

        // GET: managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager manager = db.managers.Find(id);
            db.managers.Remove(manager);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

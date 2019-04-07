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
    public class MonthlyCostsController : Controller
    {
        private messEntities db = new messEntities();

        // GET: MonthlyCosts
        public ActionResult Index()
        {
            var monthlyCosts = db.MonthlyCosts.Include(m => m.manager);
            return View(monthlyCosts.ToList());
        }

        // GET: MonthlyCosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyCost monthlyCost = db.MonthlyCosts.Find(id);
            if (monthlyCost == null)
            {
                return HttpNotFound();
            }
            return View(monthlyCost);
        }

        // GET: MonthlyCosts/Create
        public ActionResult Create()
        {
            ViewBag.managerId = new SelectList(db.managers, "managerId", "managerId");
            return View();
        }

        // POST: MonthlyCosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonthlyCostId,Month_name,total_cost,avg_cost,individual_cost,managerId")] MonthlyCost monthlyCost)
        {
            if (ModelState.IsValid)
            {
                db.MonthlyCosts.Add(monthlyCost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerId = new SelectList(db.managers, "managerId", "managerId", monthlyCost.managerId);
            return View(monthlyCost);
        }

        // GET: MonthlyCosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyCost monthlyCost = db.MonthlyCosts.Find(id);
            if (monthlyCost == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "managerId", monthlyCost.managerId);
            return View(monthlyCost);
        }

        // POST: MonthlyCosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonthlyCostId,Month_name,total_cost,avg_cost,individual_cost,managerId")] MonthlyCost monthlyCost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyCost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerId = new SelectList(db.managers, "managerId", "managerId", monthlyCost.managerId);
            return View(monthlyCost);
        }

        // GET: MonthlyCosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyCost monthlyCost = db.MonthlyCosts.Find(id);
            if (monthlyCost == null)
            {
                return HttpNotFound();
            }
            return View(monthlyCost);
        }

        // POST: MonthlyCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyCost monthlyCost = db.MonthlyCosts.Find(id);
            db.MonthlyCosts.Remove(monthlyCost);
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

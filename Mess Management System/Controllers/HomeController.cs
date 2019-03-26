using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using  Mess_Management_System.Models;

namespace Mess_Management_System.Controllers
{
  
    
    public class HomeController : Controller
    {
        private messEntities db = new messEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(mess_member reg)
        {
            if (ModelState.IsValid)
            {
                db.mess_member.Add(reg);
                db.SaveChanges();
                //ViewBag.Message = "Successfully Registered";
                TempData["status"] = "Success";
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            if (TempData["status"] != null)
            {
                ViewBag.Message = "Successfully Registered";
                TempData.Remove("status");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(mess_member login)
        {
            if (ModelState.IsValid)
            {
                messEntities db = new messEntities();
                var details = (from userlist in db.mess_member
                               where userlist.userEmail == login.userEmail && userlist.userPass == login.userPass
                               select new
                               {
                                   userlist.userId,
                                   userlist.userName
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["Username"] = details.FirstOrDefault().userName;
                    Session["UserId"] = details.FirstOrDefault().userId;
                    return RedirectToAction("Welcome", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(login);
        }


        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult MemberDetails()
        {
            return View(db.mess_member.ToList());
        }

        // GET: PersonalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "naughty");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            mess_member user1 = db.mess_member.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific
        //properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "userId,userName,userEmail,userPass,userPhone")] mess_member user1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MemberDetails");
            }
            return View(user1);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "naughty");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mess_member user1 = db.mess_member.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mess_member user = db.mess_member.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mess_member user = db.mess_member.Find(id);
            db.mess_member.Remove(user);
            db.SaveChanges();
            return RedirectToAction("MemberDetails");
        }

    }
}
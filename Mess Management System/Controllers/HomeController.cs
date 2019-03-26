using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
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


    }
}
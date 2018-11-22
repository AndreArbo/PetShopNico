using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Project_no1.Models;

namespace Project_no1.Controllers
{
    public class HomeController : Controller
    {
        private PetsDBContext db = new PetsDBContext();
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
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult TryLogIn(string Username, string Password)
        {
            var log = from u in db.Users where (string.IsNullOrEmpty(Username) || u.UserName == Username) 
                                            && (string.IsNullOrEmpty(Password) || u.Password == Password)
                      select u;

            if (log.Count() > 0)
            {
                return View("Pets");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
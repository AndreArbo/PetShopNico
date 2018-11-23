using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PetShopNico.DAL;
using PetShopNico.Models;
using System.IO;
using System.Web;

namespace PetShopNico.Controllers
{
    public class LoginController : Controller
    {
        private PetShopNicoContext db = new PetShopNicoContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] Users users)
        {
            
            var result = (from d in db.Users where users.UserName == d.UserName && users.Password == d.Password select d).FirstOrDefault();
            var resultEmployee = (from e in db.Employees where result.ID == e.UsersID select e).FirstOrDefault();
            if (resultEmployee != null )
            {
                System.Web.HttpContext.Current.Session["UserID"] = resultEmployee.UsersID;
                System.Web.HttpContext.Current.Session["Username"] = resultEmployee.Users.UserName;
                System.Web.HttpContext.Current.Session["Password"] = resultEmployee.Users.Password;
                System.Web.HttpContext.Current.Session["EmployeeID"] = resultEmployee.ID;

                return View("./../Employees/Begin",resultEmployee);
            }
            else
            {
                //Return Error
                return View();
            }

        }
    }
}
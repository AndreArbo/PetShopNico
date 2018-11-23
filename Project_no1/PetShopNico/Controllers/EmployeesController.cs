using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetShopNico.DAL;
using PetShopNico.Models;

namespace PetShopNico.Controllers
{
    public class EmployeesController : Controller
    {
        private PetShopNicoContext db = new PetShopNicoContext();

        private bool validatesession()
        {
            
            int EmployeeID = (int)System.Web.HttpContext.Current.Session["EmployeeID"];

            var result = (from e in db.Employees where e.ID == EmployeeID select e).FirstOrDefault();

            bool valid = result != null ? true : false;

            return valid;
        }

        public ActionResult Begin(Employees employee)
        {
            if(validatesession())
            {
                return View(employee);
            }
            else
            {
                return View("~/View/Shared/Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employees employee)
        {
            var result = (from e in db.Employees where e.ID == employee.ID select e).FirstOrDefault();
            result.Name = employee.Name;
            result.Role = employee.Role;
            result.Email = employee.Email;
            result.MobilePhone = employee.MobilePhone;

            db.Entry(result).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        }
}

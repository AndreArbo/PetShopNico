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
using System.IO;

namespace PetShopNico.Controllers
{
    public class EmployeesController : Controller
    {
        private PetShopNicoContext db = new PetShopNicoContext();

        private bool validatesession()
        {
            Employees Result = null;
            int? EmployeeID = System.Web.HttpContext.Current.Session["EmployeeID"] != null ? (int?)System.Web.HttpContext.Current.Session["EmployeeID"] : null;

            if(EmployeeID != null)
            { 
            Result= (from e in db.Employees where e.ID == EmployeeID select e).FirstOrDefault();
            }
            bool valid = Result != null ? true : false;

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
                return View("./../Shared/Error");
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
            return View("Begin",result);
        }

        #region Products
        public ActionResult ProductList()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.PetType).Include(p => p.ProductType);
            if (validatesession())
            {
                return View("Employees/Producst",products.ToList());
            }
            else
            {
                return View("./../Shared/Error");
            }
        }
        public ActionResult CreateProduct()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name");
            ViewBag.PetTypeID = new SelectList(db.PetsTypes, "ID", "Name");
            ViewBag.ProductTypeID = new SelectList(db.ProductsTypes, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "ID,ProductNumber,Image,Price,ProductTypeID,PetTypeID,BrandID")] Products products, HttpPostedFileBase UploadImages)
        {
            MemoryStream target = new MemoryStream();
            UploadImages.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            products.ImageName = Path.GetFileName(UploadImages.FileName); ;

            if (UploadImages != null && UploadImages.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Storage/"), Path.GetFileName(UploadImages.FileName));
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Message = "The File Already Exists in System";
                    }
                    else
                    {
                        UploadImages.SaveAs(path);
                    }

                }
                catch (Exception exception)
                {
                    ViewBag.Message = "ERROR:" + exception.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Specify the file";
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", products.BrandID);
            ViewBag.PetTypeID = new SelectList(db.PetsTypes, "ID", "Name", products.PetTypeID);
            ViewBag.ProductTypeID = new SelectList(db.ProductsTypes, "ID", "Name", products.ProductTypeID);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", products.BrandID);
            ViewBag.PetTypeID = new SelectList(db.PetsTypes, "ID", "Name", products.PetTypeID);
            ViewBag.ProductTypeID = new SelectList(db.ProductsTypes, "ID", "Name", products.ProductTypeID);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "ID,ProductNumber,Image,Price,ProductTypeID,PetTypeID,BrandID")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", products.BrandID);
            ViewBag.PetTypeID = new SelectList(db.PetsTypes, "ID", "Name", products.PetTypeID);
            ViewBag.ProductTypeID = new SelectList(db.ProductsTypes, "ID", "Name", products.ProductTypeID);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

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

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
    public class ProductsController : Controller
    {
        private PetShopNicoContext db = new PetShopNicoContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.PetType).Include(p => p.ProductType);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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

        // GET: Products/Create
        public ActionResult Create()
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
        public ActionResult Create([Bind(Include = "ID,ProductNumber,Image,Price,ProductTypeID,PetTypeID,BrandID")] Products products , HttpPostedFileBase UploadImages)
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
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "ID,ProductNumber,Image,Price,ProductTypeID,PetTypeID,BrandID")] Products products)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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

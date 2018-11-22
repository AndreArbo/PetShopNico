using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_no1.Models;

namespace Project_no1.Controllers
{
    public class TypeUsersController : Controller
    {
        private PetsDBContext db = new PetsDBContext();

        // GET: TypeUsers
        public ActionResult Index()
        {
            return View(db.TypeUsers.ToList());
        }

        // GET: TypeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeUsers typeUsers = db.TypeUsers.Find(id);
            if (typeUsers == null)
            {
                return HttpNotFound();
            }
            return View(typeUsers);
        }

        // GET: TypeUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] TypeUsers typeUsers)
        {
            if (ModelState.IsValid)
            {
                db.TypeUsers.Add(typeUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeUsers);
        }

        // GET: TypeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeUsers typeUsers = db.TypeUsers.Find(id);
            if (typeUsers == null)
            {
                return HttpNotFound();
            }
            return View(typeUsers);
        }

        // POST: TypeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] TypeUsers typeUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeUsers);
        }

        // GET: TypeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeUsers typeUsers = db.TypeUsers.Find(id);
            if (typeUsers == null)
            {
                return HttpNotFound();
            }
            return View(typeUsers);
        }

        // POST: TypeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeUsers typeUsers = db.TypeUsers.Find(id);
            db.TypeUsers.Remove(typeUsers);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniprojektRAM.DataAccessLayer;
using MiniprojektRAM.Models;

namespace MiniprojektRAM.Controllers
{
    public class QuestionCategoriesController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: QuestionCategories
        public ActionResult Index()
        {
            return View(db.QuestionCategory.ToList());
        }

        // GET: QuestionCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory questionCategory = db.QuestionCategory.Find(id);
            if (questionCategory == null)
            {
                return HttpNotFound();
            }
            return View(questionCategory);
        }

        // GET: QuestionCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatName")] QuestionCategory questionCategory)
        {
            if (ModelState.IsValid)
            {
                db.QuestionCategory.Add(questionCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionCategory);
        }

        // GET: QuestionCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory questionCategory = db.QuestionCategory.Find(id);
            if (questionCategory == null)
            {
                return HttpNotFound();
            }
            return View(questionCategory);
        }

        // POST: QuestionCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatName")] QuestionCategory questionCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionCategory);
        }

        // GET: QuestionCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory questionCategory = db.QuestionCategory.Find(id);
            if (questionCategory == null)
            {
                return HttpNotFound();
            }
            return View(questionCategory);
        }

        // POST: QuestionCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionCategory questionCategory = db.QuestionCategory.Find(id);
            db.QuestionCategory.Remove(questionCategory);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalFitnessPlusPlus.Data;
using FinalFitnessPlusPlus.Models;

namespace FinalFitnessPlusPlus.Controllers
{
    public class MuscleGroupsController : Controller
    {
        private FinalFitnessPlusPlusContext db = new FinalFitnessPlusPlusContext();

        // GET: MuscleGroups
        public ActionResult Index()
        {
            // Fetch and return a list of MuscleGroups
            var muscleGroups = db.MuscleGroups.ToList();
            return View(muscleGroups);
        }

        // GET: MuscleGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return HttpNotFound();
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MuscleGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                db.MuscleGroups.Add(muscleGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return HttpNotFound();
            }
            return View(muscleGroup);
        }

        // POST: MuscleGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muscleGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return HttpNotFound();
            }
            return View(muscleGroup);
        }

        // POST: MuscleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var muscleGroup = db.MuscleGroups.Include(mg => mg.Exercises).FirstOrDefault(mg => mg.ID == id);
            db.MuscleGroups.Remove(muscleGroup);
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

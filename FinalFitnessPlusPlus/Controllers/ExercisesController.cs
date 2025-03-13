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
using FinalFitnessPlusPlus.ViewModel;

namespace FinalFitnessPlusPlus.Controllers
{
    public class ExercisesController : Controller
    {
        private FinalFitnessPlusPlusContext db = new FinalFitnessPlusPlusContext();

        public ActionResult Index(int? selectedMuscleGroupId, string search, string sortBy)
        {
            // Instantiate a new ViewModel
            var viewModel = new ExerciseIndexViewModel();

            // Fetch exercises, including muscle group
            var exercises = db.Exercises.Include(e => e.MuscleGroup);

            // Filter by search term if provided
            if (!String.IsNullOrEmpty(search))
            {
                exercises = exercises.Where(e => e.Name.Contains(search) ||
                                                 e.Description.Contains(search) ||
                                                 e.MuscleGroup.Name.Contains(search));
                viewModel.Search = search;
            }

            // Filter by muscle group if provided
            if (selectedMuscleGroupId.HasValue)
            {
                exercises = exercises.Where(e => e.MuscleGroupID == selectedMuscleGroupId.Value);
                viewModel.SelectedMuscleGroupId = selectedMuscleGroupId.Value;
            }

            // Group results by muscle group and count exercises
            viewModel.MuscleWithCount = from matchingExercises in exercises
                                        where matchingExercises.MuscleGroupID != null
                                        group matchingExercises by matchingExercises.MuscleGroup.Name into muscleGroup
                                        select new ExerciseIndexViewModel.MuscleGroupWithCount
                                        {
                                            ID = muscleGroup.Select(m => m.MuscleGroupID).FirstOrDefault() ?? 0, // Corrected
                                            MuscleName = muscleGroup.Key,
                                            ExerciseCount = muscleGroup.Count()
                                        };

            switch (sortBy)
            {
                case "reps_lowest":
                    exercises = exercises.OrderBy(e => e.Repetitions);
                    break;
                case "reps_highest":
                    exercises = exercises.OrderByDescending(e => e.Repetitions);
                    break;
                case "total_lowest":
                    exercises = exercises.OrderBy(e => e.TotalSets);
                    break;
                case "total_highest":
                    exercises = exercises.OrderByDescending(e => e.TotalSets);
                    break;
                default:
                    exercises = exercises.OrderBy(e => e.Name);
                    break;
            }

            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Repetitions low to high", "reps_lowest" },
                {"Repetitions high to low", "reps_highest" },
                {"Total Sets low to high", "total_lowest" },
                {"Total Sets high to low", "total_highest" }
            };

            // Assign filtered exercises to ViewModel
            viewModel.Exercises = exercises;
            viewModel.SortBy = sortBy;

            return View(viewModel);
        }



        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            ViewBag.MuscleGroupID = new SelectList(db.MuscleGroups, "ID", "Name");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PercentageOf1RM,Repetitions,Description,MuscleGroupID,TotalSets")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MuscleGroupID = new SelectList(db.MuscleGroups, "ID", "Name", exercise.MuscleGroupID);
            return View(exercise);
        }


        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.MuscleGroupID = new SelectList(db.MuscleGroups, "ID", "Name", exercise.MuscleGroupID);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PercentageOf1RM,Repetitions,Description,MuscleGroupID,TotalSets")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MuscleGroupID = new SelectList(db.MuscleGroups, "ID", "Name", exercise.MuscleGroupID);
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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

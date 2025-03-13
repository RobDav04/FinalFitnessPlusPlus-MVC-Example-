using FinalFitnessPlusPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFitnessPlusPlus.ViewModel
{
    public class ExerciseIndexViewModel
    {
        public IQueryable<Exercise> Exercises { get; set; }
        public string Search { get; set; }
        public IEnumerable<MuscleGroupWithCount> MuscleWithCount { get; set; }

        public int? SelectedMuscleGroupId { get; set; }
        public string SortBy { get; set; } // For sorting
        public Dictionary<string, string> Sorts { get; set; }

        public IEnumerable<SelectListItem> MuscleFilterItems
        {
            get
            {
                // Use correct ID values
                return MuscleWithCount.Select(m => new SelectListItem
                {
                    Value = m.ID.ToString(), // Ensure this is the correct ID
                    Text = m.MuscleNameWithCount,
                    Selected = (m.ID == SelectedMuscleGroupId) // Mark as selected
                });
            }
        }

        public class MuscleGroupWithCount
        {
            public int ID { get; set; }
            public int ExerciseCount { get; set; }
            public string MuscleName { get; set; }
            public string MuscleNameWithCount => MuscleName + " (" + ExerciseCount + ")";
        }
    }


}
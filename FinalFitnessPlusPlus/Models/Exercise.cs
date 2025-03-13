using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalFitnessPlusPlus.Models
{
    public class Exercise
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Exercise")]
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        public string PercentageOf1RM { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        [Range(0, int.MaxValue)]
        public decimal Repetitions { get; set; }

        [Required(ErrorMessage = "Enter a description")]
        [MaxLength (200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        public int? MuscleGroupID { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        [Range (0, int.MaxValue)]
        public int TotalSets { get; set; }
        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
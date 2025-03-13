using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalFitnessPlusPlus.Models
{
    public class MuscleGroup
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Muscle Group")]
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
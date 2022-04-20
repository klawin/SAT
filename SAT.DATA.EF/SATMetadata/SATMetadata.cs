using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF//.SATMetadata
{
    #region CoursesMetadata

    public class CoursesMetadata
    {
        //public int CourseId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "*")]
        [UIHint("MultilineText")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Curriculum { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }
    #endregion
}

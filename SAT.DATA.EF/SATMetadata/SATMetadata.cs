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

    #region EnrollmentsMetadata
    public class EnrollmentsMetadata
    {
        [Required(ErrorMessage = "*")]
        public int EnrollmentId { get; set; }
        //public int StudentId { get; set; }
        //public int ScheduledClassId { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.DateTime, ErrorMessage = "* Must be in correct date format (mm/dd/yyyy)")]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-}")]
        public DateTime EnrollmentDate { get; set; }
    }
    #endregion

    #region ScheduledClassesMetadata
    public class ScheduledClassesMetadata
    {

        //public int ScheduledClassId { get; set; }
        [Required(ErrorMessage = "*")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Instructor Name")]
        [StringLength(40, ErrorMessage = "*Must be 40 characters or less.")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "*Must be 20 characters or less.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "*")]
        public int SCSID { get; set; }
    }

    #endregion

    #region ScheduledClassStatusses
    public class ScheduledClassStatusses
    {
        //public int SCSID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string SCSName { get; set; }
    }
    #endregion
}

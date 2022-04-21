using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF//.SATMetadata
{
    #region CoursesMetadata

    public class CourseMetadata
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
    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }
    #endregion

    #region EnrollmentsMetadata
    public class EnrollmentMetadata
    {
        [Required(ErrorMessage = "*")]
        public int EnrollmentId { get; set; }
        [Required(ErrorMessage = "*")]
        public int StudentId { get; set; }
        //public int ScheduledClassId { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.DateTime, ErrorMessage = "* Must be in correct date format (mm/dd/yyyy)")]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-}")]
        public DateTime EnrollmentDate { get; set; }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {
    }
    #endregion

    #region ScheduledClassesMetadata
    public class ScheduledClassMetadata
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
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        public string Class
        {
            get { return StartDate.ToShortDateString() + "\n" + Course.CourseName + "\n" + Location; }
        }
    }
    #endregion

    #region ScheduledClassStatusses
    public class ScheduledClassStatusMetadata
    {
        //public int SCSID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string SCSName { get; set; }
    }
    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus
    {

    }
    #endregion

    #region StudentMetadata

    //public int StudentId { get; set; }
    public class StudentMetadata
    {
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "*")]
        public int SSID { get; set; }
    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    #endregion

    #region StudentStatusesMetadata
    public class StudentStatusMetadata
    {
        //public int SSID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        [Display(Name = "Student Status")]
        public string SSName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Student Status Description")]
        public string SSDescription { get; set; }
    }
    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus
    {
    }
    #endregion
}

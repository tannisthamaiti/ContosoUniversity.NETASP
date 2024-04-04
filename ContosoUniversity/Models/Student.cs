using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string FirstMidName { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }

        [Range(1, 100)]
        public int numCoursesEnrolled { get; set; }

        public string Year { get; set; }

        [RegularExpression(@"^[A-Z]{3}-\d{5}-[A-Z]\d$")]
        public string StudentUnivID {  get; set; }
        public string StudentImageData { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; } //image url and byte array

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
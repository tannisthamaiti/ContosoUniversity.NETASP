using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string StudentImageData { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; } //image url and byte array

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
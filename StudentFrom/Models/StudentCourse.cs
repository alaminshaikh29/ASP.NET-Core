using System.ComponentModel.DataAnnotations;

namespace StudentFrom.Models
{
    public class StudentCourse
    {
        [Key]
        public long Id { get; set; }
        public long StudentId  { get; set; }
        public long CourseId { get; set; }
    }
}

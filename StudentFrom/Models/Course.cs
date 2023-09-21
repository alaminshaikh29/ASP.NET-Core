using System.ComponentModel.DataAnnotations;

namespace StudentFrom.Models
{
    public class Course
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public long Credit { get; set; }

    }
}




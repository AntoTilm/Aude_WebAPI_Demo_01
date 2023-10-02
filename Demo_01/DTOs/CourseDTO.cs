using System.ComponentModel.DataAnnotations;

namespace Demo_01.DTOs
{
    public class CourseDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

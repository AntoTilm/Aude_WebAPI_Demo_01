using System.ComponentModel.DataAnnotations;

namespace Demo_01.DTOs
{
    public class TrainerDTO
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }


}

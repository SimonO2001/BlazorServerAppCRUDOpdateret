using System.ComponentModel.DataAnnotations;

namespace BlazorServerAppCRUD.Models
{
    public class StudentEntity
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]

        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Gender is required")]

        public int Gender { get; set; } = 0;  // Defaults to 0 = Not Set, 1 = Male, 2 = Female, 3 = Other
        public DateTime? CreatedOn { get; set; }
    }
}

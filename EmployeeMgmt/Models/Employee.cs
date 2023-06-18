using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeMgmt.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}

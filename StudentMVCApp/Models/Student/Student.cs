using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMVCApp.Models.Student
{
    public class Student
    {
        [DisplayName("Reg No")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please provide a valid First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage ="Please provide a valid Last Name")] 
        [StringLength(5,ErrorMessage ="Something wrong")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
    }
}

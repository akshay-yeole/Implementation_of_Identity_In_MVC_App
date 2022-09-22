using System.ComponentModel.DataAnnotations;

namespace Implement_Identity_In_MVC_App.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage ="User Name is Required")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email Id")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password dose not match")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }

        [Required(ErrorMessage = "Please reenter password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

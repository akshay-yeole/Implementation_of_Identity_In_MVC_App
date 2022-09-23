using System.ComponentModel.DataAnnotations;

namespace Implement_Identity_In_MVC_App.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password),  Display(Name = "New Password")]
        public string NewPassword { get; set; }
        
        [Required, DataType(DataType.Password),  Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage ="Password Dose Not Match")]
        public string ConfirmPassword { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;

namespace Implement_Identity_In_MVC_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
    }
}

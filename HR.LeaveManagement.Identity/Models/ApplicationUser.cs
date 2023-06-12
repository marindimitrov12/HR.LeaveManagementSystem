
using Microsoft.AspNetCore.Identity;


namespace HR.LeaveManagement.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string?  JobTitle { get; set; }

        public int? WorkExperience { get; set; }

        public double? Salary { get; set; }
    }
}

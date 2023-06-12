namespace HR.LeaveManagement.MVC.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public double? Salary { get; set; }

        public string? JobTitle { get; set; }
        
        public int? WorkExperience { get; set; }
    }
}

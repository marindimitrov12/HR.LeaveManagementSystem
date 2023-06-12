namespace HR.LeaveManagement.Application.DTOs.EmployesInfo;

public class EmployInfoDto
{
    
    public string Email { get; set; }
    
    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
        
    public string JobTitle { get; set; }

    public double? Salary { get; set; }

    public int? WorkExperience { get; set; }
}
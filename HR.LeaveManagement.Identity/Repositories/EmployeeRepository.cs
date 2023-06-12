

using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.EmployesInfo;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Identity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class EmployeeRepository:GenericRepository<EmployInfoDto>, IEmployeeRepository
{
    private readonly LeaveManagementIdentityDbContext _dbContext;
    public EmployeeRepository(LeaveManagementIdentityDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EmployInfoDto>> GetAllEmployes()
    {
        var employes = await _dbContext.Users.ToListAsync();
        List<EmployInfoDto> result=new List<EmployInfoDto>();
        foreach (var item in employes)
        {
            EmployInfoDto dto = new EmployInfoDto();
            dto.Email = item.Email;
            dto.Firstname = item.FirstName;
            dto.Lastname = item.LastName;
            dto.WorkExperience = item.WorkExperience;
            dto.Salary = item.Salary;
            dto.JobTitle = item.JobTitle;
            
            result.Add(dto);
        }

        return result;
    }
}
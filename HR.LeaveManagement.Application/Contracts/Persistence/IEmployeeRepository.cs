using HR.LeaveManagement.Application.DTOs.EmployesInfo;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IEmployeeRepository:IGenericRepository<EmployInfoDto>
{
    Task<List<EmployInfoDto>> GetAllEmployes();
}
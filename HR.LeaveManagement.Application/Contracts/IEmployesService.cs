using HR.LeaveManagement.Application.DTOs.EmployesInfo;

namespace HR.LeaveManagement.Application.Contracts;

public interface IEmployesService
{
    public  Task<List<EmployInfoDto>> GetAllEmployes();
}
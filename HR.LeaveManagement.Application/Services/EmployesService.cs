using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.EmployesInfo;

namespace HR.LeaveManagement.Application.Services;

public class EmployesService:IEmployesService
{
    private readonly IEmployeeRepository _repo;

    public EmployesService(IEmployeeRepository repo)
    {
        _repo = repo;  
    }

    public async Task<List<EmployInfoDto>> GetAllEmployes()
    {
       return await _repo.GetAllEmployes();
    }
}
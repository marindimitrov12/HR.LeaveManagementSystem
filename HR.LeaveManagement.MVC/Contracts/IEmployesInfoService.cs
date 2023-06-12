

using HR.LeaveManagement.MVC.Models;

namespace HR.LeaveManagement.MVC.Contracts;

public interface IEmployesInfoService
{
    Task<List<EmployeeVM>> GetAdminLeaveRequestList();
}
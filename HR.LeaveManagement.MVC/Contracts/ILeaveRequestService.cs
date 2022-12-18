using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using static HR.LeaveManagement.MVC.Models.LeaveRequestVM;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequest);
        Task<Response<int>> UpdateLeaveRequest(int id, LeaveRequestVM Request);
        Task<LeaveRequestVM> GetLeaveRequest(int id);
        Task<Response<int>> DeleteLeaveRequest(int id);
        Task ApproveLeaveRequest(int id, bool approved);

    }
}

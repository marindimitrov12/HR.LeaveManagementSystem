using HR.LeaveManagement.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts
{
    public interface ILeaveRequestService
    {
        public Task<LeaveRequestDto> GetLeaveRequestDetails(int id);
        public Task<List<LeaveRequestListDto>> GetLeaveRequestListRequest(bool IsLoggedInUser);
        public  Task<BaseResponse> CreateLeaveRequest(CreateLeaveRequestDto dto);

        public  Task DeleteLeaveRequest(int id);
        public  Task UpdateLeaveRequest(UpdateLeaveRequestDto leaveDto,
           ChangeLeaveRequestApprovalDto changeLeaveRequestAprDto,
           int id);

    }
}

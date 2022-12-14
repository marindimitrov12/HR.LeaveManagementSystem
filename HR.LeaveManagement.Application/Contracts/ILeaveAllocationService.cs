using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts
{
    public interface ILeaveAllocationService
    {
        public Task<LeaveAllocationDto> GetLeaveAllocationDetail(int id);
        public Task<List<LeaveAllocationDto>> GetLeaveAllocationListRequest(bool isLogin);
        public Task<BaseResponse> CreateLeaveAllocation(CreateLeaveAllocationDto dto);
        public Task<int> DeleteAllocation(int id);
        public  Task<int> UpdateAllocation(UpdateLeaveAllocationDto dto,int id);

    }
}

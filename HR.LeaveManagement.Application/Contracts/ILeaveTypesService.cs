using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts
{
    public interface ILeaveTypesService
    {
        public  Task<List<LeaveTypeDto>> GetListRequest();
        public Task<LeaveTypeDto> GetLeaveTypeDetailRequest(int id);
        public Task<BaseResponse> CreateLeaveType(CreateLeaveTypeDto dto);
        public Task<int> UpdateLeaveType(CreateLeaveTypeDto dto,int id);

        public Task<int> DeleteLeaveType(int id);
    }
}

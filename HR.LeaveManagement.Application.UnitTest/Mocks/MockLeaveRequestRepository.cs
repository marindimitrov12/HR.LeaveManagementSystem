using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTest.Mocks
{
    public static class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetLeaveRequestRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id=1,
                    DateCreated=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    EndDate=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    RequestingEmployeedId="1",
                    Approved=true,
                    Cancelled=false,
                    CreatedBy="Marin",
                    DateRequested=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    LastModifiedBy="Marin",
                    StartDate=DateTime.Now,
                    DateActioned=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    LastModifiedDate=DateTime.Now,
                    LeaveType=new LeaveType
                    {
                        Id=1,
                        Name="sick",
                    }
                },
                new LeaveRequest
                {
                    Id=2,
                    DateCreated=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    EndDate=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    RequestingEmployeedId="1",
                    Approved=true,
                    Cancelled=false,
                    CreatedBy="Dobromir",
                    DateRequested=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    LastModifiedBy="Dobromir",
                    StartDate=DateTime.Now,
                    DateActioned=DateTime.Parse("2022-12-19T16:33:22.138Z"),
                    LastModifiedDate=DateTime.Now,
                    LeaveType=new LeaveType
                    {
                        Id=1,
                        Name="Annual",
                    }
                },
            };
            var mockRepo = new Mock<ILeaveRequestRepository>();
            mockRepo.Setup(r=>r.GetAll()).ReturnsAsync(leaveRequests);
            mockRepo.Setup(r=>r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var result = leaveRequests.FirstOrDefault(x=>x.Id==id);
                return result;
            });
            mockRepo.Setup(r=>r.Delete(It.IsAny<LeaveRequest>())).Callback((LeaveRequest request) =>
            {
                leaveRequests.Remove(request);
            });
            mockRepo.Setup(r=>r.Add(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest request) =>
            {
                int i = 1;
                leaveRequests.Add(request);
                request.Id = i++;
                return request;
            });
            mockRepo.Setup(r=>r.Update(It.IsAny<LeaveRequest>())).Callback((LeaveRequest request) =>
            {
                var old = leaveRequests.FirstOrDefault(x=>x.Id==request.Id);
                leaveRequests.Remove(old);
                leaveRequests.Add(request);
            });
            mockRepo.Setup(r => r.GetLeaveRequestsWithDetails()).ReturnsAsync(leaveRequests);
            mockRepo.Setup(r=>r.GetLeaveRequestsWithDetails(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                var result = leaveRequests.Where(x => x.Id == int.Parse(id)).ToList();
                foreach (var item in result)
                {
                    item.LeaveType = leaveRequests[1].LeaveType;
                }
                
                return result;
            });
            return mockRepo;
        }
    }
}

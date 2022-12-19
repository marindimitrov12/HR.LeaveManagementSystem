using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTest.Mocks
{
    public static class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetLeaveAllocationRepository()
        {
            var LeaveAllocations = new List<LeaveAllocation>
            {
                new LeaveAllocation()
                {
                    Id=1,
                    DateCreated=DateTime.Now,
                    CreatedBy="Marin",
                    EmployeeId="1",
                    LastModifiedBy="Marin",
                    LastModifiedDate=DateTime.Now,
                    LeaveType=new Domain.LeaveType
                    {
                        Name="sick",
                        DefaultDays=10,
                    },
                    LeaveTypeId=1,
                    NumberOfDays=10,
                    Period=10,


                },
                 new LeaveAllocation()
                {
                    Id=1,
                    DateCreated=DateTime.Now,
                    CreatedBy="Marin",
                    EmployeeId="1",
                    LastModifiedBy="Marin",
                    LastModifiedDate=DateTime.Now,
                    LeaveType=new Domain.LeaveType
                    {
                        Name="Annual",
                        DefaultDays=10,
                    },
                    LeaveTypeId=2,
                    NumberOfDays=10,
                    Period=10,


                }
            };
            var mockRepo = new Mock<ILeaveAllocationRepository>();
            mockRepo.Setup(r => r.GetUserAllocations(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync((string userId, int leaveTypeId) =>
                {
                    var result = LeaveAllocations.FirstOrDefault(q => q.EmployeeId == userId
                                          && q.LeaveTypeId == leaveTypeId);
                    return result;
                });
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(LeaveAllocations);
            mockRepo.Setup(r=>r.Update(It.IsAny<LeaveAllocation>())).Callback((LeaveAllocation allocation) =>
            {
                var old = LeaveAllocations.Where(x => x.Id == allocation.Id).FirstOrDefault();
                LeaveAllocations.Remove(old);
                LeaveAllocations.Add(allocation) ;
            });
            mockRepo.Setup(r=>r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var result = LeaveAllocations.Where(x => x.Id == id).FirstOrDefault();
                return result;
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<LeaveAllocation>())).Callback((LeaveAllocation allocation) =>
            {
                LeaveAllocations.Remove(allocation);
            });
            mockRepo.Setup(r => r.AddAllocations(It.IsAny<List<LeaveAllocation>>())).Callback((List<LeaveAllocation> allocations) =>
            {
                foreach (var item in allocations)
                {
                    if (!LeaveAllocations.Contains(item))
                    {
                        LeaveAllocations.Add(item);
                    }
                    
                }
                
            });
            return mockRepo;

        }
    }
}

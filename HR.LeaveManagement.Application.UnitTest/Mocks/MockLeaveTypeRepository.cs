using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HR.LeaveManagement.Application.UnitTest.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                },
                new LeaveType
                {
                    Id = 3,
                    DefaultDays = 15,
                    Name = "Test Maternity"
                }
            };
            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
              {
                  leaveTypes.Add(leaveType);
                  return leaveType;
              });
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                
                return leaveTypes[id];
            });
            mockRepo.Setup(r => r.Update(It.IsAny<LeaveType>())).Callback((LeaveType leavetype) =>
            {
                var old = leaveTypes.FirstOrDefault(x => x.Id == leavetype.Id);
                leaveTypes.Remove(old);
                leaveTypes.Add(leavetype);
         
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<LeaveType>())).Callback((LeaveType leavetype) =>
            {
                leaveTypes.Remove(leavetype);
            });
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
              {
                  if ((leaveTypes.Where(x=>x.Id==id).First())==null)
                  {
                      return false;
                  }
                  else
                  {
                      return true;
                  }
              });
            return mockRepo;

        }
    }
}

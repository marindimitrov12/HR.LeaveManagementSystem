using HR.LeaveManagement.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockLeaveTypeRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mockLeaveAllocationRepo = MockLeaveAllocationRepository.GetLeaveAllocationRepository();
            var mockLeaveRequestRepo = MockLeaveRequestRepository.GetLeaveRequestRepository();
            mockUow.Setup(r=>r.LeaveTypeRepository).Returns(mockLeaveTypeRepo.Object);
            mockUow.Setup(r=>r.LeaveAllocationRepository).Returns(mockLeaveAllocationRepo.Object);
            mockUow.Setup(r=>r.LeaveRequestRepository).Returns(mockLeaveRequestRepo.Object);

            return mockUow;
        }
    }
}

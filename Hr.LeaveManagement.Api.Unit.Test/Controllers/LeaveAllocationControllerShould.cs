using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hr.LeaveManagement.Api.Unit.Test.Controllers
{
    public  class LeaveAllocationControllerShould
    {
        [Fact]
        public async Task Get_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveAllocationService>();
           
            var controller = new LeaveAllocationController(serviceMock.Object);
           
            //Act
            controller.Get(false);
            //Assert
            serviceMock.Verify(x => x.GetLeaveAllocationListRequest(false), Times.Once);
        }
        [Fact]
        public async Task GetId_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveAllocationService>();

            var controller = new LeaveAllocationController(serviceMock.Object);

            //Act
            controller.Get(1);
            //Assert
            serviceMock.Verify(x => x.GetLeaveAllocationDetail(1), Times.Once);
        }
        [Fact]
        public async Task Post_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveAllocationService>();

            var controller = new LeaveAllocationController(serviceMock.Object);
            var dto = new CreateLeaveAllocationDto
            {
                LeaveTypeId = 1
            };
            //Act
            controller.Post(dto);
            //Assert
            serviceMock.Verify(x => x.CreateLeaveAllocation(dto), Times.Once);
        }
        [Fact]
        public async Task Put_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveAllocationService>();

            var controller = new LeaveAllocationController(serviceMock.Object);
            var dto = new UpdateLeaveAllocationDto
            {
                LeaveTypeId = 1,
                NumberOfDays = 3,
                Period = 2024
            };
            //Act
            controller.Put(dto,1);
            //Assert
            serviceMock.Verify(x => x.UpdateAllocation(dto,1), Times.Once);
        }
        [Fact]
        public async Task Delete_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveAllocationService>();

            var controller = new LeaveAllocationController(serviceMock.Object);
           
            //Act
            controller.Delete(1);
            //Assert
            serviceMock.Verify(x => x.DeleteAllocation(1), Times.Once);
        }

    }
}

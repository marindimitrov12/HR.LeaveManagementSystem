using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hr.LeaveManagement.Api.Unit.Test.Controllers
{
    public  class LeaveRequestControllerShould
    {
        [Fact]
        public async Task Get_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);
           
            //Act
            controller.Get();
            //Assert
            serviceMock.Verify(x => x.GetLeaveRequestListRequest(false), Times.Once);
        }
        [Fact]
        public async Task GetId_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);

            //Act
            controller.Get(1);
            //Assert
            serviceMock.Verify(x => x.GetLeaveRequestDetails(1), Times.Once);
        }
        [Fact]
        public async Task Post_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);
            var dto = new CreateLeaveRequestDto
            {
               
            };
            //Act
            controller.Post(dto);
            //Assert
            serviceMock.Verify(x => x.CreateLeaveRequest(dto), Times.Once);
        }
        [Fact]
        public async Task ChangeApproval_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);
            var dto = new ChangeLeaveRequestApprovalDto
            {

            };
            //Act
            controller.ChangeApproval(1,dto);
            //Assert
            serviceMock.Verify(x => x.UpdateLeaveRequest(null,dto,1), Times.Once);
        }
        [Fact]
        public async Task Put_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);
            var dto = new UpdateLeaveRequestDto
            {

            };

            //Act
            controller.Put(1, dto);
            //Assert
            serviceMock.Verify(x => x.UpdateLeaveRequest(dto, null, 1), Times.Once);
        }
        [Fact]
        public async Task Delete_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveRequestService>();

            var controller = new LeaveRequestsController(serviceMock.Object);
            

            //Act
            controller.Delete(1);
            //Assert
            serviceMock.Verify(x => x.DeleteLeaveRequest(1), Times.Once);
        }

    }
}

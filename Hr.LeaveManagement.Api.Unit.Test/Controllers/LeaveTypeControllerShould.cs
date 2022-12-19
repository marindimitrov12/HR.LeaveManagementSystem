using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Services;
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
    public class LeaveTypeControllerShould
    {
        [Fact]
        public async Task Get_Controller_WorkCorrectly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveTypesService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var controller = new LeaveTypesController(serviceMock.Object, httpContextAccessorMock.Object);
            //Act
            controller.Get();
            //Assert
            serviceMock.Verify(x=>x.GetListRequest(),Times.Once);

        }
        [Fact]
        public async Task GetId_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveTypesService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var controller = new LeaveTypesController(serviceMock.Object, httpContextAccessorMock.Object);
            //Act
            controller.Get(1);
            //Assert
            serviceMock.Verify(x=>x.GetLeaveTypeDetailRequest(1),Times.Once);
        }
        [Fact]
        public async Task Post_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveTypesService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Administrator") }));
            httpContextAccessorMock.Setup(r => r.HttpContext).Returns(context);
            var controller = new LeaveTypesController(serviceMock.Object, httpContextAccessorMock.Object);
            var dto = new CreateLeaveTypeDto
            {
                DefaultDays=2,
                Name="Annual"
            };
            //Act
            controller.Post(dto);
            //Assert
            serviceMock.Verify(x => x.CreateLeaveType(dto), Times.Once);
        }
        [Fact]
        public async Task Put_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveTypesService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Administrator") }));
            httpContextAccessorMock.Setup(r => r.HttpContext).Returns(context);
            var controller = new LeaveTypesController(serviceMock.Object, httpContextAccessorMock.Object);
            var dto = new CreateLeaveTypeDto
            {
                DefaultDays = 2,
                Name = "Annual"
            };
            //Act
            controller.Put(dto,1);
            //Assert
            serviceMock.Verify(x => x.UpdateLeaveType(dto,1), Times.Once);
        }
        [Fact]
        public async Task Delete_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<ILeaveTypesService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Administrator") }));
            httpContextAccessorMock.Setup(r => r.HttpContext).Returns(context);
            var controller = new LeaveTypesController(serviceMock.Object, httpContextAccessorMock.Object);
           
            //Act
            controller.Delete( 1);
            //Assert
            serviceMock.Verify(x => x.DeleteLeaveType(1), Times.Once);
        }
    }
}

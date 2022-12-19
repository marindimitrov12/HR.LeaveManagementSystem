using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hr.LeaveManagement.Api.Unit.Test.Controllers
{
    public  class AccountControllerShould
    {
        [Fact]
        public async Task Login_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<IAuthService>();

            var controller = new AccountController(serviceMock.Object);

            var dto = new AuthRequest
            {

            };
            //Act
            controller.Login(dto);
            //Assert
            serviceMock.Verify(x => x.Login(dto), Times.Once);
        }
        [Fact]
        public async Task Result_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<IAuthService>();

            var controller = new AccountController(serviceMock.Object);

            var dto = new RegistrationRequest
            {

            };
            //Act
            controller.Result(dto);
            //Assert
            serviceMock.Verify(x => x.Register(dto), Times.Once);
        }
    }
}

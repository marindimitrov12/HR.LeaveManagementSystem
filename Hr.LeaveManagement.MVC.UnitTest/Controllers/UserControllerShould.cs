using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Controllers;
using HR.LeaveManagement.MVC.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hr.LeaveManagement.MVC.UnitTest.Controllers
{
    public class UserControllerShould
    {
        [Fact]
        public async Task LoginPost_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<IAuthenticationService>();

            var controller = new UsersController(serviceMock.Object);
            var vm = new LoginVM
            {

            };

            //Act
            controller.Login(vm);
            //Assert
            serviceMock.Verify(x => x.Authenticate(vm.Email,vm.Password), Times.Once);
        }

       
        [Fact]
        public async Task LogOut_Works_Correctly()
        {
            //Arrange
            var serviceMock = new Mock<IAuthenticationService>();

            var controller = new UsersController(serviceMock.Object);
            

            //Act
            controller.Logout("/");
            //Assert
            serviceMock.Verify(x =>x.Logout(), Times.Once);
        }
    }
}

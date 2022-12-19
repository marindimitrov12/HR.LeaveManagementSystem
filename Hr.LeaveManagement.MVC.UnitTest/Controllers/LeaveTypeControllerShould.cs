using AutoMapper;
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
    public class LeaveTypeControllerShould
    {
        [Fact]
        public async Task IndexUser_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            //Act
            controller.IndexUser();
            //Assert
            _leaveRequestService.Verify(x=>x.GetUserLeaveRequests(),Times.Once);


        }
        [Fact]
        public async Task Index_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            //Act
            controller.Index();
            //Assert
            _leaveRequestService.Verify(x => x.GetAdminLeaveRequestList(), Times.Once);


        }
        [Fact]
        public async Task Delete_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            //Act
            controller.Delete(1);
            //Assert
            _leaveRequestService.Verify(x => x.DeleteLeaveRequest(1), Times.Once);


        }
        [Fact]
        public async Task EditGet_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            //Act
            controller.Edit(1);
            //Assert
            _leaveRequestService.Verify(x => x.GetLeaveRequest(1), Times.Once);


        }
        [Fact]
        public async Task EditPost_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            var vm = new LeaveRequestVM
            {

            };
            //Act
            controller.Edit(1,vm);
            //Assert
            _leaveRequestService.Verify(x => x.UpdateLeaveRequest(1,vm), Times.Once);


        }
        [Fact]
        public async Task ApproveRequest_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
           
            //Act
            controller.ApproveRequest(1,true);
            //Assert
            _leaveRequestService.Verify(x => x.ApproveLeaveRequest(1,true), Times.Once);


        }
        [Fact]
        public async Task Details_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);

            //Act
            controller.Details(1);
            //Assert
            _leaveRequestService.Verify(x => x.GetLeaveRequest(1), Times.Once);


        }
        [Fact]
        public async Task CreateGet_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);

            //Act
            controller.Create();
            //Assert
            _leaveTypeService.Verify(x => x.GetLeaveTypes(), Times.Once);


        }
        [Fact]
        public async Task CreatePost_WorksCorrectly()
        {
            //Arrange
            var _leaveTypeService = new Mock<ILeaveTypeService>();
            var _leaveRequestService = new Mock<ILeaveRequestService>();
            var _mapper = new Mock<IMapper>();
            var controller = new LeaveRequestsController(_leaveTypeService.Object,
                _leaveRequestService.Object,
                _mapper.Object);
            var vm = new CreateLeaveRequestVM
            {

            };
            //Act
            controller.Create(vm);
            //Assert
            _leaveRequestService.Verify(x=>x.CreateLeaveRequest(vm),Times.Once);
            


        }

    }
}

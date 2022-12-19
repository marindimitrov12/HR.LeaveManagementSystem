using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Services;
using HR.LeaveManagement.Application.UnitTest.Mocks;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTest.Services.LeaveRequestServiceShould
{
    public class LeaveRequestServiceShould
    {
        private readonly Moq.Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly Moq.Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Moq.Mock<IUserService> _userService;
        private readonly Moq.Mock<IEmailSender> _emailSender;
        //Set up
        public LeaveRequestServiceShould()
        {
            _mockUnitOfWork = _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim("uid", "1") }));
            _httpContextAccessor.Setup(r => r.HttpContext).Returns(context);
            _userService = new Mock<IUserService>();
            _userService.Setup(r => r.GetEmployee(It.IsAny<string>())).ReturnsAsync(new Employee()
            {
                Email = "user@mail.com",
                Firstname = "Dobromir",
                Lastname = "Dimitrov",
                Id = "1",
            });
            _userService.Setup(r => r.GetEmployees()).ReturnsAsync(new List<Employee>()
            {
                new Employee()
            {
                Email="user@mail.com",
                Firstname="Dobromir",
                Lastname="Dimitrov",
                Id="1",
            },
                new Employee()
            {
                Email = "user1@mail.com",
                Firstname = "Marin",
                Lastname = "Dimitrov",
                Id = "1",
            },

            });
            _emailSender = new Mock<IEmailSender>();

        }
        [Fact]
        public async Task GetLeaveRequestListRequest_Works_Correctly_false()
        {
            //Arrange
            var service = new LeaveRequestService(_emailSender.Object,_httpContextAccessor.Object,
                _mockUnitOfWork.Object,_mapper,_userService.Object);
            //Act
            var result = await service.GetLeaveRequestListRequest( false);
            //Assert
            Assert.Equal(2,result.Count);
        }
        [Fact]
        public async Task GetLeaveRequestListRequest_Works_Correctly_true()
        {
            //Arrange
            var service = new LeaveRequestService(_emailSender.Object, _httpContextAccessor.Object,
                _mockUnitOfWork.Object, _mapper, _userService.Object);
            //Act
            var result = await service.GetLeaveRequestListRequest(true);
            //Assert
            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async Task CreateLeaveRequest_Works_Correctly()
        {
            //Arrange
            var service = new LeaveRequestService(_emailSender.Object, _httpContextAccessor.Object,
                  _mockUnitOfWork.Object, _mapper, _userService.Object);
            var dto = new CreateLeaveRequestDto
            {
                EndDate = DateTime.Parse("2022-12-19T16:33:22.138Z"),
                LeaveTypeId = 1,
                StartDate = DateTime.Parse("2022-12-19T16:33:21.138Z"),
                RequestComments = "AAAAAAAAAAA"
            };
            //Act
            await service.CreateLeaveRequest(dto);
            var result = await _mockUnitOfWork.Object.LeaveRequestRepository.GetAll();
            //Assert
            Assert.Equal(3,result.Count);
        }
        [Fact]
        public async Task DeleteLeaveRequest_Works_Correctly()
        {
            //Arrange
            var service = new LeaveRequestService(_emailSender.Object, _httpContextAccessor.Object,
                  _mockUnitOfWork.Object, _mapper, _userService.Object);
            //Act
            await service.DeleteLeaveRequest(1);
            var result =await _mockUnitOfWork.Object.LeaveRequestRepository.GetAll();
            //Assert
            Assert.Equal(1,result.Count);
        }
        [Fact]
        public async Task UpdateLeaveRequest_Works_Correctly()
        {
            //Arrange
            var service = new LeaveRequestService(_emailSender.Object, _httpContextAccessor.Object,
                  _mockUnitOfWork.Object, _mapper, _userService.Object);
            var dto2 = new ChangeLeaveRequestApprovalDto
            {
                Approved = false,
                Id = 1,
            };
            var dto1 = new UpdateLeaveRequestDto
            {
                Id = 1,
                Cancelled = false,
                RequestComments = "AAAAAA",
                LeaveTypeId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Parse("2022-12-22T16:33:22.138Z"),

            };
            //Act
            await service.UpdateLeaveRequest(dto1,dto2,1);
            var result =await _mockUnitOfWork.Object.LeaveRequestRepository.GetAll();
            //Assert
            Assert.Equal(dto1.Id, result[1].Id);
            Assert.Equal(dto1.RequestComments, result[1].RequestComments);
            Assert.Equal(dto1.StartDate, result[1].StartDate);
        }
    }
}

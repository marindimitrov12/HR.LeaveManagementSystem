using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
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

namespace HR.LeaveManagement.Application.UnitTest.Services.LeaveAllocationServiceShould
{
    public class LeaveAllocationServiceShould
    {
        private readonly Moq.Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly Moq.Mock<IHttpContextAccessor>_httpContextAccessor;
        private readonly Moq.Mock<IUserService> _userService;

        //SetUp
        public LeaveAllocationServiceShould()
        {
            _mockUnitOfWork = _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Administrator") }));
            _httpContextAccessor.Setup(r=>r.HttpContext).Returns(context);
             _userService = new Mock<IUserService>();
            _userService.Setup(r => r.GetEmployee(It.IsAny<string>())).ReturnsAsync(new Employee()
            {
                Email="user@mail.com",
                Firstname="Dobromir",
                Lastname="Dimitrov",
                Id="1",
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
        }
        [Fact]
        public async Task GetLeaveAllocationListRequest_All_ReturnsAllocations_false()
        {
            //Arrange
            var service = new LeaveAllocationService(_mockUnitOfWork.Object,
                _mapper, _httpContextAccessor.Object, _userService.Object);
            //Act
            await service.GetLeaveAllocationListRequest(false);
            var result = await _mockUnitOfWork.Object.LeaveAllocationRepository.GetAll();
            //Assert
            Assert.Equal(2,result.Count);

        }
        [Fact]
        public async Task GetLeaveAllocationListRequest_All_ReturnsAllocations_true()
        {
            //Arrange
            var service = new LeaveAllocationService(_mockUnitOfWork.Object,
                _mapper, _httpContextAccessor.Object, _userService.Object);
            //Act
            await service.GetLeaveAllocationListRequest(true);
            var result = await _mockUnitOfWork.Object.LeaveAllocationRepository.GetAll();
            //Assert
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task CreateLeaveAllocation_Works_Correctly()
        {
            //Arrange
            var service = new LeaveAllocationService(_mockUnitOfWork.Object,
               _mapper, _httpContextAccessor.Object, _userService.Object);
            var dto = new CreateLeaveAllocationDto
            {
                LeaveTypeId=1,
            };
            //Act
            await service.CreateLeaveAllocation(dto);
            var result = await _mockUnitOfWork.Object.LeaveAllocationRepository.GetAll();
            //Assert
            Assert.Equal(4,result.Count);
        }
        [Fact]
        public async Task DeleteAllocation_Works_Correctly()
        {
            //Arrange
            var service = new LeaveAllocationService(_mockUnitOfWork.Object,
               _mapper, _httpContextAccessor.Object, _userService.Object);
            //Act
            await service.DeleteAllocation(1);
            var result = await _mockUnitOfWork.Object.LeaveAllocationRepository.GetAll();
            //Assert
            Assert.Equal(1,result.Count);
        }
        [Fact]
        public async Task UpdateAllocation_Works_Correctly()
        {
            //Arrange
            var service = new LeaveAllocationService(_mockUnitOfWork.Object,
               _mapper, _httpContextAccessor.Object, _userService.Object);
            var dto = new UpdateLeaveAllocationDto
            {
                LeaveTypeId = 1,
                NumberOfDays = 10,
                Period = 2024,
                
            };
            //Act
            await service.UpdateAllocation(dto,1);
            var Results = await _mockUnitOfWork.Object.LeaveAllocationRepository.GetAll();
            Assert.Equal(dto.LeaveTypeId,Results[1].LeaveTypeId);
            Assert.Equal(dto.NumberOfDays, Results[1].NumberOfDays);
            Assert.Equal(dto.Period, Results[1].Period);
        }
    }
}

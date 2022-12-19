using AutoMapper;
using HR.LeaveManagement.API;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Services;
using HR.LeaveManagement.Application.UnitTest.Mocks;
using HR.LeaveManagement.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTest.Services.LeaveTypeServiceShould
{
    
    public class LeaveTypesServiceShould
    {
        private readonly Moq.Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;

       
        public LeaveTypesServiceShould()
        {
            _mockUnitOfWork = _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetListRequest_Returns_The_Correct_LeaveTypes()
        {
            //Arrange
            var service = new LeaveTypesService(_mockUnitOfWork.Object,_mapper);
            //Act
            var result = await service.GetListRequest();
            //Assert
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
        [Fact]
        public async Task GetLeaveTypeDetailRequest_Returns_The_CorrectLeaveType()
        {
            //Arrange
            var service = new LeaveTypesService(_mockUnitOfWork.Object, _mapper);
            //Act
            var result = await service.GetLeaveTypeDetailRequest(1);
            //Assert
            result.ShouldBeOfType<LeaveTypeDto>();
        }
        [Fact]
        public async Task CreateLeaveType_Works_Correctly()
        {
            //Arrange
            var service = new LeaveTypesService(_mockUnitOfWork.Object, _mapper);
            var createleaveTypeDto = new CreateLeaveTypeDto()
            {
                Name="Annual",
                DefaultDays=2,
            };
            //Act
             await service.CreateLeaveType(createleaveTypeDto);
            var result = await _mockUnitOfWork.Object.LeaveTypeRepository.GetAll();
            //Assert
            Assert.Equal(4,result.Count);
           
        }
        [Fact] 
         public async  Task UpdateLeaveType_Works_Correctly()
        {
            //Arrange
            var service = new LeaveTypesService(_mockUnitOfWork.Object, _mapper);
            var createleaveTypeDto = new CreateLeaveTypeDto()
            {
                Name = "Annual",
                DefaultDays = 2,
            };
            //Act
             await service.UpdateLeaveType(createleaveTypeDto,1);
            var Results = await _mockUnitOfWork.Object.LeaveTypeRepository.GetAll();
            var result1 = Results.First(x => x.Name == createleaveTypeDto.Name);
            
            //Assert
            Assert.Equal(result1.Name, createleaveTypeDto.Name);
            Assert.Equal(result1.DefaultDays,createleaveTypeDto.DefaultDays);
        }
        [Fact]
        public async Task DeleteLeaveType_Works_Correctly()
        {
            //Arrange
            var service = new LeaveTypesService(_mockUnitOfWork.Object, _mapper);
            //Act
            await service.DeleteLeaveType(1);
            var result = await _mockUnitOfWork.Object.LeaveTypeRepository.GetAll();
            //Assert
            Assert.Equal(2,result.Count);

        }

    }
}

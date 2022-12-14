using AutoMapper;
using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagment.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Services
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        public LeaveAllocationService(IUnitOfWork unitOfWork,
           IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<LeaveAllocationDto> GetLeaveAllocationDetail(int id)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationWithDetails(id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
        public async Task<List<LeaveAllocationDto>> GetLeaveAllocationListRequest(bool isLogin)
        {
            var leaveAllocations = new List<LeaveAllocation>();
            var allocations = new List<LeaveAllocationDto>();
            if (isLogin)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
                leaveAllocations = await _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
                foreach (var alloc in allocations)
                {
                    alloc.Employee = employee;
                }
            }
            else
            {
                leaveAllocations = await _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationsWithDetails();
                allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
                foreach (var req in allocations)
                {
                    req.Employee = await _userService.GetEmployee(req.EmployeeId);
                }
            }
            return allocations;
        }
        public async Task<BaseResponse> CreateLeaveAllocation(CreateLeaveAllocationDto dto)
        {
            var response = new BaseResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(dto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Allocations Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = await _unitOfWork.LeaveTypeRepository.Get(dto.LeaveTypeId);
                var employees = await _userService.GetEmployees();
                var period = DateTime.Now.Year;
                var allocations = new List<LeaveAllocation>();
                foreach (var emp in employees)
                {
                    if (await _unitOfWork.LeaveAllocationRepository.AllocationExists(emp.Id, leaveType.Id, period))
                        continue;
                    allocations.Add(new LeaveAllocation
                    {
                        EmployeeId = emp.Id,
                        LeaveTypeId = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period = period,
                       
                        
                    });
                }
                await _unitOfWork.LeaveAllocationRepository.AddAllocations(allocations);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Allocations Successful";
            }
            return response;
        }
        public async Task<int> DeleteAllocation(int id)
        {
            var result = 1;
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.Get(id);

            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), id);
                result = 0;
            }
            await _unitOfWork.LeaveAllocationRepository.Delete(leaveAllocation);
            await _unitOfWork.Save();
            return result;

        }
        public async Task<int> UpdateAllocation(UpdateLeaveAllocationDto dto,int id)
        {
            var result = 1;
            var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(dto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
                result = 0;
            }
            var leaveAllocation = await _unitOfWork
                .LeaveAllocationRepository
                .Get(id);
            if (leaveAllocation is null)
            {
                throw new NotFoundException(nameof(leaveAllocation),
                   id);
                result = 0;

            }
            _mapper.Map(dto, leaveAllocation);

            await _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);
            await _unitOfWork.Save();

            return result;
        }
    }
}

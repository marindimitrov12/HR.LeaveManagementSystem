using AutoMapper;
using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDto.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Services
{
    public class LeaveRequestService:ILeaveRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        public LeaveRequestService(IEmailSender emailSender,IHttpContextAccessor httpContextAccessor,IUnitOfWork unitOfWork,IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _httpContextAccessor=httpContextAccessor;
            _emailSender = emailSender;
        }
        public async Task<LeaveRequestDto> GetLeaveRequestDetails(int id)
        {
            var leaveRequest = _mapper.Map<LeaveRequestDto>(await _unitOfWork.LeaveRequestRepository.GetLeaveRequestWithDetails(id));
            leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeedId);
            return leaveRequest;
        }

        public async Task<List<LeaveRequestListDto>> GetLeaveRequestListRequest(bool IsLoggedInUser)
        {
            var leaveRequests = new List<LeaveRequest>();
            var requests = new List<LeaveRequestListDto>();

            if (IsLoggedInUser)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                   q => q.Type == CustomClaimTypes.Uid)?.Value;
                leaveRequests = await _unitOfWork.LeaveRequestRepository.GetLeaveRequestsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                foreach (var req in requests)
                {
                    req.Employee = employee;
                }
            }
            else
            {
                leaveRequests = await _unitOfWork.LeaveRequestRepository.GetLeaveRequestsWithDetails();
                requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                foreach (var req in requests)
                {
                    req.Employee = await _userService.GetEmployee(req.RequestingEmployeedId);
                }
                
            }
            return requests;
        }

        public async Task<BaseResponse> CreateLeaveRequest(CreateLeaveRequestDto dto)
        {
            var response = new BaseResponse();
            var validator = new CreateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(dto);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                   q => q.Type == CustomClaimTypes.Uid)?.Value; 
                
            var allocation = await _unitOfWork.LeaveAllocationRepository
                .GetUserAllocations(userId, dto.LeaveTypeId);
            if (allocation is null)
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(dto.LeaveTypeId),
                    "You do not have any allocations for this leave type."));
            }
            else
            {
                int daysRequested = (int)(dto.EndDate - dto.StartDate).TotalDays;
                if (daysRequested > allocation.NumberOfDays)
                {
                    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(
                        nameof(dto.EndDate), "You do not have enough days for this request"));
                }
            }
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(dto);
                leaveRequest.RequestingEmployeedId = userId;
                leaveRequest = await _unitOfWork.LeaveRequestRepository.Add(leaveRequest);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = leaveRequest.Id;

                try
                {
                    var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

                    var email = new Email
                    {
                        To = emailAddress,
                        Body = $"Your leave request for {dto.StartDate:D} to {dto.EndDate:D} " +
                        $"has been submitted successfully.",
                        Subject = "Leave Request Submitted"
                    };

                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"Sending Email Failed:{ex}");
                }
            }
            return response;

        }
        public async Task DeleteLeaveRequest(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.Get(id);
            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest),id);
            await _unitOfWork.LeaveRequestRepository.Delete(leaveRequest);
            await _unitOfWork.Save();
        }
        public async Task UpdateLeaveRequest(UpdateLeaveRequestDto leaveDto,
            ChangeLeaveRequestApprovalDto changeLeaveRequestAprDto,
            int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.Get(id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(leaveRequest), id);

            if (leaveDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
                var validationResult = await validator.ValidateAsync(leaveDto);
                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                _mapper.Map(leaveDto, leaveRequest);

                await _unitOfWork.LeaveRequestRepository.Update(leaveRequest);
                await _unitOfWork.Save();
            }
            else if (changeLeaveRequestAprDto != null)
            {
                await _unitOfWork.LeaveRequestRepository.ChangeApprovalStatus(leaveRequest, changeLeaveRequestAprDto.Approved);
                if (changeLeaveRequestAprDto.Approved)
                {
                    var allocation = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeedId, leaveRequest.LeaveTypeId);
                    int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                    allocation.NumberOfDays -= daysRequested;

                    await _unitOfWork.LeaveAllocationRepository.Update(allocation);
                }

                await _unitOfWork.Save();
            }
        }
    }
}

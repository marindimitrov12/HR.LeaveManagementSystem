using AutoMapper;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Services
{
    public class LeaveTypesService:ILeaveTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveTypesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }

        public async Task<List<LeaveTypeDto>> GetListRequest()
        {
            var leaveTypes = await _unitOfWork.LeaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
        public async Task<LeaveTypeDto> GetLeaveTypeDetailRequest(int id)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
        public async Task<BaseResponse> CreateLeaveType(CreateLeaveTypeDto dto)
        {
            var response = new BaseResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);
            if (dto==null)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(dto);
                leaveType = await _unitOfWork.LeaveTypeRepository.Add(leaveType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveType.Id;
            }
            return response;
        }
        public async Task<int> UpdateLeaveType(CreateLeaveTypeDto dto,int id)
        {
            var result = 1;
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
                result = 0;
            }
               
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(id);
            if (leaveType is null)
            {
                throw new NotFoundException(nameof(leaveType), id);
                result = 0;
            }
               
            _mapper.Map(dto, leaveType);
            await _unitOfWork.LeaveTypeRepository.Update(leaveType);
            await _unitOfWork.Save();
            return result;
        }
        public async Task<int> DeleteLeaveType(int id)
        {
            var result = 1;
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), id);
                result=0;
            }
            await _unitOfWork.LeaveTypeRepository.Delete(leaveType);
            await _unitOfWork.Save();

            return result;

        }

       
    }
}

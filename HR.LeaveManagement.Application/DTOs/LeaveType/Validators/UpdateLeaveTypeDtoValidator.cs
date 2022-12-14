using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
       
        public UpdateLeaveTypeDtoValidator()
        {
           
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} must be present");
           
        }
    }
}

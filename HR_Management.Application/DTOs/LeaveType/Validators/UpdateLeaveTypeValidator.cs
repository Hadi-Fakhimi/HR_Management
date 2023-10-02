using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator:AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new LeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotEmpty()
                .WithMessage("{PropertyName} is required ");
        }

    }
}

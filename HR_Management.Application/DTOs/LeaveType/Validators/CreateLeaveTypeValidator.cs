using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeValidator:AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new LeaveTypeDtoValidator());
        }
    }
}

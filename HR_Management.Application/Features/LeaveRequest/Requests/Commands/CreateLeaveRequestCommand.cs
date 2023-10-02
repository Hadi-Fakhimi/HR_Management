using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Responses;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}

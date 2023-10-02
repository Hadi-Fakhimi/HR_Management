using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto LeaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }

}

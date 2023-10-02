using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands
{
    public class CreateLeaveAllocationCommand:IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }

    }
}

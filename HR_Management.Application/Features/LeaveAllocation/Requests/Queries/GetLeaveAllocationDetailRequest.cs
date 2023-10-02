using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest:IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}

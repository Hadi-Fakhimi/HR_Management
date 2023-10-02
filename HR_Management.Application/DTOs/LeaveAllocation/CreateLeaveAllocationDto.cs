using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto:BaseDto,ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int priod { get; set; }
    }
}

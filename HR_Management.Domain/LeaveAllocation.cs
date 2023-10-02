using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveAllocation:BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int priod { get; set; }
    }
}

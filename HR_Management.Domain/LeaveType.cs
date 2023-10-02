using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveType:BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }

    }
}

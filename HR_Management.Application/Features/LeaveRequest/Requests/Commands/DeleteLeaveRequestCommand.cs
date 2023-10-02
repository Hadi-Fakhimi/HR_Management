﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class DeleteLeaveRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestListRequest:IRequest<List<LeaveRequestDto>>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Domain;

namespace HR_Management.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest Mapping
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestList>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
           // CreateMap<LeaveRequest, ChangeLeaveRequestApprovalDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

            #endregion

            #region LeaveAllocation Mapping

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();

            #endregion

            #region LeaveType Mapping

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();

            #endregion



        }

    }
}

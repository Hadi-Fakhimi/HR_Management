using AutoMapper;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto,CreateLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
        }
    }
}

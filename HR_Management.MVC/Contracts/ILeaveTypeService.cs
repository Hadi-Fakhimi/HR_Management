using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVm>> GetLeaveTypes();
        Task<LeaveTypeVm> GetLeaveTypeDetails(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType);
        Task<Response<int>> UpdateLeaveType(int id,LeaveTypeVm leaveType);
        Task<Response<int>> DeleteLeaveType(int id);



    }
}

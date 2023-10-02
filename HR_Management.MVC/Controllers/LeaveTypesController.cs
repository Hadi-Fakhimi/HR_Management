using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }


        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVm createLeave)
        {
            
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeave);
                if (response.Success)
                {
                    return Redirect("index");
                }
                ModelState.AddModelError("",response.ValidationError);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("",e.Message);
                
            }
            return View();
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Edit(int id, LeaveTypeVm updateLeave)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id,updateLeave);
                if (response.Success)
                {
                    return Redirect("index");
                }
                ModelState.AddModelError("", response.ValidationError);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);

            }
            return View();
        }

        // GET: LeaveTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                {
                    return Redirect("index");
                }
                ModelState.AddModelError("", response.ValidationError);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);

            }

            return BadRequest();
        }

        // POST: LeaveTypesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id)
        //{

        //}
    }
}

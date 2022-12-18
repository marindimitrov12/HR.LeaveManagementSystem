using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.LeaveManagement.MVC.Controllers
{
   
        [Authorize]
        public class LeaveRequestsController : Controller
        {
            private readonly ILeaveTypeService _leaveTypeService;
            private readonly ILeaveRequestService _leaveRequestService;
            private readonly IMapper _mapper;

            public LeaveRequestsController(ILeaveTypeService leaveTypeService, ILeaveRequestService leaveRequestService,
                IMapper mapper)
            {
                this._leaveTypeService = leaveTypeService;
                this._leaveRequestService = leaveRequestService;
                this._mapper = mapper;
            }

            // GET: LeaveRequest/Create
            public async Task<ActionResult> Create()
            {
                var leaveTypes = await _leaveTypeService.GetLeaveTypes();
                var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
                var model = new CreateLeaveRequestVM
                {
                    LeaveTypes = leaveTypeItems
                };
                return View(model);
            }

            // POST: LeaveRequest/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(CreateLeaveRequestVM leaveRequest)
            {
                if (ModelState.IsValid)
                {
                    var response = await _leaveRequestService.CreateLeaveRequest(leaveRequest);
                    if (response.Success)
                    {
                        return RedirectToAction("IndexUser");
                    }
                    ModelState.AddModelError("", response.ValidationErrors);
                }

                var leaveTypes = await _leaveTypeService.GetLeaveTypes();
                var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
                leaveRequest.LeaveTypes = leaveTypeItems;

                return View(leaveRequest);
            }

            [Authorize(Roles = "Manager")]
            // GET: LeaveRequestManager
            public async Task<ActionResult> Index()
            {
                var model = await _leaveRequestService.GetAdminLeaveRequestList();
                return View(model);
            }
     
          // GET: LeaveRequestUser
          [HttpGet]
            public async Task<ActionResult> IndexUser()
            {
                 var model = await _leaveRequestService.GetUserLeaveRequests();
                 return View(model);
            }
            [HttpGet]
            public async Task<ActionResult> Details(int id)
            {
                var model = await _leaveRequestService.GetLeaveRequest(id);
                return View(model);
            }
            [HttpGet]
            public async Task<ActionResult> Edit(int id)
            {
             var model=   await _leaveRequestService.GetLeaveRequest(id);
             return View(model);
            }
            [HttpPost]
            public async Task<ActionResult> Edit(int id, LeaveRequestVM leaveRequest)
            {
            try
            {
                var response = await _leaveRequestService.UpdateLeaveRequest(id, leaveRequest);
                if (response.Success)
                {
                    return RedirectToAction("IndexUser");
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveRequest);
            }



        [HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = "Manager")]
            public async Task<ActionResult> ApproveRequest(int id, bool approved)
            {
                try
                {
                    await _leaveRequestService.ApproveLeaveRequest(id, approved);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }
            }
          [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
             {
                     try
                     {
                       var response = await _leaveRequestService.DeleteLeaveRequest(id);
                        if (response.Success)
                        {
                          return RedirectToAction("IndexUser");
                        }

                ModelState.AddModelError("", response.ValidationErrors);
                     }
                     catch (Exception ex)
                     {
                        ModelState.AddModelError("", ex.Message);
                     }

                  return BadRequest();
             }
        }

    
}

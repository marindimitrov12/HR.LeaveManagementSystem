using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestService _service;
        public LeaveRequestsController(ILeaveRequestService service)
        {
            _service = service;
        }
        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _service.GetLeaveRequestListRequest(isLoggedInUser);
            return Ok(leaveRequests);
        }
        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await _service.GetLeaveRequestDetails(id);
            return Ok(leaveRequest);
        }
        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {

            var repsonse = await _service.CreateLeaveRequest(leaveRequest);
            return Ok(repsonse);
        }
        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {

            await _service.UpdateLeaveRequest(leaveRequest,null,id);
            return NoContent();
        }
        // PUT api/<LeaveRequestsController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApproval)
        {
           
            await _service.UpdateLeaveRequest(null, changeLeaveRequestApproval,id);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(int id)
        {

            await _service.DeleteLeaveRequest(id);
            return NoContent();
        }
    }
}

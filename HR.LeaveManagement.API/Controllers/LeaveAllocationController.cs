using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _service;
        public LeaveAllocationController(ILeaveAllocationService service)
        {
            _service = service;
        }
        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedInUser = false)
        {
            var leaveAllocations = await _service.GetLeaveAllocationListRequest(isLoggedInUser);
            return Ok(leaveAllocations);
        }
        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _service.GetLeaveAllocationDetail(id);
            return Ok(leaveAllocation);
        }
        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var repsonse = await _service.CreateLeaveAllocation(leaveAllocation);
            return Ok(repsonse);
        }
        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation,int id)
        {
            await _service.UpdateAllocation(leaveAllocation,id);
            return NoContent();
        }
        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAllocation(id);
            return NoContent();
        }
    }
}

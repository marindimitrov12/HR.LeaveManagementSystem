
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypesService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveTypesController(ILeaveTypesService service, IHttpContextAccessor httpContextAccessor)
        {
            _service=service;
            _httpContextAccessor=httpContextAccessor;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _service.GetListRequest();
            return Ok(leaveTypes);
        }
        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _service.GetLeaveTypeDetailRequest(id);
            return Ok(leaveType);
        }
        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
       // [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var user = _httpContextAccessor.HttpContext.User;
           
            var response = await _service.CreateLeaveType(leaveType);
            return Ok(response);
        }
        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
      //  [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
           
            await _service.UpdateLeaveType(leaveType);
            return NoContent();
        }
        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
       // [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
           
            await _service.DeleteLeaveType(id);
            return NoContent();
        }
    }
}

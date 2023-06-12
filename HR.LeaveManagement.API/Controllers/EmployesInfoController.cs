using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.DTOs.EmployesInfo;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployesInfoController : Controller
{
    private readonly IEmployesService _service;
    public EmployesInfoController(IEmployesService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<List<EmployInfoDto>>> Get()
    {
        var employes = await _service.GetAllEmployes();
        return Ok(employes);
    }
}
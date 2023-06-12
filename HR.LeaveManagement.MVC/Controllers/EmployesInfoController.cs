using HR.LeaveManagement.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;

public class EmployesInfoController : Controller
{
    private readonly IEmployesInfoService _service;
    public EmployesInfoController(IEmployesInfoService service)
    {
        _service = service;
    }
    // GET
    public async Task<ActionResult> Index()
    {
        var employes = await _service.GetAdminLeaveRequestList();
        return View(employes);
    }
}
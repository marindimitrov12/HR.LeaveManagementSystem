using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    public class LeaveTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

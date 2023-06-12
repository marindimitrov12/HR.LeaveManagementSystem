using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services;

public class EmployesInfoService:BaseHttpService,IEmployesInfoService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IClient _httpclient;
    public EmployesInfoService(IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
    {
        this._localStorageService = localStorageService;
        this._httpclient = httpclient;
    }
    public async Task<List<EmployeeVM>> GetAdminLeaveRequestList()
    {
        var employes = await _httpclient.EmployesInfoAsync();
        var result = new List<EmployeeVM>();
        foreach (var item in employes)
        {
            EmployeeVM vm = new EmployeeVM();
            vm.Email = item.Email;
            vm.Firstname = item.Firstname;
            vm.Lastname = item.Lastname;
            vm.JobTitle = item.JobTitle;
            vm.Salary = item.Salary;
            vm.WorkExperience = item.WorkExperience;
            result.Add(vm);
        }

        return result;
    }
}
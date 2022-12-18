using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, CreateLeaveRequestVM>().ReverseMap();
            CreateMap<LeaveRequestDto, LeaveRequestVM>()
               .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested))
                .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate))
                .ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestVM>()
                .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested))
                .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate))
                .ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<LeaveRequestVM, UpdateLeaveRequestDto>().ReverseMap();
        }
    }
}

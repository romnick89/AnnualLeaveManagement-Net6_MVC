using AnnualLeaveManagement.Web.Data;
using AnnualLeaveManagement.Web.Models;
using AutoMapper;

namespace AnnualLeaveManagement.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AnnualLeaveType, LeaveTypeViewModel>().ReverseMap();
        }
    }
}

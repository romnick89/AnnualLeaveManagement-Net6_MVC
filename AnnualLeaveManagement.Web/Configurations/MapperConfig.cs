using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using AutoMapper;

namespace LeaveManagement.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using DAL;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(Src => Src.EmployeeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.DepartmentName, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}

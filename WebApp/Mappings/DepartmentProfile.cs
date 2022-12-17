using AutoMapper;
using DAL;
using System.Runtime.InteropServices;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<Department, DepartmentViewModel>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;

namespace DataAccessLayer.MappingProfiles;

public class ProjectDTOMapperConfiguration : Profile
{
    public ProjectDTOMapperConfiguration()
    {
        CreateMap<Project, ProjectDTO>();
        //.ForMember(x =>
        //    x.OrderValue, o
        //    => o.MapFrom(p => p.OrderValue))
        //.ForMember(x =>
        //    x.OrderMonth, o
        //    => o.MapFrom(x => x.OrderMonth))
        //.ForMember(x =>
        //    x.OrderYear, o
        //    => o.MapFrom(x => x.OrderYear))
        //.ForMember(x =>
        //    x.Price, o
        //    => o.MapFrom(x => x.Price))
        //.ForMember(x =>
        //    x.Street, o
        //    => o.MapFrom(x => x.Street));
    }
}
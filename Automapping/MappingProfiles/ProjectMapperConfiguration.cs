using AutoMapper;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;

namespace Presentation.Profiles;

public class ProjectMapperConfiguration : Profile
{
    public ProjectMapperConfiguration()
    {
        CreateMap<Project, ProjectDTO>();

        //.ForMember(x =>
        //    x.ProjectId, o
        //    => o.MapFrom(p => p.OrderMonth))
        //.ForMember(x =>
        //    x.OrderValue, o
        //    => o.MapFrom(x => x.BuildingNumber));
    }
}
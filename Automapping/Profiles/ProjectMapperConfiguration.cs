using AutoMapper;
using DataAccessLayer.Models;
using Presentation.ViewModels;

namespace Automapping.Profiles;

public class ProjectMapperConfiguration : Profile
{
    public ProjectMapperConfiguration()
    {
        CreateMap<Project, ProjectViewModel>()
            .ForMember(x =>
                x.ProjectId, o
                => o.MapFrom(p => p.BranchId))
            .ForMember(x => 
                x.OrderValue, o
                => o.Ignore());
    }
}
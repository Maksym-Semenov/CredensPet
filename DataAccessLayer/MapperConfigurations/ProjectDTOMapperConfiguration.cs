using AutoMapper;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;

namespace DataAccessLayer.MappingProfiles;

public class ProjectDTOMapperConfiguration
{
    public static Mapper MapToBranchDTO()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
            x.CreateMap<Project, ProjectDTO>());
       
            var mapper = new Mapper(mapperConfiguration);

        return mapper;
    }
}
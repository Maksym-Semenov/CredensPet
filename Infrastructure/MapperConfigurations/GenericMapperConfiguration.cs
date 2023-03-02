using AutoMapper;

namespace Presentation.Profiles;

public class GenericMapperConfiguration<T, K> where T  : class where K : class
{
    public static Mapper MapTo()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
            x.CreateMap<T, K>());
        var mapper = new Mapper(mapperConfiguration);
        return mapper;
    }
}
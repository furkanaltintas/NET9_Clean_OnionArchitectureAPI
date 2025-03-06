using AutoMapper;
using AutoMapper.Internal;

namespace OnionDemo.Mapper.AutoMapper;

public class Mapper : Application.Interfaces.AutoMapper.IMapper
{
    private static List<TypePair> _typePairs = new();
    private IMapper? MapperContainer;

    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<TSource, TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer.Map<IList<TSource>, IList<TDestination>>(sources);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);
        return MapperContainer.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        Config<TDestination, IList<object>>(5, ignore);
        return MapperContainer.Map<IList<TDestination>>(source);
    }



    private void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));

        if (_typePairs.Any(p => p.DestinationType == typePair.DestinationType && p.SourceType == typePair.SourceType) && ignore is null)
            return;

        _typePairs.Add(typePair);

        var config = new MapperConfiguration(cfg =>
        {
            foreach (var item in _typePairs)
            {
                if (ignore is not null)
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, m => m.Ignore()).ReverseMap();
                else
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
            }
        });

        MapperContainer = config.CreateMapper();
    }
}
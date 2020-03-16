using AutoMapper;
using System;
using AutoMapper.Extensions.ExpressionMapping;

namespace Documents.Tracker.Core.Config.Mapper
{
    internal abstract class MapperCore
    {
        public static IMapper Mapper => Lazy.Value;

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapperProfile>();
                cfg.AddExpressionMapping();
            });
            var mapper = config.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return mapper;
        });

    }
}

using AutoMapper;

namespace Documents.Tracker.Core.Config.Mapper
{
    public static class MapperSetup 
    {
        public static IMapper IMapperSetup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());

            });
            return mappingConfig.CreateMapper();
        }
    }
}

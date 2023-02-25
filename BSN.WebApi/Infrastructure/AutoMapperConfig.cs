using AutoMapper;

namespace BSN.WebApi.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<SourceObject, DestinationObject>();
            });

            mapperConfiguration.AssertConfigurationIsValid();
        }
    }

}

using AutoMapper;

namespace LuftbornBackendApi.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //User
                cfg.AddProfile<UserMappingProfiles>();
            });

            return config;
        }
    }
}

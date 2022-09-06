namespace Func_mk_test
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<Provider, FirelyProvider>();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}

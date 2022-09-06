using AutoMapper;

namespace Func_mk_test.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Provider, FirelyProvider>();
        }
    }
}

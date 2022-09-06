using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Func_mk_test.Startup))]
namespace Func_mk_test
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            Console.WriteLine("hoge1");
            AutoMapperConfig.Configure();
            //builder.Services.AddAutoMapper(typeof(Func_mk_test.Startup));
        }
    }
}

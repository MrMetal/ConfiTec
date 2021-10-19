using System;
using DemoConfiTec.Business.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DemoConfiTec.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
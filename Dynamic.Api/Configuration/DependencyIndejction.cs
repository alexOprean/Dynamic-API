namespace Dynamic.Api.DependencyInjection
{
    using AutoMapper;
    using Dynamic.Business.Services;
    using Dynamic.Api.ActionFilters;
    using Dynamic.Core.AutoMapper;
    using Dynamic.Core.Interfaces;
    using Dynamic.Core.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyIndejction
    {
        public static void Init(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddScoped<PerformanceFilter>();
            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddScoped<IDynamicService, DynamicService>();

            SetAutoMapper(services);
        }

        private static void SetAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}

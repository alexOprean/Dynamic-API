namespace Dynamic.Api
{
    using Dynamic.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using DependencyInjection;
    using Dynamic.Api.Configuration;
    using Dynamic.Api.ActionFilters;
    using Dynamic.Api.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new BsonDocumentJsonConverter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DynamicAPI", Version = "v1" });
            });

            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(PerformanceFilter));
            });

            services.AddSingleton<Context>(serviceProvider => new Context(
                Configuration.GetConnectionString("ServerName"),
                Configuration.GetConnectionString("DatabaseName"),
                Configuration.GetConnectionString("DefaultCollection")));

            LoggingConfiguration.Init();
            DependencyIndejction.Init(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }
            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}

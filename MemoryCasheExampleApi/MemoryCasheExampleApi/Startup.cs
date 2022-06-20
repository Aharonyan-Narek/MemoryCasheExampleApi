using MemoryCasheExampleApi.Options;
using MemoryCasheExampleApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MemoryCasheExampleApi;

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
        services.AddMemoryCache(_ => { });
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MemoryCasheExampleApi", Version = "v1" });
        });
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<IUserCasheManager, UserCasheManager>();
        services.AddOptions<UserCasheOptions>()
            .Bind(Configuration.GetSection(nameof(UserCasheOptions)));
        //.ValidateDataAnnotations()
        //.Validate(config =>
        //    {
        //        if (config.SizeLimitInMB > 2048)
        //            return false;

        //        return true;
        //    }, "Cashe configurations should be defined");
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MemoryCasheExampleApi v1"));
        }

        app.UseHttpLogging();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
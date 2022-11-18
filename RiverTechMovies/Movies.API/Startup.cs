using Movies.API.Installer.Base;
using Movies.API.Middleware;
using Movies.Domain.Config;

namespace Movies.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServiceAssembly(Configuration);
        
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.ConfigureExceptionHandler(logger);

        var swaggerOptions = new SwaggerOptions();
        Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

        app.UseSwagger(option =>
        {
            option.RouteTemplate = swaggerOptions.JsonRoute;
        });

        app.UseSwaggerUI(option =>
        {
            option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x =>
        {
            x.AllowAnyOrigin();
            x.AllowAnyMethod();
            x.AllowAnyHeader();
        });
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    
}
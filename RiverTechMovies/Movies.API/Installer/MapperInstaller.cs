using Movies.API.Installer.Base;
using Movies.Application.Movie.Mapper;

namespace Movies.API.Installer;

public class MapperInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MovieMapper));
    }
}
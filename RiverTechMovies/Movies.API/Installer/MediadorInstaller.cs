using System.Reflection;
using Movies.API.Installer.Base;
using Movies.Application.Movie.Commmand;
using MediatR;

namespace Movies.API.Installer;

public class MediadorInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(AddMovieCommand).GetTypeInfo().Assembly);

    }
}
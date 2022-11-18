namespace Movies.API.Installer.Base;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
namespace Movies.API.Installer.Base;

public static class InstallerExtensions
{
    public static void InstallServiceAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration));
    }
}
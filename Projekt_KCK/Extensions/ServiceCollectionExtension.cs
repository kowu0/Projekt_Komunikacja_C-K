using Projekt_KCK.Services;

namespace Projekt_KCK.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AdministratorMotherboardService>();
            serviceCollection.AddTransient<AdministratorCpuService>();
            serviceCollection.AddTransient<AdministratorGpuService>();
            serviceCollection.AddTransient<AdministratorRamService>();
            serviceCollection.AddTransient<AdministratorDiskService>();
            serviceCollection.AddTransient<AdministratorPsuService>();
            serviceCollection.AddTransient<AdministratorCaseService>();
            serviceCollection.AddTransient<AdministratorCoolerService>();
            serviceCollection.AddTransient<ConfiguratorService>();
            serviceCollection.AddDbContext<AppDbContext>();
            return serviceCollection;
        }
    }
}

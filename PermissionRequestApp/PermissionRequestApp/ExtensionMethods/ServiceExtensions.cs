using Microsoft.Extensions.DependencyInjection;
using PermissionRequestApp.Contracts;
using PermissionRequestApp.Repository;

namespace PermissionRequestApp.ExtensionMethods
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}

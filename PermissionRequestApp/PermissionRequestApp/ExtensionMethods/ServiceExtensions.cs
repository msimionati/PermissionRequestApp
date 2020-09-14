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

        public static void CordsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                     builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                  );
            });
        }
    }
}

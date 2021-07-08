using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Samples.Decorator.Services.Repository;
using Samples.Shared.Interfaces;
namespace Samples.Decorator
{
    public static class DecoratorStartupExtension
    {
        public static void AddDecoratorProjectServices(this IServiceCollection services)
        {

            services.AddMemoryCache(); // Don't forget to add this line to your startup. If you forget to do so then "Object Reference error" will be thrown.
            services.AddScoped(serviceprovider =>
            {
                var httpClient = new HttpClient();
                var memoryCache = serviceprovider.GetService<IMemoryCache>();

                IUserRepository concreteUserRepository = new UserRepository(httpClient);
                IUserRepository withCachingDecorator = new UserRepositoryCachingServiceDecorator(concreteUserRepository, memoryCache);
                return withCachingDecorator;
            });
        }
    }
}

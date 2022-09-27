using Bcm.BcmAir.Infrastructure.Common.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Bcm.BcmAir.Infrastructure.Common.Extensions
{
    public static class ServiceBusServiceCollectionExtensions
    {
        public static void AddServiceBus(this IServiceCollection services)
        {
            services.AddSingleton<IServiceBus, DaprServiceBus>();
        }
    }
}

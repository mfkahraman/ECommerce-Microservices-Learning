using ECommerce.Order.Application.Features.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Order.Application.Extentions
{
    public static class ApplicationRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
        }
    }
}

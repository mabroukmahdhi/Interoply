// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Interoply.Services.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Interoply.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInteroply(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }
}

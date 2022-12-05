using BlackJack.Events.Abstractions.Sender;
using BlackJack.Events.Sender;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.Events.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlackJackEvents(this IServiceCollection services)
    {
        services.AddTransient<IEventGridSenderFactory, EventGridSenderFactory>();
        return services;
    }
}
using System.ComponentModel;
using Azure.Identity;
using Azure.Messaging.EventGrid;
using BlackJack.Core.Configuration;
using BlackJack.Events.Abstractions.Sender;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlackJack.Events.Sender;

public class EventGridSenderFactory : IEventGridSenderFactory
{
    private readonly IOptions<AzureConfiguration> _configuration;
    private readonly ILogger<EventGridSender> _logger;

    public IEventGridSender CreateWithMsi(string topicEndpoint = null)
    {
        var eventGridTopicEndpoint = _configuration.Value.EventGridTopicEndpoint;
        if (string.IsNullOrWhiteSpace(eventGridTopicEndpoint))
        {
            throw new Exception("Expected a configuration value 'Azure:EventGridTopicEndpoint' pointing to an event grid topic");
        }

        var identity = new DefaultAzureCredential();
        var eventGridClient = new EventGridPublisherClient(
            new Uri(eventGridTopicEndpoint),
            identity);

        return new EventGridSender(eventGridClient, _logger);
    }

    public EventGridSenderFactory(IOptions<AzureConfiguration> configuration, ILogger<EventGridSender> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
}
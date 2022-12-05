using Azure.Messaging;
using Azure.Messaging.EventGrid;
using BlackJack.Events.Abstractions.Events;
using BlackJack.Events.Abstractions.Sender;
using Microsoft.Extensions.Logging;

namespace BlackJack.Events.Sender;

public class EventGridSender: IEventGridSender
{
    private readonly EventGridPublisherClient _client;
    private readonly ILogger<EventGridSender> _logger;

    public async Task<bool> SendEventAsync(IBlackJackEvent blackJackEvent)
    {
        var cloudEvent = new CloudEvent(blackJackEvent.EventSource, blackJackEvent.EventType, null);
        var response = await _client.SendEventAsync(cloudEvent);
        return !response.IsError;
    }
    public async Task<bool> SendEventAsync<TEventData>(IBlackJackEvent<TEventData> blackJackEvent)
    {
        var cloudEvent = new CloudEvent(blackJackEvent.EventSource, blackJackEvent.EventType, blackJackEvent.Data);
        var response = await _client.SendEventAsync(cloudEvent);
        return !response.IsError;
    }

    internal EventGridSender(EventGridPublisherClient client, ILogger<EventGridSender> logger)
    {
        _client = client;
        _logger = logger;
    }
}
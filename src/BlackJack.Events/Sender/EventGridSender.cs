using System.Text.Json;
using Azure.Messaging.EventGrid;
using BlackJack.Events.Abstractions.Events;
using BlackJack.Events.Abstractions.Sender;
using Microsoft.Extensions.Logging;

namespace BlackJack.Events.Sender;

public class EventGridSender: IEventGridSender
{
    private readonly EventGridPublisherClient _client;
    private readonly ILogger<EventGridSender> _logger;

    public Task<bool> SendEventAsync(IBlackJackEvent blackJackEvent)
    {
        var eventGridEvent = ToEventGridEvent(blackJackEvent);
        return PublishEvent(eventGridEvent);
    }
    public Task<bool> SendEventAsync<TEventData>(IBlackJackEvent<TEventData> blackJackEvent)
    {
        var eventGridEvent = ToEventGridEvent(blackJackEvent);
        return PublishEvent(eventGridEvent);
    }

    private async Task<bool> PublishEvent(EventGridEvent evt)
    {
        _logger.LogInformation("Publishing event grid event {eventType}", evt.EventType);
        var response = await _client.SendEventAsync(evt);
        return !response.IsError;
    }

    private EventGridEvent ToEventGridEvent<TEventData>(IBlackJackEvent<TEventData> blackJackEvent)
    {
        //var jsonData = JsonSerializer.Serialize();
        return new EventGridEvent(
            blackJackEvent.EventSource,
            blackJackEvent.EventType,
            blackJackEvent.Version,
            blackJackEvent.Data);
    }
    private EventGridEvent ToEventGridEvent(IBlackJackEvent blackJackEvent)
    {
        return new EventGridEvent(
            blackJackEvent.EventSource,
            blackJackEvent.EventType,
            blackJackEvent.Version,
            null);
    }

    internal EventGridSender(EventGridPublisherClient client, ILogger<EventGridSender> logger)
    {
        _client = client;
        _logger = logger;
    }
}
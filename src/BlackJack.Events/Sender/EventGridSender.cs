﻿using Azure.Messaging.EventGrid;
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
        _logger.LogInformation("Broadcasting event grid message {msg}", blackJackEvent);
        var cloudEvent = new EventGridEvent(blackJackEvent.EventSource, blackJackEvent.EventType, "1", null);
        var response = await _client.SendEventAsync(cloudEvent);
        return !response.IsError;
    }
    public async Task<bool> SendEventAsync<TEventData>(IBlackJackEvent<TEventData> blackJackEvent)
    {
        _logger.LogInformation("Broadcasting event grid message {msg}", blackJackEvent);
        var cloudEvent = new EventGridEvent(blackJackEvent.EventSource, blackJackEvent.EventType, "1", blackJackEvent);
        var response = await _client.SendEventAsync(cloudEvent);
        return !response.IsError;
    }

    internal EventGridSender(EventGridPublisherClient client, ILogger<EventGridSender> logger)
    {
        _client = client;
        _logger = logger;
    }
}
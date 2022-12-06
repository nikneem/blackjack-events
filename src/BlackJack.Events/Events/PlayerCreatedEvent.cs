using BlackJack.Events.Abstractions.Events;
using BlackJack.Events.EventData;

namespace BlackJack.Events.Events;

public class PlayerCreatedEvent : IBlackJackEvent<PlayerCreatedEventData>
{
    public string EventSource => "/cloudevents/blackjack/players";
    public string EventType => "Player.Created";
    public PlayerCreatedEventData Data { get; set; }

    private PlayerCreatedEvent() { }

    public static PlayerCreatedEvent Create(Guid userId, Guid sessionId)
    {
        var data = new PlayerCreatedEventData
        {
            SessionId = sessionId,
            UserId = userId
        };
        return new PlayerCreatedEvent
        {
            Data = data
        };
    }
}
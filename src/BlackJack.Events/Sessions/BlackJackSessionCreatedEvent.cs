using BlackJack.Events.Sessions.EventData;

namespace BlackJack.Events.Sessions;

public class BlackJackSessionCreatedEvent : BlackJackSessionEvent<BlackJackSessionCreatedEventData>
{
    public override string EventType { get; set; } = BlackJackEventNames.SessionCreated;
    public override string Version => "v1";
    public override BlackJackSessionCreatedEventData Data { get; set; } = null!;

    public static BlackJackSessionCreatedEvent Create(Guid userId, Guid sessionId)
    {
        var data = new BlackJackSessionCreatedEventData
        {
            SessionId = sessionId,
            UserId = userId
        };
        return new BlackJackSessionCreatedEvent
        {
            Data = data
        };
    }

}
using BlackJack.Events.EventData;

namespace BlackJack.Events.Events.Sessions;

public class BlackJackSessionCreatedEvent : BlackJackSessionEvent<TableCreatedEventData>
{
    public override string EventType { get; set; } = BlackJackEventNames.SessionCreated;
    public override string Version => "v1";
    public override TableCreatedEventData Data { get; set; } = null!;

    public static BlackJackSessionCreatedEvent Create(Guid userId, Guid sessionId)
    {
        var data = new TableCreatedEventData
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
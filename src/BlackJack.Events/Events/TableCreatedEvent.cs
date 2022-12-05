using BlackJack.Events.Abstractions.Events;
using BlackJack.Events.EventData;

namespace BlackJack.Events.Events;

public class TableCreatedEvent : IBlackJackEvent<TableCreatedEventData>
{
    public string EventSource => "/cloudevents/blackjack/sessions";
    public string EventType => "Session.Created";
    public TableCreatedEventData Data { get; set; } = null!;


    private TableCreatedEvent(){}

    public static TableCreatedEvent Create(Guid userId, Guid sessionId)
    {
        var data = new TableCreatedEventData
        {
            SessionId = sessionId,
            UserId = userId
        };
        return new TableCreatedEvent
        {
            Data = data
        };
    }

}
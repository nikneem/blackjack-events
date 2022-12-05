namespace BlackJack.Events.EventData;

public class TableCreatedEventData
{
    public Guid UserId { get; set; }
    public Guid SessionId { get; set; }
}
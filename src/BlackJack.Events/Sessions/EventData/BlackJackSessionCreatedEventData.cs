namespace BlackJack.Events.Sessions.EventData;

public class BlackJackSessionCreatedEventData
{
    public Guid UserId { get; set; }
    public Guid SessionId { get; set; }
}
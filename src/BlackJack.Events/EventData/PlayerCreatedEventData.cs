namespace BlackJack.Events.EventData;

public class PlayerCreatedEventData
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SessionId { get; set; }
    public string DisplayName { get; set; }
    public bool IsDealer { get; set; }
    public int Order { get; set; }
}
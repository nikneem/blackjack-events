namespace BlackJack.Events.Players.EventData;

public class BlackJackPlayerAddedEventData
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string DisplayName { get; set; }
    public int Order { get; set; }
    public bool IsDealer { get; set; }
}
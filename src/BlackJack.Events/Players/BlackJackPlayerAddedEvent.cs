using BlackJack.Events.Sessions;
using BlackJack.Events.Players.EventData;

namespace BlackJack.Events.Players;

public class BlackJackPlayerAddedEvent : BlackJackSessionEvent<BlackJackPlayerAddedEventData>
{
    public override string EventType { get; set; } = BlackJackEventNames.PlayerAdded;
    public override string Version => "v1";
    public override BlackJackPlayerAddedEventData Data { get; set; } = null!;

    public static BlackJackPlayerAddedEvent Create(Guid id, Guid userId, string displayName, int order, bool dealer)
    {
        var data = new BlackJackPlayerAddedEventData
        {
            Id = id,
            UserId = userId,
            DisplayName = displayName,
            Order = order,
            IsDealer = dealer
        };
        return new BlackJackPlayerAddedEvent
        {
            Data = data
        };
    }

}
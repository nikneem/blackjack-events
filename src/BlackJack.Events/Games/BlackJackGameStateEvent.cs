using BlackJack.Events.Games.EventData;
using BlackJack.Events.Sessions;

namespace BlackJack.Events.Games;


public class BlackJackGameStateEvent : BlackJackSessionEvent<BlackJackGameStateEventData>
{
    public override string EventType { get; set; } = BlackJackEventNames.GameState;
    public override string Version => "v1";
    public override BlackJackGameStateEventData Data { get; set; } = null!;

    public static BlackJackGameStateEvent Create(Guid id, Guid userId, string displayName, int order, bool dealer)
    {
        var data = new BlackJackGameStateEventData
        {
            Id = id,
            UserId = userId,
            DisplayName = displayName,
            Order = order,
            IsDealer = dealer
        };
        return new BlackJackGameStateEvent
        {
            Data = data
        };
    }

}
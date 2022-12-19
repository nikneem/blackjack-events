namespace BlackJack.Events.Players;

public abstract class BlackJackPlayerEvent<TEventData> : BlackJackEvent<TEventData> where TEventData : class
{
    public override string EventSource { get; set; } = "cloudevents/blackjack/players";
}
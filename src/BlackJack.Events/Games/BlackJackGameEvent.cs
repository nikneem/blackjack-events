namespace BlackJack.Events.Games;

public abstract class BlackJackGameEvent<TEventData> : BlackJackEvent<TEventData> where TEventData : class
{
    public override string EventSource { get; set; } = "cloudevents/blackjack/games";
}
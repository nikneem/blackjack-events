namespace BlackJack.Events.Sessions;

public abstract class BlackJackSessionEvent<TEventData> : BlackJackEvent<TEventData> where TEventData : class
{
    public override string EventSource { get; set; } = "cloudevents/blackjack/sessions";
}
namespace BlackJack.Events.Events.Sessions;

public abstract class BlackJackSessionEvent<TEventData> : BlackJackEvent<TEventData>
{
    public override string EventSource { get; set; } = "cloudevents/blackjack/sessions";
}
namespace BlackJack.Events.Abstractions.Events;

public interface IBlackJackEvent
{
    public string EventSource { get; }
    public string EventType { get; }
}
public interface IBlackJackEvent<out TEventData> : IBlackJackEvent
{
    public TEventData Data { get; }
}
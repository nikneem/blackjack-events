using BlackJack.Events.Abstractions.Events;

namespace BlackJack.Events.Abstractions.Sender;

public interface IEventGridSender
{
    Task<bool> SendEventAsync(IBlackJackEvent blackJackEvent);
    Task<bool> SendEventAsync<TEventData>(IBlackJackEvent<TEventData> blackJackEvent);
}
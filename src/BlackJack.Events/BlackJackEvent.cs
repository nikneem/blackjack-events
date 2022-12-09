using BlackJack.Events.Abstractions.Events;

namespace BlackJack.Events
{
    public abstract class BlackJackEvent<TEventData> : IBlackJackEvent<TEventData> where TEventData : class
    {
        public abstract string EventSource { get; set; }
        public abstract string EventType { get; set; }
        public abstract string Version { get; }
        public abstract TEventData Data { get; set; }
    }
}

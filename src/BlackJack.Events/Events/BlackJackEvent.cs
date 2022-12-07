﻿using BlackJack.Events.Abstractions.Events;

namespace BlackJack.Events.Events
{
    public abstract class BlackJackEvent<TEventData>: IBlackJackEvent<TEventData>
    {
        public abstract string EventSource { get; set; }
        public abstract string EventType { get; set; }
        public abstract TEventData Data { get; set; }
    }
}
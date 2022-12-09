using System.Diagnostics.Contracts;
using BlackJack.Events.Abstractions.Events;
using BlackJack.Events.Abstractions.Sender;
using BlackJack.Events.EventData;
using BlackJack.Events.Sender;
using BlackJack.Events.Sessions;
using Moq;
using Newtonsoft.Json;

namespace BlackJack.Events.Tests.Events.Sessions;

public class SessionEventsTests
{

    private Mock<IEventGridSenderFactory> _eventGridSenderFactory;
    private Mock<IEventGridSender> _eventGridSender;

    [Fact]
    public async Task When()
    {
        var evt = BlackJackSessionCreatedEvent.Create(Guid.NewGuid(), Guid.NewGuid());
        var sender = _eventGridSenderFactory.Object.CreateWithMsi();
        await sender.SendEventAsync(evt);

    }

    public string SerializeEventData<TEventData>(IBlackJackEvent<TEventData> blackJackEvent)
    {
        var eventData = JsonConvert.SerializeObject(blackJackEvent.Data);
        return eventData;
    }

    private void With()
    {
        _eventGridSender.Setup(x => x.SendEventAsync(It.IsAny<IBlackJackEvent>()))
            .ReturnsAsync(true);
    }

    public SessionEventsTests()
    {

        _eventGridSender = new Mock<IEventGridSender>();
        _eventGridSenderFactory = new Mock<IEventGridSenderFactory>();
        _eventGridSenderFactory
            .Setup(factory => factory.CreateWithMsi(It.IsAny<string>()))
            .Returns(_eventGridSender.Object);
    }
}
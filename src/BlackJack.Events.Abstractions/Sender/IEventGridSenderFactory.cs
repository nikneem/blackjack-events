namespace BlackJack.Events.Abstractions.Sender;

public interface IEventGridSenderFactory
{
    IEventGridSender CreateWithMsi(string topicEndpoint = null);
}
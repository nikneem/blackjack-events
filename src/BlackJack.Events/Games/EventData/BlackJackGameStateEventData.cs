namespace BlackJack.Events.Games.EventData;

public class BlackJackGameStateEventData
{
    /// <summary>
    /// This is the ID of the game currently played
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// This is the player ID if the player that has turn
    /// </summary>
    public Guid? PlayerTurn { get; set; }
    
    /// <summary>
    /// This is an indicator of the current status of the game. 0 - Waiting for players, 1 - Waiting for player inputs, 2 - Waiting for dealer input, 3 - Announce winner(s)
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// When populated, this array shows the winners of the game
    /// </summary>
    public List<Guid> Winners { get; set; } = null!;
}
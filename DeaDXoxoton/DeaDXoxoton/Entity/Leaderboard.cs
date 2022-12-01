namespace DeaDXoxoton.Entity;

public class Leaderboard
{
    public int GameId { get; set; }
    public int Score { get; set; }
    public string PlayerName { get; set; }

    public Leaderboard(int gameId, int score, string playerName)
    {
        GameId = gameId;
        Score = score;
        PlayerName = playerName;
    }
}
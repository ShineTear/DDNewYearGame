using System.Text.Json;
using System.Text.Json.Serialization;
using DeaDXoxoton.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DeaDXoxoton.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    [HttpGet(Name = "ShowScore")]
    public List<Leaderboard> ShowScoreOnGame(string gameName)
    {
        var leaderboard = LoadLeaderboard();
        return leaderboard.Where(x => x.GameName.Equals(gameName)).ToList();
    }
    
    /*private List<Leaderboard> LoadLeaderboardFromDatabase()
    {
        var leaderboard = new List<Leaderboard>();
        var db = new DbConnectionFactory();
        var connection = db.OpenAsync(CancellationToken.None);
        connection.Result.Database.
        using (StreamReader r = new StreamReader("Score.json"))
        {
            string json = r.ReadToEnd();
            leaderboard = JsonSerializer.Deserialize<List<Leaderboard>>(json);
        }

        return leaderboard;
    }*/
    
    private List<Leaderboard> LoadLeaderboard()
    {
        var leaderboard = new List<Leaderboard>();
        using (StreamReader r = new StreamReader("Score.json"))
        {
            string json = r.ReadToEnd();
            leaderboard = JsonSerializer.Deserialize<List<Leaderboard>>(json);
        }

        return leaderboard;
    }
}
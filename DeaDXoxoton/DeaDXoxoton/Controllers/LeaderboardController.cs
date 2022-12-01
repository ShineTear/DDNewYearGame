using System.Text.Json;
using DeaDXoxoton.Entity;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DeaDXoxoton.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderboardController : ControllerBase
{
    [HttpGet(Name = "ShowScoreOnGame")]
    public async Task<List<Leaderboard>> ShowScoreOnGame(int gameId)
    {
        var leaderboard = await LoadLeaderboardFromDatabaseAsync().ConfigureAwait(false);
        return leaderboard.Where(x => x.GameId.Equals(gameId)).OrderByDescending(x => x.Score).ToList();
    }

    private async Task<List<Leaderboard>> LoadLeaderboardFromDatabaseAsync()
    {
        var leaderboard = new List<Leaderboard>();
        var db = new DbConnectionFactory();
        var connection = await db.OpenAsync(CancellationToken.None).ConfigureAwait(false);

        var sql = "SELECT * FROM leaders";
        using var cmd = new NpgsqlCommand(sql, connection);

        using var rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            var gameId = rdr.GetInt32(0);
            var score = rdr.GetInt32(1);
            var playerName = rdr.GetString(2);
            leaderboard.Add(new Leaderboard(gameId, score, playerName));
        }

        return leaderboard;
    }

    [HttpPost(Name = "SaveScoreByGame")]
    public async Task SaveScoreByGame(int gameId, int score, string playerName)
    {
        var db = new DbConnectionFactory();
        var connection = await db.OpenAsync(CancellationToken.None).ConfigureAwait(false);

        var sql = string.Format("INSERT INTO public.leaders (game_id, score, player_name) VALUES({0}, {1}, '{2}')",
            gameId, score, playerName);
        var cmd = new NpgsqlCommand(sql, connection);
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    private List<Leaderboard> LoadLeaderboard()
    {
        var leaderboard = new List<Leaderboard>();
        using (var r = new StreamReader("Score.json"))
        {
            var json = r.ReadToEnd();
            leaderboard = JsonSerializer.Deserialize<List<Leaderboard>>(json);
        }

        return leaderboard;
    }
}
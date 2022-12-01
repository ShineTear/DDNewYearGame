using DeaDXoxoton.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace DeaDXoxoton.Controllers;

[ApiController]
[Route("api/leaderboard")]
public class LeaderboardController : ControllerBase
{
    [HttpGet("")]
    public Task<IEnumerable<LeaderboardScore>> ShowScoreOnGame(CancellationToken cancellationToken)
    {
        return LeaderboardScoreDb.GetAllAsync(cancellationToken);
    }

    [HttpPost("score")]
    public Task SaveScoreByGame(
        [FromBody] LeaderboardScore entity,
        CancellationToken cancellationToken)
    {
        return LeaderboardScoreDb.WriteAsync(entity, cancellationToken);
    }

    [HttpGet("score/{playerName}")]
    public Task<LeaderboardScore?> GetScoreAsync(
        [FromRoute] string playerName,
        CancellationToken cancellationToken)
    {
        return LeaderboardScoreDb.GetAsync(playerName, cancellationToken);
    }
}
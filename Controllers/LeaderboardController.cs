using DeaDXoxoton.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace DeaDXoxoton.Controllers;

[ApiController]
[Route("api/leaderboard")]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardScoreDb _db;

    public LeaderboardController(LeaderboardScoreDb db)
    {
        _db = db;
    }

    [HttpGet("")]
    public Task<IEnumerable<LeaderboardScore>> ShowScoreOnGame(CancellationToken cancellationToken)
    {
        return _db.GetAllAsync(cancellationToken);
    }

    [HttpPost("score")]
    public Task SaveScoreByGame(
        [FromBody] LeaderboardScore entity,
        CancellationToken cancellationToken)
    {
        return _db.WriteAsync(entity, cancellationToken);
    }
}
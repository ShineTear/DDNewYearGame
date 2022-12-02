using Dapper;

namespace DeaDXoxoton.Implementation;

public class LeaderboardScoreDb
{
    private readonly DbConnection _connection;

    public LeaderboardScoreDb(DbConnection connection)
    {
        _connection = connection;
    }
    /*
    CREATE TABLE public.leaderboard_scores (
	    player_name text NOT NULL,
	    score int8 NOT NULL,
	    CONSTRAINT leaderboard_scores_pk PRIMARY KEY (player_name)
    );
    */

    public async Task WriteAsync(
        LeaderboardScore entity,
        CancellationToken cancellationToken)
    {
        if (entity.Score <= 0)
        {
            return;
        }

        using var db = await _connection.OpenAsync(cancellationToken);

        const string sql = @"
INSERT INTO leaderboard_scores (player_name, score) 
VALUES (@PlayerName, @Score)
ON CONFLICT (player_name)
DO UPDATE
SET score = excluded.score
WHERE leaderboard_scores.score < excluded.score";

        await db.ExecuteAsync(sql, entity);
    }


    public async Task<IEnumerable<LeaderboardScore>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var db = await _connection.OpenAsync(cancellationToken);

        const string sql = @"
SELECT player_name, score 
FROM leaderboard_scores
ORDER BY score DESC";

        return await db.QueryAsync<LeaderboardScore>(sql);
    }
}
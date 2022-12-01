using Dapper;

namespace DeaDXoxoton.Implementation;

public static class LeaderboardScoreDb
{
    /*
    CREATE TABLE public.leaderboard_scores (
	    player_name text NOT NULL,
	    score int8 NOT NULL,
	    CONSTRAINT leaderboard_scores_pk PRIMARY KEY (player_name)
    );
    */

    public static async Task WriteAsync(
        LeaderboardScore entity,
        CancellationToken cancellationToken)
    {
        using var db = await DbConnection.OpenAsync(cancellationToken);

        const string sql = @"
INSERT INTO leaderboard_scores (player_name, score) 
VALUES (@PlayerName, @Score)
ON CONFLICT (player_name)
DO UPDATE
SET score = excluded.score";

        await db.ExecuteAsync(sql, entity);
    }

    public static async Task<LeaderboardScore?> GetAsync(
        string playerName,
        CancellationToken cancellationToken)
    {
        using var db = await DbConnection.OpenAsync(cancellationToken);

        const string sql = @"
SELECT player_name, score 
FROM leaderboard_scores 
WHERE player_name = @PlayerName";

        return await db.QuerySingleOrDefaultAsync<LeaderboardScore?>(sql, new { PlayerName = playerName });
    }

    public static async Task<IEnumerable<LeaderboardScore>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var db = await DbConnection.OpenAsync(cancellationToken);

        const string sql = @"
SELECT player_name, score 
FROM leaderboard_scores";

        return await db.QueryAsync<LeaderboardScore>(sql);
    }
}
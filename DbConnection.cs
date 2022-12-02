using System.Data;
using Npgsql;

namespace DeaDXoxoton;

public class DbConnection
{
    private readonly string connectionString;

    public DbConnection(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("PG");
    }

    public async Task<IDbConnection> OpenAsync(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(connectionString);

        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        return connection;
    }
}
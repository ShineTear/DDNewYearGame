using System.Data;
using Npgsql;

namespace DeaDXoxoton;

public static class DbConnection
{
    public static async Task<IDbConnection> OpenAsync(CancellationToken cancellationToken)
    {
        const string connectionString =
            @"Host=localhost;Port=5432;Database=deadhohoton;Username=pguser;Password=pgpwd";

        var connection = new NpgsqlConnection(connectionString);

        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        return connection;
    }
}
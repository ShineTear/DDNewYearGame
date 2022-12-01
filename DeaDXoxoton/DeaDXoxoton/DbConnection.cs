using System.Data;
using Npgsql;

namespace DeaDXoxoton;

public class DbConnectionFactory
{
    private string connectionString = "Host=localhost;Port=5432;Database=ddxoxoton;Username=pguser;Password=pgpwd";
    private readonly NpgsqlConnectionStringBuilder connectionStringBuilder;

    public DbConnectionFactory()
    {
        connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
    }

    public async Task<NpgsqlConnection?> OpenAsync(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(connectionStringBuilder.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        return connection;
    }
    
    
    //Host=vm-evtca-pg;Port=5432;Database={dbName};Username=evrika;Password=*****
}
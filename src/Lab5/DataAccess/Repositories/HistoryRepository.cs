using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Histories;
using Npgsql;

namespace Infrastructure.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<History> GetByAccountId(long id)
    {
        const string sql = "SELECT * FROM History WHERE account_id = @id";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        while (await reader.ReadAsync().ConfigureAwait(true))
        {
            yield return new History(
                reader.GetInt64(0),
                reader.GetInt64(1),
                reader.GetDateTime(2),
                reader.GetDecimal(3));
        }
    }

    public async Task AddHistory(long accountId, DateTime dateTime, decimal amount)
    {
        const string sql = "INSERT INTO History (account_id, date_time, amount) VALUES (@accountId, @dateTime , @amount)";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@accountId", accountId);
        command.Parameters.AddWithValue("@dateTime", dateTime);
        command.Parameters.AddWithValue("@amount", amount);

        await command.ExecuteNonQueryAsync().ConfigureAwait(true);
    }
}
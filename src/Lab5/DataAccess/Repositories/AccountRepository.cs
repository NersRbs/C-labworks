using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Accounts;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account?> GetById(long id)
    {
        const string sql = "SELECT * FROM Account WHERE id = @id";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (!await reader.ReadAsync().ConfigureAwait(true))
            return null;

        return new Account(
            reader.GetInt64(0),
            reader.GetString(1),
            reader.GetDecimal(2));
    }

    public async IAsyncEnumerable<Account> GetAll()
    {
        const string sql = "SELECT * FROM Account";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        while (await reader.ReadAsync().ConfigureAwait(true))
        {
            yield return new Account(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDecimal(2));
        }
    }

    public async Task AddNewUser(int id, string pinCode)
    {
        string hashedPinCode = BCrypt.Net.BCrypt.HashPassword(pinCode);
        const string sql = "INSERT INTO Account (id, hashed_pin_code, balance) VALUES (@id, @hashedPinCode, 0);";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@hashedPinCode", hashedPinCode);

        await command.ExecuteNonQueryAsync().ConfigureAwait(true);
    }

    public async Task Update(Account account)
    {
        string sql = "UPDATE Account SET balance = @balance WHERE id = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", account.Id);
        command.Parameters.AddWithValue("@balance", account.Balance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(true);
    }

    public async Task RemoveById(long id)
    {
        string sql = "DELETE FROM Account WHERE id = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        await command.ExecuteNonQueryAsync().ConfigureAwait(true);
    }
}
using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<string?> GetPinCode()
    {
        const string sql = "SELECT hashed_pin_code FROM Admin;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
            return null;

        return reader.GetString(0);
    }

    public async Task SetPinCode(string pinCode)
    {
        string hashedPinCode = BCrypt.Net.BCrypt.HashPassword(pinCode);

        const string sql = "UPDATE Admin SET hashed_pin_code = @hashedPinCode;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@hashedPinCode", hashedPinCode);

        await command.ExecuteNonQueryAsync().ConfigureAwait(true);
    }
}
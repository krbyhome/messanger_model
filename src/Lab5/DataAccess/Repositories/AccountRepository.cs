using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Account;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _provider;

    public AccountRepository(IPostgresConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task<Account?> FindAccountById(string? id)
    {
        const string query = """
                             SELECT account_id, user_id, Name, Balance, Pin_Code
                             FROM Bank_Account
                             WHERE Name = :id;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.AddParameter("id", id);
            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                return new Account(
                    Id: reader.GetInt64(0),
                    UserId: reader.GetInt64(1),
                    Name: reader.GetString(2),
                    Balance: reader.GetInt64(3),
                    PinCode: reader.GetString(4));
            }
        }
    }

    public async Task CreateAccount(Account account)
    {
        const string query = """
                             INSERT INTO Bank_Account (user_id, name, balance, pin_code)
                             values (:user_id, :name, :balance, :pin_code);
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("user_id", account.UserId);
            command.Parameters.AddWithValue("balance", account.Balance);
            command.Parameters.AddWithValue("pin_code", account.PinCode);
            command.Parameters.AddWithValue("name", account.Name);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task ChangeBalance(string? id, long money)
    {
        const string query = """
                             UPDATE bank_account
                             SET Balance = :money
                             where Name = :id;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("money", money);
            if (id is not null)
                command.Parameters.AddWithValue("id", id);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}
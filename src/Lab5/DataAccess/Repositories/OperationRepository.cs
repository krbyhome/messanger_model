using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _provider;

    public OperationRepository(IPostgresConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task AddOperation(Operation? operation)
    {
        const string query = """
                             INSERT INTO Operations (user_id, account_id, type, result, message)
                             VALUES (:user_id, :account_id, :type, :result, :message);
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            if (operation != null)
            {
                command.Parameters.AddWithValue("user_id", operation.UserId);
                command.Parameters.AddWithValue("account_id", operation.AccountId);
                command.Parameters.AddWithValue("type", operation.Type);
                command.Parameters.AddWithValue("result", operation.Result);
                command.Parameters.AddWithValue("message", operation.Message);
            }

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<List<Operation?>> GetOperations(string userId)
    {
        const string query = """
                             SELECT user_id, account_id, type, result, message
                             FROM Operations
                             WHERE user_id = :user_id;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("user_id", userId);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                var result = new List<Operation?>();

                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    OperationResult operationResult = await reader.GetFieldValueAsync<OperationResult>(3).ConfigureAwait(false);
                    OperationType type = await reader.GetFieldValueAsync<OperationType>(2).ConfigureAwait(false);

                    result.Add(
                        new Operation(
                            UserId: reader.GetString(0),
                            AccountId: reader.GetString(1),
                            Type: type,
                            Result: operationResult,
                            reader.GetString(4)));
                }

                return result;
            }
        }
    }
}
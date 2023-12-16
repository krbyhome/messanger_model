using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _provider;

    public UserRepository(IPostgresConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task AddUser(string username, string password)
    {
        const string query = """
                             INSERT INTO users (user_name, password, user_role)
                             VALUES (:user_name, :password, :user_role);
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            UserRole role = UserRole.User;
            command.Parameters.AddWithValue("user_name", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("user_role", role);

            await command.ExecuteNonQueryAsync().ConfigureAwait(true);
        }
    }

    public async Task ChangeRole(User user, UserRole role)
    {
        const string query = """
                             UPDATE users 
                             SET user_role = :user_role
                             WHERE user_id = :user_id;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("user_id", user.Id);
            command.Parameters.AddWithValue("user_role", role);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<User?> FindUserById(long id)
    {
        const string query = """
                             SELECT user_id, user_name, password, user_role
                             FROM users
                             WHERE user_id = :id;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.AddParameter("id", id);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                {
                    return null;
                }

                UserRole role = await reader.GetFieldValueAsync<UserRole>(3).ConfigureAwait(false);
                return new User(
                    Id: reader.GetInt64(0),
                    Name: reader.GetString(1),
                    Password: reader.GetString(2),
                    Role: role);
            }
        }
    }

    public async Task<User?> FindUserByUserName(string username)
    {
        const string query = """
                             SELECT user_id, user_name, password, user_role
                             FROM users
                             WHERE user_name = :Name;
                             """;

        NpgsqlConnection connection = await _provider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(query, connection))
        {
            command.AddParameter("Name", username);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                {
                    return null;
                }

                UserRole role = await reader.GetFieldValueAsync<UserRole>(3).ConfigureAwait(false);
                return new User(
                    Id: reader.GetInt64(0),
                    Name: reader.GetString(1),
                    Password: reader.GetString(2),
                    Role: role);
            }
        }
    }
}
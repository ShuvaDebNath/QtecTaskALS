using Microsoft.Data.SqlClient;
using QtecTaskALS.Application.Accounts.Queries;
using QtecTaskALS.Infrastructure.Services;
using System.Data;

namespace QtecTaskALS.Application.Accounts.Interfaces;

public class AccountRepository : IAccountRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public AccountRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> CreateAccount(string name, string type)
    {
        using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString); 
        using var command = new SqlCommand("usp_CreateAccount", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = name });
        command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50) { Value = type });

        var output = new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output };
        command.Parameters.Add(output);

        connection.Open();
        command.ExecuteNonQuery();

        return output.Value != DBNull.Value ? (int)output.Value : 0;
    }

    public List<AccountDto> GetAccounts()
    {
        var accounts = new List<AccountDto>();

        using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
        using var command = new SqlCommand("usp_GetAccounts", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            accounts.Add(new AccountDto
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Type = reader.GetString(2)
            });
        }

        return accounts;
    }


}

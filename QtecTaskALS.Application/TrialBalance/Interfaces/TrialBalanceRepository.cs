using Microsoft.Data.SqlClient;
using QtecTaskALS.Application.TrialBalance.Queries;
using QtecTaskALS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QtecTaskALS.Application.TrialBalance.Interfaces;

public class TrialBalanceRepository : ITrialBalanceRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public TrialBalanceRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public List<TrialBalanceDto> GetTrialBalance()
    {
        var result = new List<TrialBalanceDto>();

        using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
        using var command = new SqlCommand("usp_GetTrialBalance", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new TrialBalanceDto
            {
                AccountId = reader.GetInt32(0),
                AccountName = reader.GetString(1),
                Debit = reader.GetDecimal(2),
                Credit = reader.GetDecimal(3)
            });
        }

        return result;
    }
}


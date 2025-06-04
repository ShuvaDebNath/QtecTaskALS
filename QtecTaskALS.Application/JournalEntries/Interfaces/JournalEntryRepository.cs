
using Microsoft.Data.SqlClient;
using QtecTaskALS.Application.JournalEntries.Commands;
using QtecTaskALS.Application.JournalEntries.Queries;
using QtecTaskALS.Infrastructure.Services;
using System.Data;

namespace QtecTaskALS.Application.JournalEntries.Interfaces;

public class JournalEntryRepository : IJournalEntryRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public JournalEntryRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public int CreateJournalEntry(CreateJournalEntryCommand command)
    {
        using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            var journalEntryCmd = new SqlCommand("usp_CreateJournalEntry", connection, transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            journalEntryCmd.Parameters.AddWithValue("@Date", command.Date);
            journalEntryCmd.Parameters.AddWithValue("@Description", command.Description);

            var outputId = new SqlParameter("@JournalEntryId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            journalEntryCmd.Parameters.Add(outputId);

            journalEntryCmd.ExecuteNonQuery();
            int journalEntryId = (int)outputId.Value;

            foreach (var line in command.Lines)
            {
                var lineCmd = new SqlCommand("usp_CreateJournalEntryLine", connection, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };
                lineCmd.Parameters.AddWithValue("@JournalEntryId", journalEntryId);
                lineCmd.Parameters.AddWithValue("@AccountId", line.AccountId);
                lineCmd.Parameters.AddWithValue("@Debit", line.Debit);
                lineCmd.Parameters.AddWithValue("@Credit", line.Credit);

                lineCmd.ExecuteNonQuery();
            }

            transaction.Commit();
            return journalEntryId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<JournalEntryDto> GetAllJournalEntries()
    {
        var result = new List<JournalEntryDto>();
        var map = new Dictionary<int, JournalEntryDto>();

        using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
        using var command = new SqlCommand("usp_GetJournalEntries", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        connection.Open();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var entryId = reader.GetInt32(0);

            if (!map.TryGetValue(entryId, out var entry))
            {
                entry = new JournalEntryDto
                {
                    Id = entryId,
                    Date = reader.GetDateTime(1),
                    Description = reader.GetString(2),
                    Lines = new List<Queries.JournalEntryLineDto>()
                };
                map[entryId] = entry;
                result.Add(entry);
            }

            entry.Lines.Add(new Queries.JournalEntryLineDto
            {
                AccountId = reader.GetInt32(3),
                Debit = reader.GetDecimal(4),
                Credit = reader.GetDecimal(5)
            });
        }

        return result;
    }

}


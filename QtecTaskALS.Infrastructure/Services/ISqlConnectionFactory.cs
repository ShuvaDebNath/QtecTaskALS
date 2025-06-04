using System.Data;

namespace QtecTaskALS.Infrastructure.Services;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}

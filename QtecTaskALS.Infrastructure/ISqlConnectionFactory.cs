using System.Data;

namespace QtecTaskALS.Infrastructure;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}

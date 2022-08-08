using System.Data;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

namespace BlazorServer.Data.Repositories;

public class SqlRepository
{
    private readonly string _connString;

    public SqlRepository()
    {
        
    }

    public SqlRepository(IConfiguration config)
    {
        _connString = config.GetConnectionString("Default");
    }

    private IDbConnection GetDbConnection()
    {
        var connection = new SqliteConnection(_connString);
        connection.Open();
        return connection;
    }
}
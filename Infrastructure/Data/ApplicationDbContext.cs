using System;
using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class ApplicationDbContext
{
    private readonly string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=907708429";
    public IDbConnection Connection()=> new NpgsqlConnection(connectionString);
}

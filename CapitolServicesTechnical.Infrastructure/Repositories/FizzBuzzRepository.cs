using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using CapitolServicesTechnical.Infrastructure.Interfaces;

namespace CapitolServicesTechnical.Infrastructure.Repositories;

public class FizzBuzzRepository : IFizzBuzzRepository
{
    private readonly string _connectionString;

    public FizzBuzzRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task SaveResultsAsync(IEnumerable<string> results)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("Result", typeof(string));
        
        foreach (var result in results)
        {
            dataTable.Rows.Add(result);
        }
        
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(
            "InsertFizzBuzzResults", 
            new { Results = dataTable.AsTableValuedParameter("FizzBuzzResultType") },
            commandType: CommandType.StoredProcedure
        );
    }
}

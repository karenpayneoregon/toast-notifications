using GitHubSamples.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

#pragma warning disable CS8619

namespace GitHubSamples.Classes;

public class DataOperations
{

    /// <summary>
    /// Read Categories, ContactType and Countries tables
    /// </summary>
    /// <param name="referenceTables">An instance of <see cref="ReferenceTables"/></param>
    /// <returns>Success of the operation and if an exception, the exception is returned</returns>
    public static async Task<(bool success, Exception exception)> GetReferenceTables(ReferenceTables referenceTables)
    {

        await using SqlConnection cn = new(ConnectionString());
        await using SqlCommand cmd = new()
        {
            Connection = cn, CommandText = SqlStatements.ReferenceTableStatements
        };


        try
        {
            await cn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                referenceTables.CategoriesList.Add(new Categories()
                {
                    Id = reader.GetInt32(0), 
                    Name = reader.GetString(1)
                });
            }

            await reader.NextResultAsync();

            while (await reader.ReadAsync())
            {
                referenceTables.ContactTypesList.Add(new ContactType()
                {
                    Id = reader.GetInt32(0), 
                    Title = reader.GetString(1)
                });
            }
            
            await reader.NextResultAsync();

            while (await reader.ReadAsync())
            {
                referenceTables.CountriesList.Add(new Countries()
                {
                    Id = reader.GetInt32(0), 
                    Name = reader.GetString(1)
                });
            }

            return (true, null);
        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

    public static async Task<(bool success, Exception exception, DataSet dataSet)> GetReferenceTablesDataSet()
    {
        DataSet ds = new();

        try
        {
            SqlDataAdapter adapter = new();
            await using SqlConnection cn = new(ConnectionString());
            SqlCommand command = new(SqlStatements.ReferenceTableStatements, cn);
            adapter.SelectCommand = command;

            adapter.Fill(ds);

            ds.Tables[0].TableName = "Categories";
            ds.Tables[1].TableName = "ContactType";
            ds.Tables[2].TableName = "Countries";

            return (true, null, ds);
        }
        catch (Exception localException)
        {
            return (false, localException, null);
        }
    }
}
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using Notifications.Models;
using System.Data;

#pragma warning disable CS8619

namespace Notifications.Classes;

/// <summary>
/// EF Core could had been used but this this may be easier
/// for new coders not familiar with EF Core.
/// </summary>
public class DataOperations
{

    /// <summary>
    /// See if database exists and assumes that the table exists
    /// </summary>
    public static async Task<bool> DatabaseExist()
    {
        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        try
        {
            await cn.OpenAsync(new CancellationTokenSource(TimeSpan.FromSeconds(2)).Token);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// Empty table of all records
    /// </summary>
    public static void TruncateTable()
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand { Connection = cn, CommandText = "TRUNCATE TABLE Taxpayer" };
        cn.Open();
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Add in this case 1,000 new records
    /// </summary>
    /// <param name="taxpayers">list of <see cref="Taxpayer"/></param>
    /// <returns>result to deconstruct</returns>
    public static async Task<(bool success, Exception exception)> AddNewTaxpayers(List<Taxpayer> taxpayers)
    {

        var statement = """
            
            INSERT INTO [dbo].[Taxpayer]  ([FirstName],[LastName],[SSN],[Pin],[StartDate]) 
            VALUES (@FirstName,@LastName,@SSN,@Pin,@StartDate);
            SELECT CAST(scope_identity() AS int);

            """;

        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
        cmd.Parameters.Add("@SSN", SqlDbType.NVarChar);
        cmd.Parameters.Add("@Pin", SqlDbType.NVarChar);
        cmd.Parameters.Add("@StartDate", SqlDbType.Date); 

        try
        {
            await cn.OpenAsync();
            foreach (var taxpayer in taxpayers)
            {
                cmd.Parameters["@FirstName"].Value = taxpayer.FirstName;
                cmd.Parameters["@LastName"].Value = taxpayer.LastName;
                cmd.Parameters["@SSN"].Value = taxpayer.SSN;
                cmd.Parameters["@Pin"].Value = taxpayer.Pin;
                cmd.Parameters["@StartDate"].Value = taxpayer.StartDate!.Value.ToDateTime(new TimeOnly(0, 0, 0));
                taxpayer.Id = Convert.ToInt32(cmd.ExecuteScalar());
                //await Task.Delay(1000);
            }
            
            return (true, null);

        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

}
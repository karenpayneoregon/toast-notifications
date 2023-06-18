using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using Serilog;

namespace ToastLibrary;
public class Helpers
{
    public static async Task SimulateWorkAsync(int times = 4, int delay = 500)
    {
        for (int index = 1; index <= times; index++)
        {
            await Task.Delay(delay);
        }
    }
    public static bool HasOneThousandRecords()
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        using var cmd = new SqlCommand { Connection = cn, CommandText = "SELECT  COUNT(id) FROM dbo.Taxpayer" };
        cn.Open();

        var count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count >= 1000)
        {
            Log.Information($"Taxpayer Count: {count}");
            return true;
        }
        else
        {
            Log.Information("Less than 1,000 taxpayers");
            return false;
        }
    }
}

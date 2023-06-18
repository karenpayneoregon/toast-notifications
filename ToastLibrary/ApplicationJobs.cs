using FluentScheduler;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ToastLibrary;
public class ApplicationJobs 
{

    public static void AnnoyingToastNotification()
    {
        new ToastContentBuilder().AddText("Annoying message").Show();
    }

    public static void OnceToastNotification()
    {
        new ToastContentBuilder()
            .AddText("Shown only once")
            .AddButton(new ToastButton().SetContent("Bye"))
            .Show(toast =>{
                toast.ExpirationTime = DateTime.Now.AddSeconds(2);
        });
    }

    /// <summary>
    /// Check if there are 1,000 or more records in the taxpayer table
    /// </summary>
    public static void PollTaxpayers()
    {
        if (Helpers.HasOneThousandRecords())
        {
            new ToastContentBuilder().AddText("There are 1000 or more records in taxpayers table").Show();
            Schedule? schedule = JobManager.AllSchedules.FirstOrDefault(x => x.Name == "PollTaxpayers");
            if (schedule is not null)
            {
                JobManager.RemoveJob("PollTaxpayers");
            }
        }
    }
}

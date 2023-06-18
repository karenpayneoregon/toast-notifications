using FluentScheduler;

namespace ToastLibrary;

public class JobsRegistry : Registry
{
    public JobsRegistry()
    {
        // Toast notification

        // run once every minute while app is running
        Schedule(ApplicationJobs.AnnoyingToastNotification)
            .WithName("Annoying")
            .ToRunEvery(1).Minutes();

        Schedule(ApplicationJobs.PollTaxpayers)
            .WithName("PollTaxpayers")
            .ToRunEvery(5).Seconds();

        // run once three minutes after app starts
        DateTime dateTime = DateTime.Now.AddMinutes(3);
        Schedule(ApplicationJobs.OnceToastNotification)
            .WithName("Annoying").ToRunOnceAt(dateTime);
    }
}
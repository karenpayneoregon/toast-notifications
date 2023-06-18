using FluentScheduler;
using Microsoft.Toolkit.Uwp.Notifications;
using Notifications.Classes;
using ToastLibrary;
using ToastLibrary.Models;
using static Notifications.Classes.Dialogs;

namespace Notifications;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        if (!ToastOperations.ListenerAvailable())
        {
            MessageBox.Show(@"OS does not support code in this app");
            Controls.OfType<Button>().ToList().ForEach(button =>
            {
                button.Enabled = false;
            });
        }

        ToastOperations.OnInterceptHandler += ToastOperations_OnInterceptHandler;
    }

    /// <summary>
    /// Update intercept button text, must check control.InvokeRequired as the code
    /// is executed from another thread.
    /// </summary>
    private void ToastOperations_OnInterceptHandler(int sender)
    {
        InterceptButton.InvokeIfRequired(b => b.Text = $@"Intercept count [{sender}]");
    }
    private void HeroButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Hero();
    }

    private void ScheduleButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Schedule();
    }

    private void AlarmButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Alarm();
    }

    private void TextInputButton_Click(object sender, EventArgs e)
    {
        ToastOperations.TextBoxFavoriteColor();
    }

    private void SelectButton_Click(object sender, EventArgs e)
    {
        ToastOperations.ComboBoxFavoriteColor();
    }

    private async void DownLoadButton_Click(object sender, EventArgs e)
    {
        List<PublicHoliday> usHolidays = await WorkOperations.GetHolidays();
        if (usHolidays.Any())
        {
            ToastOperations.HolidaysDownloaded();
        }
        else
        {
            ToastOperations.HolidaysDownloadFailed();
        }
    }

    private async void InterceptButton_Click(object sender, EventArgs e)
    {
        InterceptButton.Enabled = false;
        await Helpers.SimulateWorkAsync();
        InterceptButton.Enabled = true;

        var karenPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Karen.png");

        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key2"])
            .AddText("Hey")
            .SetToastDuration(ToastDuration.Short)
            .AddAppLogoOverride(new Uri(karenPhoto), ToastGenericAppLogoCrop.Circle)
            .AddButton(new ToastButton().SetContent("Go for it")
                .AddArgument("action", "viewReport")
            )
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddMinutes(2);
            });
    }

    private void StopScheduledNotificationButton_Click(object sender, EventArgs e)
    {
        Schedule? schedule = JobManager.AllSchedules.FirstOrDefault(x => x.Name == "Annoying");
        if (schedule is not null)
        {
            JobManager.RemoveJob("Annoying");
        }
    }

    private void SelectionButton_Click(object sender, EventArgs e)
    {
        ToastOperations.SelectionBox();
    }

    private async void TaxpayerButton_Click(object sender, EventArgs e)
    {
        if (await DataOperations.DatabaseExist())
        {
            if (Question("Truncate Taxpayer table", "Question"))
            {
                DataOperations.TruncateTable();
            }

            var (success, exception) = await DataOperations.AddNewTaxpayers(BogusOperations.Taxpayers());
            if (exception is not null)
            {
                // no toast here, we want this in the user's face
                MessageBox.Show($@"Operation failed {exception.Message}");
            }
            else
            {
                ToastOperations.FinishedAddingRecords();
            }
        }
        else
        {
            MessageBox.Show("Database not found");
        }

    }


}

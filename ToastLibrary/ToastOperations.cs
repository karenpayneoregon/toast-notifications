using System.Diagnostics;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Microsoft.Toolkit.Uwp.Notifications;
using Log = Serilog.Log;
#pragma warning disable CS8618
#pragma warning disable CS8602

namespace ToastLibrary;


public class ToastOperations
{
    public static Dictionary<string, int> Dictionary { get; } = new()
    {
        { "key1", 100 }, // hero button, send user to a GitHub repository
        { "key2", 200 }, // Intercept button
        { "key3", 300 }, // alarm button
        { "key4", 400 },  // Favorite color button for text box
        { "key5", 500 },
        { "key6", 600 },
    };

    public static string MainKey => "conversationId";

    public delegate void OnIntercept(int sender);
    public static event OnIntercept OnInterceptHandler;

    public static int Counter { get; set; } = 0;
    public static bool ListenerAvailable()
    {
        if (ApiInformation.IsTypePresent("Windows.UI.Notifications.Management.UserNotificationListener"))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    public static void Clear()
    {
        ToastNotificationManagerCompat.History.Clear();
    }

    public static void OnActivated()
    {
        
        ToastNotificationManagerCompat.OnActivated += toastArgs =>
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
            
            if (args.Contains(MainKey))
            {
                if (args[MainKey] == Dictionary["key2"].ToString())
                {
                    Counter ++;
                    OnInterceptHandler?.Invoke(Counter);
                    Log.Information("Notification triggered {T} times", Counter);
                }
                else if (args[MainKey] == Dictionary["key1"].ToString())
                {
                    Process.Start(new ProcessStartInfo(args["url"]) { UseShellExecute = true });

                }
                else if (args[MainKey] == Dictionary["key5"].ToString())
                {
                    ValueSet? valueSet = toastArgs.UserInput;
                    if (!valueSet.Keys.Contains("time")) return;
                    int time = Convert.ToInt32(valueSet["time"]);
                    var item = TimeOperations.TimeList()
                        .FirstOrDefault(x => x.Id == time);
                    item.Action();

                }
                else if (args[MainKey] == Dictionary["key3"].ToString())
                {
                    if (args.Contains("action"))
                    {
                        if (args["action"] == "snooze")
                        {
                            WorkOperations.Snooze();
                        }
                        else if (args["action"] == "work")
                        {
                            WorkOperations.GotoWork();
                        }
                    }
                }else if (args[MainKey] == Dictionary["key4"].ToString())
                {
                    ValueSet? valueSet = toastArgs.UserInput;
                    
                    if (!valueSet.Keys.Contains("favoriteColor")) return;

                    var favoriteColor = valueSet["favoriteColor"].ToString();
                    if (!string.IsNullOrWhiteSpace(favoriteColor))
                    {
                        Log.Information($"favorite color: {favoriteColor}");
                    }
                }
            }
            else if (args.Contains("okColor"))
            {
                ValueSet? valueSet = toastArgs.UserInput;
                Log.Information($"favorite color: {valueSet["colors"]}");
            }
        };
    }

    /// <summary>
    /// Example that advertises which has an expiration of one day
    /// </summary>
    public static void Hero()
    {
        var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"CheckBoxes.png");
        // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", Dictionary["key1"])
            .AddText("Check out")
            .AddText("ASP.NET Core/Razor pages")
            .AddText("Working with Checkboxes")
            .AddInlineImage(new Uri(heroImage))
            .AddButton(new ToastButton()
                .SetContent("Open URL")
                .AddArgument("url", "https://dev.to/karenpayneoregon/aspnet-corerazor-pages-working-with-checkboxes-3ck4"))
            .AddAttributionText("Cool code")
            .SetToastScenario(ToastScenario.Default)
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddDays(1);
            });    
    }
    /// <summary>
    /// Shows notification that download was successful, expires in two minutes
    /// </summary>
    public static void HolidaysDownloaded()
    {
        new ToastContentBuilder()
            .AddText("Go back to app")
            .AddHeader("Holidays1", "Holidays download", "")
            .AddButton(new ToastButton().SetContent("OK"))
            .SetToastScenario(ToastScenario.Default)
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddMinutes(2);
            });
    }
    /// <summary>
    /// Shows notification that download was not successful 
    /// </summary>
    public static void HolidaysDownloadFailed()
    {
        new ToastContentBuilder()
            .AddText("Holidays not download")
            .AddText("Email sent to developer")
            .AddButton(new ToastButton().SetContent("OK"))
            .SetToastScenario(ToastScenario.Alarm)
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddMinutes(2);
            });
    }
    /// <summary>
    /// Example of an alarm
    /// </summary>
    public static void Alarm()
    {
        var alarmPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"alarm.png");
        var checkPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"checkMark.png");

        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", Dictionary["key3"])
            .AddText("Time for work")
            .AddButton(new ToastButton()
                .SetContent("OK")
                .AddArgument("action", "work")
                .SetImageUri(new Uri(checkPhoto)))
            .AddButton(new ToastButton()
                .SetContent("Snooze")
                .AddArgument("action", "snooze")
                .SetImageUri(new Uri(alarmPhoto)))
            .SetToastScenario(ToastScenario.Alarm)
            .Show();
    }

    /// <summary>
    /// Basic notification with a time delay
    /// - Tag and Group are not used here but would be for WPF
    /// </summary>
    /// <param name="seconds">delay for displaying notification</param>
    public static void Schedule(int seconds = 5)
    {
        new ToastContentBuilder()
            .AddArgument("action", "viewItemsDueToday")
            .AddText("You have")
            .AddText("Items due today!")
            .Schedule(DateTime.Now.AddSeconds(seconds), toast =>
            {
                toast.Tag = "18365"; 
                toast.Group = "PersonalAlerts";
            });
    }
    /// <summary>
    /// Example of integrating a combo box
    /// </summary>
    public static void ComboBoxFavoriteColor()
    {
        var choices = new (string comboBoxItemId, string comboBoxItemContent)[]
        {
            ("Blue", "Blue"),
            ("Green", "Green"),
            ("Red", "Red"),
            ("Yellow", "Yellow")
        };


        new ToastContentBuilder()
            .AddText("Question")
            .AddComboBox("colors",
                "What is your favorite color",
                "Green", choices)
            .AddButton(new ToastButton("OK", "okColor"))
            .AddButton(new ToastButton("Cancel", "cancelColor"))
            .Show();
    }

    public static void FinishedAddingRecords()
    {
        new ToastContentBuilder().AddText("Finished adding records").Show();
    }
    /// <summary>
    /// Example of integrating a text box
    /// </summary>
    public static void TextBoxFavoriteColor()
    {
        new ToastContentBuilder()
            .AddArgument("conversationId", Dictionary["key4"])
            .AddText("Question")
            .AddInputTextBox("favoriteColor",
                placeHolderContent: "Type a response",
                title: "What is your favorite color")
            .AddButton(new ToastButton()
                .SetContent("Give it to me"))
            .Show();
    }

    /// <summary>
    /// Simulate the need to restart the current computer
    /// </summary>
    public static void SelectionBox()
    {
        new ToastContentBuilder()
            .AddArgument("conversationId", Dictionary["key5"])
            .AddText("You computer must restart")
            .AddText("Select when")
            // id, time is used above in OnActivated
            .AddToastInput(new ToastSelectionBox("time")
            {
                DefaultSelectionBoxItemId = "0",
                // note only five items are permitted
                Items =
                {
                    new ToastSelectionBoxItem("0", "Now"),
                    new ToastSelectionBoxItem("15", "15 minutes"),
                    new ToastSelectionBoxItem("30", "30 minutes"),
                    new ToastSelectionBoxItem("45", "45 minutes"),
                    new ToastSelectionBoxItem("60", "1 hour"),
                }

            })
            .AddButton(new ToastButton().SetContent("OK"))
            .SetToastScenario(ToastScenario.Reminder)
            .Show();
    }
}

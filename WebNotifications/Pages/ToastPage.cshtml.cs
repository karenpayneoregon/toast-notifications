using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace WebNotifications.Pages;
public class ToastPageModel : PageModel
{
    private readonly ILogger<ToastPageModel> _logger;

    private readonly INotyfService _toastNotificationService;
    private readonly IToastNotification _toastNotification;

    public ToastPageModel(ILogger<ToastPageModel> logger, INotyfService toastNotificationService, IToastNotification toastNotification)
    {
        _logger = logger;
        _toastNotificationService = toastNotificationService;
        _toastNotification = toastNotification;
        
    }

    public void OnGet()
    {
        _toastNotificationService.Information("Toast examples.", 2);
        _toastNotification.AddInfoToastMessage("Toast examples.", new NotyOptions
        {
            Layout = "bottomLeft", 
            Timeout = 1300,
            ProgressBar = false
        });
    }

    public void OnPostSuccessNotification()
    {
        _toastNotificationService.Success("Work finished");
    }
    public void OnPostInformationNotification()
    {
        _toastNotificationService.Information(
            message: "Time for a break - closes in 6 seconds.", 
            durationInSeconds: 6);
    }
    public void OnPostWarningNotification()
    {
        _toastNotificationService.Warning(
            message: "You have not completed your time-sheet");
    }
    public void OnPostErrorNotification()
    {
        _toastNotificationService.Error(
            message: "Operation failed. This message closes in 4 seconds.", 
            durationInSeconds: 4);
    }
    public void OnPostCustomNotification()
    {
        _toastNotificationService.Custom(
            message: "Email sent", 
            durationInSeconds: 2, 
            backgroundColor: "black", 
            iconClassName: "fa fa-gear");
    }
}


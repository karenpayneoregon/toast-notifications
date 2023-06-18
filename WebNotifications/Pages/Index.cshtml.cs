using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System.Reflection;

namespace WebNotifications.Pages;
/// <summary>
/// Code taken from
/// https://github.com/nabinked/NToastNotify/blob/master/samples/Noty/Pages/Index.cshtml.cs
/// Demonstrates positioning while positions in ToastPage are from Program.cs
/// </summary>
public class IndexModel : PageModel
{

    private readonly string _version;
    private readonly IToastNotification _toastNotification;
    public IndexModel(IToastNotification toastNotification)
    {
        _version = Assembly.GetAssembly(typeof(IToastNotification))?.GetName().Version?.ToString() ?? throw new Exception("Version not found");
        _toastNotification = toastNotification;
    }

    public void OnGet()
    {
        Standard();
    }

    private void Standard()
    {
        _toastNotification.AddSuccessToastMessage();

        _toastNotification.AddErrorToastMessage("Version: " + _version, new NotyOptions()
        {
            Timeout = 0,
            Layout = "topLeft",
            Theme = "mint"
        });


        //Info
        _toastNotification.AddInfoToastMessage(null, new NotyOptions
        {
            Layout = "bottomLeft"
        });
        _toastNotification.AddInfoToastMessage($"This is an info toast. Version: {_version}", new NotyOptions()
        {
            ProgressBar = false,
            Layout = "center"
        });

        //Warning
        _toastNotification.AddWarningToastMessage($"Waring go bottom right. Version: {_version}", new NotyOptions()
        {
            Layout = "bottomRight"
        });

        //Error
        _toastNotification.AddErrorToastMessage($"Custom Error Message. Version: {_version}",
            new NotyOptions() { Theme = "mint" });
    }
}

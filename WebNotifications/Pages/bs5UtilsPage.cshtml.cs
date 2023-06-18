using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

namespace WebNotifications.Pages
{
    public class bs5UtilsPageModel : PageModel
    {
        [BindProperty]
        public string FirstNotification { get; set; }

        public string SecondNotification { get; set; }
        public void OnGet()
        {
            FirstNotification = "<span class='text-success fw-bold'>First message</span>";
            SecondNotification = "Next message";
        }
    }
}

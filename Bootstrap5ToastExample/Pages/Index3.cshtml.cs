using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Bootstrap5ToastExample.Classes.Howdy;

namespace Bootstrap5ToastExample.Pages
{
    public class Index3Model : PageModel
    {
        [BindProperty]
        public string ToastBody { get; set; }
        public void OnGet()
        {
            ToastBody = $"{TimeOfDay()} friend";
        }
    }
}

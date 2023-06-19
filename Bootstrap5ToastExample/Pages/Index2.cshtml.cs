using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bootstrap5ToastExample.Pages
{
    public class Index2Model : PageModel
    {
        [BindProperty]
        public string BootstrapTitle { get; set; }
        public void OnGet()
        {
            BootstrapTitle = "ViewBag: Bootstrap 5";


        }
    }
}

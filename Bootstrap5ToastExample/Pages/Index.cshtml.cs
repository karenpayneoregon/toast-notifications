
using Bootstrap5ToastExample.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bootstrap5ToastExample.Pages;
public class IndexModel : PageModel
{

    [BindProperty]
    public List<ToastContainer> Containers { get; set; }

    [BindProperty]
    public string TopToast { get; set; }
    [BindProperty]
    public string BottomToast { get; set; }
    [BindProperty]
    public string ToastMessage { get; set; }
    public void OnGet()
    {
        TopToast = "Enter something for top toast";
        BottomToast = "Enter something for bottom toast";

        ToastMessage = "Simple notification";

    }
    public IActionResult OnPost()
    {
        Containers.Add(new ToastContainer() {Name = "Top", Body = TopToast });
        Containers.Add(new ToastContainer() {Name = "Bottom", Body = BottomToast });

        return RedirectToPage("Privacy", new
        {
            containers = JsonSerializer.Serialize(
                Containers, new JsonSerializerOptions { WriteIndented = true })
        });
    }
}

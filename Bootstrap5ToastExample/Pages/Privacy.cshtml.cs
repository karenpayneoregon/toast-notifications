#nullable enable
using Bootstrap5ToastExample.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
#pragma warning disable CS8618
#pragma warning disable CS8602
#pragma warning disable CS8604


namespace Bootstrap5ToastExample.Pages;
public class PrivacyModel : PageModel
{
    /// <summary>
    /// Container for toast messages
    /// </summary>
    [BindProperty]
    public MessageContainer MessageContainer { get; set; }

    public void OnGet(string containers)
    {
        MessageContainer = new MessageContainer();

        if (!string.IsNullOrWhiteSpace(containers))
        {
            List<ToastContainer>? data = JsonSerializer.Deserialize<List<ToastContainer>>(containers);

            MessageContainer.Top = data.FirstOrDefault(x => x.Name == "Top").Body;
            MessageContainer.Bottom = data.FirstOrDefault(x => x.Name == "Bottom").Body;
        }
        else
        {
            MessageContainer.Top = "Top message";
            MessageContainer.Bottom = "Bottom message";
        }
    }
}


using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using NToastNotify;
#pragma warning disable CS0618
namespace WebNotifications;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
        {
            ProgressBar = true,
            Timeout = 5000
        });

        //builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
        //{
        //    ProgressBar = true,
        //    PositionClass = ToastPositions.TopCenter,
        //    PreventDuplicates = true,
        //    CloseButton = true
        //});



        builder.Services.AddNotyf(config =>
        {
            config.DurationInSeconds = 5;
            config.IsDismissable = true;
            config.Position = NotyfPosition.BottomRight;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseNToastNotify();

        app.UseNotyf();

        app.MapRazorPages();

        app.Run();
    }
}

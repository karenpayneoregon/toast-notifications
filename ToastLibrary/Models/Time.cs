#pragma warning disable CS8618

namespace ToastLibrary.Models;

public class Time
{
    public int Id { get; set; }
    /// <summary>
    /// Operation to perform
    /// </summary>
    public Action Action;
}
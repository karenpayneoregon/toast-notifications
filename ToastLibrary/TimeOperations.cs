using ToastLibrary.Models;
using static Serilog.Log;

namespace ToastLibrary;

public class TimeOperations
{
    /// <summary>
    /// For demonstrating working with ToastSelectionBoxItem in
    /// ToastOperations.
    ///
    /// In a real application the Action would perform a meaningful task
    /// 
    /// </summary>
    public static List<Time> TimeList() =>
        new()
        {
            new () { Id =  0, Action = () => Information("Now") },
            new () { Id = 15, Action = () => Information("15 minutes") },
            new () { Id = 30, Action = () => Information("30 minutes")  },
            new () { Id = 45, Action = () => Information("45 minutes")  },
            new () { Id = 60, Action = () => Information("60 minutes")  }
        };
}
namespace ToastLibrary;

public static class Dialogs
{
    /// <summary>
    /// displays a message with option to assign button text
    /// </summary>
    public static void Information(Control owner, string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Icon = new(Properties.Resources.exclamation24),
            Buttons = new() { okayButton }
        };

        owner.InvokeIfRequired(control => TaskDialog.ShowDialog(owner, page));

    }
}
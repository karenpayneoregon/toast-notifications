using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Classes;

internal class Dialogs
{
    public static bool Question(string caption, string heading, DialogResult defaultButton = DialogResult.No)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        TaskDialogButtonCollection buttons = new();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = caption,
            SizeToContent = true,
            Heading = heading,
            Icon = TaskDialogIcon.Information,
            Buttons = buttons
        };


        TaskDialogButton result = TaskDialog.ShowDialog(page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }
}

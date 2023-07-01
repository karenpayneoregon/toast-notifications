Imports System.IO
Imports Microsoft.Toolkit.Uwp.Notifications

Public Class Form1
    Private Sub AlarmButton_Click(sender As Object, e As EventArgs) Handles AlarmButton.Click
        Alarm()
    End Sub

    Public Shared Sub Alarm()

        Dim alarmPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "alarm.png")
        Dim checkPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "checkMark.png")

        Call (New ToastContentBuilder()).AddArgument("action", "viewConversation").
            AddArgument("conversationId", "alarmKey").
            AddText("Time for work").
            AddButton(
                (New ToastButton()).SetContent("OK").AddArgument("action", "work").
                         SetImageUri(New Uri(checkPhoto))).AddButton(
                             (New ToastButton()).SetContent("Snooze").
                                                                        AddArgument("action", "snooze").
                                                                        SetImageUri(New Uri(alarmPhoto))).
            SetToastScenario(ToastScenario.Alarm).Show()
    End Sub

    Public Sub OnActivatedToast()
        AddHandler ToastNotificationManagerCompat.OnActivated,
            Sub(toastArgs)
                Dim args As ToastArguments = ToastArguments.Parse(toastArgs.Argument)
                If args("conversationId") = "alarmKey" Then
                    If args("action") = "snooze" Then
                        WorkOperations.Snooze()
                        Label1.InvokeIfRequired(
                            Sub(item)
                                item.Text = "Snooze"
                            End Sub)
                    ElseIf args("action") = "work" Then
                        WorkOperations.GotoWork()
                        Label1.InvokeIfRequired(
                            Sub(item)
                                item.Text = "Go to work"
                            End Sub)
                    End If

                End If
            End Sub
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnActivatedToast()
    End Sub
End Class
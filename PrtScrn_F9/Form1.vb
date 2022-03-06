' You can take a single-screen-screenshot while using more than one screen.
' This works just like "Print Screen" key in your keyboard but this captures only the main screen not all multiple screens.
' You can add this program as start program manually so you can use conveniently without executing every time.
' Default key is setted to F9. You can change it in the code.
' This program has no GUI.

Public Class Form1
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function GetAsyncKeyState(ByVal vkey As System.Windows.Forms.Keys) As Short
    End Function
    Private Sub capture_and_copy()
        PictureBox1.Image = TakeScreenShot()
        CopyToClipboard()
    End Sub
    Private Sub CopyToClipboard()
        Clipboard.SetDataObject(Me.PictureBox1.Image)
    End Sub
    Private Function TakeScreenShot() As Bitmap

        Dim screen_size As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Dim screen_grab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Dim g As Graphics = Graphics.FromImage(screen_grab)

        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screen_size)

        Return screen_grab

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height ' - 40
        Me.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width
        Timer2.Start()
    End Sub

    Private Sub CaptureF9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaptureF9ToolStripMenuItem.Click
        capture_and_copy()
    End Sub
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("Press F9 to capture the main screen." & vbCrLf & "Captured image will be attached to the clipboard." & vbCrLf & "MMTR Dev.", MsgBoxStyle.Information, "Help")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hkey As Boolean
        hkey = GetAsyncKeyState(Keys.F9) 'You can change the key here to use another key.
        If hkey = True Then
            capture_and_copy()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Me.Hide()
        Timer1.Start()
    End Sub
End Class

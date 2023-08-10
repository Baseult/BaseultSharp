Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Text

Public Class Form1
    Public Stringform As Integer

    Protected Overloads Shared ReadOnly Property UseCompatibleTextRendering As Boolean
        Get
            Application.SetCompatibleTextRenderingDefault(True)
            Return True
        End Get
    End Property

    Dim auth
    Dim port

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        Form9.Hide()

        Dim appPathx As String = My.Application.Info.DirectoryPath

        Label1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(0), 10, FontStyle.Bold)
        Button1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button2.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button3.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button5.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button6.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button7.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button8.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button9.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button11.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button12.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button13.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        Button14.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)

        Me.ProgressBar1.Value = 0

        Dim r As New Random
        Dim Filename As String = RandomString(r)
        Me.Text = RandomString(r)

        Me.ProgressBar1.Value = 80

        My.Computer.Audio.Play(My.Resources._15, AudioPlayMode.Background)

        Me.ProgressBar1.Value = 90

        Dim Computername As String = Environment.UserName
        Me.ProgressBar1.Value = 100
        Await Task.Delay(2000)
        Me.ProgressBar1.Hide()

        If Startup = False Then
            Me.Size = New Size(386, 376)
            Label2.Location = New Point(0, 388)
            Label2.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Bold)
            Label2.Text = "Welcome " & Computername
            Await Task.Delay(2000)
            Label2.Text = "Coded by Baseult"
            Await Task.Delay(2000)
            Label2.Hide()
            Me.MaximumSize = New Size(386, 337)
            Me.Size = New Size(386, 337)
            Startup = True
        End If
    End Sub

    Function RandomString(r As Random)
        Dim s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        For i = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function


    <DllImport("user32.dll", SetLastError := True, CharSet := CharSet.Auto)>
    Private Shared Function SetWindowText(hwnd As IntPtr, lpString As String) As Boolean
    End Function

    Dim Startup = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 2
        Form6.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 3
        Form6.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 4
        Form6.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Audio.Play(My.Resources._20, AudioPlayMode.WaitToComplete)
        Me.Close()
        Form9.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Form9.Aram = True Then
            My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
            Me.Hide()
            Stringform = 5
            Form6.Show()
        Else
            MessageBox.Show("You can't use the Aram Exploit with the Everything Else Option. Please Restart Baseult#!")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.MaximumSize = New Size(386, 280)
        Me.Size = New Size(386, 280)
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Button1.Hide()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        Button5.Show()
        Button6.Hide()
        Button11.Show()
        Button8.Show()
        Button9.Show()
        Stringform = 6
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Me.MaximumSize = New Size(386, 335)
        Me.Size = New Size(386, 335)
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Button1.Show()
        Button2.Show()
        Button3.Show()
        Button4.Show()
        Button5.Hide()
        Button6.Show()
        Button7.Hide()
        Button8.Hide()
        Button9.Hide()
        Button11.Hide()
        Button12.Hide()
        Button13.Hide()
        Button14.Hide()
        Stringform = 6
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 7
        Form6.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 8
        Form6.Show()
    End Sub

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
        (lpstrCommand As String, lpstrReturnString As String, uReturnLength As _
            Integer, hwndCallback As Integer) As Integer

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        My.Computer.Audio.Play(My.Resources._22, AudioPlayMode.Background)
        Select Case _
            MessageBox.Show(
                "Coding this Program had cost me a lot of work and time." & vbCrLf &
                "Anything I coded and code has been and will be provided for free." & vbCrLf & vbCrLf &
                "My projects are supported by donations only, so if you like my program I would be very happy about a small donation. Thank you very much." &
                vbCrLf & vbCrLf & "Would you like to Support me with a small Donation?", "Baseult# - Donation",
                MessageBoxButtons.YesNo)
            Case DialogResult.Yes
                Process.Start("https://www.paypal.com/donate?hosted_button_id=HPL2NB5GYE5V4")
                My.Computer.Audio.Play(My.Resources._11, AudioPlayMode.Background)
        End Select
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Button7.Show()
        Button8.Hide()
        Button9.Hide()
        Button13.Show()
        Button14.Show()
        Button11.Hide()
        Button12.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Me.Hide()
        Stringform = 10
        Form6.Show()
    End Sub

    Private Sub Button9_MouseEnter(sender As Object, e As EventArgs) Handles Button9.MouseEnter
        Button9.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles Button8.MouseEnter
        Button8.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Button8.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        Button4.BackColor = Color.FromArgb(40, 30, 30)
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Button5.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Button6.BackColor = Color.FromArgb(40, 40, 30)
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter
        Button7.BackColor = Color.FromArgb(40, 40, 30)
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Button7.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button12_MouseEnter(sender As Object, e As EventArgs) Handles Button12.MouseEnter
        Button12.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button12_MouseLeave(sender As Object, e As EventArgs) Handles Button12.MouseLeave
        Button12.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button11_MouseEnter(sender As Object, e As EventArgs) Handles Button11.MouseEnter
        Button11.BackColor = Color.FromArgb(40, 40, 30)
    End Sub

    Private Sub Button11_MouseLeave(sender As Object, e As EventArgs) Handles Button11.MouseLeave
        Button11.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Public Const WM_NCLBUTTONDOWN As Integer = 161  'moveable borderless form
    Public Const HT_CAPTION As Integer = 2  'moveable borderless form

    <DllImport("User32")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer _
        'moveable borderless form
    End Function

    <DllImport("User32")>
    Private Shared Function ReleaseCapture() As Boolean 'moveable borderless form
    End Function

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown _
        'moveable borderless form
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form4.Stopping1 = True
        Form4.Stopping2 = True
        Form4.Stopping3 = True
        Form4.Stopping4 = True
        Form4.Stopping5 = True
        Form4.Stopping6 = True
        Form4.Stopping7 = True
        Form4.Stopping8 = True
        Form4.Stopping9 = True
        Form4.Stopping10 = True
        Form4.Stopping13 = True
        Form7.Stopping = True

        Try
            Form4.BackgroundWorker1.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker2.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker3.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker4.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker5.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker6.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker7.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker8.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker9.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker10.CancelAsync()
        Catch
        End Try
        Try
            Form4.BackgroundWorker13.CancelAsync()
        Catch
        End Try
        Try
            Form7.BackgroundWorker1.CancelAsync()
        Catch
        End Try
        Try
            Form7.BackgroundWorker2.CancelAsync()
        Catch
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        My.Computer.Audio.Play(My.Resources._19, AudioPlayMode.Background)
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If isElevated Then
            Me.Hide()
            Stringform = 11
            Form6.Show()
        Else
            MessageBox.Show("You need to restart the Program with Admin Rights to use this Feature!")
            Return
        End If
    End Sub
End Class

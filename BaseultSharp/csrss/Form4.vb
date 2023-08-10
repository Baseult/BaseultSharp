Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json.Linq


Public Class Form4
    Inherits Form

    Dim auth
    Dim port


    Public Stopping1 As Boolean = False
    Public Stopping2 As Boolean = False
    Public Stopping3 As Boolean = False
    Public Stopping4 As Boolean = False
    Public Stopping5 As Boolean = False
    Public Stopping6 As Boolean = False
    Public Stopping7 As Boolean = False
    Public Stopping8 As Boolean = False
    Public Stopping9 As Boolean = False
    Public Stopping10 As Boolean = False
    Public Stopping11 As Boolean = False
    Public Stopping12 As Boolean = False
    Public Stopping13 As Boolean = False

    Dim Runnercount As Int32 = 0

    Dim Lobbycreate As String
    Dim Lobbycreate2 As String
    Dim Lobbycreate3 As String
    Dim Lobbycreate4 As String
    Dim Lobbycreate5 As String
    Dim Lobbycreate6 As String
    Dim Lobbycreate7 As String
    Dim Lobbycreate8 As String
    Dim Lobbycreate9 As String
    Dim Lobbycreate10 As String
    Dim Lobbycreate13 As String

    Dim Run1 As Boolean = False
    Dim Run2 As Boolean = False
    Dim Run3 As Boolean = False
    Dim Run4 As Boolean = False
    Dim Run5 As Boolean = False
    Dim Run6 As Boolean = False
    Dim Run7 As Boolean = False
    Dim Run8 As Boolean = False
    Dim Run9 As Boolean = False
    Dim Run10 As Boolean = False
    Dim Run11 As Boolean = False
    Dim Run12 As Boolean = False

    Dim Count As Integer = 1
    Dim Invite As Boolean = True
    Dim Friends As Boolean = False


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        CheckBox17.Font = New Font(Form9.pfc.Families(0), 15, FontStyle.Regular)
        CheckBox18.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        CheckBox19.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        CheckBox20.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        TextBox1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox2.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox3.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox5.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox6.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox7.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)

        Label3.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Label7.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Button3.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        StopButton.Font = New Font(Form9.pfc.Families(0), 20, FontStyle.Bold)
        CheckBox3.Font = New Font(Form9.pfc.Families(0), 15, FontStyle.Regular)
        Input1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Input2.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Input3.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Input4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Input5.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Label6.Font = New Font(Form9.pfc.Families(0), 18, FontStyle.Regular)
        Label4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Label8.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Label9.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)

        CheckBox9.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        CheckBox10.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        CheckBox11.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        Chatbox.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        NextButton.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        Label1.Font = New Font(Form9.pfc.Families(1), 11, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        Label5.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)

        Dim r As New Random
        Me.Text = RandomString(r)
        Label2.Text = "Opacity"
        NotifyIcon1.Visible = False

        Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
        If process Is Nothing Then
            If Chatbox.TextLength = 0 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Start LoL first!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                Return
            Else
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Start LoL first!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                Return
            End If
        End If
    End Sub


    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    Private Const cGrip As Integer = 50      ' Grip size
    Private Const cCaption As Integer = 50   ' Caption bar height;

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H84 Then ' Trap WM_NCHITTEST
            Dim pos = New Point(m.LParam.ToInt32())
            pos = Me.PointToClient(pos)

            If pos.Y < cCaption Then
                m.Result = CType(2, IntPtr)  ' HTCAPTION
                Return
            End If

            If pos.X >= Me.ClientSize.Width - cGrip AndAlso pos.Y >= Me.ClientSize.Height - cGrip Then
                m.Result = CType(17, IntPtr) ' HTBOTTOMRIGHT
                Return
            End If
        End If

        MyBase.WndProc(m)
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

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.FromArgb(100, 50, 50)
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.FromArgb(39, 39, 39)
    End Sub

    Private Sub TrackBar1_MouseEnter(sender As Object, e As EventArgs) Handles TrackBar1.MouseEnter
        TrackBar1.BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Private Sub TrackBar1_MouseLeave(sender As Object, e As EventArgs) Handles TrackBar1.MouseLeave
        TrackBar1.BackColor = Color.FromArgb(30, 30, 30)
    End Sub


    Private Sub CheckBox1_MouseEnter(sender As Object, e As EventArgs) Handles CheckBox1.MouseEnter
        CheckBox1.BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Private Sub CheckBox1_MouseLeave(sender As Object, e As EventArgs) Handles CheckBox1.MouseLeave
        CheckBox1.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub CheckBox2_MouseEnter(sender As Object, e As EventArgs) Handles CheckBox2.MouseEnter
        CheckBox2.BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Private Sub CheckBox2_MouseLeave(sender As Object, e As EventArgs) Handles CheckBox2.MouseLeave
        CheckBox2.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.BackColor = Color.FromArgb(50, 100, 50)
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackColor = Color.FromArgb(39, 39, 39)
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.FromArgb(40, 40, 40)
        Label5.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.FromArgb(30, 30, 30)
        Label5.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.Opacity = TrackBar1.Value/100
        Label2.Text = TrackBar1.Value.ToString + "%"
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll

        Label4.Text = "Delay: " & TrackBar2.Value.ToString & " ms"

        If TrackBar2.Value = 8000 Then
            Label4.ForeColor = Color.FromArgb(255, 0, 255, 0)
        ElseIf TrackBar2.Value >= 3000 And TrackBar2.Value <= 7999 Then
            Label4.ForeColor = Color.FromArgb(255, 100, 255, 0)
        ElseIf TrackBar2.Value >= 2500 And TrackBar2.Value <= 3999 Then
            Label4.ForeColor = Color.FromArgb(255, 150, 255, 0)
        ElseIf TrackBar2.Value >= 1000 And TrackBar2.Value <= 2499 Then
            Label4.ForeColor = Color.FromArgb(255, 255, 255, 0)
        ElseIf TrackBar2.Value >= 500 And TrackBar2.Value <= 999 Then
            Label4.ForeColor = Color.FromArgb(255, 255, 200, 0)
        ElseIf TrackBar2.Value >= 250 And TrackBar2.Value <= 499 Then
            Label4.ForeColor = Color.FromArgb(255, 255, 150, 0)
        ElseIf TrackBar2.Value >= 150 And TrackBar2.Value <= 249 Then
            Label4.ForeColor = Color.FromArgb(255, 255, 100, 0)
        ElseIf TrackBar2.Value >= 51 And TrackBar2.Value <= 149 Then
            Label4.ForeColor = Color.FromArgb(255, 255, 50, 0)
        ElseIf TrackBar2.Value <= 50 Then
            Label4.ForeColor = Color.Red
        End If
    End Sub


    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Label4.Text = "Delay: " & TrackBar2.Value.ToString & " ms"
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
            Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                           vbCrLf
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If CheckBox1.Checked Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Input1.Click
        If Input1.Text = "Enter Targets Summoner Name or ID" Then
            Input1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Chatbox.TextChanged
        Chatbox.SelectionStart = Chatbox.Text.Length
        Chatbox.ScrollToCaret()
    End Sub


    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            TrackBar2.Value = 2500
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged


        If CheckBox4.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
            If TrackBar2.Value < 2500 Then
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                MessageBox.Show(
                    "You are using a Delay below 2500ms." & vbCrLf & vbCrLf &
                    "This might trigger RIOT's Spam Protection / Rate Limit!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox4.Checked = True Then
            Try
                Lobbycreate2 = Input1.Text
                BackgroundWorker2.RunWorkerAsync()
                Stopping2 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 2!"
                Run2 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run2 = True
                Return
            End Try
        Else
            Stopping2 = True
            Try
                BackgroundWorker2.CancelAsync()
                If Run2 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 2!"
                    Run2 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
            If TrackBar2.Value < 2500 Then
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                MessageBox.Show(
                    "You are using a Delay below 2500ms." & vbCrLf & vbCrLf &
                    "This might trigger RIOT's Spam Protection / Rate Limit!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox5.Checked = True Then
            Try
                Lobbycreate4 = Input2.Text
                BackgroundWorker4.RunWorkerAsync()
                Stopping4 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 4!"
                Run4 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run4 = True
                Return
            End Try
        Else
            Stopping4 = True
            Try
                BackgroundWorker4.CancelAsync()
                If Run4 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 4!"
                    Run4 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

        If CheckBox6.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
            If TrackBar2.Value < 2500 Then
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                MessageBox.Show(
                    "You are using a Delay below 2500ms." & vbCrLf & vbCrLf &
                    "This might trigger RIOT's Spam Protection / Rate Limit!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox6.Checked = True Then
            Try
                Lobbycreate6 = Input3.Text
                BackgroundWorker6.RunWorkerAsync()
                Stopping6 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 6!"
                Run6 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run6 = True
                Return
            End Try
        Else
            Stopping6 = True
            Try
                BackgroundWorker6.CancelAsync()
                If Run6 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 6!"
                    Run6 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged

        If CheckBox7.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
            If TrackBar2.Value < 2500 Then
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                MessageBox.Show(
                    "You are using a Delay below 2500ms." & vbCrLf & vbCrLf &
                    "This might trigger RIOT's Spam Protection / Rate Limit!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox7.Checked = True Then
            Try
                Lobbycreate8 = Input4.Text
                BackgroundWorker8.RunWorkerAsync()
                Stopping8 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 8!"
                Run8 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run8 = True
                Return
            End Try
        Else
            Stopping8 = True
            Try
                BackgroundWorker8.CancelAsync()
                If Run8 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 8!"
                    Run8 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)

        If CheckBox8.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
            If TrackBar2.Value < 2500 Then
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                MessageBox.Show(
                    "You are using a Delay below 2500ms." & vbCrLf & vbCrLf &
                    "This might trigger RIOT's Spam Protection / Rate Limit!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox8.Checked = True Then
            Try
                Lobbycreate10 = Input5.Text
                BackgroundWorker10.RunWorkerAsync()
                Stopping10 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 10!"
                Run10 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run10 = True
                Return
            End Try
        Else
            Stopping10 = True
            Try
                BackgroundWorker10.CancelAsync()
                If Run10 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 10!"
                    Run10 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged

        If CheckBox12.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox12.Checked = True Then
            Try
                Lobbycreate = TextBox1.Text
                BackgroundWorker1.RunWorkerAsync()
                Stopping1 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 1!"
                Run1 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run1 = True
                Return
            End Try
        Else
            Stopping1 = True
            Try
                BackgroundWorker1.CancelAsync()
                If Run1 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 1!"
                    Run1 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox13.Checked = True Then
            Try
                Lobbycreate3 = TextBox2.Text
                BackgroundWorker3.RunWorkerAsync()
                Stopping3 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 3!"
                Run3 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run3 = True
                Return
            End Try
        Else
            Stopping3 = True
            Try
                BackgroundWorker3.CancelAsync()
                If Run3 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 3!"
                    Run3 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox14.Checked = True Then
            Try
                Lobbycreate5 = TextBox3.Text
                BackgroundWorker5.RunWorkerAsync()
                Stopping5 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 5!"
                Run5 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run5 = True
                Return
            End Try
        Else
            Stopping5 = True
            Try
                BackgroundWorker5.CancelAsync()
                If Run5 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 5!"
                    Run5 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox15.Checked = True Then
            Try
                Lobbycreate7 = TextBox4.Text
                BackgroundWorker7.RunWorkerAsync()
                Stopping7 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 7!"
                Run7 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run7 = True
                Return
            End Try
        Else
            Stopping7 = True
            Try
                BackgroundWorker7.CancelAsync()
                If Run7 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 7!"
                    Run7 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked Then
            My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        End If

        If CheckBox16.Checked = True Then
            Try
                Lobbycreate9 = TextBox5.Text
                BackgroundWorker9.RunWorkerAsync()
                Stopping9 = False
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Started Background-Worker 9!"
                Run9 = True
                Runnercount += 1
                Label6.Text = "Active Spammers: " & Runnercount.ToString
            Catch
                Run9 = True
                Return
            End Try
        Else
            Stopping9 = True
            Try
                BackgroundWorker9.CancelAsync()
                If Run9 Then
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Stopped Background-Worker 9!"
                    Run9 = False
                    Runnercount -= 1
                End If
            Catch
            End Try
            Label6.Text = "Active Spammers: " & Runnercount.ToString
        End If
    End Sub

    Dim Textspam As String

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        BackgroundWorker13.RunWorkerAsync()
        Stopping13 = False
        Lobbycreate13 = TextBox6.Text
        Textspam = TextBox7.Text
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources._20, AudioPlayMode.WaitToComplete)
        Me.Close()
        Form9.Close()
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Computer.Audio.Play(My.Resources._18, AudioPlayMode.WaitToComplete)
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBox9_Click(sender As Object, e As EventArgs) Handles CheckBox9.Click
        If CheckBox9.Checked Then
            CheckBox10.Checked = False
            CheckBox11.Checked = False
        Else
            CheckBox9.Checked = True
        End If
    End Sub

    Private Sub CheckBox10_Click(sender As Object, e As EventArgs) Handles CheckBox10.Click
        If CheckBox10.Checked Then
            CheckBox9.Checked = False
            CheckBox11.Checked = False
        Else
            CheckBox10.Checked = True
        End If
    End Sub

    Private Sub CheckBox11_Click(sender As Object, e As EventArgs) Handles CheckBox11.Click
        If CheckBox11.Checked Then
            CheckBox10.Checked = False
            CheckBox9.Checked = False
        Else
            CheckBox11.Checked = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If Count >= 3 Then
            Count = 1
        Else
            Count = Count + 1
        End If

        If Count.Equals(1) Then
            Button1.Show()
            Label4.Show()
            Label8.Hide()
            Label9.Hide()
            TextBox6.Hide()
            TextBox7.Hide()
            Input1.Show()
            Input2.Show()
            Input3.Show()
            Input4.Show()
            Input5.Show()
            TextBox1.Hide()
            TextBox2.Hide()
            TextBox3.Hide()
            TextBox4.Hide()
            TextBox5.Hide()
            CheckBox9.Show()
            CheckBox10.Show()
            CheckBox11.Show()
            CheckBox18.Hide()
            CheckBox19.Hide()
            CheckBox20.Hide()
            CheckBox3.Show()
            CheckBox17.Hide()
            Label4.Text = "Delay: " & TrackBar2.Value.ToString & " ms"
            TrackBar4.Hide()
            TrackBar3.Hide()
            TrackBar2.Show()
            CheckBox12.Hide()
            CheckBox13.Hide()
            CheckBox14.Hide()
            CheckBox15.Hide()
            CheckBox16.Hide()
            CheckBox9.Show()
            CheckBox10.Show()
            CheckBox11.Show()
            CheckBox9.Enabled = True
            CheckBox10.Enabled = True
            CheckBox11.Enabled = True
            Me.MinimumSize = New Size(378, 546)
            Me.Size = New Size(378, 708)
            Invite = True
            Friends = False
            CheckBox3.Enabled = True
            Chatbox.Location = New Point(0, 500)
            Chatbox.Size = New Size(378, 177)
            Label6.Location = New Point(0, 471)
            Label3.Show()
            Button3.Hide()
            Input2.Show()
            Input3.Show()
            Input4.Show()
            Input5.Show()
            CheckBox4.Show()
            CheckBox5.Show()
            CheckBox6.Show()
            CheckBox7.Show()
            CheckBox8.Show()
        ElseIf Count.Equals(2) Then
            Button1.Hide()
            Label4.Hide()
            Label8.Show()
            Label9.Hide()
            Input1.Hide()
            Input2.Hide()
            Input3.Hide()
            Input4.Hide()
            Input5.Hide()
            TextBox1.Show()
            TextBox2.Show()
            TextBox3.Show()
            TextBox4.Show()
            TextBox5.Show()
            CheckBox9.Hide()
            CheckBox10.Hide()
            CheckBox11.Hide()
            CheckBox18.Show()
            CheckBox19.Show()
            CheckBox20.Show()
            CheckBox3.Hide()
            CheckBox17.Show()
            Label4.Text = "Delay: " & TrackBar3.Value.ToString & " ms"
            TrackBar4.Hide()
            TrackBar3.Show()
            TrackBar2.Hide()
            CheckBox12.Show()
            CheckBox13.Show()
            CheckBox14.Show()
            CheckBox15.Show()
            CheckBox16.Show()
            CheckBox9.Enabled = False
            CheckBox10.Enabled = False
            CheckBox11.Enabled = False
            Invite = False
            Friends = True
            CheckBox3.Enabled = False
            Label7.Show()
            Label3.Hide()
        ElseIf Count.Equals(3) Then
            Label4.Hide()
            Label8.Hide()
            Label9.Show()
            TextBox6.Show()
            TextBox7.Show()
            TextBox1.Hide()
            TextBox2.Hide()
            TextBox3.Hide()
            TextBox4.Hide()
            TextBox5.Hide()
            CheckBox18.Hide()
            CheckBox19.Hide()
            CheckBox20.Hide()
            CheckBox3.Hide()
            CheckBox17.Hide()
            Label4.Text = "Delay: " & TrackBar4.Value.ToString & " ms"
            TrackBar4.Show()
            TrackBar3.Hide()
            TrackBar2.Hide()
            CheckBox9.Hide()
            CheckBox10.Hide()
            CheckBox11.Hide()
            Me.MinimumSize = New Size(378, 500)
            Me.Size = New Size(378, 500)
            Chatbox.Location = New Point(18, 346)
            Chatbox.Size = New Size(343, 109)
            Label6.Location = New Point(18, 315)
            Input2.Hide()
            Input3.Hide()
            Input4.Hide()
            Input5.Hide()
            CheckBox12.Hide()
            CheckBox13.Hide()
            CheckBox14.Hide()
            CheckBox15.Hide()
            CheckBox16.Hide()
            CheckBox4.Hide()
            CheckBox5.Hide()
            CheckBox6.Hide()
            CheckBox7.Hide()
            CheckBox8.Hide()
            Invite = False
            Friends = False
            Button3.Show()
            Label7.Hide()
        End If

        Label5.Text = Count.ToString + "/3"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        Stopping1 = True
        Stopping2 = True
        Stopping3 = True
        Stopping4 = True
        Stopping5 = True
        Stopping6 = True
        Stopping7 = True
        Stopping8 = True
        Stopping9 = True
        Stopping10 = True

        Stopping13 = True

        Runnercount = 0

        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False

        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox14.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False

        Try
            BackgroundWorker1.CancelAsync()
            If Run1 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 1!"
                Run1 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker2.CancelAsync()
            If Run2 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 2!"
                Run2 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker3.CancelAsync()
            If Run3 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 3!"
                Run3 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker4.CancelAsync()
            If Run4 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 4!"
                Run4 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker5.CancelAsync()
            If Run5 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 5!"
                Run5 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker6.CancelAsync()
            If Run6 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 6!"
                Run6 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker7.CancelAsync()
            If Run7 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 7!"
                Run7 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker8.CancelAsync()
            If Run8 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 8!"
                Run8 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker9.CancelAsync()
            If Run9 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 9!"
                Run9 = False
            End If
        Catch
        End Try

        Try
            BackgroundWorker10.CancelAsync()
            If Run10 Then
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Stopped Background-Worker 10!"
                Run10 = False
            End If
        Catch
        End Try

        Label6.Text = "Active Spammers: 0"
    End Sub

    Private Function Execute()
        If Chatbox.Text.Length > 2400 Then
            Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                           vbCrLf
        End If

        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "POST"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json = "{""queueId"":430}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Lobby: Created Normal Lobby!"
            End Using
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Couldn't create a Lobby!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Function

    Private Async Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping1 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate) Then
                    Dim json As String = "{""name"":""" + Name + """}"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "{""name"":""" + Lobbycreate + """}"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate & " Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            ElseIf CheckBox18.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests/" & puid & "@eu1.pvp.net"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "DELETE"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Removed " &
                                   Lobbycreate & "'s Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox20.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            ElseIf CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork


        Dim Lobbyornot As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.ContentType = "application/json"
        httpWebRequest2.Method = "GET"
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest2.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Lobbyornot = streamReader.ReadToEnd()
            End Using
            httpResponse.Close()
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need to be in a Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
            GoTo Nextt
        End Try

        If Lobbyornot.Contains("""isCustom"":true") Then
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Doesn't work in Custom Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
        End If

        Nextt:

        Dim Name As String
        Dim Summid As String

        If IsNumeric(Lobbycreate2) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate2),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate2),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping2 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate2) Then
                    Dim json As String = "[{""toSummonerId"":" + Lobbycreate2 + "}]"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate2 & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            ElseIf CheckBox11.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            End If

            Dim Sumrequest As String

            If IsNumeric(Lobbycreate2) Then
                Sumrequest = Lobbycreate2
            Else
                Sumrequest = Summid
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/members/" & Sumrequest & "/kick"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Cancelled " & Lobbycreate2 & "'s Invite-Request"
                    If CheckBox3.Checked Then
                        If TrackBar2.Value >= 10 Then
                            TrackBar2.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                If CheckBox3.Checked Then
                    If TrackBar2.Value <= 7900 Then
                        TrackBar2.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox9.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            ElseIf CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate3) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate3),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate3),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping3 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate3) Then
                    Dim json As String = "{""name"":""" + Name + """}"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "{""name"":""" + Lobbycreate3 + """}"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate3 & " Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            ElseIf CheckBox18.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests/" & puid & "@eu1.pvp.net"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "DELETE"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Removed " &
                                   Lobbycreate3 & "'s Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try


            If CheckBox20.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            ElseIf CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim Lobbyornot As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.ContentType = "application/json"
        httpWebRequest2.Method = "GET"
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest2.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Lobbyornot = streamReader.ReadToEnd()
            End Using
            httpResponse.Close()
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need to be in a Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
            GoTo Nextt
        End Try

        If Lobbyornot.Contains("""isCustom"":true") Then
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Doesn't work in Custom Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
        End If

        Nextt:

        Dim Name As String
        Dim Summid As String

        If IsNumeric(Lobbycreate4) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate4),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate4),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping4 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate4) Then
                    Dim json As String = "[{""toSummonerId"":" + Lobbycreate4 + "}]"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate4 & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            ElseIf CheckBox11.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            End If

            Dim Sumrequest As String

            If IsNumeric(Lobbycreate4) Then
                Sumrequest = Lobbycreate4
            Else
                Sumrequest = Summid
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/members/" & Sumrequest & "/kick"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Cancelled " & Lobbycreate6 & "'s Invite-Request"
                    If CheckBox3.Checked Then
                        If TrackBar2.Value >= 10 Then
                            TrackBar2.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                If CheckBox3.Checked Then
                    If TrackBar2.Value <= 7900 Then
                        TrackBar2.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox9.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            ElseIf CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker5_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate5) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate5),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate5),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping5 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate5) Then
                    Dim json As String = "{""name"":""" + Name + """}"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "{""name"":""" + Lobbycreate5 + """}"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate5 & " Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            ElseIf CheckBox18.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests/" & puid & "@eu1.pvp.net"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "DELETE"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Removed " &
                                   Lobbycreate5 & "'s Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox20.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            ElseIf CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker6_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim Lobbyornot As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.ContentType = "application/json"
        httpWebRequest2.Method = "GET"
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest2.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Lobbyornot = streamReader.ReadToEnd()
            End Using
            httpResponse.Close()
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need to be in a Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
            GoTo Nextt
        End Try

        If Lobbyornot.Contains("""isCustom"":true") Then
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Doesn't work in Custom Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
        End If

        Nextt:

        Dim Name As String
        Dim Summid As String

        If IsNumeric(Lobbycreate6) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate6),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate6),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping6 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate6) Then
                    Dim json As String = "[{""toSummonerId"":" + Lobbycreate6 + "}]"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate6 & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            ElseIf CheckBox11.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            End If

            Dim Sumrequest As String

            If IsNumeric(Lobbycreate6) Then
                Sumrequest = Lobbycreate6
            Else
                Sumrequest = Summid
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/members/" & Sumrequest & "/kick"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Cancelled " & Lobbycreate6 & "'s Invite-Request"
                    If CheckBox3.Checked Then
                        If TrackBar2.Value >= 10 Then
                            TrackBar2.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                If CheckBox3.Checked Then
                    If TrackBar2.Value <= 7900 Then
                        TrackBar2.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox9.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            ElseIf CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            End If


            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker7_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate7) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate7),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate7),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping7 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate7) Then
                    Dim json As String = "{""name"":""" + Name + """}"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "{""name"":""" + Lobbycreate7 + """}"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate7 & " Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            ElseIf CheckBox18.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests/" & puid & "@eu1.pvp.net"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "DELETE"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Removed " &
                                   Lobbycreate7 & "'s Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox20.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            ElseIf CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker8_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker8.DoWork

        Dim Lobbyornot As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.ContentType = "application/json"
        httpWebRequest2.Method = "GET"
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest2.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Lobbyornot = streamReader.ReadToEnd()
            End Using
            httpResponse.Close()
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need to be in a Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
            GoTo Nextt
        End Try

        If Lobbyornot.Contains("""isCustom"":true") Then
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Doesn't work in Custom Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
        End If

        Nextt:

        Dim Name As String
        Dim Summid As String

        If IsNumeric(Lobbycreate8) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate8),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate8),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping8 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate8) Then
                    Dim json As String = "[{""toSummonerId"":" + Lobbycreate8 + "}]"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate8 & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            ElseIf CheckBox11.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            End If

            Dim Sumrequest As String

            If IsNumeric(Lobbycreate8) Then
                Sumrequest = Lobbycreate8
            Else
                Sumrequest = Summid
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/members/" & Sumrequest & "/kick"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Cancelled " & Lobbycreate8 & "'s Invite-Request"
                    If CheckBox3.Checked Then
                        If TrackBar2.Value >= 10 Then
                            TrackBar2.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                If CheckBox3.Checked Then
                    If TrackBar2.Value <= 7900 Then
                        TrackBar2.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox9.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            ElseIf CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            End If


            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker9_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker9.DoWork

        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate9) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate9),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate9),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping9 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate9) Then
                    Dim json As String = "{""name"":""" + Name + """}"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "{""name"":""" + Lobbycreate9 + """}"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate9 & " Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            ElseIf CheckBox18.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests/" & puid & "@eu1.pvp.net"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "DELETE"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Removed " &
                                   Lobbycreate9 & "'s Friend-Request"
                    If CheckBox17.Checked Then
                        If TrackBar3.Value >= 10 Then
                            TrackBar3.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Spam: Player doesn't accept further Friend Requests!"
                If CheckBox17.Checked Then
                    If TrackBar3.Value <= 7900 Then
                        TrackBar3.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar3.Value)
                GoTo Again
            End Try

            If CheckBox20.Checked Then
                Await Task.Delay(TrackBar3.Value*2)
            ElseIf CheckBox19.Checked Then
                Await Task.Delay(TrackBar3.Value)
            End If

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker10_DoWork(sender As Object, e As DoWorkEventArgs) _
        Handles BackgroundWorker10.DoWork

        Dim Lobbyornot As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.ContentType = "application/json"
        httpWebRequest2.Method = "GET"
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest2.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Lobbyornot = streamReader.ReadToEnd()
            End Using
            httpResponse.Close()
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need to be in a Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
            GoTo Nextt
        End Try

        If Lobbyornot.Contains("""isCustom"":true") Then
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: Doesn't work in Custom Lobby!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] Lobby: Creating a new Lobby!"
            Execute()
        End If

        Nextt:

        Dim Name As String
        Dim Summid As String

        If IsNumeric(Lobbycreate10) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate10),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate10),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

        End If

        Again:

        If Not Stopping10 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                If IsNumeric(Lobbycreate10) Then
                    Dim json As String = "[{""toSummonerId"":" + Lobbycreate10 + "}]"
                    streamWriter.Write(json)
                Else
                    Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                    streamWriter.Write(json)
                End If
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate10 & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            ElseIf CheckBox11.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            End If

            Dim Sumrequest As String

            If IsNumeric(Lobbycreate10) Then
                Sumrequest = Lobbycreate10
            Else
                Sumrequest = Summid
            End If

            Dim request2 =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/members/" & Sumrequest & "/kick"),
                        HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                   "] Spam: Cancelled " & Lobbycreate10 & "'s Invite-Request"
                    If CheckBox3.Checked Then
                        If TrackBar2.Value >= 10 Then
                            TrackBar2.Value -= 10
                        End If
                    End If
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
                If CheckBox3.Checked Then
                    If TrackBar2.Value <= 7900 Then
                        TrackBar2.Value += 100
                    End If
                End If
                Thread.Sleep(TrackBar2.Value)
                GoTo Again
            End Try

            If CheckBox9.Checked Then
                Await Task.Delay(TrackBar2.Value*2)
            ElseIf CheckBox10.Checked Then
                Await Task.Delay(TrackBar2.Value)
            End If


            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Async Sub BackgroundWorker13_DoWork(sender As Object, e As DoWorkEventArgs) _
        Handles BackgroundWorker13.DoWork
        Dim puid As String
        Dim Name As String

        If IsNumeric(Lobbycreate13) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + Lobbycreate13),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerName: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Try
                    BackgroundWorker13.CancelAsync()
                Catch
                End Try
                Return
            End Try

        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + Lobbycreate13),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    puid = JObject.Parse(streamReader.ReadToEnd())("puuid").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] SummonerID: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Try
                    BackgroundWorker13.CancelAsync()
                Catch
                End Try
                Return
            End Try

        End If

        Dim Region As String
        Dim httpWebRequest2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friends"),
                                    HttpWebRequest)
        httpWebRequest2.PreAuthenticate = True
        httpWebRequest2.Headers.Add("Authorization", "Basic " & auth)
        Try
            Dim httpResponse3 = CType(httpWebRequest2.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse3.GetResponseStream())
                Dim St As String = streamReader.ReadToEnd()

                Dim pFrom As Integer = St.IndexOf("""pid"":""" & puid & "@") + ("""pid"":""" & puid & "@").Length
                Dim pTo As Integer = pFrom + 3
                Region = St.Substring(pFrom, pTo - pFrom)
            End Using
        Catch
            Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                           "] ERROR: You need this Person as Friend added first!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
            Try
                BackgroundWorker13.CancelAsync()
            Catch
                Return
            End Try
        End Try

        Again:

        If Not Stopping13 Then

            If Chatbox.Text.Length > 2400 Then
                Chatbox.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                               vbCrLf
            End If

            Dim request =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/conversations/" & puid & "%40" & Region &
                            ".pvp.net/messages"),
                        HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                Dim json As String = "{""body"":""" & Textspam & """}"
                streamWriter.Write(json)
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   Lobbycreate13 & " Spam-Message"

                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Works only with Players in your Friends-List!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

            Await Task.Delay(TrackBar4.Value)

            GoTo Again
        Else
            Return
        End If
    End Sub

    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Label8.Text = "Delay: " & TrackBar3.Value.ToString & " ms"

        If TrackBar3.Value = 8000 Then
            Label8.ForeColor = Color.FromArgb(255, 0, 255, 0)
        ElseIf TrackBar3.Value >= 3000 And TrackBar3.Value <= 7999 Then
            Label8.ForeColor = Color.FromArgb(255, 100, 255, 0)
        ElseIf TrackBar3.Value >= 2500 And TrackBar3.Value <= 3999 Then
            Label8.ForeColor = Color.FromArgb(255, 150, 255, 0)
        ElseIf TrackBar3.Value >= 1000 And TrackBar3.Value <= 2499 Then
            Label8.ForeColor = Color.FromArgb(255, 255, 255, 0)
        ElseIf TrackBar3.Value >= 500 And TrackBar3.Value <= 999 Then
            Label8.ForeColor = Color.FromArgb(255, 255, 200, 0)
        ElseIf TrackBar3.Value >= 250 And TrackBar3.Value <= 499 Then
            Label8.ForeColor = Color.FromArgb(255, 255, 150, 0)
        ElseIf TrackBar3.Value >= 150 And TrackBar3.Value <= 249 Then
            Label8.ForeColor = Color.FromArgb(255, 255, 100, 0)
        ElseIf TrackBar3.Value >= 51 And TrackBar3.Value <= 149 Then
            Label8.ForeColor = Color.FromArgb(255, 255, 50, 0)
        ElseIf TrackBar3.Value <= 50 Then
            Label8.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        Label9.Text = "Delay: " & TrackBar4.Value.ToString & " ms"

        If TrackBar4.Value = 8000 Then
            Label9.ForeColor = Color.FromArgb(255, 0, 255, 0)
        ElseIf TrackBar4.Value >= 3000 And TrackBar4.Value <= 7999 Then
            Label9.ForeColor = Color.FromArgb(255, 100, 255, 0)
        ElseIf TrackBar4.Value >= 2500 And TrackBar4.Value <= 3999 Then
            Label9.ForeColor = Color.FromArgb(255, 150, 255, 0)
        ElseIf TrackBar4.Value >= 1000 And TrackBar4.Value <= 2499 Then
            Label9.ForeColor = Color.FromArgb(255, 255, 255, 0)
        ElseIf TrackBar4.Value >= 500 And TrackBar4.Value <= 999 Then
            Label9.ForeColor = Color.FromArgb(255, 255, 200, 0)
        ElseIf TrackBar4.Value >= 250 And TrackBar4.Value <= 499 Then
            Label9.ForeColor = Color.FromArgb(255, 255, 150, 0)
        ElseIf TrackBar4.Value >= 150 And TrackBar4.Value <= 249 Then
            Label9.ForeColor = Color.FromArgb(255, 255, 100, 0)
        ElseIf TrackBar4.Value >= 51 And TrackBar4.Value <= 149 Then
            Label9.ForeColor = Color.FromArgb(255, 255, 50, 0)
        ElseIf TrackBar4.Value <= 50 Then
            Label9.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CheckBox20_Click(sender As Object, e As EventArgs) Handles CheckBox20.Click
        If CheckBox20.Checked Then
            CheckBox19.Checked = False
            CheckBox18.Checked = False
        Else
            CheckBox20.Checked = True
        End If
    End Sub

    Private Sub CheckBox19_Click(sender As Object, e As EventArgs) Handles CheckBox19.Click
        If CheckBox19.Checked Then
            CheckBox20.Checked = False
            CheckBox18.Checked = False
        Else
            CheckBox19.Checked = True
        End If
    End Sub

    Private Sub CheckBox18_Click(sender As Object, e As EventArgs) Handles CheckBox18.Click
        If CheckBox18.Checked Then
            CheckBox20.Checked = False
            CheckBox19.Checked = False
        Else
            CheckBox18.Checked = True
        End If
    End Sub

    Private Sub TrackBar3_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar3.ValueChanged
        Label8.Text = "Delay: " & TrackBar3.Value.ToString & " ms"
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
    End Sub

    Private Async Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lst As New List(Of String) From {Input1.Text, Input2.Text, Input3.Text, Input4.Text, Input5.Text}

        For Each item As String In lst

            Dim Summid

            Await Task.Delay(1500)

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + item),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Summid = JObject.Parse(streamReader.ReadToEnd())("summonerId").ToString
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] ERROR: Account not found!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/friend-requests"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "POST"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                Dim json As String = "{""name"":""" + item + """}"
                streamWriter.Write(json)
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Add: Sent " &
                                   item & " Friend-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                               "] Add: Player doesn't accept further Friend Requests!"
            End Try

            Await Task.Delay(500)

            Dim request2 = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby/invitations"),
                                 HttpWebRequest)
            request2.PreAuthenticate = True
            request2.ContentType = "application/json"
            request2.Method = "POST"
            request2.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request2.GetRequestStream())
                Dim json As String = "[{""toSummonerId"":" + Summid + "}]"
                streamWriter.Write(json)
            End Using

            Try
                Dim httpResponse = CType(request2.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Sent " &
                                   item & " Invite-Request"
                End Using
            Catch
                Chatbox.Text = Chatbox.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Spam: Rate-Limited!"
            End Try
        Next
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
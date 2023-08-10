﻿Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class Form3
    Inherits Form

    Dim count As Int32 = 1

    Dim auth
    Dim port

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        B1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B2.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B3.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B4.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B5.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B6.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B7.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B8.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B9.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B10.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B11.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B12.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        I1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        I2.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        I3.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)
        I4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Bold)

        TextBox2.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        Button14.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        Button6.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        Label1.Font = New Font(Form9.pfc.Families(1), 11, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        Label3.Font = New Font(Form9.pfc.Families(0), 11, FontStyle.Bold)


        Dim r As New Random
        Me.Text = RandomString(r)
        B1.Show()
        Label2.Text = "Opacity"
        NotifyIcon1.Visible = False

        Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
        If process Is Nothing Then
            If TextBox2.TextLength = 0 Then
                TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Start LoL first!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                Return
            Else
                TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Start LoL first!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                Return
            End If
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        Dim serverCertificateValidationCallback As [Delegate] = ServicePointManager.ServerCertificateValidationCallback
        ServicePointManager.ServerCertificateValidationCallback =
            Function(se As Object, cert As X509Certificate, chain As X509Chain, sslerror As SslPolicyErrors) True
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

    Private Function Execute(Lobbycreate As String)
        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "POST"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json As String = "{""queueId"":" + Lobbycreate + "}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Lobby: Success"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Function


    Private Function Execute2(Lobbycreate As String)
        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v2/lobby"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "POST"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json As String = Lobbycreate
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Lobby: Success"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Function


    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown _
        'moveable borderless form
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

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


    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles B1.MouseEnter
        B1.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles B1.MouseLeave
        B1.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B2_MouseEnter(sender As Object, e As EventArgs) Handles B2.MouseEnter
        B2.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B2_MouseLeave(sender As Object, e As EventArgs) Handles B2.MouseLeave
        B2.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B3_MouseEnter(sender As Object, e As EventArgs) Handles B3.MouseEnter
        B3.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B3_MouseLeave(sender As Object, e As EventArgs) Handles B3.MouseLeave
        B3.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B4_MouseEnter(sender As Object, e As EventArgs) Handles B4.MouseEnter
        B4.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B4_MouseLeave(sender As Object, e As EventArgs) Handles B4.MouseLeave
        B4.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B5_MouseEnter(sender As Object, e As EventArgs) Handles B5.MouseEnter
        B5.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B5_MouseLeave(sender As Object, e As EventArgs) Handles B5.MouseLeave
        B5.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B6_MouseEnter(sender As Object, e As EventArgs) Handles B6.MouseEnter
        B6.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B6_MouseLeave(sender As Object, e As EventArgs) Handles B6.MouseLeave
        B6.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B7_MouseEnter(sender As Object, e As EventArgs) Handles B7.MouseEnter
        B7.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B7_MouseLeave(sender As Object, e As EventArgs) Handles B7.MouseLeave
        B7.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B8_MouseEnter(sender As Object, e As EventArgs) Handles B8.MouseEnter
        B8.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B8_MouseLeave(sender As Object, e As EventArgs) Handles B8.MouseLeave
        B8.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B9_MouseEnter(sender As Object, e As EventArgs) Handles B9.MouseEnter
        B9.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B9_MouseLeave(sender As Object, e As EventArgs) Handles B9.MouseLeave
        B9.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B10_MouseEnter(sender As Object, e As EventArgs) Handles B10.MouseEnter
        B10.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B10_MouseLeave(sender As Object, e As EventArgs) Handles B10.MouseLeave
        B10.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B11_MouseEnter(sender As Object, e As EventArgs) Handles B11.MouseEnter
        B11.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B11_MouseLeave(sender As Object, e As EventArgs) Handles B11.MouseLeave
        B11.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub B12_MouseEnter(sender As Object, e As EventArgs) Handles B12.MouseEnter
        B12.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub B12_MouseLeave(sender As Object, e As EventArgs) Handles B12.MouseLeave
        B12.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.Opacity = TrackBar1.Value/100
        Label2.Text = TrackBar1.Value.ToString + "%"
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.SelectionStart = TextBox2.Text.Length
        TextBox2.ScrollToCaret()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles B1.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("430")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles B2.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("400")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles B3.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("450")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles B6.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("1090")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles B7.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("1100")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles B12.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If I2.Text.Length.Equals(0) Or I3.Text.Length.Equals(0) Then
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] Error: You have to specify a password and lobby name!"
            Return
        End If
        Execute2(
            "{""customGameLobby"":{""configuration"":{""gameMode"":""PRACTICETOOL"",""gameMutator"":"""",""gameServerRegion"":"""",""mapId"":11,""mutators"":{""id"":1},""spectatorPolicy"":""AllAllowed"",""teamSize"":" &
            I5.Text & "},""lobbyName"":""" & I2.Text & """,""lobbyPassword"":""" & I3.Text & """},""isCustom"":true}")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles B8.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If I2.Text.Length.Equals(0) Or I3.Text.Length.Equals(0) Then
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] Error: You have to specify a password and lobby name!"
            Return
        End If
        Execute2(
            "{""customGameLobby"":{""configuration"":{""gameMode"":""CLASSIC"",""gameMutator"":"""",""gameServerRegion"":"""",""mapId"":11,""mutators"":{""id"":1},""spectatorPolicy"":""AllAllowed"",""teamSize"":" &
            I5.Text & "},""lobbyName"":""" & I2.Text & """,""lobbyPassword"":""" & I3.Text & """},""isCustom"":true}")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles B9.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If I2.Text.Length.Equals(0) Or I3.Text.Length.Equals(0) Then
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] Error: You have to specify a password and lobby name!"
            Return
        End If
        Execute2(
            "{""customGameLobby"":{""configuration"":{""gameMode"":""ARAM"",""gameMutator"":"""",""gameServerRegion"":"""",""mapId"":12,""mutators"":{""id"":1},""spectatorPolicy"":""AllAllowed"",""teamSize"":" &
            I5.Text & "},""lobbyName"":""" & I2.Text & """,""lobbyPassword"":""" & I3.Text & """},""isCustom"":true}")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles B10.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If I2.Text.Length.Equals(0) Or I3.Text.Length.Equals(0) Then
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] Error: You have to specify a password and lobby name!"
            Return
        End If
        Execute2(
            "{""customGameLobby"":{""configuration"":{""gameMode"":""CLASSIC"",""gameMutator"":"""",""gameServerRegion"":"""",""mapId"":11,""mutators"":{""id"":2},""spectatorPolicy"":""AllAllowed"",""teamSize"":" &
            I5.Text & "},""lobbyName"":""" & I2.Text & """,""lobbyPassword"":""" & I3.Text & """},""isCustom"":true}")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles B11.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If I1.Text.Length.Equals(0) Then
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] Error: You have to specify the Lobby ID!"
            Return
        End If
        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request =
                CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-lobby/v1/custom-games/" & I1.Text & "/join"),
                      HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "POST"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json = "{""asSpectator"":false}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Lobby: Success"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles B4.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Execute("420")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles B5.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Execute("440")
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If count >= 12 Then
            count = 1
        Else
            count = count + 1
        End If

        If count.Equals(1) Then
            B1.Show()
            B2.Hide()
            I2.Enabled = False
            I3.Enabled = False
            I4.Enabled = False
            I5.Enabled = False
        ElseIf count.Equals(2) Then
            B2.Show()
            B1.Hide()
        ElseIf count.Equals(3) Then
            B3.Show()
            B2.Hide()
        ElseIf count.Equals(4) Then
            B4.Show()
            B3.Hide()
        ElseIf count.Equals(5) Then
            B5.Show()
            B4.Hide()
        ElseIf count.Equals(6) Then
            B6.Show()
            B5.Hide()
        ElseIf count.Equals(7) Then
            B7.Show()
            B6.Hide()
        ElseIf count.Equals(8) Then
            B8.Show()
            B7.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(9) Then
            B9.Show()
            B8.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(10) Then
            B10.Show()
            B9.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(11) Then
            B11.Show()
            B10.Hide()
            I1.Enabled = True
            I2.Enabled = False
            I3.Enabled = False
            I4.Enabled = False
            I5.Enabled = False
        ElseIf count.Equals(12) Then
            B12.Show()
            B11.Hide()
            I1.Enabled = False
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        End If

        Label3.Text = count.ToString + "/12"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If count.Equals(12) Then
            B11.Show()
            B12.Hide()
            I1.Enabled = True
            I2.Enabled = False
            I3.Enabled = False
            I4.Enabled = False
            I5.Enabled = False
        ElseIf count.Equals(11) Then
            B10.Show()
            B11.Hide()
            I1.Enabled = False
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(10) Then
            B9.Show()
            B10.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(9) Then
            B8.Show()
            B9.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        ElseIf count.Equals(8) Then
            B7.Show()
            B8.Hide()
            I2.Enabled = False
            I3.Enabled = False
            I4.Enabled = False
            I5.Enabled = False
        ElseIf count.Equals(7) Then
            B6.Show()
            B7.Hide()
        ElseIf count.Equals(6) Then
            B5.Show()
            B6.Hide()
        ElseIf count.Equals(5) Then
            B4.Show()
            B5.Hide()
        ElseIf count.Equals(4) Then
            B3.Show()
            B4.Hide()
        ElseIf count.Equals(3) Then
            B2.Show()
            B3.Hide()
        ElseIf count.Equals(2) Then
            B1.Show()
            B2.Hide()
        ElseIf count.Equals(1) Then
            B12.Show()
            B1.Hide()
            I2.Enabled = True
            I3.Enabled = True
            I4.Enabled = True
            I5.Enabled = True
        End If

        If count <= 1 Then
            count = 12
        Else
            count = count - 1
        End If

        Label3.Text = count.ToString + "/12"
    End Sub

    Private Sub I1_TextClick(sender As Object, e As EventArgs) Handles I1.Click
        If I1.Text = "Lobby ID" Then
            I1.Text = ""
        End If
    End Sub

    Private Sub I2_TextClick(sender As Object, e As EventArgs) Handles I2.Click
        If I2.Text = "Lobby Name" Then
            I2.Text = ""
        End If
    End Sub

    Private Sub I3_TextClick(sender As Object, e As EventArgs) Handles I3.Click
        If I3.Text = "Lobby Password" Then
            I3.Text = ""
        End If
    End Sub

    Private Const WS_EX_TRANSPARENT As Integer = &H20

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

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
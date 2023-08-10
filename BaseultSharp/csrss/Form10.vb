Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports Nancy.Json

Public Class Form10
    Dim Id
    Dim Locked As Boolean = False
    Dim Lobbyid

    Dim auth
    Dim port

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        Label1.Font = New Font(Form9.pfc.Families(1), 11, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)

        CheckBox1.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        CheckBox2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        B1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)


        TextBox1.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Regular)
        TextBox3.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Regular)
        TextBox2.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)

        Label9.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Regular)


        Dim r As New Random
        Me.Text = RandomString(r)
        CheckForIllegalCrossThreadCalls = False

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

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.Opacity = TrackBar1.Value/100
        Label2.Text = TrackBar1.Value.ToString + "%"
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
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles B1.MouseLeave
        B1.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim counter = 0

        Again:

        If counter >= 11 Then
            counter = 0
        End If

        If Locked = False Then
            Dim request =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-champ-select/v1/session/actions/" & counter),
                        HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "PATCH"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                Dim json As String = "{""completed"":true,""championId"":" & Id & "}"
                streamWriter.Write(json)
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                    "] Instalock: Champion Locked!"
                End Using
            Catch
                counter += 1
                Thread.Sleep(10)
                GoTo Again
            End Try

            Tryagain:

            Dim httpWebRequestf = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/conversations"),
                                        HttpWebRequest)
            httpWebRequestf.PreAuthenticate = True
            httpWebRequestf.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequestf.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())


                    Dim St As String = streamReader.ReadToEnd()

                    Dim pFrom As Integer = St.IndexOf("champ-select") - 37
                    Dim pTo As Integer = pFrom + 64
                    Lobbyid = St.Substring(pFrom, pTo - pFrom).Replace("""", "").Replace(",", "")

                    If pFrom > - 1 AndAlso pTo > - 1 Then
                        If Not Lobbyid.Contains("champ-select") Then
                            Thread.Sleep(TrackBar4.Value)
                            GoTo Tryagain
                        End If
                    Else
                        Thread.Sleep(TrackBar4.Value)
                        GoTo Tryagain
                    End If

                End Using
            Catch
                Thread.Sleep(TrackBar4.Value)
                GoTo Tryagain
            End Try

            Dim requestx =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-chat/v1/conversations/" & Lobbyid & "/messages"),
                        HttpWebRequest)
            requestx.PreAuthenticate = True
            requestx.ContentType = "application/json"
            requestx.Method = "POST"
            requestx.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(requestx.GetRequestStream())
                Dim json As String = "{""body"":""" & TextBox3.Text & """}"
                streamWriter.Write(json)
            End Using

            Try
                Dim httpResponse = CType(requestx.GetResponse(), HttpWebResponse)
                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                    "] Instalock: Wrote Message!"
                End Using
                Locked = True
                B1.Enabled = True
                BackgroundWorker1.CancelAsync()
                Return
            Catch
                Thread.Sleep(TrackBar4.Value)
                GoTo Tryagain
                Return
            End Try

        Else
            Locked = True
            B1.Enabled = True
            BackgroundWorker1.CancelAsync()
            Return
        End If
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click

        B1.Enabled = False
        Locked = False

        Dim webClient As New WebClient
        Dim result As String =
                webClient.DownloadString("http://ddragon.leagueoflegends.com/cdn/11.3.1/data/en_US/champion.json")

        Try
            Dim j = New JavaScriptSerializer().Deserialize (Of Object)(result)
            Id = j("data")(TextBox1.Text)("key")
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Wrong Champion Name!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
            B1.Enabled = True
            Return
        End Try

        TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                        "] Instalock: Waiting for Lobby!"
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        If TrackBar4.Value <= 50 Then
            Label9.Text = "Extreme"
            Label9.ForeColor = Color.Red
        ElseIf TrackBar4.Value > 50 And TrackBar4.Value <= 150 Then
            Label9.Text = "Inhuman"
            Label9.ForeColor = Color.OrangeRed
        ElseIf TrackBar4.Value > 150 And TrackBar4.Value <= 300 Then
            Label9.Text = "Very Fast"
            Label9.ForeColor = Color.Orange
        ElseIf TrackBar4.Value > 300 And TrackBar4.Value <= 500 Then
            Label9.Text = "Fast"
            Label9.ForeColor = Color.Yellow
        ElseIf TrackBar4.Value > 500 And TrackBar4.Value <= 1000 Then
            Label9.Text = "Moderate"
            Label9.ForeColor = Color.YellowGreen
        ElseIf TrackBar4.Value > 1000 And TrackBar4.Value <= 1500 Then
            Label9.Text = "Default"
            Label9.ForeColor = Color.Lime
        ElseIf TrackBar4.Value > 1500 And TrackBar4.Value <= 2000 Then
            Label9.Text = "Human"
            Label9.ForeColor = Color.White
        End If
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

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
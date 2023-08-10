Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Form2
    Inherits Form

    Dim auth
    Dim port
    Dim count As Integer = 1

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        Label1.Font = New Font(Form9.pfc.Families(1), 11, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        Label3.Font = New Font(Form9.pfc.Families(0), 11, FontStyle.Bold)
        CheckBox1.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        CheckBox2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        B1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B2.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Button14.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        Button6.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox2.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)

        Dim r As New Random
        Me.Text = RandomString(r)

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

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.FromArgb(100, 50, 50)
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.FromArgb(39, 39, 39)
    End Sub

    Private Sub PictureBox5_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.BackColor = Color.FromArgb(50, 100, 50)
    End Sub

    Private Sub PictureBox5_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.BackColor = Color.FromArgb(39, 39, 39)
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles B2.MouseEnter
        B2.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles B2.MouseLeave
        B2.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles B1.MouseEnter
        B1.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles B1.MouseLeave
        B1.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources._20, AudioPlayMode.WaitToComplete)
        Me.Close()
        Form9.Close()
    End Sub

    Private Sub PictureBox3_MouseDown(sender As Object, e As MouseEventArgs)
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        My.Computer.Audio.Play(My.Resources._18, AudioPlayMode.WaitToComplete)
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If TextBox1.Text.Contains("Enter Targets Summoner Name or ID") Then
            TextBox1.Text = ""
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles B1.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        If IsNumeric(TextBox1.Text) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + TextBox1.Text),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Dim Name = JObject.Parse(streamReader.ReadToEnd())("displayName").ToString
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                    "] SummonerName: " + Name
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Account not found!"
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Only Accounts in the same Region as your logged in Account!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try
        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + TextBox1.Text),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Dim Name = JObject.Parse(streamReader.ReadToEnd())("accountId").ToString
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] SummonerID: " +
                                    Name
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Account not found!"
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Only Accounts in the same Region as your logged in Account!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles B2.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        If IsNumeric(TextBox1.Text) Then

            Dim httpWebRequest =
                    CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/summoners/" + TextBox1.Text),
                          HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())

                    Dim Name As String =
                            streamReader.ReadToEnd().Replace("{""ac", """ac").Replace("""", "").Replace(":", ": ").
                            Replace(",", vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] ").Replace("{",
                                                                                                          vbCrLf + "[" +
                                                                                                          DateTime.Now.
                                                                                                              ToString(
                                                                                                                  "hh:mm:ss") +
                                                                                                          "] ").Replace(
                                                                                                              "}", "")
                    'Dim Name = JObject.Parse(streamReader.ReadToEnd())("accountId").ToString
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] " + Name
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Account not found!"
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Only Accounts in the same Region as your logged in Account!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try
        Else

            Dim httpWebRequest =
                    CType(
                        WebRequest.Create(
                            "https://127.0.0.1:" & port & "/lol-summoner/v1/summoners?name=" + TextBox1.Text),
                        HttpWebRequest)
            httpWebRequest.PreAuthenticate = True
            httpWebRequest.Headers.Add("Authorization", "Basic " & auth)
            Try
                Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Dim Name As String =
                            streamReader.ReadToEnd().Replace("""", "").Replace(":", ": ").Replace(",",
                                                                                                  vbCrLf + "[" +
                                                                                                  DateTime.Now.ToString(
                                                                                                      "hh:mm:ss") + "] ") _
                            .Replace("{", vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] ").Replace("}", "")
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] SummonerID: " +
                                    Name
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Account not found!"
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Only Accounts in the same Region as your logged in Account!"
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return
            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)

        Label3.Text = count.ToString + "/2"

        If count >= 2 Then
            count = 1
        Else
            count = count + 1
        End If

        If count.Equals(1) Then
            B1.Show()
            B2.Hide()
        ElseIf count.Equals(2) Then
            B2.Show()
            B1.Hide()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)

        Label3.Text = count.ToString + "/2"

        If count.Equals(2) Then
            B1.Show()
            B2.Hide()
        ElseIf count.Equals(1) Then
            B2.Show()
            B1.Hide()
        End If

        If count <= 1 Then
            count = 2
        Else
            count = count - 1
        End If
    End Sub

    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.SelectionStart = TextBox2.Text.Length
        TextBox2.ScrollToCaret()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class Form7
    Inherits Form

    Dim count As Int32 = 1

    Public Stopping As Boolean = False
    Dim auth
    Dim port

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        auth = Form9.auth
        port = Form9.port

        Label1.Font = New Font(Form9.pfc.Families(1), 11, FontStyle.Bold)
        Label2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        Label3.Font = New Font(Form9.pfc.Families(0), 11, FontStyle.Bold)
        CheckBox1.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        CheckBox2.Font = New Font(Form9.pfc.Families(1), 8, FontStyle.Bold)
        B1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B2.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B3.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B4.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        B5.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Button6.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox1.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        TextBox2.Font = New Font(Form9.pfc.Families(0), 12, FontStyle.Regular)
        TextBox5.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox4.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox3.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox1.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        TextBox6.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)
        Button4.Font = New Font(Form9.pfc.Families(0), 20, FontStyle.Bold)
        Label4.Font = New Font(Form9.pfc.Families(0), 16, FontStyle.Regular)
        Button1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)
        Button2.Font = New Font(Form9.pfc.Families(0), 14, FontStyle.Bold)


        Dim r As New Random
        Me.Text = RandomString(r)
        CheckForIllegalCrossThreadCalls = False

        B1.Show()
        Label2.Text = "Opacity"
        NotifyIcon1.Visible = False

        Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
        If process Is Nothing Then
            If TextBox2.TextLength = 0 Then
                TextBox2.Text = TextBox2.Text + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Start LoL first!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
                Return
            Else
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Loading: Start LoL first!"
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
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles B1.MouseLeave
        B1.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button111_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.FromArgb(40, 40, 40)
        Label3.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button111_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(30, 30, 30)
        Label3.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub Button1111_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.FromArgb(40, 40, 40)
    End Sub

    Private Sub Button1111_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.FromArgb(30, 30, 30)
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


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.SelectionStart = TextBox2.Text.Length
        TextBox2.ScrollToCaret()
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

        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/me"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "PUT"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json As String = "{""statusMessage"":""" + TextBox6.Text + """}"
            Dim newString As String = json.Replace(vbCr, "\n").Replace(vbLf, "\n")
            streamWriter.Write(newString)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Status: Changed Status"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles B2.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Stopping = False
        Try
            BackgroundWorker1.RunWorkerAsync()
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles B3.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)

        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/current-summoner/icon"),
                            HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "PUT"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json As String = "{""profileIconId"":" + TextBox5.Text + "}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") + "] Icon: Success"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles B4.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Try
            BackgroundWorker2.RunWorkerAsync()
        Catch
        End Try
        Stopping = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles B5.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)

        If TextBox2.Text.Length > 2400 Then
            TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") + "] Loading: Cleared Text - Text limit reached!" +
                            vbCrLf
        End If

        Dim request =
                CType(
                    WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/current-summoner/summoner-profile"),
                    HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "POST"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json As String = "{""key"":""backgroundSkinId"",""value"":" + TextBox4.Text + "}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Background: Changed!"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
            My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Audio.Play(My.Resources._14, AudioPlayMode.Background)
        Stopping = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If count >= 6 Then
            count = 1
        Else
            count = count + 1
        End If

        If count.Equals(1) Then
            Button2.Hide()
            Button1.Hide()
            Me.Size = New Size(375, 345)
            B1.Show()
            TextBox4.Hide()
            TextBox6.Show()
            TextBox6.Location = New Point(18, 162)
            TextBox6.Size = New Size(340, 26)
            Label4.Location = New Point(18, 202)
            TrackBar2.Location = New Point(120, 202)
            Button4.Location = New Point(18, 237)
            TextBox2.Show()
            TextBox2.Size = New Size(340, 100)
            TextBox2.Location = New Point(18, 202)
            B5.Hide()
            TextBox6.Text = "Custom Status"
            TextBox2.Text = "Description: Give yourself a Custom Status that exceeds the char limit of Riot Games." &
                            vbCrLf & vbCrLf &
                            "Instructions: Write or Copy Paste a Status you want into the Text field above and Click the Top Button."
        ElseIf count.Equals(2) Then
            Me.Size = New Size(375, 500)
            B2.Show()
            TextBox1.Show()
            TextBox6.Hide()
            TrackBar2.Show()
            Label4.Show()
            Button4.Show()
            TextBox1.Location = New Point(18, 162)
            TextBox1.Size = New Size(340, 103)
            Label4.Location = New Point(18, 277)
            TrackBar2.Location = New Point(120, 277)
            Button4.Location = New Point(18, 312)
            TextBox2.Size = New Size(340, 91)
            TextBox2.Location = New Point(18, 366)
            TextBox2.Text = ""
            TextBox2.Text = "Description: Automatically Switches different Status Messages that you choose." & vbCrLf &
                            vbCrLf &
                            "Instructions: Each new line in the Text Field above will be a seperate Status Message."
            B1.Hide()
        ElseIf count.Equals(3) Then
            Me.Size = New Size(375, 345)
            TextBox2.Size = New Size(340, 100)
            TextBox2.Location = New Point(18, 202)
            TextBox2.Text = "Information: Icon Ids can be found at https://lolnames.gg/de/statistics/icons/"
            B3.Show()
            Button4.Hide()
            TrackBar2.Hide()
            Label4.Hide()
            TextBox1.Hide()
            TextBox5.Show()
            TextBox5.Text = "Custom Icon ID"
            TextBox5.Location = New Point(18, 162)
            TextBox5.Size = New Size(340, 26)
            B2.Hide()
            TextBox2.Text = "Description: Give yourself a Custom Icon that wouldn't be available." & vbCrLf & vbCrLf &
                            "Instructions: Choose a Custom Icon, use its ID to take it."
        ElseIf count.Equals(4) Then
            Me.Size = New Size(375, 500)
            B4.Show()
            TextBox5.Hide()
            TextBox1.Hide()
            TextBox3.Show()
            TrackBar2.Show()
            Label4.Show()
            Button4.Show()
            TextBox3.Location = New Point(18, 162)
            TextBox3.Size = New Size(340, 103)
            TextBox3.Text = "50" & vbCrLf & "51" & vbCrLf & "52" & vbCrLf & "53" & vbCrLf & "54" & vbCrLf & "55" &
                            vbCrLf & "56" & vbCrLf & "57" & vbCrLf & "58" & vbCrLf & "59" & vbCrLf & "60" & vbCrLf &
                            "61" & vbCrLf & "62" & vbCrLf & "63" & vbCrLf & "64" & vbCrLf & "65" & vbCrLf & "66" &
                            vbCrLf & "67" & vbCrLf & "68" & vbCrLf & "69" & vbCrLf & "70" & vbCrLf & "71" & vbCrLf &
                            "72" & vbCrLf & "73" & vbCrLf & "74"
            Label4.Location = New Point(18, 277)
            TrackBar2.Location = New Point(120, 277)
            Button4.Location = New Point(18, 312)
            TextBox2.Size = New Size(340, 91)
            TextBox2.Location = New Point(18, 366)
            TextBox2.Text = "Information: Icon Ids can be found at https://lolnames.gg/de/statistics/icons/"
            B3.Hide()
            TextBox2.Text = "Description: Automatically Switches different Icons." & vbCrLf & vbCrLf &
                            "Instructions: Each new line in the Text Field above will be a seperate Icon ID."
        ElseIf count.Equals(5) Then
            B5.Show()
            TextBox4.Show()
            TextBox3.Hide()
            TextBox2.Text = ""
            Me.Size = New Size(375, 345)
            TextBox3.Hide()
            TextBox4.Location = New Point(18, 162)
            TextBox4.Size = New Size(340, 26)
            Label4.Location = New Point(18, 202)
            TrackBar2.Location = New Point(120, 202)
            Button4.Location = New Point(18, 237)
            TextBox2.Show()
            TextBox2.Size = New Size(340, 100)
            TextBox2.Location = New Point(18, 202)

            TextBox4.Text = "Custom Background ID"
            B4.Hide()
            TextBox2.Text = "Description: Get any Custom Background you want without owning the Champion." & vbCrLf &
                            vbCrLf & "Instructions: You will need the Background ID for that."
        ElseIf count.Equals(6) Then
            Button2.Show()
            B5.Hide()
            TextBox4.Hide()
            TextBox2.Text = "Description: Appear as Offline." & vbCrLf & vbCrLf &
                            "Instructions: Just click the Button above!."
            Button1.Show()
        End If

        Label3.Text = count.ToString + "/6"
    End Sub


    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        If TrackBar2.Value = 2000 Then
            Label4.Text = "Slowest"
            Label4.ForeColor = Color.FromArgb(255, 255, 255, 255)
        ElseIf TrackBar2.Value >= 1000 And TrackBar2.Value <= 1999 Then
            Label4.Text = "Very Slow"
            Label4.ForeColor = Color.FromArgb(255, 255, 225, 225)
        ElseIf TrackBar2.Value >= 500 And TrackBar2.Value <= 999 Then
            Label4.Text = "Slow"
            Label4.ForeColor = Color.FromArgb(255, 255, 200, 200)
        ElseIf TrackBar2.Value >= 250 And TrackBar2.Value <= 499 Then
            Label4.Text = "Moderate"
            Label4.ForeColor = Color.FromArgb(255, 255, 150, 150)
        ElseIf TrackBar2.Value >= 150 And TrackBar2.Value <= 249 Then
            Label4.Text = "Fast"
            Label4.ForeColor = Color.FromArgb(255, 255, 100, 100)
        ElseIf TrackBar2.Value >= 51 And TrackBar2.Value <= 149 Then
            Label4.Text = "Very Fast"
            Label4.ForeColor = Color.FromArgb(255, 255, 50, 50)
        ElseIf TrackBar2.Value <= 50 Then
            Label4.Text = "Extreme"
            Label4.ForeColor = Color.Red
        End If
    End Sub

    Private Async Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        again:
        For Each sline In TextBox1.Lines

            Await Task.Delay(TrackBar2.Value)

            If Stopping = True Then
                Return
            End If

            If TextBox2.Text.Length > 2400 Then
                TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Loading: Cleared Text - Text limit reached!" + vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/me"), HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "PUT"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                Dim json As String = "{""statusMessage"":""" + sline + """}"
                Dim newString As String = json.Replace(vbCr, "\n").Replace(vbLf, "\n")
                streamWriter.Write(newString)
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Dim result = streamReader.ReadToEnd()
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                    "] Status: Changed Status"
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Something went wrong!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            End Try

        Next

        GoTo again
    End Sub

    Private Async Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        again:

        For Each sline2 In TextBox3.Lines

            Await Task.Delay(TrackBar2.Value)

            If Stopping = True Then
                Return
            End If

            If TextBox2.Text.Length > 2400 Then
                TextBox2.Text = "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Loading: Cleared Text - Text limit reached!" + vbCrLf
            End If

            Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-summoner/v1/current-summoner/icon"),
                                HttpWebRequest)
            request.PreAuthenticate = True
            request.ContentType = "application/json"
            request.Method = "PUT"
            request.Headers.Add("Authorization", "Basic " & auth)

            Using streamWriter = New StreamWriter(request.GetRequestStream())
                Dim json As String = "{""profileIconId"":" + sline2 + "}"
                Dim newString As String = json.Replace(vbCr, "\n").Replace(vbLf, "\n")
                streamWriter.Write(newString)
            End Using

            Try
                Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

                Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                    Dim result = streamReader.ReadToEnd()
                    TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                    "] Icon: Changed Icon"
                End Using
            Catch
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] ERROR: Something went wrong!"
                My.Computer.Audio.Play(My.Resources._12, AudioPlayMode.Background)
            End Try

        Next

        GoTo again
    End Sub

    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Play(My.Resources._13, AudioPlayMode.Background)
        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/me"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "PUT"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json = "{""availability"":""offline""}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Offline: You appear as Offline now!"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim request = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-chat/v1/me"), HttpWebRequest)
        request.PreAuthenticate = True
        request.ContentType = "application/json"
        request.Method = "PUT"
        request.Headers.Add("Authorization", "Basic " & auth)

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            Dim json = "{""availability"":""chat""}"
            streamWriter.Write(json)
        End Using

        Try
            Dim httpResponse = CType(request.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                                "] Offline: You appear as Offline now!"
            End Using
        Catch
            TextBox2.Text = TextBox2.Text + vbCrLf + "[" + DateTime.Now.ToString("hh:mm:ss") +
                            "] ERROR: Something went wrong!"
        End Try
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
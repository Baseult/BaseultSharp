Imports System.Drawing.Text
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Security
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class Form9
    Public xyz As Integer = 1
    Public pfc As New PrivateFontCollection
    Dim ReadOnly prun As Boolean = False
    Dim ReadOnly appPathx As String = My.Application.Info.DirectoryPath
    Dim ReadOnly r2 As New Random
    Public font1 As String = RandomString(r2)
    Public font2 As String = RandomString(r2)
    Private encryptedstring As String
    Private enc As UTF8Encoding
    Private encryptor As ICryptoTransform
    Dim ReadOnly currentversion As Double = 1.6
    Dim ReadOnly lock As DateTime = New DateTime(2021, 3, 5)
    Dim ReadOnly PrivateHWID As String = "FpXvK6yRKA7v2i10Hk0TSjeI4mXpqh2/rWI/tINT95Y="
    Public Aram As Boolean = False
    Public strFilename As String
    Public auth As String
    Public port As Integer
    Dim windowsversion As String
    Dim windows10 As Boolean = True
    Dim method As Integer
    Dim methodcount As Integer = 0
    Public LeagueVersion As String

    Public Shared Function GetCommandLine(process As Process) As String
        Using _
            searching =
                New ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " & process.Id)
            Using obj As ManagementObjectCollection = searching.[Get]()

                Return searching.Get().OfType (Of ManagementBaseObject)().FirstOrDefault()?("CommandLine")?.ToString()

            End Using
        End Using
    End Function

    Public Shared Function GetLastestLeagueUxProcess() As Process
        Return Process.GetProcessesByName("LeagueClientUx").OrderBy(Function(x) x.StartTime).Last()
    End Function

    Friend Function ProcessorId() As String
        Dim strProcessor As String = String.Empty
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        For Each info In search.Get()
            strProcessor = info("DeviceId").ToString()
        Next
        Dim sPlainText As String = strProcessorId.ToString & strProcessor.ToString
        If Not String.IsNullOrEmpty(sPlainText) Then
            Dim memoryStream = New MemoryStream()
            Dim cryptoStream = New CryptoStream(memoryStream, Me.encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(Me.enc.GetBytes(sPlainText), 0, sPlainText.Length)
            cryptoStream.FlushFinalBlock()
            encryptedstring = Convert.ToBase64String(memoryStream.ToArray())
            memoryStream.Close()
            cryptoStream.Close()
        End If
        Return encryptedstring
    End Function

    Public Function HWIDOfflineCHECK()
        Dim HWID As String = ProcessorId()
        If Not HWID = PrivateHWID Then
            Me.Hide()
            Me.Enabled = False
            Dim exepath3 As String = Assembly.GetEntryAssembly().Location
            Dim info = New ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & exepath3 & """")
            Dim info2 = New ProcessStartInfo("cmd.exe",
                                             "/C mshta javascript:alert(""Wrong HWID! This Programm will self destruct now!"");close();")
            info.WindowStyle = ProcessWindowStyle.Hidden
            info2.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info2).Dispose()
            Process.Start(info).Dispose()
            Environment.[Exit](0)
            End
        End If
    End Function

    Public Function Check() As Boolean
        Try
            Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
            Dim mainModule As ProcessModule = process.MainModule
            Dim text As String = If((mainModule IsNot Nothing), mainModule.FileName, Nothing)

            Dim text3 As String =
                    (If((text IsNot Nothing), text.Replace("LeagueClientUx.exe", String.Empty), Nothing)) & "lockfile"


            If My.Computer.FileSystem.FileExists(text3) Then
                Return True
            Else
                My.Computer.Audio.Play(My.Resources._17, AudioPlayMode.Background)
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim r As New Random
        Me.Text = RandomString(r)

        Dim serverCertificateValidationCallback As [Delegate] = ServicePointManager.ServerCertificateValidationCallback
        ServicePointManager.ServerCertificateValidationCallback =
            Function(se As Object, cert As X509Certificate, chain As X509Chain, sslerror As SslPolicyErrors) True
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        CheckForIllegalCrossThreadCalls = False

        Dim status = "undetected"

        Try
            Dim xD As String = (RuntimeInformation.OSDescription).ToString
            Dim xyz = CDbl(Val(Regex.Replace(xD, "[^\d,.]", "")))
            windowsversion = xD

            If xyz < 10 Then
                windows10 = False
            ElseIf xyz = 10 Then
                windows10 = True
            End If
        Catch

        End Try

        Dim Filename As String = RandomString(r)

        Dim location As String = Environment.GetCommandLineArgs()(0)
        Dim exepath2 = Assembly.GetEntryAssembly().Location
        Dim appName As String = Path.GetFileName(location)
        Dim appPath2 As String = My.Application.Info.DirectoryPath

        Dim KEY_128 As Byte() =
                {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95,
                 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Me.enc = New UTF8Encoding
        Me.encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)


        HWIDOfflineCHECK()


        If DateTime.Now > lock Then
            Me.Hide()
            Me.Enabled = False
            Dim exepath = Assembly.GetEntryAssembly().Location
            Dim info = New ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & exepath & """")
            Dim info2 = New ProcessStartInfo("cmd.exe",
                                             "/C mshta javascript:alert(""Each version of Baseult# works only for 10 days to protect it from redistribution. Please write Baseult#5684 on Discord to request a new version. The program remains completely free for you ^^. This program will self destruct now."");close();")
            info.WindowStyle = ProcessWindowStyle.Hidden
            info2.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info).Dispose()
            Process.Start(info2).Dispose()
            Environment.[Exit](0)
            End
        End If

        Dim p() As Process
        p = Process.GetProcessesByName("dnSpy")
        If p.Count > 0 Then
            Me.Hide()
            Me.Enabled = False
            Dim exepath = Assembly.GetEntryAssembly().Location
            Dim info = New ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & exepath & """")
            Dim info2 = New ProcessStartInfo("cmd.exe",
                                             "/C mshta javascript:alert(""Debugger Detected! This Programm will self destruct now!"");close();")
            info.WindowStyle = ProcessWindowStyle.Hidden
            info2.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info).Dispose()
            Process.Start(info2).Dispose()
            Environment.[Exit](0)
            End
        End If


        If Debugger.IsAttached Then
            Me.Hide()
            Me.Enabled = False
            Dim exepath = Assembly.GetEntryAssembly().Location
            Dim info = New ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000> Nul & Del """ & exepath & """")
            Dim info2 = New ProcessStartInfo("cmd.exe",
                                             "/C mshta javascript:alert(""Debugger Detected! This Programm will self destruct now!"");close();")
            info.WindowStyle = ProcessWindowStyle.Hidden
            info2.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info).Dispose()
            Process.Start(info2).Dispose()
            Environment.[Exit](0)
            End
        End If


        If appName.Contains("Baseult") Then
            File.Copy(exepath2, appPath2 & "\" & Filename & ".exe", True)
            Process.Start(appPath2 & "\" & Filename & ".exe")
            Dim info = New ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & exepath2 & """")
            info.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info).Dispose()
            End
        End If

        My.Computer.FileSystem.RenameFile(exepath2, RandomString(r) & ".exe")

        Try

            Dim onlineversion As Double
            Dim updatetext As String
            Dim updateactive As String
            Dim alltext As String
            Dim allactive As String
            Dim url As String


            Dim httpWebRequest = CType(WebRequest.Create("http://baseult.xyz/updatecheck.json"), HttpWebRequest)
            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim read = JObject.Parse(streamReader.ReadToEnd())
                onlineversion = read.Item("onlineversion")
                updatetext = read.Item("updatetext").ToString
                updateactive = read.Item("updateactive").ToString
                alltext = read.Item("alltext").ToString
                allactive = read.Item("allactive").ToString
                url = read.Item("url").ToString
                status = read.Item("status").ToString
            End Using

            If Not String.IsNullOrEmpty(onlineversion) Then
                If onlineversion > currentversion Then

                    If Not String.IsNullOrEmpty(updatetext) Then
                        MessageBox.Show(updatetext, "Baseult#")
                    End If

                    If Not String.IsNullOrEmpty(url) Then
                        Process.Start(url)
                    End If

                    If Not String.IsNullOrEmpty(updateactive) Then
                        If updateactive.Contains("false") Then
                            Me.Close()
                        End If
                    End If

                End If
            End If

            If Not String.IsNullOrEmpty(allactive) Then
                If allactive.Contains("false") Then
                    If Not String.IsNullOrEmpty(alltext) Then
                        MessageBox.Show(alltext, "Baseult#")
                    End If
                    Me.Close()
                End If
            End If

        Catch
        End Try


        Dim banstatus = ""

        Try
            Dim webClient As New WebClient
            banstatus = webClient.DownloadString("http://baseult.xyz/ban.txt")
        Catch
        End Try

        Try
            If status.Equals("detected") Then
                versiontext.BackColor = Color.Red
                versiontext.Text = "STATUS: DETECTED | VERSION: " & currentversion
            ElseIf Not String.IsNullOrEmpty(banstatus) Then
                versiontext.BackColor = Color.Orange
                versiontext.Text = "STATUS: UNVERIFIED BAN REPORTED | VERSION: " & currentversion
            Else
                versiontext.BackColor = Color.Lime
                versiontext.Text = "STATUS: UNDETECTED | VERSION: " & currentversion
            End If
        Catch
            versiontext.BackColor = Color.Orange
            versiontext.Text = "STATUS: UNKNOWN | VERSION: " & currentversion
        End Try


        Try
            Using fs = New FileStream(appPathx & "/" & font1 & ".ttf", FileMode.Create)
                fs.Write(My.Resources._10, 0, My.Resources._10.Length)
            End Using

            Using fs2 = New FileStream(appPathx & "/" & font2 & ".ttf", FileMode.Create)
                fs2.Write(My.Resources._9, 0, My.Resources._9.Length)
            End Using
        Catch
        End Try


        pfc.AddFontFile(appPathx & "/" & font1 & ".ttf")
        pfc.AddFontFile(appPathx & "/" & font2 & ".ttf")

        Label4.Font = New Font(pfc.Families(1), 16, FontStyle.Bold)
        Button4.Font = New Font(pfc.Families(1), 16, FontStyle.Bold)
        Label2.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        Button1.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        Button2.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        Button6.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        Button7.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        CheckBox1.Font = New Font(pfc.Families(0), 12, FontStyle.Bold)
        Label1.Font = New Font(pfc.Families(1), 11, FontStyle.Bold)
        versiontext.Font = New Font(pfc.Families(1), 9, FontStyle.Bold)
        Label3.Font = New Font(pfc.Families(0), 12, FontStyle.Regular)
        Button3.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)
        Button5.Font = New Font(pfc.Families(0), 13, FontStyle.Bold)

        My.Computer.Audio.Play(My.Resources._16, AudioPlayMode.Background)
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

    ReadOnly fd As OpenFileDialog = New OpenFileDialog()

    Dim alreadyopen = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If File.Exists("C:\Riot Games\League of Legends\LeagueClient.exe") Then
            Try
                strFilename = "C:\Riot Games\League of Legends\LeagueClient.exe"
            Catch
            End Try
        Else
            fd.Title = "Navigate to your LeagueClient.exe"
            fd.InitialDirectory = "C:\Riot Games\League of Legends"
            fd.Filter = "LeagueClient.exe|LeagueClient.exe"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFilename = fd.FileName
            Else
                Return
            End If
        End If

        Me.Size = New Size(375, 360)

        Label3.Show()
        Button7.Show()
        Button6.Show()
        Button2.Show()
        Button1.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Audio.Play(My.Resources._20, AudioPlayMode.Background)
        Try
            If Aram = True Then
                Process.Start(strFilename, "--allow-multiple-clients")
                Button2.Hide()
                Label2.Show()
                Timer1.Enabled = True
                Timer1.Start()
            Else
                Process.Start(strFilename)
                Button2.Hide()
                Label2.Show()
                Timer1.Enabled = True
                Timer1.Start()
            End If
        Catch
        End Try


        Me.Size = New Size(375, 200)
        CheckBox1.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Computer.Audio.Play(My.Resources._20, AudioPlayMode.WaitToComplete)
        Timer1.Stop()
        Timer2.Stop()
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.FromArgb(100, 50, 50)
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.FromArgb(39, 39, 39)
    End Sub

    Private Sub Form9_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If prun Then
            Me.Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Timer2.Stop()
        Timer1.Stop()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim p2() As Process
        p2 = Process.GetProcessesByName("LeagueClient")
        If p2.Count > 0 Then
            Dim p4() As Process
            p4 = Process.GetProcessesByName("LeagueClientUx")
            If p4.Count > 0 Then
                Try
                    Timer3.Enabled = True
                    Timer3.Start()
                    Timer1.Stop()
                Catch
                End Try
            End If
        End If
    End Sub

    Public Enum ThreadAccess As Integer
        TERMINATE = (&H1)
        SUSPEND_RESUME = (&H2)
        GET_CONTEXT = (&H8)
        SET_CONTEXT = (&H10)
        SET_INFORMATION = (&H20)
        QUERY_INFORMATION = (&H40)
        SET_THREAD_TOKEN = (&H80)
        IMPERSONATE = (&H100)
        DIRECT_IMPERSONATION = (&H200)
    End Enum

    Public Declare Function OpenThread Lib "kernel32.dll"(dwDesiredAccess As ThreadAccess, bInheritHandle As Boolean,
                                                          dwThreadId As UInteger) As IntPtr
    Public Declare Function SuspendThread Lib "kernel32.dll"(hThread As IntPtr) As UInteger
    Public Declare Function ResumeThread Lib "kernel32.dll"(hThread As IntPtr) As UInteger
    Public Declare Function CloseHandle Lib "kernel32.dll"(hHandle As IntPtr) As Boolean

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim game As Process() = Process.GetProcessesByName("LeagueClientUxRender")
        Try
            For Each t As ProcessThread In game(0).Threads
                Try
                    Dim th As IntPtr
                    th = OpenThread(ThreadAccess.SUSPEND_RESUME, False, t.Id)
                    If th <> IntPtr.Zero Then
                        If killed = False Then
                            killed = True
                            Process.GetProcessesByName("LeagueClientUxRender")(0).Kill()
                            Process.GetProcessesByName("LeagueClientUxRender")(1).Kill()
                        End If
                        SuspendThread(th)
                        CloseHandle(th)
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
    End Sub


    Dim killed As Boolean = False

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        If CheckBox1.Checked Then
            Dim result As DialogResult =
                    MessageBox.Show(
                        "Experimental: Hides your League of Legends Client after Loggin." & vbCrLf & vbCrLf &
                        "Press 'OK' after you are logged in and your League Client is visible!" & vbCrLf & vbCrLf &
                        "Information: This may freezes the Baseult# Program for some Seconds.", "Baseult#",
                        MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then
                CheckBox1.Checked = False
                Return
            ElseIf result = DialogResult.OK Then
                Timer2.Enabled = True
                Timer2.Start()
            End If
        Else
            Timer2.Stop()
        End If
    End Sub

    Private Sub Form9_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing


        Me.Hide()

        Timer1.Stop()
        Timer2.Stop()

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
        Try
            Form10.BackgroundWorker1.CancelAsync()
        Catch
        End Try


        Try
            Dim info = New ProcessStartInfo("cmd.exe",
                                            "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & appPathx & "\" & font1 &
                                            ".ttf" & """")
            Dim info2 = New ProcessStartInfo("cmd.exe",
                                             "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & appPathx & "\" & font2 &
                                             ".ttf" & """")
            info.WindowStyle = ProcessWindowStyle.Hidden
            info2.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info).Dispose()
            Process.Start(info2).Dispose()
            Environment.[Exit](0)
        Catch
        End Try
    End Sub


    Public Function GetToken1() As Boolean
        Dim result As Boolean
        Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
        Try
            Dim mainModule As ProcessModule = process.MainModule
            Dim text As String = If((mainModule IsNot Nothing), mainModule.FileName, Nothing)

            Dim text2 As String =
                    (If((text IsNot Nothing), text.Split(New String() {"RADS"}, StringSplitOptions.None)(0), Nothing)) &
                    "lockfile"
            Dim text3 As String =
                    (If((text IsNot Nothing), text.Replace("LeagueClientUx.exe", String.Empty), Nothing)) & "lockfile"
            Dim flag2 = False

            If My.Computer.FileSystem.FileExists(text3) Then
                flag2 = True
            Else
                Return ""
            End If

            Dim text5 As String
            Using _
                fileStream =
                    New FileStream(If(flag2, text3, text2), FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using streamReader = New StreamReader(fileStream, Encoding.[Default])
                    Dim text4 As String = streamReader.ReadToEnd()
                    Dim array As String() = text4.Split(New Char() {":"c})
                    port = Integer.Parse(array(2))
                    text5 = array(3)
                End Using
            End Using
            auth = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + text5))
            result = True
        Catch
            result = False
        End Try

        Return result
    End Function

    Private Function GetLeagueVersion() As Boolean


        Dim serverCertificateValidationCallback As [Delegate] = ServicePointManager.ServerCertificateValidationCallback
        ServicePointManager.ServerCertificateValidationCallback =
            Function(se As Object, cert As X509Certificate, chain As X509Chain, sslerror As SslPolicyErrors) True
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim result As Boolean
        Dim httpWebRequest = CType(WebRequest.Create("https://127.0.0.1:" & port & "/system/v1/builds"), HttpWebRequest)
        httpWebRequest.PreAuthenticate = True
        httpWebRequest.Headers.Add("Authorization", "Basic " & auth)

        Try
            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                LeagueVersion = JObject.Parse(streamReader.ReadToEnd())("branch").ToString.Replace("Releases/", "")
            End Using
            result = True
        Catch
            If method = 2 Then
                If methodcount >= 10 Then
                    Try
                        Timer3.Stop()
                    Catch
                    End Try
                    MessageBox.Show(
                        "Okay I see.. something does not work here how it should.. Now try the following:" & vbCrLf &
                        vbCrLf &
                        "Close Baseult# and League of Legends -> Start your League of Legends manually -> Login -> After you logged in and have your League Client open just close it again -> Start Baseult# and try again." &
                        vbCrLf & vbCrLf &
                        "If that doesn't work it probably means your System is running on Windows 7 or something that is not Windows 10 which basically means I won't be able to fix that issue for you. Baseult# has been optimized for Windows 10 and there won't be any other option for you than upgrading your Windows to Windows 10 if that issue doesn't go away.. Im sorry.",
                        "Baseult#", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                Else
                    methodcount = methodcount + 1
                End If
            End If
            result = False
        End Try
        Return result
    End Function


    Private Sub CheckforBan()

        Dim serverCertificateValidationCallback As [Delegate] = ServicePointManager.ServerCertificateValidationCallback
        ServicePointManager.ServerCertificateValidationCallback =
            Function(se As Object, cert As X509Certificate, chain As X509Chain, sslerror As SslPolicyErrors) True
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim Computername As String = Environment.UserName
        Dim Banmessage As String
        Dim Banchecking = CType(WebRequest.Create("https://127.0.0.1:" & port & "/lol-login/v1/session"), HttpWebRequest)
        Banchecking.PreAuthenticate = True
        Banchecking.Headers.Add("Authorization", "Basic " & auth)
        Try
            Dim httpResponse = CType(Banchecking.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim St As String = streamReader.ReadToEnd()

                Dim pFrom As Integer = St.IndexOf("""error"":{""") + """error"":{""".Length
                Dim pTo As Integer = St.LastIndexOf("},""gasToken")
                Banmessage =
                    St.Substring(pFrom, pTo - pFrom).Replace("{", "").Replace("}", "").Replace("\r", "").Replace("\n",
                                                                                                                 "").
                        Replace("t\", "").Replace("\", "")
            End Using

            If Not String.IsNullOrEmpty(Banmessage) Then
                Timer3.Stop()
                Dim testMsg As Integer
                testMsg =
                    MsgBox(
                        "Baseult# Ban detection found an active ban on your Account." & vbCrLf & vbCrLf &
                        "For the safety of other Baseult# users, Please do the following:" & vbCrLf & vbCrLf &
                        "If you believe you were banned because of Baseult#, click Yes." & vbCrLf & vbCrLf &
                        "If you have been banned for AFK, Feeding, Verbal Abuse, Scripting or something else not Baseult# related, click NO." &
                        vbCrLf & vbCrLf & "Please be honest! Unnecessary false reports mean unnecessary Work for me Dx",
                        vbYesNo + vbExclamation, "Baseult# - Ban Detection")
                If testMsg = vbYes Then
                    Dim userMsg As String
                    userMsg =
                        InputBox(
                            "Please write the Ban Reason which you can see at your League Client into the Text field below!",
                            "Baseult# - Ban Detection", "Enter Ban-Reason here", 500, 700)
                    If userMsg <> "" Then

                        Dim request = CType(WebRequest.Create("http://baseult.xyz/ban.php"), HttpWebRequest)
                        request.Method = "POST"

                        Using streamWriter = New StreamWriter(request.GetRequestStream())
                            Dim json As String = Computername & " - " & Banmessage & " - Reason: " & userMsg
                            streamWriter.Write(json)
                        End Using

                        Try
                            Dim Sendban = CType(request.GetResponse(), HttpWebResponse)
                            Using streamReader = New StreamReader(Sendban.GetResponseStream())
                            End Using
                        Catch
                        End Try

                    Else
                        Dim request = CType(WebRequest.Create("http://baseult.xyz/noban.php"), HttpWebRequest)
                        request.Method = "POST"

                        Using streamWriter = New StreamWriter(request.GetRequestStream())
                            Dim json As String = Computername & " - " & Banmessage
                            streamWriter.Write(json)
                        End Using

                        Try
                            Dim Sendban = CType(request.GetResponse(), HttpWebResponse)
                            Using streamReader = New StreamReader(Sendban.GetResponseStream())
                            End Using
                        Catch
                        End Try
                    End If

                ElseIf testMsg = vbNo Then
                    Dim request = CType(WebRequest.Create("http://baseult.xyz/noban.php"), HttpWebRequest)
                    request.Method = "POST"

                    Using streamWriter = New StreamWriter(request.GetRequestStream())
                        Dim json As String = Computername & " - " & Banmessage
                        streamWriter.Write(json)
                    End Using

                    Try
                        Dim Sendban = CType(request.GetResponse(), HttpWebResponse)
                        Using streamReader = New StreamReader(Sendban.GetResponseStream())
                        End Using
                    Catch
                    End Try
                End If
            End If
        Catch
        End Try
    End Sub

    Private Function GetToken2() As Boolean
        Dim result As Boolean
        Dim process As Process = Process.GetProcessesByName("LeagueClientUx").FirstOrDefault
        Try
            Dim gameProcess = GetLastestLeagueUxProcess()
            Dim gameArgs =
                    GetCommandLine(Process.GetProcessesByName("LeagueClientUx").OrderBy(Function(x) x.StartTime).Last())
            Dim password = Regex.Match(gameArgs, "(""--remoting-auth-token=)([^""]*)("")").Groups(2).Value
            port = Integer.Parse(Regex.Match(gameArgs, "(""--app-port=)([^""]*)("")").Groups(2).Value)
            Dim authBytes As Byte() = Encoding.UTF8.GetBytes($"riot:{password}")
            Dim auth2 = Convert.ToBase64String(authBytes)
            auth = auth2.ToString
            If String.IsNullOrEmpty(auth) Then
                result = False
            Else
                result = True
            End If
        Catch
            result = False
        End Try
        Return result
    End Function

    Private Sub CheckVersion()
        If LeagueVersion.Equals("11.4") Then
            Label2.Enabled = False
            Label2.Hide()
            Button4.Enabled = True
            Button4.Visible = True
            Try
                Timer3.Stop()
            Catch
            End Try
        ElseIf LeagueVersion.Equals("11.3") Then
            If Aram = True Then
                Label2.Enabled = False
                Label2.Hide()
                Button4.Enabled = True
                Button4.Visible = True
                Try
                    Timer3.Stop()
                Catch
                End Try
            Else
                Me.Hide()
                Me.Enabled = False
                Dim exepath3 = Assembly.GetEntryAssembly().Location
                Dim info = New ProcessStartInfo("cmd.exe",
                                                "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & exepath3 & """")
                Dim info2 = New ProcessStartInfo("cmd.exe",
                                                 "/C mshta javascript:alert(""League of Legends had an Update. For Accountsafety Reasons this Program will disable itself after each Patch. Look at Baseults Discord for the new Update!"");close();")
                info.WindowStyle = ProcessWindowStyle.Hidden
                info2.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(info2).Dispose()
                Process.Start(info).Dispose()
                Environment.[Exit](0)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        Try
            Timer1.Stop()
        Catch
        End Try

        If GetToken1() = False Then
            If GetToken2() = False Then
                Return
            Else
                method = 2
            End If
        Else
            method = 1
        End If

        If GetLeagueVersion() = False Then
            Return
        End If

        Try
            CheckforBan()
        Catch
        End Try

        Try
            CheckVersion()
        Catch
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        xyz = 1
        CheckBox1.Hide()
        Label3.Hide()
        Button6.Hide()
        Button5.Show()
        Button3.Show()
        Button2.Hide()
        Me.Size = New Size(375, 175)
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        My.Computer.Audio.Play(My.Resources._36, AudioPlayMode.Background)
        xyz = 9
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Button3.Hide()
        Button5.Hide()
        Button2.Show()
        CheckBox1.Show()
        Me.Size = New Size(375, 200)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)

        If windows10 = False Then
            MessageBox.Show(
                "Baseult# detected that your Windows is below Version 10!" & vbCrLf &
                "The Detection says your Windows Version is:" & vbCrLf & windowsversion & "." & vbCrLf & vbCrLf &
                "Aram Boost has been optimized for Windows 10 Users and might will not work on your System. If Baseult# keeps telling you to 'login to your League Client' then it does not work and there will not be any other workaroung than Upgrading your Windows to Version 10!",
                "Baseult#", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Aram = True
        xyz = 2

        Dim p2() As Process
        p2 = Process.GetProcessesByName("LeagueClient")
        Dim p3() As Process
        p3 = Process.GetProcessesByName("RiotClientUx")
        Dim p4() As Process
        p4 = Process.GetProcessesByName("LeagueClientUx")
        Dim p5() As Process
        p5 = Process.GetProcessesByName("LeagueClientUxRender")
        Dim p6() As Process
        p6 = Process.GetProcessesByName("LeagueCrashHandler")
        Dim p7() As Process
        p7 = Process.GetProcessesByName("RiotClientServices")

        If p2.Count > 0 Or p3.Count > 0 Or p4.Count > 0 Then
            MessageBox.Show(
                "League of Legends has to be closed first!" & vbCrLf & "I will close it for you." & vbCrLf & vbCrLf &
                "Press OK as soon as you are Ready.", "Baseult#")
            Try
                Process.GetProcessesByName("LeagueClient")(0).Kill()
            Catch
            End Try
            Try
                Process.GetProcessesByName("RiotClientUx")(0).Kill()
            Catch
            End Try
            Try
                Process.GetProcessesByName("LeagueClientUx")(0).Kill()
            Catch
            End Try
            Try
                Process.GetProcessesByName("LeagueClientUxRender")(0).Kill()
            Catch
            End Try
            Try
                Process.GetProcessesByName("LeagueCrashHandler")(0).Kill()
            Catch
            End Try
            Try
                Process.GetProcessesByName("RiotClientServices")(0).Kill()
            Catch
            End Try

            Thread.Sleep(2000)
        End If

        Button3.Hide()
        Button5.Hide()
        Button2.Show()
        CheckBox1.Show()


        Me.Size = New Size(375, 200)
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Computer.Audio.Play(My.Resources._21, AudioPlayMode.Background)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class


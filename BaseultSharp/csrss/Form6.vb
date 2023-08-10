Imports System.ComponentModel
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Font = New Font(Form9.pfc.Families(1), 16, FontStyle.Bold)

        Dim r As New Random
        Me.Text = RandomString(r)
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Dim ReadOnly savein As String = Form9.strFilename.Replace("\LeagueClient.exe", "")

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

    Private Sub Form6_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Form9.xyz = 1 Then
            speech()
        ElseIf Form9.xyz = 2 Then

            My.Computer.Audio.Play(My.Resources._37, AudioPlayMode.BackgroundLoop)
            WC.DownloadFileAsync(
                New Uri(
                    "https://cdn.filesend.jp/private/K4XN5dLdxFgZlXrpgesEeFDI7cqJsHLQ2A18a9iDI7Q4Gw2fWZgJ7MrDInoogyB4/1"),
                savein & "\Plugins\plugin-manifest.json") 'Champion
        Else
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Dim WithEvents WC As New WebClient
    Dim WithEvents WC2 As New WebClient
    Dim WithEvents WC3 As New WebClient
    Dim WithEvents WC4 As New WebClient

    Private Sub WC_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) _
        Handles WC.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Dim downloaded As String = (e.BytesReceived/1000000).ToString
        Dim havetodownload As String = (e.TotalBytesToReceive/1000000).ToString
        Me.Label2.Text = "Downloading File 1/4: " + downloaded & " / " & havetodownload & " MB"
    End Sub

    Private Sub WC2_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) _
        Handles WC2.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Dim downloaded As String = (e.BytesReceived/1000000).ToString
        Dim havetodownload As String = (e.TotalBytesToReceive/1000000).ToString
        Me.Label2.Text = "Downloading File 2/4: " + downloaded & " / " & havetodownload & " MB"
    End Sub

    Private Sub WC3_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) _
        Handles WC3.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Dim downloaded As String = (e.BytesReceived/1000000).ToString
        Dim havetodownload As String = (e.TotalBytesToReceive/1000000).ToString
        Me.Label2.Text = "Downloading File 3/4: " + downloaded & " / " & havetodownload & " MB"
    End Sub

    Private Sub WC4_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) _
        Handles WC4.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Dim downloaded As String = (e.BytesReceived/1000000).ToString
        Dim havetodownload As String = (e.TotalBytesToReceive/1000000).ToString
        Me.Label2.Text = "Downloading File 4/4: " + downloaded & " / " & havetodownload & " MB"
    End Sub

    Private Sub WC_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        WC2.DownloadFileAsync(
            New Uri("https://cdn.filesend.jp/private/hH5fUdOeJU_9lmlfb5UXy6RycuQvj9KDmih10VonhoQbsilDnZzAeFw8DWh3S1FZ/2"),
            savein & "\Plugins\rcp-fe-lol-champ-select\assets.wad") 'manifest
    End Sub

    Private Sub WC2_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles WC2.DownloadFileCompleted
        WC3.DownloadFileAsync(
            New Uri("https://cdn.filesend.jp/private/kALHQ4ObXXsfK1uCHsiNOal9CJqsiEL7RBN8PirPdLYtm2E9R_2cRgPLakCbAOvJ/3"),
            savein & "\LeagueClient.exe")
    End Sub

    Private Sub WC3_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles WC3.DownloadFileCompleted
        WC4.DownloadFileAsync(
            New Uri("https://cdn.filesend.jp/private/qOA8YrQ-jyNjYIBn9t2tsnIhnZ-mzrarZhoZBsUsGmqJ2ihVJ-Y2uQ2QCHReTKtY/4"),
            savein & "\LeagueClientUx.exe")
    End Sub

    Private Sub WC4_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles WC4.DownloadFileCompleted
        My.Computer.Audio.Stop()
        Me.Close()
    End Sub


    Private Async Sub speech()
        Me.ProgressBar1.Value = 0
        Await Task.Delay(500)
        My.Computer.Audio.Play(My.Resources._35, AudioPlayMode.Background)
        Me.ProgressBar1.Value = 10
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 20
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 30
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 40
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 50
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 60
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 70
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 80
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 90
        Thread.Sleep(650)
        Me.ProgressBar1.Value = 100
        Thread.Sleep(650)
        Me.Close()
    End Sub

    'Totally Useless Form I know but just because it looks cool

    Private Async Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Me.ProgressBar1.Value = 0

        Me.ProgressBar1.Value = 100

        Await Task.Delay(1000)

        Me.Close()
    End Sub

    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Form1.Stringform = 2 Then
            Form2.Show()
        ElseIf Form1.Stringform = 3 Then
            Form3.Show()
        ElseIf Form1.Stringform = 4 Then
            Form4.Show()
        ElseIf Form1.Stringform = 5 Then
            Form5.Show()
        ElseIf Form1.Stringform = 7 Then
            Form7.Show()
        ElseIf Form1.Stringform = 8 Then
            Form8.Show()
        ElseIf Form1.Stringform = 10 Then
            Form10.Show()
        ElseIf Form9.xyz = 1 Or Form9.xyz = 2 Then
            Form9.xyz = 0
            Form9.Show()
        ElseIf Form1.Stringform = 11 Then
            Form11.Show()
        End If
    End Sub
End Class
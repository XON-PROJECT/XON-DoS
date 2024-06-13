Imports System.Net
Imports System.IO
Imports System.Diagnostics
Imports System.Threading.Tasks

Class MainWindow

    Private Async Sub ExecuteButton_Click(sender As Object, e As RoutedEventArgs)
        executeButton.Visibility = Visibility.Collapsed
        statusText.Text = "Download..."
        statusText.Visibility = Visibility.Visible

        Dim client As New WebClient()
        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "XON-LOADER")
        Dim filePath As String = Path.Combine(tempPath, "DoS.exe")

        If Not Directory.Exists(tempPath) Then
            Directory.CreateDirectory(tempPath)
        End If

        AddHandler client.DownloadFileCompleted, AddressOf Client_DownloadFileCompleted

        Await client.DownloadFileTaskAsync(New Uri("https://github.com/XON-PROJECT/XON-DoS/releases/download/DoS/DoS.exe"), filePath)
    End Sub

    Private Async Sub Client_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        statusText.Text = "Completed!"

        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "XON-LOADER")
        Dim filePath As String = Path.Combine(tempPath, "DoS.exe")
        Process.Start(filePath)

        Await Task.Delay(2000)
        Me.Close()
    End Sub

End Class
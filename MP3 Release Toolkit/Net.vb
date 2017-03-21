Public Class Net
    Public Shared Function Getnrun_srr(i As String)

        Dim FolderName = New System.IO.DirectoryInfo(i).Name
        Threading.Thread.Sleep(3000)
        Dim p As New Process()
        Dim workdir As String = My.Application.Info.DirectoryPath & "\wget.exe"
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\wget.exe", My.Resources.wget)
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\libintl.dll", My.Resources.libintl3)
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\libiconv2.dll", My.Resources.libiconv2)
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\libeay32.dll", My.Resources.libeay32)
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\libssl32.dll", My.Resources.libssl32)
        p.StartInfo.FileName = workdir
        Dim cmdline2 As String = "--no-check-certificate https://www.srrdb.com/download/srr/" & FolderName & "/" & FolderName & ".srr"

        p.StartInfo.Arguments = cmdline2
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.CreateNoWindow = True
        Dim sOutput As String
        p.Start()
        'sOutput = p.StandardOutput.ReadToEnd()
        sOutput = p.StandardError.ReadToEnd()
        p.WaitForExit()
        p.Close()

        If frm_Srrdb.cb_Logwget.Checked = True Then
            FileOpen(1, My.Application.Info.DirectoryPath & "\wgetlog.txt", OpenMode.Append)
            Write(1, sOutput)
            FileClose(1)
        End If

        If FileLen(FolderName & ".srr") = 31 Then
            MessageBox.Show("srrdb daily limit reached")
            'Application.Exit()
            Exit Function
        End If

        If FileLen(FolderName & ".srr") = 34 Then
            Exit Function
        End If

        'Dim curFile As String = FolderName & ".srr"
        'Console.WriteLine(If(System.IO.File.Exists(curFile), "File exists.", "File does not exist."))
        FileCopy(FolderName & ".srr", i & FolderName & ".srr")


        Dim q As New Process()
        q.StartInfo.FileName = "retag.exe"
        q.StartInfo.Arguments = "-y " & FolderName & ".srr"
        q.StartInfo.WorkingDirectory = i
        q.StartInfo.UseShellExecute = False
        q.StartInfo.RedirectStandardOutput = True
        q.StartInfo.CreateNoWindow = True
        Dim sOutput2 As String
        q.Start()
        sOutput2 = q.StandardOutput.ReadToEnd()
        q.WaitForExit()
        q.Close()

        If frm_Srrdb.cb_logretag.Checked = True Then
            FileOpen(2, My.Application.Info.DirectoryPath & "\retaglog.txt", OpenMode.Append)
            Write(2, sOutput2)
            FileClose(2)
        End If

    End Function
End Class

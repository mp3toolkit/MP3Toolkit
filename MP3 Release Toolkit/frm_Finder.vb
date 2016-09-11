Imports System.IO
Imports System.Diagnostics
Public Class frm_Finder
    Private Sub btn_mp3_root_dir_Click(sender As Object, e As EventArgs) Handles btn_mp3_root_dir.Click
        Using FBD As New FolderBrowserDialog
            If FBD.ShowDialog() = DialogResult.OK Then
                mp3_root_dir.Text = FBD.SelectedPath
                btn_result_dir.Enabled = True
                btn_mis_m3u.Enabled = True
                btn_mis_sfv.Enabled = True
                btn_mis_nfo.Enabled = True
                btn_find_renames.Enabled = True
            End If
        End Using
    End Sub
    Private Sub btn_result_dir_Click(sender As Object, e As EventArgs) Handles btn_result_dir.Click
        Using FBD As New FolderBrowserDialog
            If FBD.ShowDialog = DialogResult.OK Then TextBox2.Text = FBD.SelectedPath
        End Using
    End Sub
    Sub ForEachSubPath(StartFolder As String)
        Dim ssfvName As String
        Dim sOriFiFo As String
        Dim FQFileName As String
        Dim FolderName As String
        Dim ReleaseNameOriginal As String
        Dim strCheckLine As String
        Dim Dirs As New ArrayList
        Dim DirsNo As Integer
        Dim i As Integer
        Dim F As Integer
        Dim ooPos As Integer
        Dim editflag As Integer
        Dim Gac As Integer

        'Eventually add Backslash
        If reRight(StartFolder, 1) <> "\" Then StartFolder = StartFolder & "\"

        'List all files in the folder
        ssfvName = Dir(StartFolder & "*.sfv")

        While Len(ssfvName) > 0
            FQFileName = StartFolder & ssfvName                               'FQFilename contains full path & filename

            'ssfvName - ".sfv"
            sOriFiFo = reLeft(ssfvName, ssfvName.Length - 4)

            'check is nfo starts with 00* - If yes try reconstructing Releasename
            If Mid(ssfvName, 1, 3) = "00-" Or Mid(ssfvName, 1, 3) = "00_" Or Mid(ssfvName, 1, 3) = "00." Then sOriFiFo = reRight(sOriFiFo, ssfvName.Length - 7)
            If Mid(ssfvName, 1, 5) = "00_-_" Then sOriFiFo = reRight(sOriFiFo, ssfvName.Length - 9)
            If Mid(ssfvName, 1, 3) = "000" Then sOriFiFo = reRight(sOriFiFo, ssfvName.Length - 8)

            'check for rare Artist-00-Album
            ooPos = InStr(1, ssfvName, "-00-", vbTextCompare)
            If ooPos > 0 Then sOriFiFo = reLeft(sOriFiFo, ooPos) & reRight(sOriFiFo, sOriFiFo.Length - ooPos - 3)

            'check for old VA
            If StrComp(Mid(sOriFiFo, 1, 15), "Various_Artists", vbTextCompare) = 0 Then sOriFiFo = Replace(sOriFiFo, "Various_Artists", "VA", 1, 1, vbTextCompare)

            'check if nfo is anonymized (dropping of grp name) - if yes add GRP
            If StrComp(reRight(Vars.OrdnerName, 4), reRight(sOriFiFo, 4), 1) <> 0 Then sOriFiFo = sOriFiFo & "-" & reRight(Vars.OrdnerName, Vars.OrdnerName.Length - InStrRev(Vars.OrdnerName, "-"))

            'Compare Foldername with reconstructed one
            editflag = Vars.OrdnerName.Length - sOriFiFo.Length

            'editflag 0 = should be ok;
            'editflag 3 = back in the days the language was often added to the Dirname manually but the nfo name lacks it
            If editflag = 0 Or editflag > 20 Or editflag < -20 And StrComp(Vars.OrdnerName, sOriFiFo, CompareMethod.Text) = 0 Then GoTo Weiter
            If editflag = 3 And (InStr(1, Vars.OrdnerName, "-DE-", vbTextCompare) <> 0) And (InStr(1, sOriFiFo, "-DE-", vbTextCompare) = 0) Then GoTo Weiter
            If editflag = 7 And (InStr(1, Vars.OrdnerName, "-Retail-", vbTextCompare) <> 0) And (InStr(1, sOriFiFo, "-Retail-", vbTextCompare) = 0) Then GoTo Weiter

            'Check for "int" - similar to above
            If StrComp(reRight(Vars.OrdnerName, 3), "int", vbTextCompare) = 0 Then GoTo Weiter

            If InStr(ssfvName, "_-_") > 0 Then
                If InStr(Vars.OrdnerName, "_-_") > 0 Then GoTo Kontroll1
                ReleaseNameOriginal = Vars.OrdnerName
                If InStr(Vars.OrdnerName, "--") <> 0 Then ReleaseNameOriginal = Replace(Vars.OrdnerName, "--", "_-_", 1, 1, vbTextCompare) Else ReleaseNameOriginal = Replace(Vars.OrdnerName, "-", "_-_", 1, 1, vbTextCompare)

                F = FreeFile()
                FileOpen(F, TextBox2.Text & "\rename.bat", OpenMode.Append)
                PrintLine(F, "REM " & ssfvName)
                PrintLine(F, "Ren " & Chr(34) & reLeft(StartFolder, StartFolder.Length - 1) & Chr(34) & " " & Chr(34) & ReleaseNameOriginal & Chr(34))
                PrintLine(F, " ")
                FileClose()
                ReleaseNameOriginal = ""
                GoTo Weiter
            End If

            If InStr(ssfvName, "--") > 0 Then
                If InStr(Vars.OrdnerName, "--") > 0 Then GoTo Kontroll2

                ReleaseNameOriginal = Replace(Vars.OrdnerName, "_-_", "--", 1, 1, vbTextCompare)
                If StrComp(ReleaseNameOriginal, Vars.OrdnerName, vbTextCompare) = 0 Then GoTo Kontroll3

                F = FreeFile()
                FileOpen(F, TextBox2.Text & "\rename.bat", OpenMode.Append)
                PrintLine(F, "REM " & ssfvName)
                PrintLine(F, "Ren " & Chr(34) & reLeft(StartFolder, StartFolder.Length - 1) & Chr(34) & " " & Chr(34) & ReleaseNameOriginal & Chr(34))
                PrintLine(F, " ")
                FileClose()
                ReleaseNameOriginal = ""
                GoTo Weiter

            Else
                ReleaseNameOriginal = Replace(Vars.OrdnerName, "_-_", "-", 1, 1, vbTextCompare)
                If StrComp(ReleaseNameOriginal, Vars.OrdnerName, vbTextCompare) = 0 Then GoTo Kontroll4

                F = FreeFile()
                FileOpen(F, TextBox2.Text & "\rename.bat", OpenMode.Append)
                PrintLine(F, "REM " & ssfvName)
                PrintLine(F, "Ren " & Chr(34) & reLeft(StartFolder, StartFolder.Length - 1) & Chr(34) & " " & Chr(34) & ReleaseNameOriginal & Chr(34))
                PrintLine(F, " ")
                FileClose()
                ReleaseNameOriginal = ""
                GoTo Weiter

Kontroll1:
                F = F
Kontroll2:
                F = F
Kontroll3:
                F = F
Kontroll4:
                F = FreeFile()

                strCheckLine = ssfvName & StrDup(120, " ")
                Mid(strCheckLine, 110, Vars.OrdnerName.Length) = Vars.OrdnerName
                FileOpen(F, TextBox2.Text & "\2check.txt", OpenMode.Append)
                PrintLine(F, strCheckLine)
                PrintLine(F, " ")
                FileClose()
            End If

Weiter:

            ssfvName = Dir()
        End While

        'Read all Subdirs into an array
        DirsNo = 0
        ssfvName = Dir(StartFolder, vbDirectory)
        While Len(ssfvName) > 0
            If GetAttr(StartFolder & "\" & ssfvName) And vbDirectory = vbDirectory Then
                Gac = GetAttr(StartFolder & "\" & ssfvName)
                If Gac <> 16 And Gac <> 8208 And Gac <> 8240 And Gac <> 48 Then GoTo Nodir
                If ssfvName <> "." And ssfvName <> ".." And ssfvName <> "2DO" And ssfvName <> "_Ex-Rel" And ssfvName <> "_Incomplete" And ssfvName <> "_Work" And ssfvName <> "-=Incomplete=-" And ssfvName <> "-=Req=-" And ssfvName <> "-=Tapez=-" Then
                    DirsNo = DirsNo + 1
                    Dirs.Add(ssfvName)
                Else
                End If
            Else
            End If
Nodir:
            ssfvName = Dir()
        End While

        For i = 0 To DirsNo - 1
            FolderName = StartFolder & Dirs(i) & "\"
            Vars.OrdnerName = Dirs(i)

            ForEachSubPath(FolderName)

        Next

    End Sub

    ' Left in VB.NET nachgebaut
    Public Function reLeft(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(0, nLen))
    End Function

    ' Right in VB.NET nachgebaut
    Public Function reRight(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(sText.Length - nLen))
    End Function


    Private Sub btn_mis_m3u_Click(sender As Object, e As EventArgs) Handles btn_mis_m3u.Click
        Dim F As Integer
        btn_mp3_root_dir.Enabled = False
        btn_result_dir.Enabled = False
        btn_mis_sfv.Enabled = False
        btn_mis_nfo.Enabled = False
        btn_find_renames.Enabled = False
        If System.IO.File.Exists(TextBox2.Text & "\nom3u.txt") = True Then System.IO.File.Delete(TextBox2.Text & "\nom3u.txt")
        ListBox1.Items.Clear()
        F = FreeFile()
        FileOpen(F, TextBox2.Text & "\_m3usearch.bat", OpenMode.Output)
        PrintLine(F, "@ECHO OFF")
        PrintLine(F, "setlocal enabledelayedexpansion")
        PrintLine(F, "set nocopyflag=0")
        PrintLine(F, "for /f %%a in ('dir " & Chr(34) & mp3_root_dir.Text & Chr(34) & " /b /s /ad') do (")
        PrintLine(F, " set nocopyflag=0")
        PrintLine(F, " >nul 2>&1 dir /s " & Chr(34) & "%%a\*.m3u" & Chr(34) & " && set /a nocopyflag+=1")
        PrintLine(F, " if !nocopyflag! equ 0 (")
        PrintLine(F, "  echo %%a >>" & Chr(34) & TextBox2.Text & Chr(34) & "\nom3u.txt")
        PrintLine(F, "  REM rd /s /q %%a")
        PrintLine(F, " ) else (")
        PrintLine(F, "  REM echo !nocopyflag! of the requested filetypes are present, do not delete: %%a")
        PrintLine(F, " )")
        PrintLine(F, ") ")
        PrintLine(F, "exit /b")
        FileClose()
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo = New ProcessStartInfo(TextBox2.Text & "\_m3usearch.bat")
        Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Proc.StartInfo.UseShellExecute = False
        Proc.StartInfo.CreateNoWindow = True
        Proc.Start()
        ' Allows script to execute sequentially instead of simultaneously
        Proc.WaitForExit()
        If System.IO.File.Exists(TextBox2.Text & "\nom3u.txt") = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(TextBox2.Text & "\nom3u.txt"))
        If System.IO.File.Exists(TextBox2.Text & "\_m3usearch.bat") = True Then System.IO.File.Delete(TextBox2.Text & "\_m3usearch.bat")
        btn_mp3_root_dir.Enabled = True
        btn_result_dir.Enabled = True
        btn_mis_sfv.Enabled = True
        btn_mis_nfo.Enabled = True
        btn_find_renames.Enabled = True
    End Sub

    Private Sub btn_find_renames_Click(sender As Object, e As EventArgs) Handles btn_find_renames.Click
        btn_mp3_root_dir.Enabled = False
        btn_result_dir.Enabled = False
        btn_mis_m3u.Enabled = False
        btn_mis_sfv.Enabled = False
        btn_mis_nfo.Enabled = False
        If System.IO.File.Exists(TextBox2.Text & "\2check.txt") = True Then System.IO.File.Delete(TextBox2.Text & "\2check.txt")
        If System.IO.File.Exists(TextBox2.Text & "\rename.bat") = True Then System.IO.File.Delete(TextBox2.Text & "\rename.bat")
        ListBox1.Items.Clear()

        ForEachSubPath(mp3_root_dir.Text)

        If System.IO.File.Exists(TextBox2.Text & "\rename.bat") = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(TextBox2.Text & "\rename.bat"))

        btn_mp3_root_dir.Enabled = True
        btn_result_dir.Enabled = True
        btn_mis_m3u.Enabled = True
        btn_mis_sfv.Enabled = True
        btn_mis_nfo.Enabled = True
    End Sub

    Private Sub btn_mis_sfv_Click(sender As Object, e As EventArgs) Handles btn_mis_sfv.Click
        Dim F As Integer
        btn_mp3_root_dir.Enabled = False
        btn_result_dir.Enabled = False
        btn_mis_m3u.Enabled = False
        btn_mis_nfo.Enabled = False
        btn_find_renames.Enabled = False
        If System.IO.File.Exists(TextBox2.Text & "\nosfv.txt") = True Then System.IO.File.Delete(TextBox2.Text & "\nosfv.txt")
        ListBox1.Items.Clear()
        F = FreeFile()
        FileOpen(F, TextBox2.Text & "\_sfvsearch.bat", OpenMode.Output)
        PrintLine(F, "@ECHO OFF")
        PrintLine(F, "setlocal enabledelayedexpansion")
        PrintLine(F, "set nocopyflag=0")
        PrintLine(F, "for /f %%a in ('dir " & Chr(34) & mp3_root_dir.Text & Chr(34) & " /b /s /ad') do (")
        PrintLine(F, " set nocopyflag=0")
        PrintLine(F, " >nul 2>&1 dir /s " & Chr(34) & "%%a\*.sfv" & Chr(34) & " && set /a nocopyflag+=1")
        PrintLine(F, " if !nocopyflag! equ 0 (")
        PrintLine(F, "  echo %%a >>" & Chr(34) & TextBox2.Text & Chr(34) & "\nosfv.txt")
        PrintLine(F, "  REM rd /s /q %%a")
        PrintLine(F, " ) else (")
        PrintLine(F, "  REM echo !nocopyflag! of the requested filetypes are present, do not delete: %%a")
        PrintLine(F, " )")
        PrintLine(F, ") ")
        PrintLine(F, "exit /b")
        FileClose()
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo = New ProcessStartInfo(TextBox2.Text & "\_sfvsearch.bat")
        Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Proc.StartInfo.UseShellExecute = False
        Proc.StartInfo.CreateNoWindow = True
        Proc.Start()
        ' Allows script to execute sequentially instead of simultaneously
        Proc.WaitForExit()
        If System.IO.File.Exists(TextBox2.Text & "\nosfv.txt") = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(TextBox2.Text & "\nosfv.txt"))
        If System.IO.File.Exists(TextBox2.Text & "\_sfvsearch.bat") = True Then System.IO.File.Delete(TextBox2.Text & "\_sfvsearch.bat")
        btn_mp3_root_dir.Enabled = True
        btn_result_dir.Enabled = True
        btn_mis_m3u.Enabled = True
        btn_mis_nfo.Enabled = True
        btn_find_renames.Enabled = True
    End Sub

    Private Sub btn_mis_nfo_Click(sender As Object, e As EventArgs) Handles btn_mis_nfo.Click
        Dim F As Integer
        btn_mp3_root_dir.Enabled = False
        btn_result_dir.Enabled = False
        btn_mis_m3u.Enabled = False
        btn_mis_sfv.Enabled = False
        btn_find_renames.Enabled = False
        If System.IO.File.Exists(TextBox2.Text & "\nonfo.txt") = True Then System.IO.File.Delete(TextBox2.Text & "\nonfo.txt")
        ListBox1.Items.Clear()
        F = FreeFile()
        FileOpen(F, TextBox2.Text & "\_nfosearch.bat", OpenMode.Output)
        PrintLine(F, "@ECHO OFF")
        PrintLine(F, "setlocal enabledelayedexpansion")
        PrintLine(F, "set nocopyflag=0")
        PrintLine(F, "for /f %%a in ('dir " & Chr(34) & mp3_root_dir.Text & Chr(34) & " /b /s /ad') do (")
        PrintLine(F, " set nocopyflag=0")
        PrintLine(F, " >nul 2>&1 dir /s " & Chr(34) & "%%a\*.nfo" & Chr(34) & " && set /a nocopyflag+=1")
        PrintLine(F, " if !nocopyflag! equ 0 (")
        PrintLine(F, "  echo %%a >>" & Chr(34) & TextBox2.Text & Chr(34) & "\nonfo.txt")
        PrintLine(F, "  REM rd /s /q %%a")
        PrintLine(F, " ) else (")
        PrintLine(F, "  REM echo !nocopyflag! of the requested filetypes are present, do not delete: %%a")
        PrintLine(F, " )")
        PrintLine(F, ") ")
        PrintLine(F, "exit /b")
        FileClose()
        Dim Proc As New System.Diagnostics.Process
        Proc.StartInfo = New ProcessStartInfo(TextBox2.Text & "\_nfosearch.bat")
        Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Proc.StartInfo.UseShellExecute = False
        Proc.StartInfo.CreateNoWindow = True
        Proc.Start()
        ' Allows script to execute sequentially instead of simultaneously
        Proc.WaitForExit()
        If System.IO.File.Exists(TextBox2.Text & "\nonfo.txt") = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(TextBox2.Text & "\nonfo.txt"))
        If System.IO.File.Exists(TextBox2.Text & "\_nfosearch.bat") = True Then System.IO.File.Delete(TextBox2.Text & "\_nfosearch.bat")
        btn_mp3_root_dir.Enabled = True
        btn_result_dir.Enabled = True
        btn_mis_m3u.Enabled = True
        btn_mis_sfv.Enabled = True
        btn_find_renames.Enabled = True
    End Sub

    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListBox1.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim n As Integer = Me.ListBox1.IndexFromPoint(e.X, e.Y)
            If n <> ListBox.NoMatches Then
                Me.ListBox1.SelectedIndex = n

                ' Show context menu here using 'ContextMenu.Show'...
                If e.Button = System.Windows.Forms.MouseButtons.Right Then
                    ContextMenuStrip1.Show(MousePosition)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim index2 As Integer = ListBox1.SelectedItem.LastIndexOf("\")
        Dim index3 As Integer = ListBox1.SelectedItem.LastIndexOf(Chr(34) & " " & Chr(34))
        Dim entry As String = ListBox1.SelectedItem.Substring(0, 3)
        If entry = "REM" Then
            MessageBox.Show("Click the release not the comment...")
            GoTo Fertig
        End If

        If entry = "Ren" Then entry = Trim(Replace(ListBox1.SelectedItem.Substring(index3 + 3), Chr(34), " ")) Else entry = ListBox1.SelectedItem.Substring(index2 + 1)
        entry = "http://www.srrdb.com/release/details/" & entry
        Process.Start(entry)
Fertig:
    End Sub

    Private Sub Finder_Click(sender As Object, e As EventArgs) Handles Finder.Click
        frm_Srrdb.Close()
        frm_fixit.Close()
    End Sub

    Private Sub Srrdb_Click(sender As Object, e As EventArgs) Handles Srrdb.Click
        frm_fixit.Close()
        frm_Srrdb.Location = New Point(Me.Left, Me.Top)
        frm_Srrdb.Show()
        Me.Close()
    End Sub

    Private Sub Fixer_Click(sender As Object, e As EventArgs) Handles Fixer.Click
        frm_Srrdb.Close()
        frm_fixit.Location = New Point(Me.Left, Me.Top)
        frm_fixit.Show()
        Me.Close()
    End Sub

    Private Sub frm_Finder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Application.Info.DirectoryPath
    End Sub
End Class

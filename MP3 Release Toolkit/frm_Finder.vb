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
                btn_2x_m3u.Enabled = True
                btn_2x_nfo.Enabled = True
                btn_2x_sfv.Enabled = True
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
        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nom3u.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.m3u", "missing")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nom3u.txt")))

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
        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nosfv.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "missing")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nosfv.txt")))

    End Sub

    Private Sub btn_mis_nfo_Click(sender As Object, e As EventArgs) Handles btn_mis_nfo.Click
        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nonfo.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "missing")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nonfo.txt")))

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
        entry = "https://www.srrdb.com/release/details/" & entry
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

    Private Sub btn_2x_nfo_Click(sender As Object, e As EventArgs) Handles btn_2x_nfo.Click
        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xnfo.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "double")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt")))

    End Sub

    Private Sub btn_2x_sfv_Click(sender As Object, e As EventArgs) Handles btn_2x_sfv.Click

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xsfv.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "double")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt")))

    End Sub

    Private Sub btn_2x_m3u_Click(sender As Object, e As EventArgs) Handles btn_2x_m3u.Click

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xm3u.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.m3u", "double")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt")))

    End Sub
End Class

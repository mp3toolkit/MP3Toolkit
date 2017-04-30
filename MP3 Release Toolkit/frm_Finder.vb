﻿Imports System.IO
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
            If FBD.ShowDialog = DialogResult.OK Then
                TextBox2.Text = FBD.SelectedPath
                Vars.workdir = TextBox2.Text
            End If
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
        info_listbox.Text = "Found the folllowing Releases WITHOUT an *.m3u:"
        Dim dblfile_release As New List(Of String)
        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nom3u.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.m3u", "missing")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\nom3u.txt"), dblfile_release)
        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nom3u.txt")))


    End Sub

    Private Sub btn_find_renames_Click(sender As Object, e As EventArgs) Handles btn_find_renames.Click

        If System.IO.File.Exists(TextBox2.Text & "\2check.txt") = True Then System.IO.File.Delete(TextBox2.Text & "\2check.txt")
        If System.IO.File.Exists(TextBox2.Text & "\rename.bat") = True Then System.IO.File.Delete(TextBox2.Text & "\rename.bat")
        ListBox1.Items.Clear()

        ForEachSubPath(mp3_root_dir.Text)

        If System.IO.File.Exists(TextBox2.Text & "\rename.bat") = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(TextBox2.Text & "\rename.bat"))

    End Sub

    Private Sub btn_mis_sfv_Click(sender As Object, e As EventArgs) Handles btn_mis_sfv.Click
        info_listbox.Text = "Found the folllowing Releases WITHOUT an *.sfv:"
        Dim dblfile_release As New List(Of String)

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nosfv.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "missing")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\nosfv.txt"), dblfile_release)

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nosfv.txt")))
    End Sub

    Private Sub btn_mis_nfo_Click(sender As Object, e As EventArgs) Handles btn_mis_nfo.Click
        Dim dblfile_release As New List(Of String)

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\nonfo.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "missing")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\nonfo.txt"), dblfile_release)

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\nonfo.txt")))
        info_listbox.Text = "Found the folllowing Releases WITHOUT an *.nfo:"
    End Sub

    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListBox1.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim n As Integer = Me.ListBox1.IndexFromPoint(e.X, e.Y)
            If n <> ListBox.NoMatches Then
                Me.ListBox1.SelectedIndex = n

                ' Show context menu here using 'ContextMenu.Show'...
                If e.Button = System.Windows.Forms.MouseButtons.Right Then
                    Dim entry As String = ListBox1.SelectedItem.Substring(0, 10)
                    If entry = "      --  " Then
                        ToolStripMenuItem4.Enabled = True
                        ToolStripMenuItem1.Enabled = False
                        ToolStripMenuItem2.Enabled = False
                        ToolStripMenuItem3.Enabled = False
                    ElseIf entry.Substring(0, 3) = "REN" Then
                        ToolStripMenuItem1.Enabled = True
                        ToolStripMenuItem2.Enabled = True
                        ToolStripMenuItem3.Enabled = True
                        ToolStripMenuItem4.Enabled = False
                    ElseIf entry.Substring(0, 3) = "REM" Then
                        ToolStripMenuItem4.Enabled = False
                        ToolStripMenuItem1.Enabled = False
                        ToolStripMenuItem2.Enabled = False
                        ToolStripMenuItem3.Enabled = False
                    Else
                        ToolStripMenuItem1.Enabled = True
                        ToolStripMenuItem2.Enabled = True
                        ToolStripMenuItem3.Enabled = True
                        ToolStripMenuItem4.Enabled = False
                    End If
                    ContextMenuStrip1.Show(MousePosition)
                    End If
                End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim index2 As Integer = ListBox1.SelectedItem.LastIndexOf("\")
        Dim index3 As Integer = ListBox1.SelectedItem.LastIndexOf(Chr(34) & " " & Chr(34))
        Dim entry As String = ""
        If index3 = -1 Then
            entry = ListBox1.SelectedItem.Substring(index2 + 1)
        Else
            entry = Trim(Replace(ListBox1.SelectedItem.Substring(index3 + 3), Chr(34), " "))
        End If
        entry = "https://www.srrdb.com/release/details/" & entry
            Process.Start(entry)

            ToolStripMenuItem1.Enabled = False
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If System.IO.Directory.Exists(ListBox1.SelectedItem) = True Then Process.Start(ListBox1.SelectedItem)
        ToolStripMenuItem2.Enabled = False
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        System.IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\reksfv.exe", My.Resources.RekSFV)
        If System.IO.Directory.Exists(ListBox1.SelectedItem) = True Then Process.Start("reksfv.exe", ListBox1.SelectedItem)
        ToolStripMenuItem3.Enabled = False
    End Sub
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim entry As String = ListBox1.SelectedItem.Substring(10)
        If System.IO.File.Exists(entry) = True Then System.IO.File.Delete(entry)
        If System.IO.File.Exists(entry) = False Then ListBox1.Items.Remove(ListBox1.SelectedItem)
        Dim lines(ListBox1.Items.Count - 1) As String
        If info_listbox.Text = "Found the folllowing Releases WITHOUT an *.nfo:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\nonfo.txt"), lines)
        ElseIf info_listbox.Text = "Found the folllowing Releases WITHOUT an *.m3u:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\nom3u.txt"), lines)
        ElseIf info_listbox.Text = "Found the folllowing Releases WITHOUT an *.sfv:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\nosfv.txt"), lines)
        ElseIf info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.nfo:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt"), lines)
        ElseIf info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.sfv:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt"), lines)
        ElseIf info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.m3u:" Then
            ListBox1.Items.CopyTo(lines, 0)
            File.WriteAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt"), lines)

        End If
        ToolStripMenuItem4.Enabled = False
    End Sub

    Private Sub Finder_Click(sender As Object, e As EventArgs) Handles Finder.Click
        frm_Srrdb.Close()
        frm_fixit.Close()
        frm_lists.Close()
    End Sub

    Private Sub Srrdb_Click(sender As Object, e As EventArgs) Handles Srrdb.Click
        frm_fixit.Close()
        frm_lists.Close()
        frm_Srrdb.Location = New Point(Me.Left, Me.Top)
        frm_Srrdb.Show()
        Me.Close()
    End Sub

    Private Sub Fixer_Click(sender As Object, e As EventArgs) Handles Fixer.Click
        frm_Srrdb.Close()
        frm_lists.Close()
        frm_fixit.Location = New Point(Me.Left, Me.Top)
        frm_fixit.Show()
        Me.Close()
    End Sub

    Private Sub Lists_Click(sender As Object, e As EventArgs) Handles Lists.Click
        frm_fixit.Close()
        frm_Srrdb.Close()
        frm_lists.Location = New Point(Me.Left, Me.Top)
        frm_lists.Show()
        Me.Close()
    End Sub

    Private Sub frm_Finder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mp3_root_dir.Text = My.Application.Info.DirectoryPath
        If Vars.workdir = "" Then
            TextBox2.Text = My.Application.Info.DirectoryPath
        Else
            TextBox2.Text = Vars.workdir
        End If
    End Sub

    Private Sub btn_2x_nfo_Click(sender As Object, e As EventArgs) Handles btn_2x_nfo.Click
        Dim dblfile_release As New List(Of String)
        info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.nfo:"

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xnfo.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "double")
        File.WriteAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt"), dblfile_release)
        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt")))
    End Sub

    Private Sub btn_2x_sfv_Click(sender As Object, e As EventArgs) Handles btn_2x_sfv.Click
        Dim dblfile_release As New List(Of String)
        info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.sfv:"

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xsfv.txt"))

        Call searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "double")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt"), dblfile_release)
        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt")))
    End Sub

    Private Sub btn_2x_m3u_Click(sender As Object, e As EventArgs) Handles btn_2x_m3u.Click
        Dim dblfile_release As New List(Of String)
        info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.m3u:"

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\2xm3u.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.m3u", "double")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt"), dblfile_release)
        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt")))
    End Sub

    Private Sub btn_sysjpg_Click(sender As Object, e As EventArgs) Handles btn_sysjpg.Click
        Dim dblfile_release As New List(Of String)
        info_listbox.Text = "Found the folllowing Releases WITH Windows *.jpgs ( ""Folder.jpg"" & ""AlbumArtSmall.jpg"") :"

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\systemjpgs.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\systemjpgs.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.jpg", "sysjpgs")
        File.AppendAllLines(Vars.workdir & Convert.ToString("\systemjpgs.txt"), dblfile_release)
        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\systemjpgs.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\systemjpgs.txt")))
    End Sub

    Private Sub btn_ftpdfiles_Click(sender As Object, e As EventArgs) Handles btn_ftpdfiles.Click
        Dim dblfile_release As New List(Of String)
        info_listbox.Text = "Found the folllowing Releases WITH FTPD files ("".acl"" & "".zs"" & "".crc"" & "".message"" :"

        Vars.mp3_rootdir = mp3_root_dir.Text
        Vars.workdir = TextBox2.Text
        ListBox1.Items.Clear()

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\ftpds.txt")) = True Then System.IO.File.Delete(Vars.workdir & Convert.ToString("\ftpds.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.jpg", "missing")

        If System.IO.File.Exists(Vars.workdir & Convert.ToString("\ftpds.txt")) = True Then ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\ftpds.txt")))
    End Sub


End Class

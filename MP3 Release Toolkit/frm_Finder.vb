Imports System.IO
Imports System.Diagnostics
Public Class frm_Finder

    Private Sub frm_Finder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Registry.CurrentUser.OpenSubKey("Software\mp3toolkit")
            Vars.mp3_rootdir = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\mp3toolkit", "mp3root", Nothing)
            Vars.workdir = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\mp3toolkit", "workdir", Nothing)
        Catch
        End Try

        If Vars.workdir = "" Then
            workdir.Text = My.Application.Info.DirectoryPath
        Else
            workdir.Text = Vars.workdir
        End If
        If Vars.mp3_rootdir = "" Then
            mp3_root_dir.Text = My.Application.Info.DirectoryPath
        Else
            mp3_root_dir.Text = Vars.mp3_rootdir
        End If

    End Sub

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

                Vars.mp3_rootdir = mp3_root_dir.Text.Trim

                My.Computer.Registry.CurrentUser.CreateSubKey("Software\mp3toolkit")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\mp3toolkit", "mp3root", Vars.mp3_rootdir)
            End If
        End Using
    End Sub
    Private Sub btn_result_dir_Click(sender As Object, e As EventArgs) Handles btn_result_dir.Click
        Using FBD As New FolderBrowserDialog
            If FBD.ShowDialog = DialogResult.OK Then
                workdir.Text = FBD.SelectedPath
                Vars.workdir = workdir.Text.Trim
                My.Computer.Registry.CurrentUser.CreateSubKey("Software\mp3toolkit")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\mp3toolkit", "workdir", Vars.workdir)
            End If
        End Using
    End Sub

    Private Sub btn_find_renames_Click(sender As Object, e As EventArgs) Handles btn_find_renames.Click
        'has to be reworked - Old Stuff - Probably Defunct right now
        If File.Exists(Vars.workdir & "\2check.txt") Then File.Delete(Vars.workdir & "\2check.txt")
        If File.Exists(Vars.workdir & "\rename.bat") Then File.Delete(Vars.workdir & "\rename.bat")
        ListBox1.Items.Clear()

        searcher.ForEachSubPath(Vars.mp3_rootdir)
        'Dim dblfile_release As New List(Of String)
        'dblfile_release = searcher.GetFilesRecursive(Vars.mp3_rootdir, "", "renames")
        If File.Exists(Vars.workdir & "\rename.bat") Then ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & "\rename.bat"))

    End Sub


    Private Sub btn_mis_m3u_Click(sender As Object, e As EventArgs) Handles btn_mis_m3u.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\nom3u.txt"))

        dblfile_release = searcher.GetFilesRecursive(Vars.mp3_rootdir, "*.m3u", "missing")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\nom3u.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\nom3u.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\nom3u.txt")))
            info_listbox.Text = "Found the folllowing Releases WITHOUT an *.m3u:"

        End If


    End Sub

    Private Sub btn_mis_sfv_Click(sender As Object, e As EventArgs) Handles btn_mis_sfv.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\nosfv.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "missing")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\nosfv.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\nosfv.txt")) Then
            info_listbox.Text = "Found the folllowing Releases WITHOUT an *.sfv:"
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\nosfv.txt")))
        End If
    End Sub

    Private Sub btn_mis_nfo_Click(sender As Object, e As EventArgs) Handles btn_mis_nfo.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\nonfo.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "missing")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\nonfo.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\nonfo.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\nonfo.txt")))
            info_listbox.Text = "Found the folllowing Releases WITHOUT an *.nfo:"

        End If

    End Sub

    Private Sub btn_2x_nfo_Click(sender As Object, e As EventArgs) Handles btn_2x_nfo.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\2xnfo.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.nfo", "double")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\2xnfo.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt")))
            info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.nfo:"

        End If
    End Sub

    Private Sub btn_2x_sfv_Click(sender As Object, e As EventArgs) Handles btn_2x_sfv.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\2xsfv.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.sfv", "double")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\2xsfv.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt")))
            info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.sfv:"
        End If
    End Sub

    Private Sub btn_2x_m3u_Click(sender As Object, e As EventArgs) Handles btn_2x_m3u.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\2xm3u.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.m3u", "double")

        If dblfile_release.Count > 0 Then File.WriteAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\2xm3u.txt")) = True Then
            ListBox1.Items.AddRange(IO.File.ReadAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt")))
            info_listbox.Text = "Found the folllowing Releases with MULTIPLE *.m3u:"

        End If
    End Sub

    Private Sub btn_sysjpg_Click(sender As Object, e As EventArgs) Handles btn_sysjpg.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\systemjpgs.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\systemjpgs.txt"))

        dblfile_release = searcher.GetFilesRecursive(mp3_root_dir.Text, "*.jpg", "sysjpgs")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\systemjpgs.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\systemjpgs.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\systemjpgs.txt")))
            info_listbox.Text = "Found the folllowing Releases WITH Windows *.jpgs ( ""Folder.jpg"" & ""AlbumArtSmall.jpg"") :"

        End If
    End Sub

    Private Sub btn_ftpdfiles_Click(sender As Object, e As EventArgs) Handles btn_ftpdfiles.Click
        Dim dblfile_release As New List(Of String)
        ListBox1.Items.Clear()

        If File.Exists(Vars.workdir & Convert.ToString("\ftpds.txt")) Then File.Delete(Vars.workdir & Convert.ToString("\ftpds.txt"))

        dblfile_release = searcher.GetFilesRecursive(Vars.mp3_rootdir, "", "ftpds")

        File.WriteAllLines(Vars.workdir & Convert.ToString("\ftpds.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\ftpds.txt")) Then
            ListBox1.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\ftpds.txt")))
            info_listbox.Text = "Found the folllowing Releases WITH FTPD files ("".acl"" & "".zs"" & "".crc"" & "".message"" :"

        End If
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
        If Directory.Exists(ListBox1.SelectedItem) Then Process.Start(ListBox1.SelectedItem)
        ToolStripMenuItem2.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        File.WriteAllBytes(My.Application.Info.DirectoryPath & "\reksfv.exe", My.Resources.RekSFV)
        If Directory.Exists(ListBox1.SelectedItem) Then Process.Start("reksfv.exe", ListBox1.SelectedItem)
        ToolStripMenuItem3.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim entry As String = ListBox1.SelectedItem.Substring(10)
        If File.Exists(entry) Then File.Delete(entry)
        If File.Exists(entry) = False Then ListBox1.Items.Remove(ListBox1.SelectedItem)
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
End Class

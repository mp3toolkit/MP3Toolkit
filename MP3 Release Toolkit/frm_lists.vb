Imports System.IO

Public Class frm_lists

    Private Sub btn_loadlist1_Click(sender As Object, e As EventArgs) Handles btn_loadlist1.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "txt Files|*.txt"
            OFD.Title = "Select a txt List File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ListBox1.Items.AddRange(File.ReadAllLines(OFD.FileName))
            End If
        End Using
    End Sub

    Private Sub btn_load_list2_Click(sender As Object, e As EventArgs) Handles btn_load_list2.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "txt Files|*.txt"
            OFD.Title = "Select a txt List File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ListBox2.Items.AddRange(File.ReadAllLines(OFD.FileName))
            End If
        End Using
    End Sub

    Private Sub btn_compare_Click(sender As Object, e As EventArgs) Handles btn_compare.Click

        Dim list2Keys As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim listFound As New List(Of String)()
        Dim listNFound = New List(Of String)()

        If cb_2to1.Checked = True Then
            For Each line As String In ListBox1.Items
                Dim linearray() As String = {line}
                list2Keys.Add(linearray(0))
            Next
            For Each line As String In ListBox2.Items
                Dim linearray() As String = {line}
                If list2Keys.Contains(linearray(0)) Then
                    listFound.Add(line)
                Else
                    listNFound.Add(line)
                End If
            Next
        ElseIf cb_1to2.Checked = True Then
            For Each line As String In ListBox2.Items
                Dim linearray() As String = {line}
                list2Keys.Add(linearray(0))
            Next
            For Each line As String In ListBox1.Items
                Dim linearray() As String = {line}
                If list2Keys.Contains(linearray(0)) Then
                    listFound.Add(line)
                Else
                    listNFound.Add(line)
                End If
            Next
        End If


        'ListBox3.Location = New Point(228, 54)
        ListBox3.Items.Clear()
        ListBox3.Sorted = True
        ListBox3.Items.AddRange(listNFound.ToArray)

        If File.Exists(Vars.workdir & Convert.ToString("\listcompare.txt")) Then
            File.Delete(Vars.workdir & Convert.ToString("\listcompare.txt"))
            File.WriteAllLines(Vars.workdir & Convert.ToString("\listcompare.txt"), listNFound.ToArray)
        End If

    End Sub

    Private Sub btn_createlist_Click(sender As Object, e As EventArgs) Handles btn_createlist.Click

        Dim dblfile_release As New List(Of String)
        Label1.Text = "Found the folllowing Releases:"
        If Vars.mp3_rootdir = "" Then
            Using FBD As New FolderBrowserDialog
                If FBD.ShowDialog() = DialogResult.OK Then
                    Vars.mp3_rootdir = FBD.SelectedPath
                Else
                    Exit Sub
                End If
            End Using
        End If

        dblfile_release = searcher.GetFilesRecursive(Vars.mp3_rootdir, "", "")
        'Label1.Text = "Found the folllowing Releases:" & " (" & dblfile_release.Count & ")"
        File.WriteAllLines(Vars.workdir & Convert.ToString("\mymp3list.txt"), dblfile_release)

        If File.Exists(Vars.workdir & Convert.ToString("\mymp3list.txt")) = True Then ListBox3.Items.AddRange(File.ReadAllLines(Vars.workdir & Convert.ToString("\mymp3list.txt")))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using FBD As New FolderBrowserDialog
            If FBD.ShowDialog = DialogResult.OK Then
                Vars.workdir = FBD.SelectedPath.Trim
            End If
        End Using
    End Sub

    Private Sub cb_1to2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_1to2.CheckedChanged
        If cb_1to2.Checked = True Then cb_2to1.Checked = False
    End Sub

    Private Sub cb_2to1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_2to1.CheckedChanged
        If cb_2to1.Checked = True Then cb_1to2.Checked = False
    End Sub

    Private Sub Finder_Click(sender As Object, e As EventArgs) Handles Finder.Click
        frm_Srrdb.Close()
        frm_fixit.Close()
        frm_Finder.StartPosition = FormStartPosition.Manual
        frm_Finder.Location = New Point(Me.Left, Me.Top)
        frm_Finder.Show()
        Me.Close()
    End Sub

    Private Sub Srrdb_Click(sender As Object, e As EventArgs) Handles Srrdb.Click
        frm_Finder.Close()
        frm_fixit.Close()
        frm_Srrdb.Location = New Point(Me.Left, Me.Top)
        frm_Srrdb.Show()
        Me.Close()
    End Sub

    Private Sub Fixer_Click(sender As Object, e As EventArgs) Handles Fixer.Click
        frm_Finder.Close()
        frm_Srrdb.Close()
        frm_fixit.Location = New Point(Me.Left, Me.Top)
        frm_fixit.Show()
        Me.Close()
    End Sub

    Private Sub Lists_Click(sender As Object, e As EventArgs)
        frm_Srrdb.Close()
        frm_Finder.Close()
        frm_fixit.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub frm_lists_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Vars.workdir = "" Then Button1.Visible = True
    End Sub
End Class
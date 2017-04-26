Public Class frm_lists
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
    Private Sub Lists_Click(sender As Object, e As EventArgs) Handles Lists.Click
        frm_Srrdb.Close()
        frm_Finder.Close()
        frm_fixit.Close()
    End Sub

    Private Sub btn_loadlist1_Click(sender As Object, e As EventArgs) Handles btn_loadlist1.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "txt Files|*.txt"
            OFD.Title = "Select a txt List File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ListBox1.Items.AddRange(IO.File.ReadAllLines(OFD.FileName))
            End If
        End Using
    End Sub

    Private Sub btn_load_list2_Click(sender As Object, e As EventArgs) Handles btn_load_list2.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "txt Files|*.txt"
            OFD.Title = "Select a txt List File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ListBox2.Items.AddRange(IO.File.ReadAllLines(OFD.FileName))
            End If
        End Using
    End Sub

    Private Sub btn_compare_Click(sender As Object, e As EventArgs) Handles btn_compare.Click

        Dim list2Keys As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each line As String In ListBox1.Items
            Dim linearray() As String = {line}
            list2Keys.Add(linearray(0))
        Next

        Dim listFound As New List(Of String)()
        Dim listNFound = New List(Of String)()

        For Each line As String In ListBox2.Items
            Dim linearray() As String = {line}
            If list2Keys.Contains(linearray(0)) Then
                listFound.Add(line)
            Else
                listNFound.Add(line)
            End If
        Next
        ListBox3.Items.Clear()
        ListBox3.Sorted = True
        ListBox3.Items.AddRange(listNFound.ToArray)
        'IO.File.WriteAllText("D:\temp\Same.txt", String.Join(Environment.NewLine, listFound.ToArray()))
        'IO.File.WriteAllText("D:\temp\Differrent.txt", String.Join(Environment.NewLine, listNFound.ToArray()))
    End Sub
End Class
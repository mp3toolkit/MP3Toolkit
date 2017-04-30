Public Class frm_Srrdb
    Private Sub Srrdb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_loadfolderlist.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "txt Files|*.txt"
            OFD.Title = "Select a txt List File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ListBox1.Items.AddRange(IO.File.ReadAllLines(OFD.FileName))
            End If
        End Using
    End Sub

    Private Sub Finder_Click(sender As Object, e As EventArgs) Handles Finder.Click
        frm_fixit.Close()
        frm_lists.Close()
        frm_Finder.StartPosition = FormStartPosition.Manual
        frm_Finder.Location = New Point(Me.Left, Me.Top)
        frm_Finder.Show()
        Me.Close()
    End Sub

    Private Sub Srrdb_Click(sender As Object, e As EventArgs) Handles Srrdb.Click
        frm_fixit.Close()
        frm_Finder.Close()
        frm_lists.Close()
    End Sub

    Private Sub Fixer_Click(sender As Object, e As EventArgs) Handles Fixer.Click
        frm_Finder.Close()
        frm_lists.Close()
        frm_fixit.Location = New Point(Me.Left, Me.Top)
        frm_fixit.Show()
        Me.Close()
    End Sub
    Private Sub Lists_Click(sender As Object, e As EventArgs)
        frm_Finder.Close()
        frm_fixit.Close()
        frm_lists.Location = New Point(Me.Left, Me.Top)
        frm_lists.Show()
        Me.Close()
    End Sub

    Private Sub btn_fixit_Click(sender As Object, e As EventArgs)
        For Each i As String In ListBox1.Items
            If i.Contains("&") Then GoTo goon
            Call Net.Getnrun_srr(i)
goon:
        Next
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub


End Class

Imports System.IO

Public Class frm_fixit
    Private Sub btn_fixit_Click(sender As Object, e As EventArgs) Handles btn_fixit.Click
        Vars.buff = System.IO.File.ReadAllBytes(txbox_filename.Text)
        Vars.st = txbox_filename.Text.Split("\")
        Vars.trackno = CInt(Vars.st(Vars.st.Length - 1).Substring(0, 2))
        Vars.mp3size = Vars.buff.Length
        Vars.buffcopy = Vars.buff


        If txbox_filename.Text = "" Or txbox_filename.Text = "C:\Users\Home\MP3s\Artist-Album-Year-GRP\01-Intro.mp3" Then
            txbox_filename.Text = "Choose File first!"
            txbox_filename.ForeColor = Color.Red
            Exit Sub
        End If

        If TextBox2.Text = "" Or TextBox2.Text.Length <> 8 Or TextBox2.Text = "12345678" Then
            TextBox2.Text = "8-digit CRC32!"
            TextBox2.ForeColor = Color.Red
            Exit Sub
        End If

        For Each element As Integer In Vars.lastbyte_int
            Call Modify.ID3v1_lastbyte(Vars.buffcopy, element)
        Next

        For Each element As Integer In Vars.lastbyte_int
            Call Modify.ID3v1_trackno(Vars.buffcopy, element, Vars.trackno)
        Next


        Call Modify.RemoveMp3CRC(Vars.buffcopy)
        Call Modify.RemoveLyrics(Vars.buffcopy)
        Call Modify.RemoveID3v2(Vars.buffcopy)
        Call Modify.Space2Zero(Vars.buffcopy)
        Call Modify.Zero2Space(Vars.buffcopy)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.ForeColor = Color.Black
    End Sub

    Private Sub btn_dlg_open_file_Click(sender As Object, e As EventArgs) Handles btn_dlg_open_file.Click
        txbox_filename.ForeColor = Color.Black
        Using OFD As New OpenFileDialog()
            OFD.Filter = "mp3 Files|*.mp3"
            OFD.Title = "Select a mp3 File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txbox_filename.Text = OFD.FileName
            End If
            btn_dlg_open_crc.Enabled = True
        End Using
    End Sub

    Private Sub btn_dlg_open_crc_Click(sender As Object, e As EventArgs) Handles btn_dlg_open_crc.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "sfv Files|*.sfv"
            OFD.Title = "Select a sfv File"
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim mp3name As String = System.IO.Path.GetFileName(txbox_filename.Text)
                Dim sfvcontent As String = File.ReadAllText(OFD.FileName)

                Dim crc As String = UCase(sfvcontent.Substring(sfvcontent.IndexOf(mp3name) + mp3name.Length + 1, 8))
                If crc.Contains(Chr(10)) Then crc = UCase(sfvcontent.Substring(sfvcontent.IndexOf(mp3name, sfvcontent.IndexOf(mp3name) + mp3name.Length) + mp3name.Length + 1, 8))
                If sfvcontent.Contains(mp3name) Then TextBox2.Text = crc Else TextBox2.Text = "right sfv?"
            End If
        End Using
    End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim about As String = "Trys to fix mp3s against a given crc with the following techniques:" & ControlChars.NewLine & ControlChars.NewLine & "- widespread ending bytes" & ControlChars.NewLine & "- tracknumber (ID3v1.1)" & ControlChars.NewLine & "- remove morgoths crc" & ControlChars.NewLine & "- remove Lyrics2 tag" & ControlChars.NewLine & "- remove ID3v2 tag" & ControlChars.NewLine & "- replace 00 with 20 (one at a time)"
        MessageBox.Show(about, "About")
    End Sub

    Private Sub Finder_Click(sender As Object, e As EventArgs) Handles Finder.Click
        frm_Srrdb.Close()
        frm_Finder.StartPosition = FormStartPosition.Manual
        frm_Finder.Location = New Point(Me.Left, Me.Top)
        frm_Finder.Show()
        Me.Close()
    End Sub

    Private Sub Srrdb_Click(sender As Object, e As EventArgs) Handles Srrdb.Click
        frm_Finder.Close()
        frm_Srrdb.Location = New Point(Me.Left, Me.Top)
        frm_Srrdb.Show()
        Me.Close()
    End Sub

    Private Sub Fixer_Click(sender As Object, e As EventArgs) Handles Fixer.Click
        frm_Srrdb.Close()
        frm_Finder.Close()
    End Sub

    Private Sub frm_fixit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_cleanmorgdir_Click(sender As Object, e As EventArgs) Handles btn_cleanmorgdir.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "mp3 Files|*.mp3"
            OFD.Title = "Select infected mp3s"
            OFD.Multiselect = True
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim file As String
                For Each file In OFD.FileNames
                    Vars.buffcopy = System.IO.File.ReadAllBytes(file)
                    Vars.mp3size = Vars.buffcopy.Length
                    If Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_size - 1) = &H30 AndAlso Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_size - 2) = &H30 AndAlso Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_size - 3) = &H32 Then
                        Vars.id3v1_lenly = CInt(Chr(Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_lenly_pos)) & Chr(Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_lenly_pos + 1)) & Chr(Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_lenly_pos + 2)))
                        Vars.id3v1_ly_pos = Vars.id3v1_size + &HF + Vars.id3v1_lenly
                        Dim buffmod() As Byte = Vars.buffcopy
                        Array.Resize(buffmod, buffmod.Length - Vars.id3v1_ly_pos)

                        For i = 0 To Vars.id3v1_size - 1
                            Array.Resize(buffmod, buffmod.Length + 1)
                            buffmod(buffmod.Length - 1) = Vars.buffcopy(Vars.buffcopy.Length - Vars.id3v1_size + i)
                        Next
                        If cb_trknum.Checked = True Then buffmod(buffmod.Length - 2) = CInt(System.IO.Path.GetFileName(file).Substring(0, 2))
                        'System.IO.File.Delete(file)
                        System.IO.File.WriteAllBytes(file & "2", buffmod)
                    End If
                Next
                MessageBox.Show("Cleaned Files Saved. Check Tracknumbers", "Success", MessageBoxButtons.OK)


            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_patchposition.Click
        Using OFD As New OpenFileDialog()
            OFD.Filter = "mp3 Files|*.mp3"
            OFD.Title = "Select infected mp3s"
            OFD.Multiselect = True
            If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim file As String
                For Each file In OFD.FileNames
                    Vars.buff = System.IO.File.ReadAllBytes(file)
                    Vars.mp3size = Vars.buff.Length
                    Vars.buff(Vars.mp3size - TextBox1.Text) = TextBox3.Text
                    System.IO.File.Delete(file)
                    System.IO.File.WriteAllBytes(file, Vars.buff)
                Next
            End If
        End Using

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class



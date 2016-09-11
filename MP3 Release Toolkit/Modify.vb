Imports System.IO
Public Class Modify

    Public Shared Function ID3v1_lastbyte(ByVal buffcopy() As Byte, ByVal lastbyte_int As Integer) As Boolean
        buffcopy(buffcopy.Length - 1) = lastbyte_int
        buffcopy(buffcopy.Length - 2) = 0
        Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
        If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
    End Function

    Public Shared Function ID3v1_trackno(ByVal buffcopy() As Byte, ByVal lastbyte_int As Integer, ByVal trackno As Integer) As Boolean
        buffcopy(buffcopy.Length - 1) = lastbyte_int
        buffcopy(buffcopy.Length - 2) = trackno
        Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
        If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
    End Function

    Public Shared Function Zero2Space(ByVal buffcopy() As Byte) As Boolean
        For i = 0 To Vars.id3v1_size - 1
            If buffcopy(buffcopy.Length - Vars.id3v1_size + i) = 0 Then buffcopy(buffcopy.Length - Vars.id3v1_size + i) = &H20
            Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
            If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
        Next
    End Function

    Public Shared Function Space2Zero(ByVal buffcopy() As Byte) As Boolean
        For i = 0 To Vars.id3v1_size - 1
            If buffcopy(buffcopy.Length - Vars.id3v1_size + i) = &H20 Then buffcopy(buffcopy.Length - Vars.id3v1_size + i) = 0
            Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
            If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
        Next
    End Function

    Public Shared Function RemoveMp3CRC(ByVal buffcopy() As Byte) As Boolean
        'Remove morgoths CRC
        If buffcopy(buffcopy.Length - Vars.id3v1_mp3crc_pos) = &H43 AndAlso buffcopy(buffcopy.Length - Vars.id3v1_mp3crc_pos + 1) = &H52 AndAlso buffcopy(buffcopy.Length - Vars.id3v1_mp3crc_pos + 2) = &H43 Then
            Dim buffmod() As Byte = buffcopy
            Array.Resize(buffmod, buffmod.Length - Vars.id3v1_mp3crc_pos)

            For i = 0 To Vars.id3v1_size + &HF - 1
                Array.Resize(buffmod, buffmod.Length + 1)
                buffmod(buffmod.Length - 1) = buffcopy(buffcopy.Length - Vars.id3v1_size - &HF + i)
            Next
            'Correct Lyrics Length
            buffmod(buffmod.Length - &H8B) = buffmod(buffmod.Length - &H8B) - 1 ' - Length of MP3CRC
            buffmod(buffmod.Length - &H8A) = buffmod(buffmod.Length - &H8A) - 6 ' - Length of MP3CRC
            buffcopy = buffmod
            'System.IO.File.WriteAllBytes(TextBox1.Text & ".withoutcrc", buffcopy)
            For Each element As Integer In Vars.lastbyte_int
                Call Modify.ID3v1_lastbyte(buffcopy, element)
            Next

            For Each element As Integer In Vars.lastbyte_int
                Call Modify.ID3v1_trackno(buffcopy, element, Vars.trackno)
            Next
            Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
            If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
        End If
    End Function
    Public Shared Function RemoveLyrics(ByVal buffcopy() As Byte) As Boolean
        'Remove Complete Lyrics
        If buffcopy(buffcopy.Length - Vars.id3v1_size - 1) = &H30 AndAlso buffcopy(buffcopy.Length - Vars.id3v1_size - 2) = &H30 AndAlso buffcopy(buffcopy.Length - Vars.id3v1_size - 3) = &H32 Then
            Vars.id3v1_lenly = CInt(Chr(buffcopy(buffcopy.Length - Vars.id3v1_lenly_pos)) & Chr(buffcopy(buffcopy.Length - Vars.id3v1_lenly_pos + 1)) & Chr(buffcopy(buffcopy.Length - Vars.id3v1_lenly_pos + 2)))
            Vars.id3v1_ly_pos = Vars.id3v1_size + &HF + Vars.id3v1_lenly
            Dim buffmod() As Byte = buffcopy
            Array.Resize(buffmod, buffmod.Length - Vars.id3v1_ly_pos)

            For i = 0 To Vars.id3v1_size - 1
                Array.Resize(buffmod, buffmod.Length + 1)
                buffmod(buffmod.Length - 1) = buffcopy(buffcopy.Length - Vars.id3v1_size + i)
            Next
            buffcopy = buffmod
            Call Modify.RemoveMp3CRC(buffcopy)
            'System.IO.File.WriteAllBytes(TextBox1.Text & ".withoutlyrics", buffcopy)
            Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
            If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
        End If
    End Function
    Public Shared Function RemoveID3v2(ByVal buffcopy() As Byte) As Boolean
        'Remove ID3 v2
        If buffcopy(0) = &H49 AndAlso buffcopy(1) = &H44 AndAlso buffcopy(2) = &H33 Then
            Dim buffmod() As Byte = buffcopy
            Vars.id3v2_size = ((buffmod(9) And &HFF) Or ((buffmod(8) And &HFF) << 7) Or ((buffmod(7) And &HFF) << 14) Or ((buffmod(6) And &HFF) << 21)) + 10
            Array.Copy(buffcopy, Vars.id3v2_size, buffmod, 0, buffcopy.Length - Vars.id3v2_size)
            Array.Resize(buffmod, buffcopy.Length - Vars.id3v2_size)
            buffcopy = buffmod
            Call Modify.RemoveLyrics(buffcopy)
            'System.IO.File.WriteAllBytes(TextBox1.Text & ".withoutid3v2", buffcopy)
            Vars.crcresult = CRC32.GetCRC32(buffcopy, Vars.mp3size)
            If Vars.crcresult = frm_fixit.TextBox2.Text Then Call Save_Fixed_Msg(buffcopy)
        End If
    End Function
    Shared Sub Save_Fixed_Msg(ByVal buffcopy() As Byte)
        Select Case MessageBox.Show("Success", "Save as fixed copy ?", MessageBoxButtons.YesNo)
            Case System.Windows.Forms.DialogResult.Yes
                System.IO.File.WriteAllBytes(frm_fixit.txbox_filename.Text & ".fixed", buffcopy)
                Exit Sub
            Case System.Windows.Forms.DialogResult.No
                Exit Sub
        End Select
    End Sub
End Class

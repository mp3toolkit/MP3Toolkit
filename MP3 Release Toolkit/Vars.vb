Public Class Vars

    Public Shared id3v1_size As Integer = &H80
    Public Shared id3v1_mp3crc_pos As Integer = &H9F
    Public Shared id3v1_lenly_pos As Integer = &H8C
    Public Shared id3v1_lenly As Integer
    Public Shared id3v1_ly_pos As Integer
    Public Shared id3v2_size As Integer
    Public Shared lastbyte_int() As Integer = {&H5, &H7, &HC, &HF, &HFF}
    Public Shared crcresult As String
    Public Shared buff() As Byte
    Public Shared st() As String
    Public Shared trackno As Integer
    Public Shared mp3size As Integer
    Public Shared buffcopy() As Byte
    Public Shared crccounter As Integer = 0
    Public Shared mp3crc_pos As Integer
    Public Shared OrdnerName As String
End Class

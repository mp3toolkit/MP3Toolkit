Public Class CRC32
    Shared CRC32Table() As Integer

    Shared Sub New()
        Dim _CRC32Table(256) As Integer
        Dim DWPolynomial As Integer = &HEDB88320
        Dim DWCRC As Integer
        Dim e, f As Integer
        For e = 0 To 255
            DWCRC = e
            For f = 8 To 1 Step -1
                If (DWCRC And 1) Then
                    DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                    DWCRC = DWCRC Xor DWPolynomial
                Else
                    DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                End If
            Next f
            _CRC32Table(e) = DWCRC
        Next e
        CRC32Table = _CRC32Table
    End Sub
    Public Shared Function GetCRC32(ByVal Data() As Byte, ByVal BlockLength As Integer) As String
        Try
            Dim CRC32Result As Integer = &HFFFFFFFF
            Dim ReadSize As Integer = BlockLength
            Dim Count As Integer = 0
            Dim DataBuffer(BlockLength - 1) As Byte
            If Data.Length < ReadSize Then
                Count = Data.Length
            Else
                Count = ReadSize
            End If
            Buffer.BlockCopy(Data, 0, DataBuffer, 0, Count)
            Dim c As Integer = 1
            Dim i As Integer, n As Integer
            Do While (Count > 0)
                For i = 0 To Count - 1
                    n = (CRC32Result And &HFF) Xor DataBuffer(i)
                    CRC32Result = ((CRC32Result And &HFFFFFF00) \ &H100) And &HFFFFFF
                    CRC32Result = CRC32Result Xor CRC32Table(n)
                Next i
                Dim offset As UInt32 = c * ReadSize
                If ReadSize <> BlockLength Or Data.Length < BlockLength Then
                    Count = 0
                Else
                    If (offset + ReadSize) > Data.Length Then
                        ReadSize = Data.Length - offset
                    End If
                    Buffer.BlockCopy(Data, offset, DataBuffer, 0, ReadSize)
                    Count = ReadSize
                End If
                c += 1
            Loop
            Vars.crcCounter = Vars.crcCounter + 1
            frm_fixit.Label3.Text = Vars.crcCounter & " CRCs calculated"
            Application.DoEvents()
            Return Hex(Not (CRC32Result)) '// gibt checksumme als hexcode zurück
            'Return CRC32Result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

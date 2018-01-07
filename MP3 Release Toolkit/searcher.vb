Imports System.IO
Imports System.Linq
Public Class searcher
    Public Shared Function GetFilesRecursive(ByVal initial As String, filetype As String, mode As String) As List(Of String)
        ' This list stores the results.
        Dim dblfile_release As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                If filetype = "" And mode = "" Then
                    dblfile_release.Add(dir)
                    GoTo dirsonly
                End If
                ' Add all immediate file paths
                Dim tmpfilenames As New List(Of String)
                Dim filenames = Directory.EnumerateFiles(dir, filetype)

                ' Check for existence of at least 2 files of filetype
                If mode = "double" And filenames.Count >= 2 And dir IsNot initial And dir.ToString.ToLower.Contains("2cd") = False And dir.ToString.ToLower.Contains("3cd") = False And dir.ToString.ToLower.Contains("4cd") = False Then
                    'could be possible that a multiple cd release has additional files too
                    dblfile_release.Add(dir)
                    For i = 0 To filenames.Count - 1
                        dblfile_release.Add("      --  " & filenames(i))
                    Next i

                    'Check for zero files(types) in Dir and exclude alphabet dirs
                ElseIf mode = "missing" And filenames.Count = 0 And dir IsNot initial And (dir.Length - initial.Length >= 6) Then
                    dblfile_release.Add(dir)
                    For i = 0 To filenames.Count - 1
                        dblfile_release.Add("      --  " & filenames(i))
                    Next i

                    'Check for WMP Jpgs > 15KB
                ElseIf mode = "sysjpgs" And filenames.Count >= 1 And dir IsNot initial Then
                    For Each file In filenames
                        If file.ToString.ToLower.Contains("albumartsmall") Or file.ToString.ToLower.Contains("folder") And file.Length <= 15000 Then tmpfilenames.Add(file)
                    Next
                    If tmpfilenames.Count >= 1 Then
                        dblfile_release.Add(dir)
                        For Each file In tmpfilenames
                            dblfile_release.Add("      --  " & file)
                        Next
                    End If

                    'Check for FTPds
                ElseIf mode = "ftpds" And filenames.Count >= 1 And dir IsNot initial Then
                    For Each file In filenames
                        If file.ToString.ToLower.Contains("raidenftpd") Or file.ToString.ToLower.Contains("crc") Or file.ToString.ToLower.Contains(".zs") Or file.ToString.ToLower.Contains(".message") Or file.Length = 0 Then tmpfilenames.Add(file)
                    Next
                    If tmpfilenames.Count >= 1 Then
                        dblfile_release.Add(dir)
                        For Each file In tmpfilenames
                            dblfile_release.Add("      --  " & file)
                        Next
                    End If
                ElseIf mode = "renames" And filenames.Count >= 1 And dir IsNot initial Then


                End If

dirsonly:

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop

        ' Return the list
        If filetype = "" And mode = "" Then dblfile_release.Sort()
        Return dblfile_release
    End Function

    Public Shared Function ForEachSubPath(StartFolder As String)
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
                FileOpen(F, Vars.workdir & "\rename.bat", OpenMode.Append)
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
                FileOpen(F, Vars.workdir & "\rename.bat", OpenMode.Append)
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
                FileOpen(F, Vars.workdir & "\rename.bat", OpenMode.Append)
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
                FileOpen(F, Vars.workdir & "\2check.txt", OpenMode.Append)
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

    End Function


    ' Left in VB.NET rebuilt
    Public Shared Function reLeft(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(0, nLen))
    End Function

    ' Right in VB.NET rebuilt
    Public Shared Function reRight(ByVal sText As String, ByVal nLen As Integer) As String
        If nLen > sText.Length Then nLen = sText.Length
        Return (sText.Substring(sText.Length - nLen))
    End Function
End Class

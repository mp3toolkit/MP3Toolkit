Imports System.IO
Public Class searcher
    Public Shared Function GetFilesRecursive(ByVal initial As String, filetype As String, mode As String) As List(Of String)
        ' This list stores the results.
        'Dim result As New List(Of String)
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
                ' Add all immediate file paths
                If mode = "double" And Directory.GetFiles(dir, filetype).Count >= 2 Then
                    dblfile_release.Add(dir)
                ElseIf mode = "missing" And Directory.GetFiles(dir, filetype).Count = 0 And dir IsNot initial Then
                    dblfile_release.Add(dir)
                End If

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop
        If mode = "double" And filetype = "*.sfv" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\2xsfv.txt"), dblfile_release)
        ElseIf mode = "double" And filetype = "*.nfo" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt"), dblfile_release)
        ElseIf mode = "double" And filetype = "*.m3u" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\2xm3u.txt"), dblfile_release)
        ElseIf mode = "missing" And filetype = "*.nfo" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\nonfo.txt"), dblfile_release)
        ElseIf mode = "missing" And filetype = "*.sfv" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\nosfv.txt"), dblfile_release)
        ElseIf mode = "missing" And filetype = "*.m3u" Then
            File.AppendAllLines(Vars.workdir & Convert.ToString("\nom3u.txt"), dblfile_release)
        End If

        ' Return the list
        ' Return result
    End Function
End Class

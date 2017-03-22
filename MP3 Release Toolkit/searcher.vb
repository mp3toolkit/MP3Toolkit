Imports System.IO
Public Class searcher
    Public Shared Function GetFilesRecursive(ByVal initial As String, filetype As String, mode As String) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)
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
                result.AddRange(Directory.GetFiles(dir, filetype))
                If mode = "double" And result.Count >= 2 Then
                    dblfile_release.Add(dir)
                ElseIf mode = "missing" And result.Count = 0 And dir IsNot initial Then
                    dblfile_release.Add(dir)
                End If
                result.Clear()

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop
        File.AppendAllLines(Vars.workdir & Convert.ToString("\2xnfo.txt"), dblfile_release)
        ' Return the list
        ' Return result
    End Function
End Class

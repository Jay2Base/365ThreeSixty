Public Module commentFactory

    Public Function getRecipients(comment As String) As DataTable
        'validate comment structure to return error if not started with /360 and @ hadles don't exist
        'parse the rest of the comment to give an accurate score

        If Not (comment.StartsWith("/360")) Then
            MsgBox("To submit a review you must start with '/360'")
            Exit Function
            Return Nothing
        ElseIf InStr(comment, "@", CompareMethod.Binary) = False Then
            MsgBox("please include the recipient handle in your comment")
            Exit Function
            Return Nothing
        End If

        'capture the recipients from the @handles and add to array

        Dim handleList As New DataTable

        handleList.Columns.Add("handle")
        Dim newRow As DataRow

        Dim listOfHandles() As String
        Dim recipientHandle As String

        listOfHandles = comment.Split(" ")



        For Each word In listOfHandles

            If Left(word, 1) = "@" Then
                recipientHandle = word

                newRow = handleList.NewRow()
                newRow("handle") = recipientHandle
                handleList.Rows.Add(newRow)
            End If

        Next

        Return handleList


    End Function



    Private Function countAts(comment)
        Dim cnt As Integer = 0
        For Each c As Char In comment
            cnt += 1
        Next
        Return cnt
    End Function

    Function getWord(words As String)
        Dim word As String
        word = ""

        For Each c As Char In words
            If Not (c = " ") Then
                word = word & c
            End If
        Next

        Return word
    End Function


End Module

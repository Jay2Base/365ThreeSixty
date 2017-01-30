Public Class Chat_Demo
    Inherits System.Web.UI.Page

    Public commentTable As DataTable
    Public ds As DataSet
    Public reviewer As reviewer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get all the goodies in from the session

        commentTable = Session("commentTable")

        If commentTable Is Nothing Then
            commentTable = initialiseTable()
        End If
        redrawTable(commentTable)

        ds = Session("Sds")
        reviewer = Session("reviewer")


    End Sub



    Private Sub drawCommentTable(newComment As String, commentTable As DataTable)

        Dim moveMeUp As String

        For i = 1 To commentTable.Rows.Count - 1

            moveMeUp = commentTable.Rows(i).Item("comments")

            commentTable.Rows(i - 1).Item("comments") = moveMeUp

        Next

        commentTable.Rows(commentTable.Rows.Count - 1).Item("comments") = newComment

        Session("commentTable") = commentTable
    End Sub

    Protected Sub btnchatComment_Click(sender As Object, e As EventArgs) Handles btnchatComment.Click

        Dim newComment As String
        newComment = captureReviewAndRespond(txtNewComment.Text)

        drawCommentTable(newComment, commentTable)

    End Sub
    Public Function initialiseTable() As DataTable
        'initialise comment table with blanks

        Dim x As Integer
        Dim newRow As DataRow
        Dim commentTable As New DataTable

        commentTable.Columns.Add("comments")

        For x = 1 To 5
            newRow = commentTable.NewRow
            newRow("comments") = x.ToString
            commentTable.Rows.Add(newRow)
        Next

        Return commentTable
    End Function

    Sub redrawTable(commentTable As DataTable)

        'Building an HTML string.
        Dim html As New StringBuilder()

        'Table start.
        html.Append("<table border = '1'>")

        'Building the Header row.
        html.Append("<tr>")
        For Each column As DataColumn In commentTable.Columns
            html.Append("<th>")
            html.Append(column.ColumnName)
            html.Append("</th>")
        Next
        html.Append("</tr>")

        'Building the Data rows.
        For Each row As DataRow In commentTable.Rows
            html.Append("<tr>")
            For Each column As DataColumn In commentTable.Columns
                html.Append("<td>")
                html.Append(row(column.ColumnName))
                html.Append("</td>")
            Next
            html.Append("</tr>")
        Next

        'Table end.
        html.Append("</table>")

        'Append the HTML string to Placeholder.
        chatWindow.Controls.Add(New Literal() With {
          .Text = html.ToString()
        })
        'End If
    End Sub

    Public Function captureReviewAndRespond(newComment As String) As String
        'check comment for tag and return newComment unscathed
        If Not (newComment.StartsWith("/360")) Then

            Return newComment
            'if tag is there, check for handles, return err mesage if missing, or not valid
        ElseIf InStr(newComment, "@", CompareMethod.Binary) = False Then
            '####TODO### validate handles against database
            Return "You need to provide the correct handles to submit a review"
        Else
            'if handles are there
            'process reviews ad return succes message
            Dim handleList As New DataTable


            handleList.Columns.Add("handle")
            Dim newRow As DataRow

            Dim listOfHandles() As String
            Dim recipientHandle As String

            listOfHandles = newComment.Split(" ")



            For Each word In listOfHandles

                If Left(word, 1) = "@" Then
                    recipientHandle = word

                    newRow = handleList.NewRow()
                    newRow("handle") = recipientHandle
                    handleList.Rows.Add(newRow)
                End If

            Next

            Dim reviewerRef As String
            Dim recipientRef As String
            Dim recipientList As New DataTable

            recipientList = handleList


            reviewerRef = reviewer.Ref



            Dim comment As String
            comment = newComment

            Dim vote As New vote
            Dim handleText As String
            Dim recipientRow As DataRow()
            Dim allTheVotes As New List(Of vote)

            For Each row In recipientList.Rows
                handleText = row.item("handle")
                recipientRow = ds.Tables(0).Select("handle = '" & handleText & "'")
                recipientRef = recipientRow(0)("employeeRef")

                vote = createVote(reviewerRef, recipientRef, comment, ds)
                allTheVotes.Add(vote)

            Next
            For Each vote In allTheVotes
                writeVoteToDb(vote)
            Next

            Return "Thanks, your comments have been accepted"

        End If
    End Function
End Class
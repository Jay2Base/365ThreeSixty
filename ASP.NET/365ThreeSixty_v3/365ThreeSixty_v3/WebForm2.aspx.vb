Public Class WebForm2
    Inherits System.Web.UI.Page


    Public commentTable As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub


    Public Sub updateTable(newComment As String, commentTable As DataTable)
        'If Not Me.IsPostBack Then
        'Populating a DataTable from database.
        Call drawCommentTable(newComment, commentTable)

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
    Private Sub drawCommentTable(newComment As String, commentTable As DataTable)

        Dim moveMeUp As String

        For i = 1 To commentTable.Rows.Count - 1

            moveMeUp = commentTable.Rows(i).Item("comments")

            commentTable.Rows(i - 1).Item("comments") = moveMeUp

        Next

        commentTable.Rows(commentTable.Rows.Count - 1).Item("comments") = newComment

        ViewState("commentTable") = commentTable
    End Sub

    Protected Sub btnchatComment_Click(sender As Object, e As EventArgs) Handles btnchatComment.Click

        commentTable = ViewState("commentTable")
        If commentTable Is Nothing Then
            commentTable = initialiseTable()
        End If

        Call updateTable(txtNewComment.Text, commentTable)
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
End Class
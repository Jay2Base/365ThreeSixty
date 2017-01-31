Public Class Slackish
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
        Dim tablecode As StringBuilder
        tablecode = redrawTable(commentTable)
        chatWindow.Controls.Add(New Literal() With {
          .Text = tablecode.ToString()
        })

        ds = Session("Sds")
        reviewer = Session("reviewer")
    End Sub
    Protected Sub btnchatComment_Click(sender As Object, e As EventArgs) Handles btnchatComment.Click

        Dim newComment As String
        newComment = captureReviewAndRespond(txtNewComment.Text)

        drawCommentTable(newComment, commentTable)
        Session("commentTable") = commentTable

    End Sub
End Class
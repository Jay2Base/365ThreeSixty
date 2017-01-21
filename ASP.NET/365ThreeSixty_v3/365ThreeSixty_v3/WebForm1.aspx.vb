Public Class WebForm1
    Inherits System.Web.UI.Page

    Public ds As DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String
    Dim tblEmployees As DataTable

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim newCon As New OleDb.OleDbConnection
        newCon = openDbConnection()

        newCon.Open()
        ds = New DataSet
        sql = "select employeeRef, employeeName, tier, teamRef from employees;"
        da = New OleDb.OleDbDataAdapter(sql, newCon)
        da.FillSchema(ds, SchemaType.Source)
        da.Fill(ds)
        newCon.Close()

        frmReviewer.DataSource = ds.Tables(0)
        frmReviewer.DataTextField = "employeeName"
        frmReviewer.DataValueField = "employeeRef"
        frmReviewer.DataBind()

        updateTable()
    End Sub

    Public Sub createReviewer_Click(sender As Object, e As EventArgs) Handles createReviewer.Click
        'get list of everyone else into datatable
        'populate recipient list
        Dim thisRef = frmReviewer.SelectedValue.ToString

        Dim recipientTable As New DataTable

        recipientTable.Columns.Add("Name", GetType(String))
        recipientTable.Columns.Add("Ref", GetType(String))

        For Each row In ds.Tables(0).Rows
            If Not (row.item("employeeRef") = thisRef) Then
                recipientTable.Rows.Add(row.item("employeeName"), row.item("employeeRef"))
            End If
        Next

        'create reviewer class
        Dim reviewer As New reviewer
        reviewer = reviewerFactory.createReviewer(thisRef, ds)

        'populate recipient dropdown
        frmRecipients.DataSource = recipientTable
        frmRecipients.DataTextField = "Name"
        frmRecipients.DataValueField = "Ref"
        frmRecipients.DataBind()

        submitAreview.Visible = True
        '##todo. add admin property to class to control who can see what



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles frmSubmitReview.Click
        'create vote class
        Dim reviewerRef As String
        Dim recipientRef As String


        reviewerRef = frmReviewer.SelectedValue
        recipientRef = frmRecipients.SelectedValue
        Dim comment As String
        comment = frmComment.Text

        Dim vote As New vote
        vote = createVote(reviewerRef, recipientRef, comment, ds)
        writeVoteToDb(vote)

        PlaceHolder1.Controls.Clear()
        updateTable()

        'Response.Redirect(Request.RawUrl)


    End Sub


    Public Sub updateTable()
        'If Not Me.IsPostBack Then
        'Populating a DataTable from database.
        Dim dt As DataTable = Me.getData()

            'Building an HTML string.
            Dim html As New StringBuilder()

            'Table start.
            html.Append("<table border = '1'>")

            'Building the Header row.
            html.Append("<tr>")
            For Each column As DataColumn In dt.Columns
                html.Append("<th>")
                html.Append(column.ColumnName)
                html.Append("</th>")
            Next
            html.Append("</tr>")

            'Building the Data rows.
            For Each row As DataRow In dt.Rows
                html.Append("<tr>")
                For Each column As DataColumn In dt.Columns
                    html.Append("<td>")
                    html.Append(row(column.ColumnName))
                    html.Append("</td>")
                Next
                html.Append("</tr>")
            Next

            'Table end.
            html.Append("</table>")

            'Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(New Literal() With {
          .Text = html.ToString()
        })
        'End If
    End Sub

    Public Function getData()
        Dim dsV = New DataSet
        Dim Sql As String
        Dim daV As OleDb.OleDbDataAdapter
        Dim newCon As New OleDb.OleDbConnection

        newCon = openDbConnection()

        newCon.Open()


        Sql = "select * from reviews;"
        daV = New OleDb.OleDbDataAdapter(Sql, newCon)
        daV.FillSchema(dsV, SchemaType.Source)

        daV.Fill(dsV)

        newCon.Close()
        Return dsV.Tables(0)
    End Function





End Class
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

    Public ds As DataSet
    Dim da As System.Data.SqlClient.SqlDataAdapter
    Dim sql As String
    Dim tblEmployees As DataTable
    Private daM As New SqlDataAdapter
    Private dsM As New DataSet

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim newCon As New System.Data.SqlClient.SqlConnection
        newCon = openDbConnection()

        'newCon.Open()
        ds = New DataSet
        sql = "select employeeRef, employeeName, tier, teamRef, handle from employees;"
        da = New System.Data.SqlClient.SqlDataAdapter(sql, newCon)
        da.FillSchema(ds, SchemaType.Source)
        da.Fill(ds)

        sql = "select * from mission;"
        daM = New SqlClient.SqlDataAdapter(sql, newCon)
        daM.FillSchema(dsM, SchemaType.Source)
        daM.Fill(dsM)
        'newCon.Close()

        Session("Sds") = ds

        If Not (Page.IsPostBack) Then
            frmReviewer.DataSource = ds.Tables(0)
            frmReviewer.DataTextField = "employeeName"
            frmReviewer.DataValueField = "employeeRef"
            frmReviewer.DataBind()


        End If
        If dsM.Tables(0).Rows.Count > 0 Then
            lblMission.Text = dsM.Tables(0).Rows(0).Item("mission").ToString
        End If

    End Sub

    Public Sub createReviewer_Click(sender As Object, e As EventArgs) Handles createReviewer.Click
        'get list of everyone else into datatable
        'populate recipient list
        createNewReviewer()
        createReviewer.PostBackUrl = "~/Chat_Demo.aspx"

        Response.Redirect("Chat_Demo.aspx")





    End Sub
    Sub createNewReviewer()
        Dim thisRef = frmReviewer.SelectedValue

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
        Session("reviewer") = reviewer
    End Sub





    Public Function getData()
        Dim dsV = New DataSet
        Dim Sql As String
        Dim daV As SqlClient.SqlDataAdapter
        Dim newCon As New SqlClient.SqlConnection

        newCon = openDbConnection()

        newCon.Open()


        Sql = "select * from reviews;"
        daV = New SqlClient.SqlDataAdapter(Sql, newCon)
        daV.FillSchema(dsV, SchemaType.Source)

        daV.Fill(dsV)

        newCon.Close()
        Return dsV.Tables(0)
    End Function



    Protected Sub btnUpdateValues_Click(sender As Object, e As EventArgs) Handles btnUpdateValues.Click
        Call updateMissionStatement(txtNewMission.Text)
        lblMission.Text = txtNewMission.Text
        txtNewMission.Text.Remove(0)
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim DefaultFileName As String
        Dim employeeFilePath As String
        DefaultFileName = "uploads/"

        employeeFilePath = Server.MapPath(DefaultFileName) + staffUpload.FileName

        staffUpload.SaveAs(employeeFilePath)

        If staffUpload.HasFile Then
            ImportEmployees(da, ds, employeeFilePath)
        End If
    End Sub

    Private Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Call doFreshStart()
    End Sub
End Class
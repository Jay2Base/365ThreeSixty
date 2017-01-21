Public Class startUp
    Public ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String
    Dim tblEmployees As DataTable

    Private Sub startUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim newCon As New OleDb.OleDbConnection
        newCon = openDbConnection()

        newCon.Open()
        Sql = "select employeeRef, employeeName, tier, teamRef from employees;"
        da = New OleDb.OleDbDataAdapter(Sql, newCon)
        da.FillSchema(ds, SchemaType.Source)
        da.Fill(ds)

        reviewer.DataSource = ds.Tables(0)
        reviewer.DisplayMember = "employeeName"
        reviewer.ValueMember = "employeeRef"
    End Sub
End Class
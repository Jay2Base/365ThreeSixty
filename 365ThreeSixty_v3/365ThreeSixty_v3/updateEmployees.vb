Module updateEmployees
    Sub ImportEmployees(da As SqlClient.SqlDataAdapter, ds As DataSet, employeeFilePath As String)

        Dim Econ As New OleDb.OleDbConnection
        Dim dbProvider As String
        Dim dbSource As String
        Dim FullDatabasePath As String
        Dim SQL As String
        Dim eda As OleDb.OleDbDataAdapter
        Dim employeeInput As New DataSet


        employeeFilePath = Replace(employeeFilePath, "\", "/")


        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        FullDatabasePath = employeeFilePath
        dbSource = "Data Source = " & FullDatabasePath & ";EXTENDED PROPERTIES = EXCEL 12.0"

        Econ.ConnectionString = dbProvider & dbSource
        Econ.Open()

        SQL = "select * from [Sheet1$]"

        eda = New OleDb.OleDbDataAdapter(SQL, Econ)
        eda.Fill(employeeInput)
        Econ.Close()
        'update empyees table

        Dim cb As New SqlClient.SqlCommandBuilder(da)

        'empty the table    
        For Each row In ds.Tables(0).Rows
            row.delete()
        Next

        da.Update(ds)
        'refil with spreadsheet data
        Dim dsNewRow As DataRow

        For Each row In employeeInput.Tables(0).Rows
            dsNewRow = ds.Tables(0).NewRow()


            dsNewRow.Item("employeeRef") = row.Item("employeeRef")
            dsNewRow.Item("employeeName") = row.Item("employeeName")
            dsNewRow.Item("tier") = row.Item("tier")
            dsNewRow.Item("teamRef") = row.Item("teamRef")
            dsNewRow.Item("handle") = row.item("Handle")

            ds.Tables(0).Rows.Add(dsNewRow)

        Next
        Dim rows = da.Update(ds)

    End Sub
End Module

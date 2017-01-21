Public Class Form1

    Dim con As New OleDb.OleDbConnection
    Dim dbProvider As String
    Dim dbSource As String
    Dim MyDocumentsFolder As String
    Dim TheDatabase As String
    Dim FullDatabasePath As String

    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String

    Dim inc As Integer
    Dim maxRows As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        TheDatabase = "/365ThreeSixty.accdb"
        MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        FullDatabasePath = "C:/Users/jayra/Google Drive/365threesixty" & TheDatabase
        dbSource = "Data Source = " & FullDatabasePath

        con.ConnectionString = dbProvider & dbSource
        con.Open()
        'MessageBox.Show("db.open")
        sql = "select * from employees;"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "Employees")



        con.Close()
        'MessageBox.Show("db closed")

        maxRows = ds.Tables("Employees").Rows.Count
        inc = -1
    End Sub
    Private Sub navigateRecords()
        employeeName.Text = ds.Tables("Employees").Rows(inc).Item(1)
        tier.Text = ds.Tables("Employees").Rows(inc).Item(2)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New OleDb.OleDbCommandBuilder(da)

        ds.Tables("Employees").Rows(1).Item(1) = employeeName.Text
        ds.Tables("Employees").Rows(1).Item(2) = tier.Text

        da.Update(ds, "Employees")

        MessageBox.Show("Data updated")
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnCommit.Enabled = True
        btnAddNew.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

        employeeName.Clear()
        tier.Clear()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnCommit.Enabled = False
        btnAddNew.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True

        inc = 0
        navigateRecords()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click


        Dim cb As New OleDb.OleDbCommandBuilder(da)

        Dim dsNewRow As DataRow

        dsNewRow = ds.Tables("Employees").NewRow()

            dsNewRow.Item("employeeName") = employeeName.Text
            dsNewRow.Item("tier") = tier.Text

        ds.Tables("Employees").Rows.Add(dsNewRow)

        dsNewRow = ds.Tables("Employees").NewRow()

        dsNewRow.Item("employeeName") = employeeName.Text
        dsNewRow.Item("tier") = tier.Text

        ds.Tables("Employees").Rows.Add(dsNewRow)



        da.Update(ds, "Employees")

            MessageBox.Show("New Record added to the Database")

            btnCommit.Enabled = False
            btnAddNew.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True


    End Sub
End Class

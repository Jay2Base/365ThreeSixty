Imports System.Data.OleDb

Public Class Form1


    Public ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String
    Dim tblEmployees As DataTable
    Dim tblExclusions As DataTable

    Dim Econ As New OleDb.OleDbConnection
    Dim employeeInput As New DataSet
    Dim eda As OleDb.OleDbDataAdapter


    Dim inc As Integer
    Dim maxRows As Integer
    Private daX As OleDbDataAdapter
    Private dsX As New DataSet
    Private daK As OleDbDataAdapter
    Public dsK As New DataSet
    Private daV As OleDbDataAdapter
    Public dsV As New DataSet

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim newCon As New OleDb.OleDbConnection
        newCon = openDbConnection()

        newCon.Open()
        sql = "select employeeRef, employeeName, tier, teamRef from employees;"
        da = New OleDb.OleDbDataAdapter(sql, newCon)
        da.FillSchema(ds, SchemaType.Source)
        da.Fill(ds)


        sql = "select * from keywordDictionary;"
        daK = New OleDb.OleDbDataAdapter(sql, newCon)
        daK.FillSchema(dsK, SchemaType.Source)
        daK.Fill(dsK)

        sql = "select * from reviews;"
        daV = New OleDb.OleDbDataAdapter(sql, newCon)
        daV.FillSchema(dsV, SchemaType.Source)

        daV.Fill(dsV)

        newCon.Close()


        txtMissionStatement.Visible = False
        btnSubmit.Visible = False



    End Sub
    Private Sub btnImportEmployees_Click(sender As Object, e As EventArgs) Handles btnImportEmployees.Click
        Dim employeeFilePath As String
        Dim dialog As New OpenFileDialog()
        Dim con As New OleDb.OleDbConnection
        Dim dbProvider As String
        Dim dbSource As String
        Dim MyDocumentsFolder As String
        Dim TheDatabase As String
        Dim FullDatabasePath As String

        If DialogResult.OK = dialog.ShowDialog Then
            employeeFilePath = Replace(dialog.FileName, "\", "/")
        Else
            Exit Sub
        End If

        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        FullDatabasePath = employeeFilePath
        dbSource = "Data Source = " & FullDatabasePath & ";EXTENDED PROPERTIES = EXCEL 12.0"

        Econ.ConnectionString = dbProvider & dbSource
        Econ.Open()

        sql = "select * from [Sheet1$]"

        eda = New OleDb.OleDbDataAdapter(sql, Econ)
        eda.Fill(employeeInput)
        Econ.Close()

        Dim cb As New OleDb.OleDbCommandBuilder(da)

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

            ds.Tables(0).Rows.Add(dsNewRow)

        Next
        Dim rows = da.Update(ds)

        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "employeeName"
        ComboBox1.ValueMember = "employeeRef"
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtMissionStatement.Visible = True
        btnSubmit.Visible = True

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim newRow As DataRow

        'CLEAR DOWN EXISITING KEYWORDS
        Dim cb As New OleDb.OleDbCommandBuilder(daK)
        For Each row In dsK.Tables(0).Rows
            row.delete()
        Next

        daK.Update(dsK)

        'SPLIT MISSION INTO DATASET
        Dim statement As String
        statement = txtMissionStatement.Text
        statement = Replace(statement, ",", "")
        statement = Replace(statement, ".", "")
        statement = Replace(statement, ";", "")
        statement = Replace(statement, ":", "")
        statement = Replace(statement, "!", "")
        statement = Replace(statement, "?", "")
        Dim keywordArray As String() = statement.Split(" ")

        Dim keywordTable As New DataTable
        keywordTable.Columns.Add("keywords")
        For Each item In keywordArray

            newRow = keywordTable.NewRow()
            newRow(0) = item
            keywordTable.Rows.Add(newRow)
        Next

        'GET THE EXCLUSIONS FROM DB

        Dim newCon As New OleDb.OleDbConnection
        newCon = openDbConnection()
        newCon.Open()
        sql = "select * from exclusions;"
        daX = New OleDb.OleDbDataAdapter(sql, newCon)
        daX.FillSchema(dsX, SchemaType.Source)
        daX.Fill(dsX)
        newCon.Close()

        'COMPARE STATEMENTS WITH EXCLUSIONS
        Dim i As Integer
        Dim k As String
        Dim x As String

        Dim originalNumberOfKeyword As Integer
        originalNumberOfKeyword = keywordTable.Rows.Count

        Dim keywordsLeft As Integer
        keywordsLeft = originalNumberOfKeyword

        For i = 0 To originalNumberOfKeyword - 1
            If i > keywordsLeft Then Exit For

            For Each row In dsX.Tables(0).Rows

                k = keywordArray(i).ToString
                x = row.ToString

                If k = x Then
                    keywordTable.Rows(i).Delete()
                    keywordsLeft = keywordTable.Rows.Count
                    i = i - 1
                    Exit For
                End If
            Next
        Next i

        'WRITE TO KEYWORD TABLE
        For Each row In keywordTable.Rows
            newRow = dsK.Tables(0).NewRow()
            newRow(1) = row.item("keywords")
            dsK.Tables(0).Rows.Add(newRow)
        Next
        daK.Update(dsK)




        txtMissionStatement.Visible = False
        btnSubmit.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reviewerRef As String
        Dim recipientRef As String
        Dim Vote As vote

        reviewerRef = ComboBox1.SelectedValue
            recipientRef = ComboBox2.SelectedValue


            Dim cb As New OleDb.OleDbCommandBuilder(daV)
        Dim comment As String
        comment = InputBox("Write a comment")

        Vote = createVote(reviewerRef, recipientRef, comment)

        Dim newRow As DataRow

            newRow = dsV.Tables(0).NewRow()
            newRow("reviewerRef") = Vote.reviewer
            newRow("recipientRef") = Vote.recipient
            newRow("reviewDate") = Today()
            newRow("deltaFactor") = Vote.tierFactor
            newRow("rawScore") = Vote.rawScore
        newRow("weightedScore") = Vote.weightedScore
        newRow("reviewerFactor") = Vote.reviewerFactor
        newRow("reviewerScore") = Vote.reviewerScore
        newRow("recipientFactor") = Vote.RecipientFactor
        newRow("recipientScore") = Vote.recipientScore
        newRow("commentFactor") = Vote.commentScore
        newRow("comment") = Vote.comment

        dsV.Tables(0).Rows.Add(newRow)
        daV.Update(dsV)

        MessageBox.Show("Feedback has been recieved, thanks.")

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'populate recipient list
        Dim thisRef = ComboBox1.SelectedValue.ToString

        Dim recipientTable As New DataTable
        ComboBox2.DisplayMember = "Name"
        ComboBox2.ValueMember = "Ref"

        recipientTable.Columns.Add("Name", GetType(String))
        recipientTable.Columns.Add("Ref", GetType(String))

        For Each row In ds.Tables(0).Rows
            If Not (row.item("employeeRef") = thisRef) Then
                recipientTable.Rows.Add(row.item("employeeName"), row.item("employeeRef"))
            End If
        Next
        ComboBox2.DataSource = recipientTable
            ComboBox2.DisplayMember = "Name"
            ComboBox2.ValueMember = "Ref"

    End Sub
End Class

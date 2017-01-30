Public Module reviewerFactory

    Public Function createReviewer(reviewerRef As String, ds As DataSet) As reviewer

        Dim f As New reviewer()

        f.tier = getTier(reviewerRef, ds)
        f.team = getTeam(reviewerRef, ds)
        f.Ref = Val(reviewerRef)
        f.ReviewsInLast7Days = getVotesSent("reviewer", reviewerRef)
        Return f

    End Function
    Public Function createRecipient(recipientRef As String, ds As DataSet) As recipient

        Dim f As New recipient()

        f.tier = getTier(recipientRef, ds)
        f.team = getTeam(recipientRef, ds)
        f.Ref = Val(recipientRef)
        f.ReviewsInLast7Days = getVotesSent("recipient", recipientRef)
        Return f

    End Function

    Public Function getTier(Ref, ds) As Integer


        Dim tab As DataTable
        tab = ds.Tables(0)

        Dim foundRows() As DataRow
        foundRows = tab.Select("employeeRef = " & Ref)

        Dim emp As Integer
        emp = foundRows(0)("tier")
        Return emp


    End Function


    Public Function getTeam(Ref, ds) As Integer


        Dim tab As DataTable
        tab = ds.Tables(0)

        Dim foundRows() As DataRow
        foundRows = tab.Select("employeeRef = " & Ref)

        Dim emp As Integer
        emp = foundRows(0)("teamRef")
        Return emp


    End Function

    Public Function getVotesSent(EmployeeType As String, Ref As String)

        Dim newCon As New SqlClient.SqlConnection
        newCon = openDbConnection()

        newCon.Open()
        Dim dsV = New DataSet
        Dim Sql As String
        Dim daV As SqlClient.SqlDataAdapter

        Sql = "select * from reviews;"
        daV = New SqlClient.SqlDataAdapter(Sql, newCon)
        daV.FillSchema(dsV, SchemaType.Source)

        daV.Fill(dsV)

        newCon.Close()



        Dim tab As DataTable
        tab = dsV.Tables(0)

        Dim typeString As String

        If EmployeeType = "reviewer" Then
            typeString = "reviewerRef"
        ElseIf EmployeeType = "recipient" Then
            typeString = "recipientRef"
        Else
            Return Err.Description

        End If

        Dim startDate As String
        startDate = Today.AddDays(-7).ToString("MM/dd/yyyy")

        Dim querySTring As String
        querySTring = typeString & " = " & Ref & " and reviewDate >= #" & startDate & "#"

        Dim foundRows() As DataRow
        foundRows = tab.Select(querySTring)

        Dim votesSent As Integer
        votesSent = foundRows.Count
        Return votesSent
    End Function


End Module

Public Module reviewerFactory

    Public Function createReviewer(reviewerRef As String) As reviewer

        Dim f As New reviewer()

        f.tier = getTier(reviewerRef)
        f.team = getTeam(reviewerRef)
        f.Ref = Val(reviewerRef)
        f.ReviewsInLast7Days = getVotesSent("reviewer", reviewerRef)
        Return f

    End Function
    Public Function createRecipient(recipientRef As String) As recipient

        Dim f As New recipient()

        f.tier = getTier(recipientRef)
        f.team = getTeam(recipientRef)
        f.Ref = Val(recipientRef)
        f.ReviewsInLast7Days = getVotesSent("recipient", recipientRef)
        Return f

    End Function

    Public Function getTier(Ref) As Integer


        Dim tab As DataTable
        tab = Form1.ds.Tables(0)

        Dim foundRows() As DataRow
        foundRows = tab.Select("employeeRef = " & Ref)

        Dim emp As Integer
        emp = foundRows(0)("tier")
        Return emp


    End Function


    Public Function getTeam(Ref) As Integer


        Dim tab As DataTable
        tab = Form1.ds.Tables(0)

        Dim foundRows() As DataRow
        foundRows = tab.Select("employeeRef = " & Ref)

        Dim emp As Integer
        emp = foundRows(0)("teamRef")
        Return emp


    End Function

    Private Function getVotesSent(EmployeeType, Ref)
        Dim tab As DataTable
        tab = Form1.dsV.Tables(0)

        Dim typeString As String

        If EmployeeType = "reviewer" Then
                typeString = "reviewerRef"
            ElseIf EmployeeType = "recipient" Then
                typeString = "recipientRef"
            Else
            Return Err.Description

        End If

        Dim foundRows() As DataRow
        foundRows = tab.Select(typeString & " = " & Ref & "and reviewDate <= #" & Today.AddDays(-7) & "#")

        Dim votesSent As Integer
        votesSent = foundRows.Count
        Return votesSent
    End Function



End Module

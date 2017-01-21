Module voteFactory
    Public Function createVote(reviewerRef As Integer, recipientRef As Integer, comment As String, ds As DataSet)

        Dim reviewer As reviewer
        Dim recipient As recipient

        Dim v As vote

        v = New vote

        reviewer = createReviewer(reviewerRef, ds)
        recipient = createRecipient(recipientRef, ds)

        v.reviewer = reviewer.Ref
        v.recipient = recipient.Ref
        v.rawScore = 100
        v.tierFactor = getTierDeltaScore(reviewer.tier, recipient.tier)

        v.reviewerFactor = 0.9
        v.reviewerScore = getReviewerScore(v.reviewerFactor, reviewer.ReviewsInLast7Days)

        v.RecipientFactor = 0.9
        v.recipientScore = getRecipientScore(v.RecipientFactor, recipient.ReviewsInLast7Days)

        v.comment = comment
        v.commentScore = getCommentScore(comment)

        v.weightedScore = v.rawScore * v.tierFactor * v.reviewerScore * v.recipientScore * v.commentScore

        Return v
    End Function

    Public Function getTierDeltaScore(reviewerTier, recipientTier) As Double
        Dim DeltaScore As Double
        If reviewerTier >= recipientTier Then
            DeltaScore = 1 + (reviewerTier - recipientTier) / 10
        Else
            DeltaScore = 1 + (recipientTier - reviewerTier) / 10
        End If

        Return DeltaScore

    End Function

    Private Function getReviewerScore(factor As Double, ReviewsInLast7Days As Integer) As Double

        Dim ReviewerScore As Double

        ReviewerScore = factor ^ (ReviewsInLast7Days)
        Return ReviewerScore
    End Function

    Private Function getRecipientScore(factor As Double, ReviewsInLast7Days As Integer) As Double

        Dim recipientScore As Double

        recipientScore = factor ^ (ReviewsInLast7Days)
        Return recipientScore
    End Function

    Private Function getCommentScore(comment As String)



        '2 load review into array

        Dim reviewTable As New DataTable
        Dim reviewArray() As String
        comment = Replace(comment, ",", "")
        comment = Replace(comment, ".", "")
        comment = Replace(comment, ";", "")
        comment = Replace(comment, ":", "")


        reviewArray = comment.Split(" ")

        reviewTable.Columns.Add("commentWord")

        For Each word In reviewArray
            reviewTable.Rows.Add.Item("commentWord") = word
        Next

        'collect keywords
        Dim newCon As New OleDb.OleDbConnection
        newCon = openDbConnection()

        newCon.Open()
        Dim dsK = New DataSet
        Dim Sql As String
        Dim daK As OleDb.OleDbDataAdapter

        Sql = "select * from keywordDictionary;"
        daK = New OleDb.OleDbDataAdapter(Sql, newCon)
        daK.FillSchema(dsK, SchemaType.Source)

        daK.Fill(dsK)

        newCon.Close()


        'for each elemnent get a fuzzy percentage

        Dim matchRate As Single
        Dim totalMatchScore As Double

        totalMatchScore = 0
        For Each keyword In dsK.Tables(0).Rows
            For Each review In reviewTable.Rows

                matchRate = FuzzyPercent(keyword.item("keyword"), review.item("commentWord"))

                If matchRate >= 0.8 Then
                    totalMatchScore = totalMatchScore + 1
                End If

            Next

        Next
        Dim numberOfKeywords As Integer
        numberOfKeywords = dsK.Tables(0).Rows.Count

        If totalMatchScore > numberOfKeywords Then
            totalMatchScore = 2
        Else
            totalMatchScore = 1 + (totalMatchScore / numberOfKeywords)
        End If
        Return totalMatchScore
    End Function

    Public Sub writeVoteToDb(vote As vote)
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
        Dim cb As New OleDb.OleDbCommandBuilder(daV)
        Dim newRow As DataRow

        newRow = dsV.Tables(0).NewRow()
        newRow("reviewerRef") = vote.reviewer
        newRow("recipientRef") = vote.recipient
        newRow("reviewDate") = Today()
        newRow("deltaFactor") = vote.tierFactor
        newRow("rawScore") = vote.rawScore
        newRow("weightedScore") = vote.weightedScore
        newRow("reviewerFactor") = vote.reviewerFactor
        newRow("reviewerScore") = vote.reviewerScore
        newRow("recipientFactor") = vote.RecipientFactor
        newRow("recipientScore") = vote.recipientScore
        newRow("commentFactor") = vote.commentScore
        newRow("comment") = vote.comment

        dsV.Tables(0).Rows.Add(newRow)
        daV.Update(dsV)

        MsgBox("Feedback has been recieved, thanks.")
    End Sub
End Module

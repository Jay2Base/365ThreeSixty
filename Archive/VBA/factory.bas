Attribute VB_Name = "factory"
Option Compare Database
Option Explicit

Public Function createReviewer(Ref As Integer)

Set createReviewer = New reviewer
    
Dim tier As Integer
Dim Team As Integer
Dim ReviewsInLast7Days As Integer
Dim teamSize As Integer

    tier = getTier(Ref)
    Team = getTeam(Ref)
    ReviewsInLast7Days = getVotesSent(Ref)
    teamSize = getteamSIze(Ref, Team)
    
    
createReviewer.initiateProperties Ref:=Ref, tier:=tier, Team:=Team, ReviewsInLast7Days:=ReviewsInLast7Days, teamSize:=teamSize

End Function



Public Function createRecipient(Ref As Integer)

Set createRecipient = New recipient
    
Dim tier As Integer
Dim Team As Integer
Dim ReviewsRecievedInLast7Days As Integer
Dim teamSize As Integer
    
    tier = getTier(Ref)
    Team = getTeam(Ref)
    ReviewsRecievedInLast7Days = getVotesRecieved(Ref)
    teamSize = getteamSIze(Ref, Team)

    
createRecipient.initiateProperties Ref:=Ref, tier:=tier, Team:=Team, ReviewsRecievedInLast7Days:=ReviewsRecievedInLast7Days, teamSize:=teamSize

End Function
Private Function getTier(Ref) As Integer
    getTier = DLookup("tier", "employees", "employeeRef = " & Ref)
End Function

Private Function getTeam(Ref) As Integer
    getTeam = DLookup("teamRef", "employees", "employeeRef = " & Ref)
End Function

Private Function getVotesSent(Ref)
    getVotesSent = DCount("voteRef", "reviews", "reviewerRef = " & Ref)
End Function

Private Function getVotesRecieved(Ref)
    getVotesRecieved = DCount("voteRef", "reviews", "recipientRef = " & Ref)
End Function
Private Function getteamSIze(Ref, Team)
    getteamSIze = DCount("employeeRef", "employees", "teamRef = " & Team)
End Function

Public Function createVote(reviewerRef As Integer, recipientRef As Integer, Score As Integer, comment As String, reviewerTeam As Integer, recipientTeam As Integer, reviewerTier As Integer, recipientTier As Integer, ReviewsInLast7Days As Integer, ReviewsRecievedInLast7Days As Integer, reviewerTeamSize As Integer, recieverTeamSize As Integer)

Set createVote = New vote

Dim reviewerScore As Double
    reviewerScore = getReviewerScore(ReviewsInLast7Days, reviewerTeamSize)
Dim recieverScore As Double
    recieverScore = getRecieverScore(ReviewsRecievedInLast7Days, recieverTeamSize)
Dim deltaScore As Double
    deltaScore = getDeltaScore(reviewerTier, recipientTier)
Dim commentScore As Double
    commentScore = getCommentMatchScore(comment)
    
Dim weightedScore As Double
weightedScore = Score * reviewerScore * recieverScore * deltaScore * commentScore

      
createVote.initiateProperties reviewer:=reviewerRef, recipient:=recipientRef, Score:=Score, comment:=comment, weightedScore:=weightedScore, commentScore:=commentScore

End Function

Private Function getReviewerScore(ReviewsInLast7Days, reviewerTeamSize) As Double
Dim Factor As Double
Factor = 0.9

    getReviewerScore = Factor ^ (ReviewsInLast7Days)
End Function

Private Function getRecieverScore(ReviewsRecievedInLast7Days, recieverTeamSize) As Double
Dim Factor As Double
Factor = 0.9
    getRecieverScore = Factor ^ (ReviewsRecievedInLast7Days)
End Function

Private Function getDeltaScore(reviewerTier, recipientTier)

If reviewerTier >= recipientTier Then
    getDeltaScore = 1 + (reviewerTier - recipientTier) / 10
Else
    getDeltaScore = 1 + (recipientTier - reviewerTier) / 10
End If
End Function

Private Function getCommentMatchScore(comment)

'1-load keywords into array
Dim dbs As DAO.Database
Dim keywordsArray() As Variant
Dim rstData    As DAO.Recordset

Set dbs = CurrentDb

Set rstData = dbs.OpenRecordset("keywordDictionary", dbOpenTable)
keywordsArray() = rstData.GetRows(rstData.RecordCount)

'2-load review into array

Dim reviewArray As Variant
reviewArray = Replace(comment, ",", "")
reviewArray = Replace(comment, ".", "")
reviewArray = Replace(comment, ";", "")
reviewArray = Replace(comment, ":", "")

reviewArray = Split(comment, " ")

'for each elemnent get a fuzzy percentage
Dim k As Integer
Dim r As Integer
Dim matchRate As Single
Dim totalMatchScore
For k = 0 To UBound(keywordsArray, 2)
    For r = 0 To UBound(reviewArray, 1)
    
        matchRate = FuzzyPercent(keywordsArray(1, k), reviewArray(r))
        'Debug.Print (keywordsArray(1, k) & " - " & reviewArray(r) & ": " & "matchrate= " & matchRate)
        If matchRate >= 0.8 Then
            totalMatchScore = totalMatchScore + 1
        End If
            
    Next r
    
Next k
    If totalMatchScore > UBound(keywordsArray, 2) Then
        totalMatchScore = 2
    Else
        totalMatchScore = 1 + totalMatchScore / UBound(keywordsArray, 2)
    End If
    getCommentMatchScore = totalMatchScore
End Function

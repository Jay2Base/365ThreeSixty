Attribute VB_Name = "factory"
Option Compare Database
Option Explicit

Public Function createReviewer(Ref As Integer)

Set createReviewer = New reviewer
    
Dim tier As Integer
Dim Team As Integer
Dim ReviewsInLast7Days As Integer

    tier = getTier(Ref)
    Team = getTeam(Ref)
    ReviewsInLast7Days = getVotesSent(Ref)
    
createReviewer.initiateProperties Ref:=Ref, tier:=tier, Team:=Team, ReviewsInLast7Days:=ReviewsInLast7Days

End Function



Public Function createRecipient(Ref As Integer)

Set createRecipient = New recipient
    
Dim tier As Integer
Dim Team As Integer
Dim ReviewsRecievedInLast7Days As Integer
    
    tier = getTier(Ref)
    Team = getTeam(Ref)
    ReviewsRecievedInLast7Days = getVotesRecieved(Ref)

    
createRecipient.initiateProperties Ref:=Ref, tier:=tier, Team:=Team, ReviewsRecievedInLast7Days:=ReviewsRecievedInLast7Days

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

Public Function createVote(reviewerRef As Integer, recipientRef As Integer, score As Integer, comment As String)

Set createVote = New vote

'stuff
      
createVote.initiateProperties reviewer:=reviewerRef, recipient:=recipientRef, score:=score, comment:=comment

End Function

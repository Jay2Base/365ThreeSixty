Attribute VB_Name = "main"
Option Compare Database
Option Explicit

Sub captureReview()

'create reviewer class
Dim sender As reviewer
Set sender = factory.createReviewer(2)
 
'create recipient class
Dim reciever As recipient
Set reciever = factory.createRecipient(1)

'create a vote
Dim v As vote
Set v = factory.createVote(sender.Ref, reciever.Ref, 100, "gettin", sender.Team, reciever.Team, sender.tier, reciever.tier, sender.ReviewsInLast7Days, reciever.ReviewsRecievedInLast7Days, sender.teamSize, reciever.teamSize)


'write vote to database
Dim writeVoteToDB As String
writeVoteToDB = "INSERT INTO reviews ( reviewerRef, recipientRef, reviewDate, rawScore, review, weightedScore ) SELECT " & v.reviewer & ", " & v.recipient & ", #" & Format(Now(), "yyyy-mm-dd hh:mm:ss") & "#, " & v.rawScore & ", '" & v.comment & "', " & v.weightedScore & ";"
Debug.Print writeVoteToDB
Application.DoCmd.RunSQL writeVoteToDB
 
End Sub

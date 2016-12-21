VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "recipient"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Compare Database
Option Explicit

Private pTier As Integer
Private pTeam As Integer
Private pReviewsRecievedInLast7Days As Integer
Private pRef As Integer

Public Sub initiateProperties(Ref As Integer, tier As Integer, Team As Integer, ReviewsRecievedInLast7Days As Integer)

pTier = tier
pTeam = Team
pRef = Ref
pReviewsRecievedInLast7Days = ReviewsRecievedInLast7Days

End Sub

Public Property Get tier() As Integer
tier = pTier
End Property

Public Property Get Team() As Integer
Team = pTeam
End Property

Public Property Get Ref() As Integer
Ref = pRef
End Property

Public Property Get ReviewsRecievedInLast7Days() As Integer
ReviewsRecievedInLast7Days = pReviewsRecievedInLast7Days
End Property


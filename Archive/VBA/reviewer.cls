VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "reviewer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Compare Database
Option Explicit

Private pTier As Integer
Private pTeam As Integer
Private pReviewsInLast7Days As Integer
Private pRef As Integer
Private pTeamSize As Integer

Public Sub initiateProperties(Ref As Integer, tier As Integer, Team As Integer, ReviewsInLast7Days As Integer, teamSize As Integer)

pTier = tier
pTeam = Team
pRef = Ref
pReviewsInLast7Days = ReviewsInLast7Days
pTeamSize = teamSize

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

Public Property Get ReviewsInLast7Days() As Integer
ReviewsInLast7Days = pReviewsInLast7Days
End Property

Public Property Get teamSize() As Integer
teamSize = pTeamSize
End Property

VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "vote"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Compare Database
Option Explicit

Private pReviewer As Integer
Private pRecipient As Integer
Private pRawScore As Integer
Private pWeightedScore As Double
Private pComment As String

Public Sub initiateProperties(reviewer As Integer, recipient As Integer, score As Integer, comment As String, weightedScore As Double)

pReviewer = reviewer
pRecipient = recipient
pRawScore = score
pComment = comment
pWeightedScore = weightedScore

End Sub

Public Property Get reviewer() As Integer
reviewer = pReviewer
End Property

Public Property Get recipient() As Integer
recipient = pRecipient
End Property
Public Property Get rawScore() As Integer
rawScore = pRawScore
End Property
Public Property Get comment() As String
comment = pComment
End Property
Public Property Get weightedScore() As String
weightedScore = pWeightedScore
End Property



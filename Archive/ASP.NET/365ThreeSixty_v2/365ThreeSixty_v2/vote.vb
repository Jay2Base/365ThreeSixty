Public Class vote
    Private pReviewerRef As Integer
    Private pRecipientRef As Integer
    Private pRawScore As Integer
    Private pWeightedScore As Double
    Private pComment As String
    Private pCommentScore As Double
    Private pTierFactor As Double
    Private pReviewerFactor As Double
    Private pReviewerScore As Double
    Private pRecipientFactor As Double
    Private pRecipientScore As Double

    Public Property reviewer() As Integer
        Get
            Return pReviewerRef
        End Get
        Set(value As Integer)
            pReviewerRef = value
        End Set
    End Property

    Public Property recipient() As Integer
        Get
            Return pRecipientRef
        End Get
        Set(value As Integer)
            pRecipientRef = value
        End Set
    End Property

    Public Property rawScore() As Integer
        Get
            Return pRawScore
        End Get
        Set(value As Integer)
            pRawScore = value
        End Set
    End Property

    Public Property weightedScore() As Double
        Get
            Return pWeightedScore
        End Get
        Set(value As Double)
            pWeightedScore = value
        End Set
    End Property

    Public Property tierFactor() As Double
        Get
            Return pTierFactor
        End Get
        Set(value As Double)
            pTierFactor = value
        End Set
    End Property

    Public Property reviewerFactor() As Double
        Get
            Return pReviewerFactor
        End Get
        Set(value As Double)
            pReviewerFactor = value
        End Set
    End Property
    Public Property reviewerScore() As Double
        Get
            Return pReviewerScore
        End Get
        Set(value As Double)
            pReviewerScore = value
        End Set
    End Property
    Public Property RecipientFactor() As Double
        Get
            Return pRecipientFactor
        End Get
        Set(value As Double)
            pRecipientFactor = value
        End Set
    End Property
    Public Property recipientScore() As Double
        Get
            Return pRecipientScore
        End Get
        Set(value As Double)
            pRecipientScore = value
        End Set
    End Property

    Public Property comment() As String
        Get
            Return pComment
        End Get
        Set(value As String)
            pComment = value
        End Set
    End Property

    Public Property commentScore As Double
        Get
            Return pCommentScore
        End Get
        Set(value As Double)
            pCommentScore = value
        End Set
    End Property
End Class
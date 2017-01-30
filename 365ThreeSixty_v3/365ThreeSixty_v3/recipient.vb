Public Class recipient
    Private pTier As Integer
    Private pTeam As Integer
    Private pReviewsInLast7Days As Integer
    Private pRef As Integer
    Private pTeamSize As Integer
    Private value As Integer

    Public Property Ref() As Integer
        Get
            Return pRef
        End Get
        Set(value As Integer)
            pRef = value
        End Set
    End Property

    Public Property tier() As Integer
        Get
            Return pTier
        End Get
        Set(value As Integer)
            pTier = value
        End Set
    End Property

    Public Property team() As Integer
        Get
            Return pTeam
        End Get
        Set(value As Integer)
            pTeam = value
        End Set
    End Property
    Public Property ReviewsInLast7Days() As Integer
        Get
            Return pReviewsInLast7Days
        End Get
        Set(value As Integer)
            pReviewsInLast7Days = value
        End Set
    End Property
End Class

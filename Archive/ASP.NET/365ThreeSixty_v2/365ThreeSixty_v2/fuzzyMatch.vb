Module fuzzyMatch
    Function FuzzyPercent(ByVal String1 As String,
                      ByVal String2 As String,
                      Optional Algorithm As Integer = 3,
                      Optional Normalised As Boolean = False) As Single
        '*************************************
        '** Return a % match on two strings **
        '*************************************
        Dim intLen1 As Integer, intLen2 As Integer

        Dim intScore As Integer
        Dim intTotScore As Integer


        '-------------------------------------------------------
        '-- If strings havent been normalised, normalise them --
        '-------------------------------------------------------
        If Normalised = False Then
            String1 = LCase$(Trim(String1))
            String2 = LCase$(Trim(String2))
        End If

        '----------------------------------------------
        '-- Give 100% match if strings exactly equal --
        '----------------------------------------------
        If String1 = String2 Then
            Return 1
            Exit Function
        End If

        intLen1 = Len(String1)
        intLen2 = Len(String2)

        '----------------------------------------
        '-- Give 0% match if string length < 2 --
        '----------------------------------------
        If intLen1 < 2 Then
            Return 0
            Exit Function
        End If

        intTotScore = 0                   'initialise total possible score
        intScore = 0                      'initialise current score

        '--------------------------------------------------------
        '-- If Algorithm = 1 or 3, Search for single characters --
        '--------------------------------------------------------
        If (Algorithm And 1) <> 0 Then
            FuzzyAlg1(String1, String2, intScore, intTotScore)
            If intLen1 < intLen2 Then FuzzyAlg1(String2, String1, intScore, intTotScore)
        End If

        '-----------------------------------------------------------
        '-- If Algorithm = 2 or 3, Search for pairs, triplets etc. --
        '-----------------------------------------------------------
        If (Algorithm And 2) <> 0 Then
            FuzzyAlg2(String1, String2, intScore, intTotScore)
            If intLen1 < intLen2 Then FuzzyAlg2(String2, String1, intScore, intTotScore)
        End If

        FuzzyPercent = intScore / intTotScore

    End Function
    Private Sub FuzzyAlg1(ByVal String1 As String,
                          ByVal String2 As String,
                          ByRef Score As Integer,
                          ByRef TotScore As Integer)
        Dim intLen1 As Integer, intPos As Integer, intPtr As Integer, intStartPos As Integer

        intLen1 = Len(String1)
        TotScore = TotScore + intLen1              'update total possible score
        intPos = 0
        For intPtr = 1 To intLen1
            intStartPos = intPos + 1
            intPos = InStr(intStartPos, String2, Mid$(String1, intPtr, 1))
            If intPos > 0 Then
                If intPos > intStartPos + 3 Then     'No match if char is > 3 bytes away
                    intPos = intStartPos
                Else
                    Score = Score + 1          'Update current score
                End If
            Else
                intPos = intStartPos
            End If
        Next intPtr
    End Sub
    Private Sub FuzzyAlg2(ByVal String1 As String,
                            ByVal String2 As String,
                            ByRef Score As Integer,
                            ByRef TotScore As Integer)
        Dim intCurLen As Integer, intLen1 As Integer, intTo As Integer, intPtr As Integer, intPos As Integer
        Dim strWork As String

        intLen1 = Len(String1)
        For intCurLen = 2 To intLen1
            strWork = String2                          'Get a copy of String2
            intTo = intLen1 - intCurLen + 1
            TotScore = TotScore + Int(intLen1 / intCurLen)  'Update total possible score
            For intPtr = 1 To intTo Step intCurLen
                intPos = InStr(strWork, Mid$(String1, intPtr, intCurLen))
                If intPos > 0 Then
                    Mid(strWork, intPos, intCurLen) = intCurLen.ToString 'corrupt found string
                    Score = Score + 1     'Update current score
                End If
            Next intPtr
        Next intCurLen

    End Sub
End Module

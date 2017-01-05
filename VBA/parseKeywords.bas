Attribute VB_Name = "parseKeywords"
Option Compare Database
Option Explicit

Public Sub captureNewKeywords()

Dim testString As String

testString = "To create the best human resources platforms tools and services in the world"

'clear down existing keywords
DoCmd.RunSQL "DELETE keywordDictionary.[keywordIndex], keywordDictionary.[keyword] FROM keywordDictionary;"

'split mission sattemt into string array - excluding conjunctives and prononuns
Dim keywordArray As Variant
testString = Replace(testString, ",", "")
testString = Replace(testString, ".", "")
testString = Replace(testString, ";", "")
testString = Replace(testString, ":", "")

keywordArray = Split(testString, " ")

'add it all to a collection
Dim keywordCollection As Collection
Dim Keyword As Variant

Set keywordCollection = New Collection

For Each Keyword In keywordArray
    keywordCollection.Add (Keyword)
Next Keyword

'get the exclusions from the db
Dim dbs As DAO.Database
Dim exclusionArray() As Variant
Dim rstData    As DAO.Recordset

Set dbs = CurrentDb

Set rstData = dbs.OpenRecordset("exclusions", dbOpenTable)
exclusionArray() = rstData.GetRows(rstData.RecordCount)

'compare statement to exclusions
Dim i As Integer
Dim e As Integer
Dim k As String
Dim x As String

Dim originalNumberOfKeyword As Integer
originalNumberOfKeyword = keywordCollection.Count

Dim keywordsLeft As Integer
keywordsLeft = originalNumberOfKeyword

For i = 1 To originalNumberOfKeyword
    If i > keywordsLeft Then Exit For
    
    For e = 0 To UBound(exclusionArray, 2)
        
        k = keywordCollection.Item(i)
        x = exclusionArray(1, e)
        
        If k = x Then
            keywordCollection.Remove (i)
            keywordsLeft = keywordCollection.Count
            i = i - 1
            Exit For
        End If
    Next e
Next i
    
'write to keyword table
Dim insertString As String
Dim delimiter As String
For i = 1 To keywordCollection.Count
    insertString = "INSERT INTO keywordDictionary ( keyword ) VALUES ('" & keywordCollection.Item(i) & "')"
    DoCmd.RunSQL (insertString)
Next i

End Sub





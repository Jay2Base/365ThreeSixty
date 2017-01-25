
Module parseKeywords
    Sub updateMissionStatement(mission As String)
        Dim daK As SqlClient.SqlDataAdapter
        Dim dsK As New DataSet
        Dim sql As String
        Dim newCon As SqlClient.SqlConnection

        newCon = openDbConnection()

        sql = "select * from keywordDictionary;"
        daK = New SqlClient.SqlDataAdapter(sql, newCon)
        daK.FillSchema(dsK, SchemaType.Source)
        daK.Fill(dsK)

        newCon.Close()

        'clear down existing mission keywords

        Dim cb As New SqlClient.SqlCommandBuilder(daK)
        For Each row In dsK.Tables(0).Rows
            row.delete()
        Next

        daK.Update(dsK)

        'split mission in dataset
        'SPLIT MISSION INTO DATASET
        Dim statement As String
        statement = mission
        statement = Replace(statement, ",", "")
        statement = Replace(statement, ".", "")
        statement = Replace(statement, ";", "")
        statement = Replace(statement, ":", "")
        statement = Replace(statement, "!", "")
        statement = Replace(statement, "?", "")
        Dim keywordArray As String() = statement.Split(" ")

        Dim keywordTable As New DataTable
        Dim newRow As DataRow
        keywordTable.Columns.Add("keywords")
        For Each item In keywordArray

            newRow = keywordTable.NewRow()
            newRow(0) = item
            keywordTable.Rows.Add(newRow)
        Next

        'get exclusions from db
        Dim daX As SqlClient.SqlDataAdapter
        Dim dsX As New DataSet

        newCon.Open()
        sql = "select * from exclusions;"
        daX = New SqlClient.SqlDataAdapter(sql, newCon)
        daX.FillSchema(dsX, SchemaType.Source)
        daX.Fill(dsX)
        newCon.Close()

        'run comprison against exclusions
        Dim i As Integer
        Dim k As String
        Dim x As String

        Dim originalNumberOfKeyword As Integer
        originalNumberOfKeyword = keywordTable.Rows.Count

        Dim keywordsLeft As Integer
        keywordsLeft = originalNumberOfKeyword

        For i = 0 To originalNumberOfKeyword - 1
            If i > keywordsLeft Then Exit For

            For Each row In dsX.Tables(0).Rows

                k = keywordArray(i).ToString
                x = row.ToString

                If k = x Then
                    keywordTable.Rows(i).Delete()
                    keywordsLeft = keywordTable.Rows.Count
                    i = i - 1
                    Exit For
                End If
            Next
        Next i
        'write to key word table
        'WRITE TO KEYWORD TABLE
        For Each row In keywordTable.Rows
            newRow = dsK.Tables(0).NewRow()
            newRow(1) = row.item("keywords")
            dsK.Tables(0).Rows.Add(newRow)
        Next
        daK.Update(dsK)



    End Sub

End Module

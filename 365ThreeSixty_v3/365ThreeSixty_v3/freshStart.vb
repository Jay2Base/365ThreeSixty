Module freshStart
    Sub doFreshStart()
        Dim daR As SqlClient.SqlDataAdapter
        Dim dsR As New DataSet
        Dim sql As String
        Dim newCon As SqlClient.SqlConnection

        newCon = openDbConnection()
        sql = "select * from reviews;"
        daR = New SqlClient.SqlDataAdapter(sql, newCon)
        daR.FillSchema(dsR, SchemaType.Source)
        daR.Fill(dsR)



        Dim cs As New SqlClient.SqlCommandBuilder(daR)
        For Each row In dsR.Tables(0).Rows
            row.delete()
        Next
        daR.Update(dsR)

    End Sub

End Module

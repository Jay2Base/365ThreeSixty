Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration
Module openDatabaseLink




    Dim con As New System.Data.SqlClient.SqlConnection
    Dim dbProvider As String
    Dim dbSource As String
    Dim MyDocumentsFolder As String
    Dim TheDatabase As String
    Dim FullDatabasePath As String


    Public Function openDbConnection()


        'dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"

        'TheDatabase = "/365ThreeSixty_v2.accdb"
        'MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'FullDatabasePath = "C:/Users/jayra/Google Drive/365threesixty/ASP.NET/365ThreeSixty_v2" & TheDatabase
        'dbSource = "Data Source = " & FullDatabasePath
        Dim connStr As String
        connStr = ConfigurationManager.ConnectionStrings("365ThreeSixtyConnectionString1").ConnectionString

        con.ConnectionString = connStr
        Return con

    End Function
End Module

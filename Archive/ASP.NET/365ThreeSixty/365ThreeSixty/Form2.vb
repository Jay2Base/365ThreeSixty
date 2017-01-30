Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As OleDb.OleDbConnection
        Dim dbProvider As String
        Dim dbSource As String
        Dim MyDocumentsFolder As String
        Dim TheDatabase As String
        Dim FullDatabasePath As String

        dbProvider = "PROVIDER=Microsoft.Office.12.0.Access.Database.Engine.OLE.DB.Provider;"
        TheDatabase = "/365ThreeSixty.accdb"
        MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        FullDatabasePath = "C:/Users/jayra/Google Drive/365threesixty" & TheDatabase
        dbSource = "Data Source = " & FullDatabasePath

        con.ConnectionString = dbProvider & dbSource
        con.Open()
        MessageBox.Show("db.open")
        con.Close()
        MessageBox.Show("db closed")


    End Sub
End Class
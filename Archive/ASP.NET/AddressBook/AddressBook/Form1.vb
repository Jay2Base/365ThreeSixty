Public Class Form1
    Private Sub TblContactsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TblContactsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TblContactsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AddressBookDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AddressBookDataSet.tblContacts' table. You can move, or remove it, as needed.
        Me.TblContactsTableAdapter.Fill(Me.AddressBookDataSet.tblContacts)

    End Sub
End Class

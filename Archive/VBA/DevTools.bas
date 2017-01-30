Attribute VB_Name = "DevTools"
Public Sub ExportSourceFiles()
 
Dim component As VBComponent
For Each component In Application.VBE.ActiveVBProject.VBComponents
If component.Type = vbext_ct_ClassModule Or component.Type = vbext_ct_StdModule Then
component.Export "C:\Users\jayra\Google Drive\365threesixty\VBA\" & component.Name & ToFileExtension(component.Type)
End If
Next
 
End Sub
 
Private Function ToFileExtension(vbeComponentType As vbext_ComponentType) As String
Select Case vbeComponentType
Case vbext_ComponentType.vbext_ct_ClassModule
ToFileExtension = ".cls"
Case vbext_ComponentType.vbext_ct_StdModule
ToFileExtension = ".bas"
Case vbext_ComponentType.vbext_ct_MSForm
ToFileExtension = ".frm"
Case vbext_ComponentType.vbext_ct_ActiveXDesigner
Case vbext_ComponentType.vbext_ct_Document
Case Else
ToFileExtension = vbNullString
End Select
 
End Function

Public Sub RemoveAllModules()
Dim project As VBProject
Set project = Application.VBE.ActiveVBProject
 
Dim comp As VBComponent
For Each comp In project.VBComponents
If Not comp.Name = "DevTools" And (comp.Type = vbext_ct_ClassModule Or comp.Type = vbext_ct_StdModule) Then
project.VBComponents.Remove comp
End If
Next
End Sub

Public Sub ImportSourceFiles()
Dim file As String
file = Dir("C:\Users\jayra\Google Drive\365threesixty\VBA\")
While (file <> vbNullString)
Application.VBE.ActiveVBProject.VBComponents.Import "C:\Users\jayra\Google Drive\365threesixty\VBA\" & file
file = Dir
Wend

End Sub

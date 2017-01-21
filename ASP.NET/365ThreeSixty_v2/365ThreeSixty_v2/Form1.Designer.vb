<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpSetUp = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImportEmployees = New System.Windows.Forms.Button()
        Me.txtMissionStatement = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.grpSetUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSetUp
        '
        Me.grpSetUp.Controls.Add(Me.Button1)
        Me.grpSetUp.Controls.Add(Me.btnImportEmployees)
        Me.grpSetUp.Location = New System.Drawing.Point(73, 47)
        Me.grpSetUp.Name = "grpSetUp"
        Me.grpSetUp.Size = New System.Drawing.Size(493, 324)
        Me.grpSetUp.TabIndex = 0
        Me.grpSetUp.TabStop = False
        Me.grpSetUp.Text = "Set up"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(228, 72)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Enter a Mission Statement"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImportEmployees
        '
        Me.btnImportEmployees.Location = New System.Drawing.Point(32, 83)
        Me.btnImportEmployees.Name = "btnImportEmployees"
        Me.btnImportEmployees.Size = New System.Drawing.Size(228, 72)
        Me.btnImportEmployees.TabIndex = 0
        Me.btnImportEmployees.Text = "Import Employees"
        Me.btnImportEmployees.UseVisualStyleBackColor = True
        '
        'txtMissionStatement
        '
        Me.txtMissionStatement.Font = New System.Drawing.Font("Comic Sans MS", 27.9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMissionStatement.Location = New System.Drawing.Point(73, 389)
        Me.txtMissionStatement.Multiline = True
        Me.txtMissionStatement.Name = "txtMissionStatement"
        Me.txtMissionStatement.Size = New System.Drawing.Size(493, 223)
        Me.txtMissionStatement.TabIndex = 1
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(338, 643)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(228, 72)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit Statment"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(743, 109)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(228, 72)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Vote"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(743, 274)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(428, 91)
        Me.ComboBox1.TabIndex = 3
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(743, 438)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(428, 91)
        Me.ComboBox2.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1306, 912)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtMissionStatement)
        Me.Controls.Add(Me.grpSetUp)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.grpSetUp.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpSetUp As GroupBox
    Friend WithEvents btnImportEmployees As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtMissionStatement As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
End Class

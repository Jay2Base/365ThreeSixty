<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class startUp
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
        Me.reviewer = New System.Windows.Forms.ComboBox()
        Me.isAdmin = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'reviewer
        '
        Me.reviewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reviewer.FormattingEnabled = True
        Me.reviewer.Location = New System.Drawing.Point(36, 104)
        Me.reviewer.Margin = New System.Windows.Forms.Padding(4)
        Me.reviewer.Name = "reviewer"
        Me.reviewer.Size = New System.Drawing.Size(313, 54)
        Me.reviewer.TabIndex = 0
        '
        'isAdmin
        '
        Me.isAdmin.AutoSize = True
        Me.isAdmin.Location = New System.Drawing.Point(36, 208)
        Me.isAdmin.Margin = New System.Windows.Forms.Padding(4)
        Me.isAdmin.Name = "isAdmin"
        Me.isAdmin.Size = New System.Drawing.Size(313, 50)
        Me.isAdmin.TabIndex = 1
        Me.isAdmin.Text = "I am an Admin"
        Me.isAdmin.UseVisualStyleBackColor = True
        '
        'startUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(240.0!, 240.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(578, 452)
        Me.Controls.Add(Me.isAdmin)
        Me.Controls.Add(Me.reviewer)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "startUp"
        Me.Text = "startUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents reviewer As ComboBox
    Friend WithEvents isAdmin As CheckBox
End Class

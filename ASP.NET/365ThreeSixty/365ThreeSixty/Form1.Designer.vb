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
        Me.firstNumber = New System.Windows.Forms.TextBox()
        Me.secondNumber = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'firstNumber
        '
        Me.firstNumber.Location = New System.Drawing.Point(405, 259)
        Me.firstNumber.Name = "firstNumber"
        Me.firstNumber.Size = New System.Drawing.Size(275, 38)
        Me.firstNumber.TabIndex = 0
        '
        'secondNumber
        '
        Me.secondNumber.Location = New System.Drawing.Point(405, 341)
        Me.secondNumber.Name = "secondNumber"
        Me.secondNumber.Size = New System.Drawing.Size(275, 38)
        Me.secondNumber.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(405, 428)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(275, 38)
        Me.TextBox3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(244, 265)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "First Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Second Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Telephone"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(725, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 91)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(725, 358)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 116)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Get Answer"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 597)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.secondNumber)
        Me.Controls.Add(Me.firstNumber)
        Me.Name = "Form1"
        Me.Text = "My First Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents firstNumber As TextBox
    Friend WithEvents secondNumber As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class

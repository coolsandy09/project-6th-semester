<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.ClientName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.compname = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ClientName
        '
        Me.ClientName.AutoSize = True
        Me.ClientName.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientName.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientName.Location = New System.Drawing.Point(67, 95)
        Me.ClientName.Name = "ClientName"
        Me.ClientName.Size = New System.Drawing.Size(128, 57)
        Me.ClientName.TabIndex = 0
        Me.ClientName.Text = "Label"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Monotype Corsiva", 13.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(36, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(374, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Time for ad of the following client has end"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Image = Global.Reminder.My.Resources.Resources.icons8_alarm_off_50
        Me.Button2.Location = New System.Drawing.Point(211, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 71)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Image = Global.Reminder.My.Resources.Resources.icons8_snooze_50
        Me.Button1.Location = New System.Drawing.Point(50, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 71)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        '
        'compname
        '
        Me.compname.AutoSize = True
        Me.compname.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compname.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.compname.Location = New System.Drawing.Point(68, 226)
        Me.compname.Name = "compname"
        Me.compname.Size = New System.Drawing.Size(113, 50)
        Me.compname.TabIndex = 5
        Me.compname.Text = "Label"
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        '
        'Timer4
        '
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(458, 647)
        Me.ControlBox = False
        Me.Controls.Add(Me.compname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ClientName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALARM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClientName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents compname As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer4 As Timer
End Class

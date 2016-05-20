<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmdispatch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdispatch))
        Me.txtcode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDispNo = New System.Windows.Forms.ComboBox
        Me.txtempcode = New System.Windows.Forms.TextBox
        Me.chkOther = New System.Windows.Forms.CheckBox
        Me.btnclear = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtcode
        '
        Me.txtcode.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtcode.Location = New System.Drawing.Point(46, 107)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(187, 23)
        Me.txtcode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.Text = "Barcode"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.Text = "Dispatch No"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.Text = "User"
        '
        'cboDispNo
        '
        Me.cboDispNo.Location = New System.Drawing.Point(89, 49)
        Me.cboDispNo.Name = "cboDispNo"
        Me.cboDispNo.Size = New System.Drawing.Size(144, 23)
        Me.cboDispNo.TabIndex = 9
        '
        'txtempcode
        '
        Me.txtempcode.Location = New System.Drawing.Point(89, 10)
        Me.txtempcode.Name = "txtempcode"
        Me.txtempcode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtempcode.Size = New System.Drawing.Size(144, 23)
        Me.txtempcode.TabIndex = 15
        '
        'chkOther
        '
        Me.chkOther.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkOther.Location = New System.Drawing.Point(45, 136)
        Me.chkOther.Name = "chkOther"
        Me.chkOther.Size = New System.Drawing.Size(153, 22)
        Me.chkOther.TabIndex = 20
        Me.chkOther.Text = "Other"
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(44, 220)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(72, 20)
        Me.btnclear.TabIndex = 25
        Me.btnclear.Text = "Clear"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(124, 220)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 20)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "Close"
        '
        'frmdispatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(241, 268)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnclear)
        Me.Controls.Add(Me.chkOther)
        Me.Controls.Add(Me.txtempcode)
        Me.Controls.Add(Me.cboDispNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmdispatch"
        Me.Text = "Dispatch"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDispNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtempcode As System.Windows.Forms.TextBox
    Friend WithEvents chkOther As System.Windows.Forms.CheckBox
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class

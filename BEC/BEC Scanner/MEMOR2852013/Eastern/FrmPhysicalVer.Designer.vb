<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrmPhysicalVer
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnclear = New System.Windows.Forms.Button
        Me.txtcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.txtempcode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(125, 245)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 20)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Close"
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(45, 245)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(72, 20)
        Me.btnclear.TabIndex = 27
        Me.btnclear.Text = "Save"
        '
        'txtcode
        '
        Me.txtcode.Location = New System.Drawing.Point(80, 46)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(152, 23)
        Me.txtcode.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 20)
        Me.Label1.Text = "Barcode :"
        '
        'ListView1
        '
        Me.ListView1.Columns.Add(Me.ColumnHeader2)
        Me.ListView1.Columns.Add(Me.ColumnHeader1)
        Me.ListView1.Columns.Add(Me.ColumnHeader3)
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(7, 83)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(227, 156)
        Me.ListView1.TabIndex = 56
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Linked Before FP Barcode"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemName"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Qty"
        Me.ColumnHeader3.Width = 73
        '
        'txtempcode
        '
        Me.txtempcode.Location = New System.Drawing.Point(80, 6)
        Me.txtempcode.Name = "txtempcode"
        Me.txtempcode.Size = New System.Drawing.Size(152, 23)
        Me.txtempcode.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(2, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.Text = "Usercode :"
        '
        'ListView2
        '
        Me.ListView2.Columns.Add(Me.ColumnHeader4)
        Me.ListView2.Columns.Add(Me.ColumnHeader6)
        Me.ListView2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular)
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(7, 83)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(227, 156)
        Me.ListView2.TabIndex = 60
        Me.ListView2.View = System.Windows.Forms.View.Details
        Me.ListView2.Visible = False
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Itemcode"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "SerialNo"
        Me.ColumnHeader6.Width = 73
        '
        'FrmPhysicalVer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(241, 268)
        Me.Controls.Add(Me.txtempcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnclear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView2)
        Me.Name = "FrmPhysicalVer"
        Me.Text = "Physical Verification"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtempcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class

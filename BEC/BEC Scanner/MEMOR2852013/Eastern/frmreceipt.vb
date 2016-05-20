Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
'Imports DLCEDEVICELib
Public Class frmreceipt
    Public con As System.Data.SqlClient.SqlConnection
    Public sqlcmd As System.Data.SqlClient.SqlCommand
    Public i As Integer = 0, j As Integer = 0, dispno As String = "", locode, prodcode, floc As Integer
    'Dim a As New DatalogicDevice
    Public indentcode As Double = 0, item As Double = 0, empcode As Double = 0, loccode As Double = 0, BinCode As Integer = 0, Qty As Integer = 0
    Public divcode As Integer = 0
    Public cnt As Integer, sno As Integer
    Public query1 As String, query2 As String, query3, RACKID As String
    Public dTable As New Data.DataTable, dTable1 As New Data.DataTable, dTable2 As New Data.DataTable, dTable3 As New Data.DataTable, dTable4 As New Data.DataTable
    Public dat As Date = DateTime.Today
    Dim now As String = Format(DateTime.Today, "dd-MMM-yy")
    Public mytransaction As SqlTransaction
    Public dr As SqlDataReader
    Private Sub frmreceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            txtcode.Text = ""
            txtempcode.Text = ""
            txtempcode.Focus()

        ElseIf e.KeyCode = Keys.F2 Then
            frmmain.Show()
            frmmain.Focus()
            frmmain.Activate()
        End If
    End Sub
   

    Private Sub frmreceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim path As String, path1 As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

        Dim mindex As Integer
        Dim myreader As System.IO.StreamReader
        Dim Readtext As String = "", uname As String = "", pwd As String = "", DB As String = "", str As String = ""
        'Dim Readtext As String = "192.168.1.16", uname As String = "Sa", pwd As String = "", DB As String = "EastCon", str As String = ""
        pwd = "stallion"
        'pwd = "stallion"
        path = path & "\Server.txt"
        myreader = New System.IO.StreamReader(path)
        mindex = 0
        While myreader.Peek <> -1
            Readtext = myreader.ReadLine
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()
        If Readtext = "" Then
            MsgBox("Sever Does not Exists", MsgBoxStyle.Critical, "Eastern")
            Exit Sub
        End If

        path1 = path1 & "\Data.txt"
        myreader = New System.IO.StreamReader(path1)
        mindex = 0
        While myreader.Peek <> -1
            str = myreader.ReadLine
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()

        If str = "" Then
            MsgBox("Sever Connection Failed", MsgBoxStyle.Critical, "Eastern")
            Exit Sub
        End If

        str = Trim(str)
        DB = Mid(str, 1, (InStr(1, str, ",", vbTextCompare) - 1))

        str = Mid(str, (InStr(1, str, ",", vbTextCompare) + 1), Len(str))
        uname = str

        con = New System.Data.SqlClient.SqlConnection("Data Source=" & Readtext & ";Initial Catalog=" & DB & ";User ID=" & uname & ";password=" & pwd & ";")
        'Me.con = frmmain.con
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        sqlcmd = con.CreateCommand
        txtempcode.Focus()
    End Sub
  
    Public Sub conn()
        If sqlcmd.Connection.State = ConnectionState.Open Then
            sqlcmd.Connection.Close()
        End If
        sqlcmd.Connection.Open()
    End Sub
    Private Sub clearparam(ByVal sqlcmd As SqlCommand)
        sqlcmd.Parameters.Clear()
    End Sub
    Private Sub txtempcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtempcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtempcode.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter User", MsgBoxStyle.Critical, "BEC")
                txtempcode.Focus()
                Exit Sub
            Else
                dTable.Clear()
                'vipin
                Dim dAdpt1 As New SqlDataAdapter("SELECT  * from tbl_userMast where User_id = @ecode  and User_Del= 0 ", con)
                With dAdpt1.SelectCommand
                    .Parameters.AddWithValue("@ecode", txtempcode.Text)
                End With
                'Dim dAdpt1 As New SqlDataAdapter("SELECT  * from EmployeeMaster where Emp_Id = '" & txtempcode.Text & "'  and Emp_Del= 0 ", con)
                dAdpt1.Fill(dTable)
                clearparam(dAdpt1.SelectCommand)
                If dTable.Rows.Count > 0 Then
                    empcode = dTable.Rows(0).Item("User_id")

                Else
                    'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                    MsgBox("Invalid  User", MsgBoxStyle.Critical, "BEC")
                    txtempcode.Text = ""
                    txtempcode.Focus()
                End If
                txtRack.Focus()
            End If
        End If
    End Sub
    'Private Sub txtbinno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbinno.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If txtempcode.Text = "" Then
    '            MsgBox("Enter Employee code", MsgBoxStyle.Critical, "Eastern")
    '            txtempcode.Focus()
    '        ElseIf txtbinno.Text = "" Then
    '            'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
    '            MsgBox("Enter Bin No", MsgBoxStyle.Critical, "Eastern")
    '            txtbinno.Focus()
    '        Else
    '            dTable.Clear()
    '            Dim dAdpt1 As New SqlDataAdapter("SELECT  * from EmployeeMaster where Emp_Id = '" & Mid(txtempcode.Text, 2, Len(txtempcode.Text)) & "'  and Emp_Del= 0 ", con)
    '            dAdpt1.Fill(dTable)
    '            If dTable.Rows.Count > 0 Then
    '                empcode = dTable.Rows(0).Item("Emp_Code")
    '                loccode = dTable.Rows(0).Item("Loc_code")
    '                txtbinno.Focus()
    '            Else
    '                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
    '                MsgBox("Invalid  Employee", MsgBoxStyle.Critical, "Eastern")
    '                txtempcode.Text = ""
    '                txtempcode.Focus()
    '                Exit Sub
    '            End If
    '            dTable.Clear()
    '            Dim dAdpt As New SqlDataAdapter("SELECT  * from BinMaster Where Bin_No = '" & txtbinno.Text & "' and Bin_Del =0 and Loc_Code=" & loccode & "", con)
    '            dAdpt.Fill(dTable)
    '            If dTable.Rows.Count > 0 Then
    '                txtcode.Focus()
    '            Else
    '                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
    '                MsgBox("Invalid Bin No", MsgBoxStyle.Critical, "Eastern")
    '                txtcode.Text = ""
    '                txtcode.Focus()
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Sub txtcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtempcode.Text = "" Then
                MsgBox("Enter Employee code", MsgBoxStyle.Critical, "BEC")
                txtempcode.Focus()
                Exit Sub
            ElseIf txtRack.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter the Rack No", MsgBoxStyle.Critical, "BEC")
                txtRack.Focus()
                Exit Sub
            ElseIf txtcode.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter the Barcode", MsgBoxStyle.Critical, "BEC")
                txtcode.Focus()
                Exit Sub

            End If
            conn()
            dTable.Clear()
            Dim dAdpt1 As New SqlDataAdapter("SELECT  * from tbl_userMast where user_id = @ucode  and User_Del= 0 ", con)
            With dAdpt1.SelectCommand
                .Parameters.Add("@ucode", txtempcode.Text)
            End With
            dAdpt1.Fill(dTable)
            If dTable.Rows.Count > 0 Then
                empcode = dTable.Rows(0).Item("User_id")

            Else
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Invalid  Employee", MsgBoxStyle.Critical, "BEC")
                txtempcode.Text = ""
                txtempcode.Focus()
                Exit Sub
            End If
            
            dTable2.Clear()
            dTable.Clear()
            Dim dAdpt3 As New SqlDataAdapter("SELECT * FROM dbo.Tbl_RackMaster WHERE IsDelete=0 AND RackNo ='" & txtRack.Text & "' ", con)
            'With dAdpt1.SelectCommand
            '    .Parameters.Add("@ucode", txtempcode.Text)
            'End With
            dAdpt3.Fill(dTable)

            'Dim DT As DataTable
            'Dim da As New SqlDataAdapter("SELECT * FROM dbo.Tbl_RackMaster WHERE IsDelete=0 AND RackNo ='" & txtRack.Text & "' ", con)
            'da.Fill(DT)
            If dTable.Rows.Count > 0 Then
                RACKID = dTable.Rows(0)("RackId")
            Else
                MsgBox("Invalid Rack No", MsgBoxStyle.Critical, "BEC")
                Exit Sub
            End If

            dTable.Clear()
            Dim dAdpt As New SqlDataAdapter("SELECT  * from tbl_barcode where Serial_No = @cno", con)
            With dAdpt.SelectCommand
                .Parameters.AddWithValue("@cno", txtcode.Text)

            End With
            dAdpt.Fill(dTable)
            If dTable.Rows.Count = 0 Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Invalid Scan", MsgBoxStyle.Critical, "BEC")
                ' txtcode.Text = ""
                ' txtcode.Focus()
                Exit Sub
            Else
                If dTable.Rows(0).Item("Status") = 1 Then
                    MsgBox("Item Already Scanned", MsgBoxStyle.Critical, "BEC")
                    txtcode.Text = ""
                End If
            End If

            Try
                mytransaction = con.BeginTransaction()
                sqlcmd.Transaction = mytransaction
                clearparam(sqlcmd)
                '------------------------------------------
                query1 = "Update tbl_barcode set status=1,userid=@ucode,store_date=@date where serial_no=@cno"
                sqlcmd.CommandText = query1
                With sqlcmd
                    .Parameters.AddWithValue("@date", Date.Today)
                    .Parameters.AddWithValue("@cno", txtcode.Text)
                    .Parameters.AddWithValue("@ucode", empcode)
                End With
                sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)
                query1 = "INSERT INTO dbo.Tbl_ReciptScan(SerialNo,RackId,UserID)VALUES ('" & txtcode.Text & "'," & RACKID & ",'" & txtempcode.Text & "')"
                sqlcmd.CommandText = query1
                sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)

                mytransaction.Commit()
                txtcode.Text = ""
                txtcode.Focus()
            Catch ex As Exception
                mytransaction.Rollback()
                MsgBox(ex.Message & sqlcmd.CommandText)
                MsgBox("Please Scan Again")
                txtcode.Text = ""
                txtcode.Focus()
            End Try


        End If
    End Sub
    'Public Function syncmaxno() As Double
    '    Dim dr1 As SqlDataReader
    '    Dim sno1 As Integer = 0
    '    sqlcmd.CommandText = "select isnull(Max(Sno),0)+1  as no from SyncTable"
    '    dr1 = sqlcmd.ExecuteReader
    '    If dr1.Read Then
    '        sno1 = dr1(0)
    '    End If
    '    dr1.Close()
    '    Return sno1
    'End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmmain.Show()
        frmmain.Focus()
        frmmain.Activate()
        Me.Hide()
    End Sub

    Private Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        txtcode.Text = ""
        txtempcode.Text = ""
        txtempcode.Focus()
        txtRack.Text = ""
    End Sub


    Private Sub txtRack_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRack.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtRack.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter the Rack No", MsgBoxStyle.Critical, "BEC")
                txtRack.Focus()
                Exit Sub
            End If
            conn()
            dTable.Clear()
            Dim dAdpt1 As New SqlDataAdapter("SELECT * FROM dbo.Tbl_RackMaster WHERE IsDelete=0 AND RackNo ='" & txtRack.Text & "' ", con)
            'With dAdpt1.SelectCommand
            '    .Parameters.Add("@ucode", txtempcode.Text)
            'End With
            dAdpt1.Fill(dTable)

            'Dim DT As DataTable
            'Dim da As New SqlDataAdapter("SELECT * FROM dbo.Tbl_RackMaster WHERE IsDelete=0 AND RackNo ='" & txtRack.Text & "' ", con)
            'da.Fill(DT)
            If dTable.Rows.Count > 0 Then
            Else
                MsgBox("Invalid Rack No", MsgBoxStyle.Critical, "BEC")
                Exit Sub
            End If
            txtcode.Focus()
        End If
    End Sub
End Class
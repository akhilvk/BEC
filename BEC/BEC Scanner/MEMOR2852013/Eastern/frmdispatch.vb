Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
'Imports DLCEDEVICELib
Public Class frmdispatch

    Public con As System.Data.SqlClient.SqlConnection
    Public con1 As System.Data.SqlClient.SqlConnection
    Public sqlcmd As System.Data.SqlClient.SqlCommand
    'Transaction Object mytransaction for each for
    Dim mytransaction As SqlTransaction
    Dim loc As String
    Public i As Integer = 0, j As Integer = 0, k As Integer = 0, sno As Integer = 0, loccode As Double, qty As Double = 0, itemcode As Integer = 0
    'Dim a As New DatalogicDevice
    Public divcode As Integer = 0
    Public item As String, msg As String, MDATE As String
    Public status As Integer
    Public inbarcode As String, Cuscode As String, Query1 As String, Query2 As String, QueryS As String, Batch As String
    Public empcode As Double = 0
    Public DispNo As Double = 0
    Public Toloc As Double = 0, fromloc As Double = 0
    Public DisDate As Date
    Public dr As SqlDataReader
    Dim now As String = Format(DateTime.Today, "dd-MMM-yy")
    Dim EmpCheckFlag As Boolean = False
    Public dTable As New Data.DataTable, dTable1 As New Data.DataTable, dTable2 As New Data.DataTable, dTable3 As New Data.DataTable, dTable4 As New Data.DataTable

    Private Sub frmdispatch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim path As String, path1 As String, path2 As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path2 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        txtempcode.Focus()
        Dim mindex As Integer
        Dim myreader As System.IO.StreamReader
        Dim Readtext As String = "", uname As String = "", pwd As String = "", DB As String = "", str As String = ""
        pwd = "stallion"
        'pwd = "BEC"

        'path2 = "E:\Projects\VKC Scanner\MEMOR2852013\Eastern\bin\Debug\loc.txt"

        path2 = path2 & "\Loc.txt"
        myreader = New System.IO.StreamReader(path2)
        mindex = 0
        While myreader.Peek <> -1
            Readtext = myreader.ReadLine
            loc = Readtext
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()


        path = path & "\Server.txt"
        'path = "E:\Projects\VKC Scanner\MEMOR2852013\Eastern\bin\Debug\Server.txt"

        myreader = New System.IO.StreamReader(path)

        mindex = 0
        While myreader.Peek <> -1
            Readtext = myreader.ReadLine
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()
        If Readtext = "" Then
            MsgBox("Sever Does not Exists", MsgBoxStyle.Critical, "BEC")
            Exit Sub
        End If

        path1 = path1 & "\Data.txt"
        'path1 = "E:\Projects\VKC Scanner\MEMOR2852013\Eastern\bin\Debug\Data.txt"

        myreader = New System.IO.StreamReader(path1)
        mindex = 0
        While myreader.Peek <> -1
            str = myreader.ReadLine
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()

        If str = "" Then
            MsgBox("Sever Connection Failed", MsgBoxStyle.Critical, "BEC")
            Exit Sub
        End If

        str = Trim(str)
        DB = Mid(str, 1, (InStr(1, str, ",", vbTextCompare) - 1))

        str = Mid(str, (InStr(1, str, ",", vbTextCompare) + 1), Len(str))
        uname = str

        con = New System.Data.SqlClient.SqlConnection("Data Source=" & Readtext & ";Initial Catalog=" & DB & ";User ID=" & uname & "; password=" & pwd & ";")
        'con1 = New System.Data.SqlClient.SqlConnection("Data Source=" & Readtext & ";Initial Catalog=" & DB & ";User ID=" & uname & "; password=" & pwd & ";")
        'con = frmmain.con
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        sqlcmd = con.CreateCommand
        dTable1.Clear()
        cboDispNo.Items.Clear()
        Dim dAdpt2 As New SqlDataAdapter("SELECT DISTINCT Desp_no  FROm tbl_Despdet   WHERE status=0", con)
        dAdpt2.Fill(dTable1)
        If dTable1.Rows.Count > 0 Then
            For j = 0 To dTable1.Rows.Count - 1
                cboDispNo.Items.Add(dTable1.Rows(j).Item("Desp_no"))
            Next
        End If
        txtempcode.Focus()
    End Sub
    Private Sub frmdispatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            clearscreen()
            txtcode.Text = ""
            txtempcode.Text = ""
            txtempcode.Focus()
            txtcode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            clearscreen()
            txtcode.Text = ""
            txtempcode.Text = ""
            txtempcode.Focus()
            frmmain.Focus()
            frmmain.Show()
        End If
    End Sub
    Public Sub conn()
        If sqlcmd.Connection.State = ConnectionState.Open Then
            sqlcmd.Connection.Close()
        End If
        sqlcmd.Connection.Open()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
        Catch ex As Exception
            MsgBox("Error in Connection2")
        End Try

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

                    cboDispNo.Focus()
                Else
                    'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                    MsgBox("Invalid  User", MsgBoxStyle.Critical, "BEC")
                    txtempcode.Text = ""
                    txtempcode.Focus()
                End If

            End If
            sqlcmd = con.CreateCommand
            dTable1.Clear()
            cboDispNo.Items.Clear()
            Dim dAdpt2 As New SqlDataAdapter("SELECT DISTINCT Desp_no  FROm tbl_Despdet   WHERE status=0", con)
            dAdpt2.Fill(dTable1)
            If dTable1.Rows.Count > 0 Then
                For j = 0 To dTable1.Rows.Count - 1
                    cboDispNo.Items.Add(dTable1.Rows(j).Item("Desp_no"))
                Next
            End If
        End If
    End Sub
    Private Sub txtcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcode.KeyDown
        Dim fromloc, toloc, inputqty, depspacks As Integer
        Dim NoofPacs As Integer = 0
        Dim balanceq As Integer = 0
        Dim blnfinish As Boolean = True
        If e.KeyCode = Keys.Enter Then
            If txtempcode.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter User", MsgBoxStyle.Critical, "BEC")
                txtempcode.Focus()
                Exit Sub
            ElseIf cboDispNo.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Select Dispatch", MsgBoxStyle.Critical, "BEC")
                cboDispNo.Focus()
                Exit Sub
            ElseIf txtcode.Text = "" Then
                'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                MsgBox("Enter the Barcode", MsgBoxStyle.Critical, "BEC")
                txtcode.Focus()
                Exit Sub
            End If
            conn()
            If EmpCheckFlag = False Then
                dTable.Clear()
                Dim dAdpt1 As New SqlDataAdapter("SELECT  * from Tbl_userMast where User_id = @ucode  and User_Del= 0 ", con)
                With dAdpt1.SelectCommand
                    .Parameters.AddWithValue("@ucode", txtempcode.Text)
                End With
                dAdpt1.Fill(dTable)
                clearparam(dAdpt1.SelectCommand)
                If dTable.Rows.Count > 0 Then
                    empcode = dTable.Rows(0).Item("User_id")

                Else
                    'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                    MsgBox("Invalid  User", MsgBoxStyle.Critical, "BEC")
                    txtempcode.Text = ""
                    txtempcode.Focus()
                    Exit Sub
                End If
                EmpCheckFlag = True
            End If
            'MsgBox("1")
            'Get Barcode Table Values
            dTable.Rows.Clear()
            Try
                sqlcmd.CommandText = "select * from tbl_Barcode where serial_no=@code"
                With sqlcmd
                    .Parameters.AddWithValue("@code", txtcode.Text)

                End With
                dr = sqlcmd.ExecuteReader
                dTable.Load(dr)
                dr.Close()
                clearparam(sqlcmd)
                Try
                    NoofPacs = dTable.Rows(0)("NoofPacks")
                Catch ex As Exception
                    NoofPacs = 0
                End Try

              
                If dTable.Rows(0).Item("Status") = 0 Then
                    MsgBox("Storage Not Done!", MsgBoxStyle.Critical, "BEC")
                    txtcode.Text = ""
                    Exit Sub
                ElseIf dTable.Rows(0).Item("Status") > 1 Then
                    '    If dTable.Rows(0).Item("Status") = 2 Then
                    '        If NoofPacs > 0 Then
                    '            sqlcmd.CommandText = "select * from tbl_desp_barcode where desp_no=@despcode  and serial_no=@code"
                    '            With sqlcmd
                    '                .Parameters.AddWithValue("@despcode", cboDispNo.Text)
                    '                .Parameters.Add("@code", txtcode.Text)
                    '            End With
                    '            dr = sqlcmd.ExecuteReader
                    '            While dr.Read
                    '                depspacks = IIf(IsDBNull(dr(6)) = True, 0, dr(6))
                    '            End While
                    '            clearparam(sqlcmd)
                    '            dr.Close()
                    '            If inputqty = 0 Then
                    '                MsgBox("Invalid Scan ", MsgBoxStyle.Critical, "BEC")
                    '                txtcode.Text = ""
                    '                Exit Sub
                    '            End If
                    '            If depspacks >= inputqty Then
                    '                mytransaction = con.BeginTransaction()
                    '                sqlcmd.Transaction = mytransaction

                    '                Query2 = "Update tbl_desp_barcode set status=1,NoofPacks=NoofPacks+" & inputqty & " where desp_no=@dcode and serial_no=@code"
                    '                sqlcmd.CommandText = Query2
                    '                With sqlcmd
                    '                    .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                    '                    .Parameters.AddWithValue("@code", txtcode.Text)
                    '                End With
                    '                sqlcmd.ExecuteNonQuery()
                    '                clearparam(sqlcmd)
                    '                sqlcmd.CommandText = "select * from tbl_desp_sub where desp_no=@code1"
                    '                With sqlcmd
                    '                    .Parameters.AddWithValue("@code1", cboDispNo.Text)
                    '                End With
                    '                dr = sqlcmd.ExecuteReader
                    '                While dr.Read
                    '                    If dr(3) <> dr(4) Then
                    '                        blnfinish = False
                    '                    Else
                    '                        If NoofPacs > 0 Then
                    '                            If inputqty + depspacks < NoofPacs Then
                    '                                blnfinish = False
                    '                            End If
                    '                        End If
                    '                    End If
                    '                End While
                    '                dr.Close()
                    '                clearparam(sqlcmd)
                    '                If blnfinish = True Then
                    '                    Query2 = "Update tbl_despdet set status=1 where desp_no=@dcode"
                    '                    sqlcmd.CommandText = Query2
                    '                    With sqlcmd
                    '                        .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                    '                    End With
                    '                    sqlcmd.ExecuteNonQuery()
                    '                    clearparam(sqlcmd)
                    '                    MsgBox("All items of Despatch Scanned", MsgBoxStyle.OkOnly, "BEC")
                    '                    cboDispNo.Text = ""
                    '                    'clearscreen()
                    '                End If
                    '                mytransaction.Commit()
                    '                If blnfinish Then
                    '                    clearscreen()
                    '                End If
                    '                txtcode.Text = ""
                    '                Exit Sub
                    '            Else
                    '                MsgBox("Quantity Unavailable", MsgBoxStyle.Critical, "BEC")
                    '                clearscreen()
                    '                Exit Sub
                    '            End If
                    '        Else
                    '            MsgBox("Item Already Desptached", MsgBoxStyle.Critical, "BEC")
                    '            txtcode.Text = ""
                    '            Exit Sub
                    '        End If

                    MsgBox("Item Already Desptached", MsgBoxStyle.Critical, "BEC")
                    txtcode.Text = ""
                    Exit Sub
                End If
                If NoofPacs > 0 Then
                    Dim Sta As String
                    Sta = InputBox("How Many Packs?", "BEC")
                    If Integer.Parse(Sta, Globalization.NumberStyles.Integer) Then

                    Else
                        MessageBox.Show("You must enter No of Packs")
                        Exit Sub
                    End If
                    If Sta.Trim = "" Then
                        MessageBox.Show("You must enter No of Packs")
                        Exit Sub
                    End If
                    inputqty = Sta
                    If inputqty > NoofPacs Then
                        MsgBox("Quantity Unavailable !", MsgBoxStyle.Critical, "BEC")
                        Exit Sub
                    End If
                End If
                If dTable.Rows.Count = 0 Then
                    MsgBox("Invalid Barcode ", MsgBoxStyle.Critical, "BEC")
                    txtcode.Text = ""
                    Exit Sub
                Else
                End If
            Catch ex As Exception
                MsgBox("Error During the Barcode Read", MsgBoxStyle.Critical, "BEC")
                txtcode.Text = ""
                txtcode.Focus()
                Exit Sub
            End Try
            'dTable.Rows.Clear()
            Try
                sqlcmd.CommandText = "select * from tbl_desp_barcode where desp_no=@despcode  and serial_no=@code"
                With sqlcmd
                    .Parameters.AddWithValue("@despcode", cboDispNo.Text)
                    .Parameters.Add("@code", txtcode.Text)
                End With
                dr = sqlcmd.ExecuteReader
                'dTable1.Load(dr)
                If dr.Read Then
                    depspacks = IIf(IsDBNull(dr(6)) = True, 0, dr(6))
                Else
                    MsgBox("This barcode doesnot exist for this despatch", MsgBoxStyle.Critical, "BEC")
                    dr.Close()
                    Exit Sub
                End If
                dr.Close()
                clearparam(sqlcmd)
                'If dTable1.Rows.Count = 0 Then
                '    MsgBox("This barcode doesnot exist for this despatch", MsgBoxStyle.Critical, "BEC")
                '    Exit Sub
                'End If
                'depspacks = dTable1.Rows(0).Item("NoofPacks")
            Catch ex As Exception
                MsgBox("Error!!", MsgBoxStyle.Critical, "BEC")
                txtcode.Text = ""
                txtcode.Focus()
                Exit Sub
            End Try

            'MsgBox("2")
            'If ListBarcode.Count > 0 Then
            '    If ListBarcode.Item(0).Status <= 2 Then
            '        MsgBox("Item Storage Scanning Not Done", MsgBoxStyle.Critical, "BEC")
            '        conn()
            '        'sqlcmd.CommandText = "insert into ErrLog values('" & CDate(now) & "','" & txtempcode.Text & "','Despatch','Item Storage Scanning Not Done','" & txtcode.Text & "')"
            '        'sqlcmd.ExecuteNonQuery()
            '        txtcode.Text = ""
            '        txtcode.Focus()
            '        Exit Sub
            '    ElseIf ListBarcode.Item(0).Status = 3 Then
            '        dTable.Clear()
            '        'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
            '        'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
            '        'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
            '        'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
            '        'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
            '        Dim dAdptcd As New SqlDataAdapter("SELECT  * from tbl_Despatch where Desp_code = @despcode and from_loc_code=@lcode", con)
            '        With dAdptcd.SelectCommand
            '            .Parameters.AddWithValue("@despcode", cboDispNo.Text)
            '            .Parameters.AddWithValue("@lcode", loccode)
            '        End With
            '        dAdptcd.Fill(dTable)
            '        clearparam(dAdptcd.SelectCommand)
            '        If dTable.Rows.Count > 0 Then
            '            fromloc = dTable.Rows(0).Item("from_loc_code")
            '            toloc = dTable.Rows(0).Item("to_loc_code")
            '            If dTable.Rows(0).Item("Desp_code") <> cboDispNo.Text Then
            '                MsgBox("Item  Despatched in another dispatch No " & dTable.Rows(0).Item("Desp_code"), MsgBoxStyle.Critical, "BEC")
            '                txtcode.Text = ""
            '                txtcode.Focus()
            '                Exit Sub
            '            End If
            '        End If
            '    Else
            '        MsgBox("Item   already Scanned", MsgBoxStyle.Critical, "BEC")
            '        txtcode.Text = ""
            '        txtcode.Focus()
            '        Exit Sub
            '    End If
            'Else
            '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical, "BEC")
            '    txtcode.Text = ""
            '    txtcode.Focus()
            '    Exit Sub
            'End If
            'dTable.Clear()
            'Dim dAdptcd1 As New SqlDataAdapter("SELECT  * from Tbl_Despatchscan where Carton_Serial_No = @cno and from_loc_code=@lcode", con)
            'With dAdptcd1.SelectCommand
            '    .Parameters.AddWithValue("@cno", txtcode.Text)
            '    .Parameters.AddWithValue("@lcode", loccode)
            'End With
            'dAdptcd1.Fill(dTable)
            'clearparam(dAdptcd1.SelectCommand)
            'If dTable.Rows.Count > 0 Then
            '    MsgBox("Already Scanned")
            '    txtcode.Text = ""
            '    txtcode.Focus()
            '    Exit Sub
            'End If
            'If ListBarcodesub.Count > 0 Then
            '    If ListBarcodesub.Item(0).plan_qty <= ListBarcodesub.Item(0).scan_qty Then
            '        MsgBox("Qnty Exceeds the Limit for the Scanned Item", MsgBoxStyle.Critical, "BEC")
            '        txtcode.Text = ""
            '        txtcode.Focus()
            '        Exit Sub
            '    End If
            'End If
            'conn()


            '' MsgBox("3")
            ''---------Transaction Initialisation
            Try
                mytransaction = con.BeginTransaction()
                sqlcmd.Transaction = mytransaction
                '  lbMessage.Text = "After Transaction"
                '-------------------------------
                'Query2 = "insert into tbl_despatchscan values(@dcode,@pcode,@date,@floc,@toloc,@cno,@ucode)"
                'sqlcmd.CommandText = Query2
                'With sqlcmd
                '    .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                '    .Parameters.AddWithValue("@pcode", ListBarcode.Item(0).Prod_Code)
                '    .Parameters.AddWithValue("@date", Date.Today)
                '    .Parameters.AddWithValue("@floc", fromloc)
                '    .Parameters.AddWithValue("@toloc", toloc)
                '    .Parameters.AddWithValue("@cno", txtcode.Text)
                '    .Parameters.AddWithValue("@ucode", empcode)
                'End With
                'sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)
                Query2 = "Update tbl_desp_sub set sqty=sqty+1 where desp_no=@dcode and item_code=@pcode"
                sqlcmd.CommandText = Query2
                With sqlcmd
                    .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                    .Parameters.AddWithValue("@pcode", dTable.Rows(0).Item("Item_code"))
                End With
                sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)
                If NoofPacs > 0 Then
                    Query2 = "Update tbl_desp_barcode set status=1,NoofPacks=NoofPacks+" & inputqty & " where desp_no=@dcode and serial_no=@code"
                Else
                    Query2 = "Update tbl_desp_barcode set status=1 where desp_no=@dcode and serial_no=@code"
                End If

                sqlcmd.CommandText = Query2
                With sqlcmd
                    .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                    .Parameters.AddWithValue("@code", dTable.Rows(0).Item("serial_no"))
                End With
                sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)

                balanceq = NoofPacs - inputqty
                If balanceq <> 0 Then
                    sqlcmd.CommandText = "Update tbl_barcode set status=1,Noofpacks=" & balanceq & " where serial_no=@cno"
                Else
                    sqlcmd.CommandText = "Update tbl_barcode set status=2,Noofpacks=" & balanceq & " where serial_no=@cno"
                End If

                With sqlcmd
                    .Parameters.AddWithValue("@cno", txtcode.Text)
                End With
                sqlcmd.ExecuteNonQuery()
                clearparam(sqlcmd)
                '    '-------------------------------
                sqlcmd.CommandText = "select * from tbl_desp_sub where desp_no=@code"
                With sqlcmd
                    .Parameters.AddWithValue("@code", cboDispNo.Text)
                End With
                dr = sqlcmd.ExecuteReader
                While dr.Read
                    If dr(3) <> dr(4) Then
                        blnfinish = False
                    Else
                        'If balanceq > 0 Then
                        '    blnfinish = False
                        'End If
                    End If
                End While
                dr.Close()
                clearparam(sqlcmd)
                'If balanceq > 0 Then
                '    Query2 = "Update tbl_despdet set status=1 where desp_no=@dcode"
                '    sqlcmd.CommandText = Query2
                '    With sqlcmd
                '        .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                '    End With
                '    sqlcmd.ExecuteNonQuery()
                '    clearparam(sqlcmd)
                'End If
                If blnfinish = True Then
                    Query2 = "Update tbl_despdet set status=1 where desp_no=@dcode"
                    sqlcmd.CommandText = Query2
                    With sqlcmd
                        .Parameters.AddWithValue("@dcode", cboDispNo.Text)
                    End With
                    sqlcmd.ExecuteNonQuery()
                    clearparam(sqlcmd)
                    If balanceq = 0 Then
                        sqlcmd.CommandText = "Update tbl_barcode set status=2 where serial_no=@cno"
                        With sqlcmd
                            .Parameters.AddWithValue("@cno", txtcode.Text)
                        End With
                        sqlcmd.ExecuteNonQuery()
                        clearparam(sqlcmd)
                        
                    End If
                    MsgBox("All items of Despatch Scanned", MsgBoxStyle.OkOnly, "BEC")
                    cboDispNo.Text = ""
                    'clearscreen()
                End If
                mytransaction.Commit()
                If blnfinish Then
                    clearscreen()
                End If
                txtcode.Text = ""
            Catch ex As Exception
                mytransaction.Rollback()
                MsgBox(ex.Message)
                MsgBox("Please Scan Again", MsgBoxStyle.Critical, "BEC")
                txtcode.Text = ""
                txtcode.Focus()
            End Try
        End If
    End Sub

    Private Sub clearscreen()
        If cboDispNo.Text <> "" Then
            dTable1.Clear()
            Dim dAdptv As New SqlDataAdapter("SELECT DISTINCT Desp_no  FROm tbl_Despdet   WHERE status=0", con)
            dAdptv.Fill(dTable1)
            If dTable1.Rows.Count > 0 Then
                txtcode.Text = ""
                txtcode.Focus()
            Else
                dTable1.Clear()
                cboDispNo.Items.Clear()
                Dim dAdpt2 As New SqlDataAdapter("SELECT DISTINCT Desp_no  FROm tbl_Despdet   WHERE status=0", con)
                dAdpt2.Fill(dTable1)
                If dTable1.Rows.Count > 0 Then
                    For j = 0 To dTable1.Rows.Count - 1
                        cboDispNo.Items.Add(dTable1.Rows(j).Item("Desp_code"))
                    Next
                End If
                txtcode.Text = ""
                cboDispNo.Focus()
            End If
        Else
            dTable1.Clear()
            cboDispNo.Items.Clear()
            Dim dAdpt2 As New SqlDataAdapter("SELECT DISTINCT Desp_no  FROm tbl_Despdet   WHERE status=0", con)
            dAdpt2.Fill(dTable1)
            Try
                If dTable1.Rows.Count > 0 Then
                    For j = 0 To dTable1.Rows.Count - 1
                        cboDispNo.Items.Add(dTable1.Rows(j).Item("Desp_code"))
                    Next
                End If
            Catch ex As Exception

            End Try
           
            txtcode.Text = ""
            cboDispNo.Focus()
        End If



    End Sub
    Public Function syncmaxno(ByVal con As SqlConnection) As Double
        Dim dr As SqlDataReader
        Dim sno1 As Integer = 0
        sqlcmd.CommandText = "select isnull(Max(Sno),0)+1  as no from SyncTable"
        dr = sqlcmd.ExecuteReader
        If dr.Read Then
            sno1 = dr(0)
        End If
        dr.Close()
        Return sno1
    End Function

    Private Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        EmpCheckFlag = False
    End Sub

    Private Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clearscreen()
        txtcode.Text = ""
        txtempcode.Text = ""
        txtempcode.Focus()
        txtcode.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        clearscreen()
        txtcode.Text = ""
        txtempcode.Text = ""
        txtempcode.Focus()
        frmmain.Focus()
        frmmain.Show()
    End Sub

    Private Sub cboDispNo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDispNo.SelectedValueChanged
        If cboDispNo.Text <> "" Then
            txtcode.Focus()
        End If
    End Sub
End Class
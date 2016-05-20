Imports System.Data.SqlClient
Imports System.Data

Public Class FrmPhysicalVer
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
    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
                    txtcode.Focus()
                Else
                    'Dim a As New DatalogicDeviceBeeper(500, 2000, 0, 0)
                    MsgBox("Invalid  User", MsgBoxStyle.Critical, "BEC")
                    txtempcode.Text = ""
                    txtempcode.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub clearparam(ByVal sqlcmd As SqlCommand)
        sqlcmd.Parameters.Clear()
    End Sub

    Private Sub txtcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim intcount As Integer = 0
            If txtcode.Text <> "" Then
                If txtempcode.Text = "" Then
                    MsgBox("User code Empty", MsgBoxStyle.Critical, "BEC")
                    Exit Sub
                End If
                dTable.Rows.Clear()
                clearparam(sqlcmd)
                sqlcmd.CommandText = "Select * from tbl_barcode where serial_no=@sno"
                sqlcmd.Parameters.AddWithValue("@sno", txtcode.Text)
                dr = sqlcmd.ExecuteReader
                dTable.Load(dr)
                If dTable.Rows.Count > 0 Then
                    If dTable.Rows(0).Item("Status") = 0 Then
                        MsgBox("Reciept Scan Not Done", MsgBoxStyle.Critical, "BEC")
                        Exit Sub
                    ElseIf dTable.Rows(0).Item("Status") > 1 Then
                        MsgBox("Item Already Despatched", MsgBoxStyle.Critical, "BEC")
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical, "BEC")
                    Exit Sub
                End If
                clearparam(sqlcmd)
                For intcount = 0 To ListView2.Items.Count - 1
                    If txtcode.Text = ListView2.Items(intcount).SubItems(1).Text Then
                        MsgBox("Already Scanned", MsgBoxStyle.Critical, "BMR")
                        txtcode.Text = ""
                        Exit Sub
                    End If
                Next
                dTable.Clear()
                sqlcmd.CommandText = "Select * from tbl_barcode A inner join tbl_ItemMast B on A.item_code=B.item_id where A.serial_no=@sno"
                sqlcmd.Parameters.AddWithValue("@sno", txtcode.Text)
                dr = sqlcmd.ExecuteReader
                dTable.Load(dr)
                Dim list As New ListViewItem
                list = New ListViewItem(dTable.Rows(0).Item("Item_id").ToString)
                list.SubItems.Add(txtcode.Text)
                'list.SubItems.Add(dTable.Rows(0).Item("Item_code").ToString)
                ListView2.Items.Add(list)
                'ListView2.EnsureVisible(ListView2.Items.Count - 1)
                'ListView2.Update()
                For intcount = 0 To ListView1.Items.Count - 1
                    If dTable.Rows(0).Item("Item_id").ToString = ListView1.Items(intcount).Text Then
                        ListView1.Items(intcount).SubItems(2).Text = Val(ListView1.Items(intcount).SubItems(2).Text) + 1
                        GoTo exit1
                    End If
                Next
                Dim list1 As New ListViewItem
                list1 = New ListViewItem(dTable.Rows(0).Item("Item_id").ToString)
                list1.SubItems.Add(dTable.Rows(0).Item("Item_name").ToString)
                list1.SubItems.Add("1")
                'list.SubItems.Add(dTable.Rows(0).Item("Item_code").ToString)
                ListView1.Items.Add(list1)
exit1:
                txtcode.Text = ""

            End If
        End If
    End Sub

    Private Sub FrmPhysicalVer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        txtempcode.Focus()
    End Sub

    Private Sub btnclear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        If ListView2.Items.Count > 0 Then
            If txtempcode.Text <> "" Then
                Dim intid, intcount As Integer
                clearparam(sqlcmd)
                sqlcmd.CommandText = "Select isnull(Max(Phy_id),0)+1 from tbl_phy_ver_scan"
                intid = Val(sqlcmd.ExecuteScalar)
                For intcount = 0 To ListView2.Items.Count - 1
                    sqlcmd.CommandText = "Insert into tbl_phy_ver_scan values(" & intid & ",getdate(),'" & txtempcode.Text & "','" & ListView2.Items(intcount).SubItems(1).Text & "','" & ListView2.Items(intcount).Text & "')"
                    sqlcmd.ExecuteNonQuery()
                    clearparam(sqlcmd)
                Next
                ListView1.Items.Clear()
                ListView2.Items.Clear()
                txtempcode.Text = ""
                txtempcode.Text = ""
            Else
                MsgBox("User Code empty!", MsgBoxStyle.Critical, "BEC")
                Exit Sub
            End If
        Else
            MsgBox("No items Scanned", MsgBoxStyle.Critical, "BEC")
            Exit Sub
        End If
    End Sub

End Class
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
'Imports DLCEDEVICELib
Public Class frmmain
    Public MyVersion As Integer = 1
    Public con As System.Data.SqlClient.SqlConnection
    Public sqlcmd As System.Data.SqlClient.SqlCommand
    Public dr As System.Data.SqlClient.SqlDataReader
    Private Sub frmmain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.D1 Then
            If versioncheck() = True Then
                frmdispatch.Focus()
                frmdispatch.Show()
            End If
        ElseIf e.KeyCode = Keys.D2 Then
            If versioncheck() = True Then
                frmreceipt.Focus()
                frmreceipt.Show()
            End If
            'ElseIf e.KeyCode = Keys.D3 Then
            '    If versioncheck() = True Then
            '        'frmInvoice.Focus()
            '        'frmInvoice.Show()
            '        frmreceipt.Focus()
            '        frmreceipt.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.D4 Then
            '    '   frmreceipt.Focus()
            '    '   frmreceipt.Show()
            '    If versioncheck() = True Then
            '        frmPalletScan.Focus()
            '        frmPalletScan.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.D5 Then
            '    If versioncheck() = True Then
            '        frmmultiplerepack.Focus()
            '        frmmultiplerepack.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.D6 Then
            '    'frmexport.Focus()
            '    'frmexport.Show()
            'ElseIf e.KeyCode = Keys.D7 Then
            '    If versioncheck() = True Then
            '        'frmrescaning.Focus()
            '        'frmrescaning.Show()
            '        frmInvoice.Focus()
            '        frmInvoice.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.D8 Then
            '    If versioncheck() = True Then
            '        frmstockreturn.Focus()
            '        frmstockreturn.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.D9 Then
            '    If versioncheck() = True Then
            '        frmrework.Focus()
            '        frmrework.Show()
            '    End If
            'ElseIf e.KeyCode = Keys.F2 Then
            '    If versioncheck() = True Then
            '        frmstockretcom.Focus()
            '        frmstockretcom.Show()
            '    End If
        ElseIf e.KeyCode = Keys.F1 Then
            frmdispatch.Close()
            frmreceipt.Close()
            Me.Close()
            'ElseIf e.KeyCode = Keys.D0 Then
            '    If versioncheck() = True Then
            '        frmtempread.Focus()
            '        frmtempread.Show()
            '    End If
        End If
    End Sub
    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'versioncheck()
    End Sub
    Public Function versioncheck() As Boolean
        versioncheck = False
        Dim path As String, path1 As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Dim mindex As Integer
        Dim myreader As System.IO.StreamReader
        Dim Readtext As String = "", uname As String = "", pwd As String = "", DB As String = "", str As String = ""
        pwd = "stallion"
        '  pwd = "stallion"
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
            MsgBox("Sever Does not Exists", MsgBoxStyle.Critical, "Eastern")
            Exit Function
        End If
        'path1 = "E:\Projects\VKC Scanner\MEMOR2852013\Eastern\bin\Debug\Data.txt"
        path1 = path1 & "\Data.txt"
        myreader = New System.IO.StreamReader(path1)
        mindex = 0
        While myreader.Peek <> -1
            str = myreader.ReadLine
            mindex = mindex + 1
            Exit While
        End While
        myreader.Close()

        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

        'path = path & "\version.txt"
        'myreader = New System.IO.StreamReader(path)
        'mindex = 0
        'While myreader.Peek <> -1
        '    MyVersion = myreader.ReadLine
        '    mindex = mindex + 1
        '    Exit While
        'End While
        'myreader.Close()

        If str = "" Then
            MsgBox("Sever Connection Failed", MsgBoxStyle.Critical, "Eastern")
            Exit Function
        End If

        str = Trim(str)
        DB = Mid(str, 1, (InStr(1, str, ",", vbTextCompare) - 1))

        str = Mid(str, (InStr(1, str, ",", vbTextCompare) + 1), Len(str))
        uname = str
        'con.ConnectionString = "Data Source=172.28.0.199;Initial Catalog=EASTCON;User ID=sa; password=BEC;"
        con = New System.Data.SqlClient.SqlConnection("Data Source=" & Readtext & ";Initial Catalog=" & DB & ";User ID=" & uname & "; password=" & pwd & ";")
        con.Open()
        'sqlcmd = con.CreateCommand
        'sqlcmd.CommandText = "select appversion from Softwareversion where appname='Memor' and appversion=" & MyVersion
        'dr = sqlcmd.ExecuteReader
        'If dr.Read = False Then
        '    dr.Close()
        '    con.Close()
        '    MsgBox("Please use latest exe", MsgBoxStyle.Critical, "eastern@123")
        '    Application.Exit()
        '    Exit Function
        'Else
        '    dr.Close()
        '    Dim CurServerDate As Date = Now()
        '    sqlcmd.CommandText = "select getdate()"
        '    dr = sqlcmd.ExecuteReader
        '    If dr.Read Then
        '        CurServerDate = dr(0)
        '    End If
        '    dr.Close()
        '    con.Close()
        '    If Format(Now(), "dd/MMM/yyyy") <> Format(CurServerDate, "dd/MMM/yyyy") Then
        '        MsgBox("Current Server Date:" & CurServerDate.ToString & " Please CHeck Memor Date", MsgBoxStyle.Critical, "eastern@123")
        '        Application.Exit()
        '        Exit Function
        '    End If
        'GetURL("192.168.1.21", "/version.txt", 80)
        'If System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "/version.txt") Then
        '    myreader = New System.IO.StreamReader(path)
        '    mindex = 0
        '    While myreader.Peek <> -1
        '        Readtext = myreader.ReadLine
        '        mindex = mindex + 1
        '        'Exit While
        '    End While
        '    myreader.Close()

        '    If Readtext <> MyVersion Then
        '        Process.Start(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "/updater.exe", "192.168.1.21 /VKC.exe 80")
        '        Application.Exit()
        '    End If
        'End If
        versioncheck = True
        'End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If versioncheck() = True Then
            frmdispatch.Focus()
            frmdispatch.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If versioncheck() = True Then
            frmreceipt.Focus()
            frmreceipt.Show()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmdispatch.Close()
        frmreceipt.Close()
        Me.Close()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If versioncheck() = True Then
            FrmPhysicalVer.Focus()
            FrmPhysicalVer.Show()
        End If
    End Sub
End Class

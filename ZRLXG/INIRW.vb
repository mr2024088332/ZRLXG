Module INIRW
#Region "InI 的读写"
    'Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '  Dim path As String
    'ini文件名为 Send.ini
    '     path = Application.StartupPath + "\Send.ini"

    '     TextBox1.Text = GetINI("Send", "Send1", "", path)
    '     TextBox2.Text = GetINI("Send", "Send2", "", path)
    '   Dim IsSms As Integer = GetINI("Send", "IsSms", "", path)
    '      If (IsSms = 1) Then
    '          Me.RadioButton1.Checked = True
    '      ElseIf (IsSms = 0) Then
    '      End If
    '  End Sub

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    '定义读取配置文件函数

    Public Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String

        Dim Str As String = LSet(Str, 256)

        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)

        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)

    End Function

    '定义写入配置文件函数

    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long

        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)

    End Function

    '   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '     Try
    'Dim path As String
    '         path = Application.StartupPath + "\Send.ini"
    '        WriteINI("Send", "Send1", TextBox1.Text, path)
    '        WriteINI("Send", "Send2", TextBox2.Text, path)
    '       If (Me.RadioButton1.Checked = True) Then
    '           WriteINI("Send", "IsSms", 1, path)
    ''       ElseIf (Me.RadioButton2.Checked = True) Then
    '           WriteINI("Send", "IsSms", 0, path)
    '       End If
    '       MsgBox("配置设置已经成功！！！！")
    '   Catch ex As Exception
    '       MsgBox("错误！！！！")
    '   End Try
#End Region
End Module

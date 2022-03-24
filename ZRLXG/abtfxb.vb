Imports System.Windows.Forms

Public Class abtfxb
    Public Path As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub abtfxb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path = Application.StartupPath & "Dev.ini"
        Try
            If GetINI("dev", "isnoffical", "", Path) = "1" Then
                Label2.Text = "不"
            Else
                Label2.Text = "是"
            End If
            Label4.Text = GetINI("Dev", "Corp", "", Path)
            If GetINI("Dev", "Corp", "", Path) = "" Then
                Label4.Text = "OMDN Inc"
            End If
        Catch ex As Exception
            Label2.Text = "盗版"
            Label4.Text = "无法验证发布者"
        End Try

    End Sub
End Class

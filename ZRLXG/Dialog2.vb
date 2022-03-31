Imports System.Windows.Forms

Public Class Dialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            mygamerules.Title = GetINI("Mode", "Name", "", TextBox1.Text.ToString)

            
            Start_MYR()

            Me.Close()
        Catch ex As Exception
          MessageBox.Show("Error", "Error: " & RndString(5), MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Dialog1.Show()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New OpenFileDialog
        a.Title = "选择一个自定义游戏的配置文件"
        a.Filter = "Game Config File|*.GCF|All File|*.*"
        a.ShowDialog()
        TextBox1.Text = a.FileName


    End Sub
End Class

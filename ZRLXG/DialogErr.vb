Imports System.Windows.Forms

Public Class DialogErr

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = StringR.RndString(5000)
    End Sub

    Private Sub DialogErr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Normal.Close()
        Dialog1.Close()
        abtfxb.Close()
        abtfrm.Close()
        SplashScreen.Close()
        SplashScreenClose.Close()
    End Sub
End Class

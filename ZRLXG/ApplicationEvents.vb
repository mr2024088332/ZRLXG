Namespace My

    ' 以下事件可用于 MyApplication:
    ' 
    ' Startup: 应用程序启动时在创建启动窗体之前引发。
    ' Shutdown: 在关闭所有应用程序窗体后引发。如果应用程序异常终止，则不会引发此事件。
    ' UnhandledException: 在应用程序遇到未经处理的异常时引发。
    ' StartupNextInstance: 在启动单实例应用程序且应用程序已处于活动状态时引发。
    ' NetworkAvailabilityChanged: 在连接或断开网络连接时引发。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            ' Dim a As String
            ' MessageBox.Show("你要退出!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SplashScreenClose.Show()

        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            SplashScreen.BackgroundImage = My.Resources.Sblogo
            ' Print("WelCome")
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            DialogErr.Show()
            Normal.Close()
            Dialog1.Close()
            abtfxb.Close()
            abtfrm.Close()
            SplashScreen.Close()
            SplashScreenClose.Close()
            ErrorToString()
        End Sub
    End Class


End Namespace


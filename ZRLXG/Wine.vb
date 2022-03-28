Public Class Wine
#Region "菜单栏代码"
    Private Sub 全屏ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全屏ToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub 窗口化ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 窗口化ToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
    End Sub

    Private Sub 关于ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于ToolStripMenuItem.Click
        abtfrm.ShowDialog()

    End Sub
#End Region

#Region "杂项"
    Private Sub 关闭ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripMenuItem.Click
        Close()
    End Sub
#End Region

#Region "地图选择"
    Private Sub CityOfWarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CityOfWarToolStripMenuItem.Click
        PictureBox1.BackgroundImage = My.Resources.City_of_War
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        PictureBox1.BackgroundImage = My.Resources.LG1
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        PictureBox1.BackgroundImage = My.Resources.LG2
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        PictureBox1.BackgroundImage = My.Resources.LG3
    End Sub
#End Region
#Region "Menu Items 2"
    Private Sub 新关卡ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新关卡ToolStripMenuItem.Click
        Dialog1.Show()
    End Sub

    Private Sub 发行版信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 发行版信息ToolStripMenuItem.Click
        abtfxb.ShowDialog()
    End Sub

    Private Sub 显示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 显示ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
    End Sub

    Private Sub 不显示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 不显示ToolStripMenuItem.Click
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub 显示ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 显示ToolStripMenuItem1.Click
        Me.ControlBox = True
    End Sub

    Private Sub 不显示ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 不显示ToolStripMenuItem1.Click
        Me.ControlBox = False
    End Sub
#End Region
#Region "ZRLGOMAP"
    Private Sub 张锐的头像ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 张锐的头像ToolStripMenuItem.Click
        PictureBox1.BackgroundImage = My.Resources.ZRLGO
    End Sub
#End Region
 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("You Win!!!", vbYes, "傻逼张锐终于被用酒灌醉而死了 !!!")
        Dialog1.Show()
    End Sub
End Class
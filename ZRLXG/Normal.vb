Public Class Normal
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
#Region "会动的张锐"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Point1 As Point
        Point1.X = Int(((Me.Size.Width - 500 + 1) * Rnd() + Me.Size.Width / 2))
        Point1.Y = Int(((Me.Size.Height - 500 + 1) * Rnd() + Me.Size.Height / 2))
        Dim Point2 As Point
        Point2.X = Int(((Me.Size.Width - 600 + 1) * Rnd() + Me.Size.Width / 2))
        Point2.Y = Int(((Me.Size.Height - 600 + 1) * Rnd() + Me.Size.Height / 2))
        Dim Point3 As Point
        Point3.X = Int(((Me.Size.Width - 700 + 1) * Rnd() + Me.Size.Width / 2))
        Point3.Y = Int(((Me.Size.Height - 700 + 1) * Rnd() + Me.Size.Height / 2))

        PictureBox2.Location = Point1
        PictureBox3.Location = Point2
        PictureBox4.Location = Point3
    End Sub
#End Region
#Region "杂项"
    Private Sub 关闭ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripMenuItem.Click
        Close()
    End Sub
#End Region
#Region "胜利，开始"
   
    Private Sub 新关卡ToolStripMenuItem_Click() '(sender As Object, e As EventArgs) Handles 新关卡ToolStripMenuItem.Click
        Dialog1.Show()
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Timer1.Enabled = False
        MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

        Dialog1.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Timer1.Enabled = False
        MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

        Dialog1.Show()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Timer1.Enabled = False
        MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

        Dialog1.Show()
    End Sub
#End Region
#Region "地图选择"
    Private Sub CityOfWarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CityOfWarToolStripMenuItem.Click
        PictureBox1.Image = My.Resources.City_of_War
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        PictureBox1.Image = My.Resources.LG1
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        PictureBox1.Image = My.Resources.LG2
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        PictureBox1.Image = My.Resources.LG3
    End Sub
#End Region

   
    Private Sub 新关卡ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新关卡ToolStripMenuItem.Click
        Dialog1.Show()
    End Sub

    Private Sub 发行版信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 发行版信息ToolStripMenuItem.Click
        abtfxb.ShowDialog()
    End Sub
End Class


'开发文档还没写，敬请期待
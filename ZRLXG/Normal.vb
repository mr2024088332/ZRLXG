Public Class Normal
#Region "定义全局变量"
    Public E_ZRH As Boolean
#End Region
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

        ZRHX.Text = ZRH.Value.ToString '定义张锐的生命值

        Timer2.Enabled = E_ZRH



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

    Private Sub 关闭ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripMenuItem1.Click
        E_ZRH = False
    End Sub
    Private Sub 新关卡ToolStripMenuItem_Click() '(sender As Object, e As EventArgs) Handles 新关卡ToolStripMenuItem.Click
        Dialog1.Show()
    End Sub

    Private Sub Normal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        E_ZRH = False
        ZRH.Value = ZRH.Maximum
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        If E_ZRH = True Then
            If ZRH.Value < ZRH.Minimum Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

                Dialog1.Show()
            Else
                ZRH.Value -= 5
            End If
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
            MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

            Dialog1.Show()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If E_ZRH = True Then
            If ZRH.Value < ZRH.Minimum Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

                Dialog1.Show()
            Else
                ZRH.Value -= 5
            End If
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
            MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

            Dialog1.Show()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        If E_ZRH = True Then
            If ZRH.Value < ZRH.Minimum Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

                Dialog1.Show()
            Else
                ZRH.Value -= 5
            End If
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
            MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

            Dialog1.Show()
        End If
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
    Private Sub 开启ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开启ToolStripMenuItem.Click
        E_ZRH = True
    End Sub
#Region "Timer2"
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If ZRH.Value = ZRH.Minimum Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            MsgBox("You Win!!!", vbYes, "ZhengRUi Is Death !!!")

            Dialog1.Show()
        Else
            ZRH.Value -= 5
        End If


    End Sub
#End Region

   
    Private Sub Err_log_Do_Tick(sender As Object, e As EventArgs) Handles Err_log_Do.Tick
        If ZRH.Value < ZRH.Minimum Then
            DialogErr.Show()
        End If
    End Sub
End Class


'开发文档还没写，敬请期待
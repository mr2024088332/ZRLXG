<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Normal
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.窗口化运行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.窗口化ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全屏ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.新关卡ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.窗口化运行ToolStripMenuItem, Me.新关卡ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(688, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '窗口化运行ToolStripMenuItem
        '
        Me.窗口化运行ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.窗口化ToolStripMenuItem, Me.全屏ToolStripMenuItem, Me.关闭ToolStripMenuItem})
        Me.窗口化运行ToolStripMenuItem.Name = "窗口化运行ToolStripMenuItem"
        Me.窗口化运行ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.窗口化运行ToolStripMenuItem.Text = "窗口化运行"
        '
        '窗口化ToolStripMenuItem
        '
        Me.窗口化ToolStripMenuItem.Name = "窗口化ToolStripMenuItem"
        Me.窗口化ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.窗口化ToolStripMenuItem.Text = "窗口化"
        '
        '全屏ToolStripMenuItem
        '
        Me.全屏ToolStripMenuItem.Name = "全屏ToolStripMenuItem"
        Me.全屏ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.全屏ToolStripMenuItem.Text = "全屏"
        '
        '关闭ToolStripMenuItem
        '
        Me.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem"
        Me.关闭ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.关闭ToolStripMenuItem.Text = "关闭"
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ZRLXG.My.Resources.Resources.City_of_War
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(688, 531)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ZRLXG.My.Resources.Resources.ZRLGO
        Me.PictureBox2.Location = New System.Drawing.Point(278, 255)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(104, 108)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 550
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.ZRLXG.My.Resources.Resources.ZRLGO
        Me.PictureBox4.Location = New System.Drawing.Point(63, 28)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(104, 108)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 4
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ZRLXG.My.Resources.Resources.ZRLGO
        Me.PictureBox3.Location = New System.Drawing.Point(153, 175)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(104, 108)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        '新关卡ToolStripMenuItem
        '
        Me.新关卡ToolStripMenuItem.Name = "新关卡ToolStripMenuItem"
        Me.新关卡ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.新关卡ToolStripMenuItem.Text = "新关卡"
        '
        'Normal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(688, 556)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Normal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "张锐历险记"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 窗口化运行ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 窗口化ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全屏ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents 关闭ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents 新关卡ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

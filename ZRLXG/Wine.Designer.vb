<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Wine
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.窗口化运行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.窗口化ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全屏ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.边框ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.边框ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.显示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.不显示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.按钮ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.显示ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.不显示ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.血量ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.开启ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关闭ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.新关卡ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.地图选择ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CityOfWarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.骆正义ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.张锐的头像ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.发行版信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.ZRLXG.My.Resources.Resources.City_of_War
        Me.PictureBox1.Location = New System.Drawing.Point(0, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(595, 346)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.窗口化运行ToolStripMenuItem, Me.血量ToolStripMenuItem, Me.新关卡ToolStripMenuItem, Me.地图选择ToolStripMenuItem, Me.关于ToolStripMenuItem, Me.发行版信息ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(595, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '窗口化运行ToolStripMenuItem
        '
        Me.窗口化运行ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.窗口化ToolStripMenuItem, Me.全屏ToolStripMenuItem, Me.边框ToolStripMenuItem, Me.关闭ToolStripMenuItem})
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
        Me.全屏ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.全屏ToolStripMenuItem.Name = "全屏ToolStripMenuItem"
        Me.全屏ToolStripMenuItem.ShowShortcutKeys = False
        Me.全屏ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.全屏ToolStripMenuItem.Text = "全屏"
        Me.全屏ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.全屏ToolStripMenuItem.Visible = False
        '
        '边框ToolStripMenuItem
        '
        Me.边框ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.边框ToolStripMenuItem1, Me.按钮ToolStripMenuItem})
        Me.边框ToolStripMenuItem.Name = "边框ToolStripMenuItem"
        Me.边框ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.边框ToolStripMenuItem.Text = "边框"
        '
        '边框ToolStripMenuItem1
        '
        Me.边框ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.显示ToolStripMenuItem, Me.不显示ToolStripMenuItem})
        Me.边框ToolStripMenuItem1.Name = "边框ToolStripMenuItem1"
        Me.边框ToolStripMenuItem1.Size = New System.Drawing.Size(100, 22)
        Me.边框ToolStripMenuItem1.Text = "边框"
        '
        '显示ToolStripMenuItem
        '
        Me.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem"
        Me.显示ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.显示ToolStripMenuItem.Text = "显示"
        '
        '不显示ToolStripMenuItem
        '
        Me.不显示ToolStripMenuItem.Name = "不显示ToolStripMenuItem"
        Me.不显示ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.不显示ToolStripMenuItem.Text = "不显示"
        '
        '按钮ToolStripMenuItem
        '
        Me.按钮ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.显示ToolStripMenuItem1, Me.不显示ToolStripMenuItem1})
        Me.按钮ToolStripMenuItem.Name = "按钮ToolStripMenuItem"
        Me.按钮ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.按钮ToolStripMenuItem.Text = "按钮"
        '
        '显示ToolStripMenuItem1
        '
        Me.显示ToolStripMenuItem1.Name = "显示ToolStripMenuItem1"
        Me.显示ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.显示ToolStripMenuItem1.Text = "显示"
        '
        '不显示ToolStripMenuItem1
        '
        Me.不显示ToolStripMenuItem1.Name = "不显示ToolStripMenuItem1"
        Me.不显示ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.不显示ToolStripMenuItem1.Text = "不显示"
        '
        '关闭ToolStripMenuItem
        '
        Me.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem"
        Me.关闭ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.关闭ToolStripMenuItem.Text = "关闭"
        '
        '血量ToolStripMenuItem
        '
        Me.血量ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.开启ToolStripMenuItem, Me.关闭ToolStripMenuItem1})
        Me.血量ToolStripMenuItem.Name = "血量ToolStripMenuItem"
        Me.血量ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.血量ToolStripMenuItem.Text = "血量"
        Me.血量ToolStripMenuItem.Visible = False
        '
        '开启ToolStripMenuItem
        '
        Me.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem"
        Me.开启ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.开启ToolStripMenuItem.Text = "开启"
        '
        '关闭ToolStripMenuItem1
        '
        Me.关闭ToolStripMenuItem1.Name = "关闭ToolStripMenuItem1"
        Me.关闭ToolStripMenuItem1.Size = New System.Drawing.Size(100, 22)
        Me.关闭ToolStripMenuItem1.Text = "关闭"
        '
        '新关卡ToolStripMenuItem
        '
        Me.新关卡ToolStripMenuItem.Name = "新关卡ToolStripMenuItem"
        Me.新关卡ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.新关卡ToolStripMenuItem.Text = "新关卡"
        '
        '地图选择ToolStripMenuItem
        '
        Me.地图选择ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CityOfWarToolStripMenuItem, Me.骆正义ToolStripMenuItem, Me.张锐的头像ToolStripMenuItem})
        Me.地图选择ToolStripMenuItem.Name = "地图选择ToolStripMenuItem"
        Me.地图选择ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.地图选择ToolStripMenuItem.Text = "地图选择"
        Me.地图选择ToolStripMenuItem.Visible = False
        '
        'CityOfWarToolStripMenuItem
        '
        Me.CityOfWarToolStripMenuItem.Name = "CityOfWarToolStripMenuItem"
        Me.CityOfWarToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CityOfWarToolStripMenuItem.Text = "City Of War"
        '
        '骆正义ToolStripMenuItem
        '
        Me.骆正义ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.骆正义ToolStripMenuItem.Name = "骆正义ToolStripMenuItem"
        Me.骆正义ToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.骆正义ToolStripMenuItem.Text = "骆正义"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripMenuItem2.Text = "1"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripMenuItem3.Text = "2"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripMenuItem4.Text = "3"
        '
        '张锐的头像ToolStripMenuItem
        '
        Me.张锐的头像ToolStripMenuItem.Name = "张锐的头像ToolStripMenuItem"
        Me.张锐的头像ToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.张锐的头像ToolStripMenuItem.Text = "张锐的头像"
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        '发行版信息ToolStripMenuItem
        '
        Me.发行版信息ToolStripMenuItem.Name = "发行版信息ToolStripMenuItem"
        Me.发行版信息ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.发行版信息ToolStripMenuItem.Text = "发行版信息"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.ZRLXG.My.Resources.Resources.LG3
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(32, 55)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(132, 228)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ZRLXG.My.Resources.Resources.ZRLGO
        Me.PictureBox3.Location = New System.Drawing.Point(344, 55)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(239, 228)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(196, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(142, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "使用骆正义的酒灌醉张锐"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.ZRLXG.My.Resources.Resources.Wine
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(218, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 184)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "灌醉"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Wine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 371)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Wine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "张锐历险记 -Wine Mode (Dev)"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 窗口化运行ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 窗口化ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全屏ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 边框ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 边框ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 显示ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 不显示ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 按钮ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 显示ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 不显示ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关闭ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 血量ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 开启ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关闭ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 新关卡ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 地图选择ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CityOfWarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 骆正义ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 张锐的头像ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 发行版信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

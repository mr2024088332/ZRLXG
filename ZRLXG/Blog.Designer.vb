<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent_A()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnReadOnly = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudTabIndex = New System.Windows.Forms.NumericUpDown()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnLoading = New System.Windows.Forms.Button()
        Me.tbxEvents = New System.Windows.Forms.TextBox()
        CType(Me.nudTabIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContainer
        '
        Me.pnlContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlContainer.Location = New System.Drawing.Point(9, 105)
        Me.pnlContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(934, 615)
        Me.pnlContainer.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(51, 25)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(12, 72)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(51, 25)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(69, 72)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(63, 25)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(69, 12)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(82, 25)
        Me.btnRemoveAll.TabIndex = 2
        Me.btnRemoveAll.Text = "RemoveAll"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnReadOnly
        '
        Me.btnReadOnly.Location = New System.Drawing.Point(157, 12)
        Me.btnReadOnly.Name = "btnReadOnly"
        Me.btnReadOnly.Size = New System.Drawing.Size(111, 25)
        Me.btnReadOnly.TabIndex = 3
        Me.btnReadOnly.Text = "ReadOnly:False"
        Me.btnReadOnly.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "以下按钮指定索引操作，TabIndex:"
        '
        'nudTabIndex
        '
        Me.nudTabIndex.Location = New System.Drawing.Point(215, 43)
        Me.nudTabIndex.Name = "nudTabIndex"
        Me.nudTabIndex.Size = New System.Drawing.Size(60, 23)
        Me.nudTabIndex.TabIndex = 5
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(138, 72)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(62, 25)
        Me.btnSelect.TabIndex = 6
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnLoading
        '
        Me.btnLoading.Location = New System.Drawing.Point(206, 72)
        Me.btnLoading.Name = "btnLoading"
        Me.btnLoading.Size = New System.Drawing.Size(96, 25)
        Me.btnLoading.TabIndex = 7
        Me.btnLoading.Text = "Loading:False"
        Me.btnLoading.UseVisualStyleBackColor = True
        '
        'tbxEvents
        '
        Me.tbxEvents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxEvents.Location = New System.Drawing.Point(320, 5)
        Me.tbxEvents.Multiline = True
        Me.tbxEvents.Name = "tbxEvents"
        Me.tbxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbxEvents.Size = New System.Drawing.Size(623, 92)
        Me.tbxEvents.TabIndex = 8
        Me.tbxEvents.Text = "事件记录"
        Me.tbxEvents.WordWrap = False
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(952, 729)
        Me.Controls.Add(Me.tbxEvents)
        Me.Controls.Add(Me.btnLoading)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.nudTabIndex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnReadOnly)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.pnlContainer)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "仿Edge浏览器风格的TabControl控件演示"
        CType(Me.nudTabIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlContainer As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemoveAll As Button
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnReadOnly As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents nudTabIndex As NumericUpDown
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnLoading As Button
    Friend WithEvents tbxEvents As TextBox
End Class

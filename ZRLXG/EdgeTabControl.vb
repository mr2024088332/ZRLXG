Imports System.ComponentModel

Public Class EdgeTabControl
    Inherits Windows.Forms.Control
    Implements IMessageFilter

    Private tmpControl As Control
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        'WM_MOUSEFIRST - WM_MOUSELAST，WM_KEYFIRST - WM_KEYLAST
        If _ReadOnly AndAlso ((m.Msg >= &H200 AndAlso m.Msg <= &H20D) OrElse (m.Msg >= &H100 AndAlso m.Msg <= &H108)) Then
            tmpControl = Control.FromChildHandle(m.HWnd)
            While tmpControl IsNot Nothing
                If tmpControl Is Me Then
                    Return True
                End If
                tmpControl = tmpControl.Parent
            End While
        End If
        Return False
    End Function



#Region "事件"

    ''' <summary>
    ''' 在标签页被移除之前触发。
    ''' </summary>
    Public Event BeforeTabRemoved(sender As Object, e As EdgeTabPageEventArgs)

    ''' <summary>
    ''' 当取消选择标签页时发生。
    ''' </summary>
    Public Event TabDeselected(sender As Object, e As EdgeTabPageEventArgs)

    ''' <summary>
    ''' 在选择标签页时发生。
    ''' </summary>
    Public Event TabSelected(sender As Object, e As EdgeTabPageEventArgs)

    ''' <summary>
    ''' 在 <see cref="SelectedIndex"/> 属性更改后发生。
    ''' </summary>
    Public Event SelectedIndexChanged As EventHandler

    ''' <summary>
    ''' 在用户单击新建标签页后触发。
    ''' </summary>
    Public Event TabNewClicked As EventHandler

    Public Class EdgeTabPageEventArgs
        Inherits EventArgs

        Public Sub New(index As Integer, tabPage As EdgeTabPage)
            _TabPageIndex = index
            _TabPage = tabPage
        End Sub

        Private _TabPageIndex As Integer
        ''' <summary>当前事件相关的标签页索引。</summary>
        Public ReadOnly Property TabPageIndex As Integer
            Get
                Return _TabPageIndex
            End Get
        End Property

        Private _TabPage As EdgeTabPage
        ''' <summary>当前事件相关的标签页对象。</summary>
        Public ReadOnly Property TabPage As EdgeTabPage
            Get
                Return _TabPage
            End Get
        End Property
    End Class

#End Region


#Region "方法"

    ''' <summary>
    ''' 添加标签页。
    ''' </summary>
    ''' <param name="value">需要添加的标签页。</param>
    ''' <param name="selectNewTab">是否需要激活此标签页。</param>
    ''' <exception cref="ArgumentNullException">标签页对象不能为Null。</exception>
    ''' <exception cref="Exception">标签页对象无法重复添加。</exception>
    Public Sub Add(value As EdgeTabPage, Optional selectNewTab As Boolean = False)
        If value Is Nothing Then
            Throw New ArgumentNullException("value", "标签页对象不能为Null。")
        Else
            For tabpageIndex As Integer = 0 To tabPages.Length - 1
                If tabPages(tabpageIndex) Is value Then
                    Throw New Exception("标签页对象已存在，无法重复添加。")
                End If
            Next
        End If
        ' 更新tabPages
        Dim newTabPages(tabPages.Length) As EdgeTabPage
        newTabPages(tabPages.Length) = value
        Array.Copy(tabPages, 0, newTabPages, 0, tabPages.Length)
        tabPages = newTabPages
        ' 添加控件
        value.TabBar.ReadOnly = _ReadOnly
        value.Visible = False
        value.Location = New Point(0, 30)
        value.Size = New Size(Me.Width, Me.Height - 30)
        value.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Me.Controls.Add(value)
        value.TabBar.Visible = False
        Me.Controls.Add(value.TabBar)
        ' 添加事件关联
        AddHandler value.TabBar.TabApplySelect, AddressOf TabApplySelect
        AddHandler value.TabBar.TabApplyRemove, AddressOf TabApplyRemove
        AddHandler value.TabBar.MouseEnter, AddressOf TabMouseEnter
        AddHandler value.TabBar.MouseLeave, AddressOf TabMouseLeave
        ' 激活标签页
        If selectNewTab Then
            Dim oldSelectedIndex As Integer = _SelectedIndex
            _SelectedIndex = tabPages.Length - 1
            ' 刷新显示
            RefreshTabPages()
            ' 触发事件
            RaiseEvent SelectedIndexChanged(Me, Nothing)
            If oldSelectedIndex >= 0 Then
                RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
            End If
            RaiseEvent TabSelected(Me, New EdgeTabPageEventArgs(_SelectedIndex, tabPages(_SelectedIndex)))
        Else
            ' 刷新显示
            RefreshTabPages()
        End If
    End Sub

    ''' <summary>
    ''' 批量添加标签页。
    ''' </summary>
    ''' <param name="pages">需要添加的标签页数组。</param>
    ''' <exception cref="ArgumentNullException">标签页对象不能为Null。</exception>
    ''' <exception cref="Exception">标签页对象无法重复添加。</exception>
    Public Sub AddRange(pages() As EdgeTabPage)
        Dim newpageIndex As Integer
        If pages Is Nothing Then
            Throw New ArgumentNullException("pages", "标签页数组不能为Null。")
        Else
            For newpageIndex = 0 To pages.Length - 1
                If pages(newpageIndex) Is Nothing Then
                    Throw New ArgumentNullException("pages", "标签页对象不能为Null。")
                End If
            Next
            For tabpageIndex = 0 To tabPages.Length - 1
                For newpageIndex = 0 To pages.Length - 1
                    If pages(newpageIndex) Is tabPages(tabpageIndex) Then
                        Throw New Exception("标签页对象已存在，无法重复添加。")
                    End If
                Next
            Next
        End If
        ' 更新tabPages
        Dim newTabPages(tabPages.Length + pages.Length - 1) As EdgeTabPage
        Array.Copy(tabPages, 0, newTabPages, 0, tabPages.Length)
        Array.Copy(pages, 0, newTabPages, tabPages.Length, pages.Length)
        tabPages = newTabPages
        ' 遍历处理
        For newpageIndex = 0 To pages.Length - 1
            ' 添加控件
            pages(newpageIndex).TabBar.ReadOnly = _ReadOnly
            pages(newpageIndex).Visible = False
            pages(newpageIndex).Location = New Point(0, 30)
            pages(newpageIndex).Size = New Size(Me.Width, Me.Height - 30)
            pages(newpageIndex).Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            Me.Controls.Add(pages(newpageIndex))
            pages(newpageIndex).TabBar.Visible = False
            Me.Controls.Add(pages(newpageIndex).TabBar)
            ' 添加事件关联
            AddHandler pages(newpageIndex).TabBar.TabApplySelect, AddressOf TabApplySelect
            AddHandler pages(newpageIndex).TabBar.TabApplyRemove, AddressOf TabApplyRemove
            AddHandler pages(newpageIndex).TabBar.MouseEnter, AddressOf TabMouseEnter
            AddHandler pages(newpageIndex).TabBar.MouseLeave, AddressOf TabMouseLeave
        Next
        ' 刷新显示
        RefreshTabPages()
    End Sub

    ''' <summary>
    ''' 返回指定标签页的索引，如果标签页为Null或不在控件中，则返回-1。
    ''' </summary>
    Public Function IndexOf(page As EdgeTabPage) As Integer
        If page IsNot Nothing Then
            For tabpageIndex As Integer = 0 To tabPages.Length - 1
                If tabPages(tabpageIndex) Is page Then
                    Return tabpageIndex
                End If
            Next
        End If
        Return -1
    End Function

    ''' <summary>
    ''' 将标签页插入到指定索引处，可以通过此方法变更标签页顺序。
    ''' </summary>
    ''' <param name="index">从零开始的索引位置。</param>
    ''' <param name="tabPage">需要插入的标签页。</param>
    ''' <exception cref="ArgumentOutOfRangeException">索引值不能越界。</exception>
    ''' <exception cref="ArgumentNullException">标签页对象不能为Null。</exception>
    Public Sub Insert(index As Integer, tabPage As EdgeTabPage)
        If tabPage Is Nothing Then
            Throw New ArgumentNullException("tabPage", "标签页对象不能为Null。")
        End If
        ' 判断tabPage是否为当前标签页组的其中一员
        Dim tabpageIndex As Integer = 0
        While tabpageIndex < tabPages.Length
            If tabPages(tabpageIndex) Is tabPage Then
                Exit While
            End If
            tabpageIndex += 1
        End While
        If tabpageIndex >= 0 AndAlso tabpageIndex < tabPages.Length Then
            ' tabPage是当前标签页组的其中一员
            If index < 0 OrElse index > tabPages.Length - 1 Then
                Throw New ArgumentOutOfRangeException("index", "索引值越界。")
            End If
            If tabpageIndex = index Then Return
            ' 更新tabPages
            Dim tmpTabPage As EdgeTabPage = tabPages(tabpageIndex)
            tabPages(tabpageIndex) = tabPages(index)
            tabPages(index) = tmpTabPage
            ' 触发索引变更事件
            If _SelectedIndex = tabpageIndex Then
                _SelectedIndex = index
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前激活状态的标签页未变更，只是索引值有变更
            ElseIf _SelectedIndex = index Then
                _SelectedIndex = tabpageIndex
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前激活状态的标签页未变更，只是索引值有变更
            Else
                ' 刷新显示
                RefreshTabPages()
            End If
        Else
            ' tabPage不是当前标签页组的其中一员
            If index < 0 OrElse index > tabPages.Length Then
                Throw New ArgumentOutOfRangeException("index", "索引值越界。")
            End If
            ' 更新tabPages
            Dim newTabPages(tabPages.Length) As EdgeTabPage
            newTabPages(index) = tabPage
            Array.Copy(tabPages, 0, newTabPages, 0, index)
            Array.Copy(tabPages, index, newTabPages, index + 1, tabPages.Length - index)
            tabPages = newTabPages
            ' 添加控件
            tabPage.TabBar.ReadOnly = _ReadOnly
            tabPage.Visible = False
            tabPage.Location = New Point(0, 30)
            tabPage.Size = New Size(Me.Width, Me.Height - 30)
            tabPage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            Me.Controls.Add(tabPage)
            tabPage.TabBar.Visible = False
            Me.Controls.Add(tabPage.TabBar)
            ' 添加事件关联
            AddHandler tabPage.TabBar.TabApplySelect, AddressOf TabApplySelect
            AddHandler tabPage.TabBar.TabApplyRemove, AddressOf TabApplyRemove
            AddHandler tabPage.TabBar.MouseEnter, AddressOf TabMouseEnter
            AddHandler tabPage.TabBar.MouseLeave, AddressOf TabMouseLeave
            ' 更新SelectedIndex
            If index <= _SelectedIndex Then
                _SelectedIndex += 1
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前激活状态的标签页未变更，只是索引值有变更
            Else
                ' 刷新显示
                RefreshTabPages()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 移除指定的标签页。
    ''' </summary>
    ''' <param name="value">需要移除的标签页对象。</param>
    ''' <exception cref="ArgumentNullException">标签页对象不能为Null。</exception>
    Public Sub Remove(value As EdgeTabPage)
        If value Is Nothing Then
            Throw New ArgumentNullException("value", "标签页对象不能为Null。")
        End If
        Dim tabpageIndex As Integer = tabPages.Length
        While tabpageIndex > 0
            tabpageIndex -= 1
            If tabPages(tabpageIndex) Is value Then
                ' 创建新标签页数组
                Dim newTabPages(tabPages.Length - 2) As EdgeTabPage
                Array.Copy(tabPages, 0, newTabPages, 0, tabpageIndex)
                Array.Copy(tabPages, tabpageIndex + 1, newTabPages, tabpageIndex, tabPages.Length - tabpageIndex - 1)
                ' 触发事件
                RaiseEvent BeforeTabRemoved(Me, New EdgeTabPageEventArgs(tabpageIndex, tabPages(tabpageIndex)))
                ' 取消关联事件
                RemoveHandler tabPages(tabpageIndex).TabBar.TabApplySelect, AddressOf TabApplySelect
                RemoveHandler tabPages(tabpageIndex).TabBar.TabApplyRemove, AddressOf TabApplyRemove
                RemoveHandler tabPages(tabpageIndex).TabBar.MouseEnter, AddressOf TabMouseEnter
                RemoveHandler tabPages(tabpageIndex).TabBar.MouseLeave, AddressOf TabMouseLeave
                ' 移除控件
                Me.Controls.Remove(tabPages(tabpageIndex))
                Me.Controls.Remove(tabPages(tabpageIndex).TabBar)
                ' 释放资源
                tabPages(tabpageIndex).Dispose()
                ' 更新数组
                tabPages = newTabPages
                ' 更新SelectedIndex
                If tabpageIndex = _SelectedIndex Then
                    _SelectedIndex = -1
                    ' 刷新显示
                    RefreshTabPages()
                    ' 触发事件
                    RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前选择的标签页已被移除
                ElseIf tabpageIndex < _SelectedIndex Then
                    _SelectedIndex -= 1
                    ' 刷新显示
                    RefreshTabPages()
                    ' 触发事件
                    RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前选择的标签页未变更，只是索引值有变更
                Else
                    ' 刷新显示
                    RefreshTabPages()
                End If
                Exit While
            End If
        End While
    End Sub

    ''' <summary>
    ''' 移除所有标签页。
    ''' </summary>
    Public Sub RemoveAll()
        If tabPages.Length > 0 Then
            Dim tabpageIndex As Integer = tabPages.Length
            While tabpageIndex > 0
                tabpageIndex -= 1
                ' 触发事件
                RaiseEvent BeforeTabRemoved(Me, New EdgeTabPageEventArgs(tabpageIndex, tabPages(tabpageIndex)))
                ' 取消关联事件
                RemoveHandler tabPages(tabpageIndex).TabBar.TabApplySelect, AddressOf TabApplySelect
                RemoveHandler tabPages(tabpageIndex).TabBar.TabApplyRemove, AddressOf TabApplyRemove
                RemoveHandler tabPages(tabpageIndex).TabBar.MouseEnter, AddressOf TabMouseEnter
                RemoveHandler tabPages(tabpageIndex).TabBar.MouseLeave, AddressOf TabMouseLeave
                ' 移除控件
                Me.Controls.Remove(tabPages(tabpageIndex))
                Me.Controls.Remove(tabPages(tabpageIndex).TabBar)
                ' 释放资源
                tabPages(tabpageIndex).Dispose()
            End While
            ' 更新数组
            tabPages = {}
            ' 更新SelectedIndex
            If _SelectedIndex <> -1 Then
                _SelectedIndex = -1
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前激活状态的标签页已被移除
            End If
            ' 刷新显示
            RefreshTabPages()
        End If
    End Sub

    ''' <summary>
    ''' 移除指定索引位置的标签页。
    ''' </summary>
    ''' <param name="index">要移除的标签页从零开始的索引。</param>
    ''' <exception cref="ArgumentOutOfRangeException">索引值不能越界。</exception>
    Public Sub RemoveAt(index As Integer)
        If index >= 0 AndAlso index < tabPages.Length Then
            ' 创建新标签页数组
            Dim newTabPages(tabPages.Length - 2) As EdgeTabPage
            Array.Copy(tabPages, 0, newTabPages, 0, index)
            Array.Copy(tabPages, index + 1, newTabPages, index, tabPages.Length - index - 1)
            ' 触发事件
            RaiseEvent BeforeTabRemoved(Me, New EdgeTabPageEventArgs(index, tabPages(index)))
            ' 取消关联事件
            RemoveHandler tabPages(index).TabBar.TabApplySelect, AddressOf TabApplySelect
            RemoveHandler tabPages(index).TabBar.TabApplyRemove, AddressOf TabApplyRemove
            RemoveHandler tabPages(index).TabBar.MouseEnter, AddressOf TabMouseEnter
            RemoveHandler tabPages(index).TabBar.MouseLeave, AddressOf TabMouseLeave
            ' 移除控件
            Me.Controls.Remove(tabPages(index))
            Me.Controls.Remove(tabPages(index).TabBar)
            ' 释放资源
            tabPages(index).Dispose()
            ' 更新数组
            tabPages = newTabPages
            ' 更新SelectedIndex
            If index = _SelectedIndex Then
                _SelectedIndex = -1
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前选择的标签页已被移除
            ElseIf index < _SelectedIndex Then
                _SelectedIndex -= 1
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)  '当前选择的标签页未变更，只是索引值有变更
            Else
                ' 刷新显示
                RefreshTabPages()
            End If
        Else
            Throw New ArgumentOutOfRangeException("index", "索引值越界。")
        End If
    End Sub

    ''' <summary>
    ''' 使具有指定索引的标签页成为当前标签页，设置为-1时表示不激活任何标签页。
    ''' </summary>
    ''' <param name="index">要选择的标签页在集合中的索引，设置为-1时表示不激活任何标签页。</param>
    ''' <exception cref="ArgumentOutOfRangeException">索引值不能越界。</exception>
    Public Sub SelectTab(index As Integer)
        If index = _SelectedIndex Then Return
        Dim oldSelectedIndex As Integer = _SelectedIndex
        If index >= 0 AndAlso index < tabPages.Length Then
            _SelectedIndex = index
            ' 刷新显示
            RefreshTabPages()
            ' 触发事件
            RaiseEvent SelectedIndexChanged(Me, Nothing)
            If oldSelectedIndex >= 0 Then
                RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
            End If
            RaiseEvent TabSelected(Me, New EdgeTabPageEventArgs(_SelectedIndex, tabPages(_SelectedIndex)))
        ElseIf index = -1 Then
            _SelectedIndex = -1
            ' 刷新显示
            RefreshTabPages()
            ' 触发事件
            RaiseEvent SelectedIndexChanged(Me, Nothing)
            If oldSelectedIndex >= 0 Then
                RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
            End If
        Else
            Throw New ArgumentOutOfRangeException("index", "索引值越界。")
        End If
    End Sub

    ''' <summary>
    ''' 使指定的 <see cref="EdgeTabPage"/> 成为当前标签页，如果设置为Null则不选择任何标签页。
    ''' </summary>
    ''' <param name="tabPage">要选择的 <see cref="EdgeTabPage"/>，如果设置为Null则不选择任何标签页。</param>
    ''' <exception cref="Exception">待选择的标签页必须属于当前控件。</exception>
    Public Sub SelectTab(tabPage As EdgeTabPage)
        Dim index As Integer
        If tabPage Is Nothing Then
            index = -1
        Else
            index = 0
            While index < tabPages.Length
                If tabPages(index) Is tabPage Then
                    Exit While
                End If
                index += 1
            End While
        End If
        If index = _SelectedIndex Then Return
        Dim oldSelectedIndex As Integer = _SelectedIndex
        If index >= 0 AndAlso index < tabPages.Length Then
            _SelectedIndex = index
            ' 刷新显示
            RefreshTabPages()
            ' 触发事件
            RaiseEvent SelectedIndexChanged(Me, Nothing)
            If oldSelectedIndex >= 0 Then
                RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
            End If
            RaiseEvent TabSelected(Me, New EdgeTabPageEventArgs(_SelectedIndex, tabPages(_SelectedIndex)))
        ElseIf index = -1 Then
            _SelectedIndex = -1
            ' 刷新显示
            RefreshTabPages()
            ' 触发事件
            RaiseEvent SelectedIndexChanged(Me, Nothing)
            If oldSelectedIndex >= 0 Then
                RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
            End If
        Else
            Throw New Exception("待选择的标签页对象不属于当前控件。")
        End If
    End Sub

#End Region


#Region "属性"

    ''' <summary>
    ''' 获取指定索引的标签页。
    ''' </summary>
    ''' <param name="index">从零开始的索引。</param>
    ''' <exception cref="ArgumentOutOfRangeException">索引值不能越界。</exception>
    <Browsable(False)>
    Default Public ReadOnly Property Item(index As Integer) As EdgeTabPage
        Get
            If index >= 0 AndAlso index < tabPages.Length Then
                Return tabPages(index)
            Else
                Throw New ArgumentOutOfRangeException("index", "索引值越界。")
            End If
        End Get
    End Property

    ''' <summary>标签页组是否为只读，只读状态下用户无法通过鼠标添加关闭激活标签页，无法操作标签页上的内容。</summary>
    Private _ReadOnly As Boolean = False
    ''' <summary>
    ''' 获取或设置标签页组是否为只读，只读状态下用户无法通过鼠标添加关闭激活标签页，无法操作标签页上的内容。
    ''' </summary>
    <Browsable(False), DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(value As Boolean)
            If _ReadOnly = value Then Return
            _ReadOnly = value
            For tabpageIndex As Integer = 0 To tabPages.Length - 1
                tabPages(tabpageIndex).TabBar.ReadOnly = _ReadOnly
            Next
            tabAddButton.Visible = (Not _ReadOnly)
            If _ReadOnly Then
                Application.AddMessageFilter(Me)
            Else
                Application.RemoveMessageFilter(Me)
            End If
            RefreshTabPages()
        End Set
    End Property

    ''' <summary>当前选定的标签页的索引。当未选定任何标签页时为-1。</summary>
    Private _SelectedIndex As Integer = -1
    ''' <summary>
    ''' 获取或设置当前选定的标签页的索引，-1时表示不激活任何标签页。
    ''' </summary>
    ''' <exception cref="ArgumentOutOfRangeException">索引值不能越界。</exception>
    <Browsable(False), DefaultValue(-1)>
    Public Property SelectedIndex As Integer
        Get
            Return _SelectedIndex
        End Get
        Set(value As Integer)
            If _SelectedIndex = value Then Return
            Dim oldSelectedIndex As Integer = _SelectedIndex
            If value >= 0 AndAlso value < tabPages.Length Then
                _SelectedIndex = value
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)
                If oldSelectedIndex >= 0 Then
                    RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
                End If
                RaiseEvent TabSelected(Me, New EdgeTabPageEventArgs(_SelectedIndex, tabPages(_SelectedIndex)))
            ElseIf value = -1 Then
                _SelectedIndex = -1
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)
                If oldSelectedIndex >= 0 Then
                    RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
                End If
            Else
                Throw New ArgumentOutOfRangeException("value", "索引值越界。")
            End If
        End Set
    End Property

    ''' <summary>
    ''' 获取或设置当前选定的标签页，Null表示任何标签页都没有被选定。
    ''' </summary>
    ''' <exception cref="Exception">待选择的标签页必须属于当前控件。</exception>
    <Browsable(False)>
    Public Property SelectedTab As EdgeTabPage
        Get
            If _SelectedIndex >= 0 AndAlso _SelectedIndex < tabPages.Length Then
                Return tabPages(_SelectedIndex)
            Else
                Return Nothing
            End If
        End Get
        Set(value As EdgeTabPage)
            Dim index As Integer
            If value Is Nothing Then
                index = -1
            Else
                index = 0
                While index < tabPages.Length
                    If tabPages(index) Is value Then
                        Exit While
                    End If
                    index += 1
                End While
            End If
            If index = _SelectedIndex Then Return
            Dim oldSelectedIndex As Integer = _SelectedIndex
            If index >= 0 AndAlso index < tabPages.Length Then
                _SelectedIndex = index
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)
                If oldSelectedIndex >= 0 Then
                    RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
                End If
                RaiseEvent TabSelected(Me, New EdgeTabPageEventArgs(_SelectedIndex, tabPages(_SelectedIndex)))
            ElseIf index = -1 Then
                _SelectedIndex = -1
                ' 刷新显示
                RefreshTabPages()
                ' 触发事件
                RaiseEvent SelectedIndexChanged(Me, Nothing)
                If oldSelectedIndex >= 0 Then
                    RaiseEvent TabDeselected(Me, New EdgeTabPageEventArgs(oldSelectedIndex, tabPages(oldSelectedIndex)))
                End If
            Else
                Throw New Exception("待选择的标签页对象不属于当前控件。")
            End If
        End Set
    End Property

    ''' <summary>
    ''' 获取标签页的数目。
    ''' </summary>
    <Browsable(False)>
    Public ReadOnly Property TabCount As Integer
        Get
            Return tabPages.Length
        End Get
    End Property

#End Region


    ''' <summary>标签页数组。</summary>
    Private tabPages As EdgeTabPage() = {}

    ''' <summary>添加标签页按钮</summary>
    Private tabAddButton As EdgeTabNew = Nothing


    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            Me.Controls.Clear()
            If tabPages IsNot Nothing Then
                Dim tabpageIndex As Integer = tabPages.Length
                While tabpageIndex > 0
                    tabpageIndex -= 1
                    ' 释放资源
                    tabPages(tabpageIndex).Dispose()
                End While
                tabPages = Nothing
            End If
        Catch
        End Try
        Try
            tabAddButton.Dispose()
        Catch
        End Try
        MyBase.Dispose(disposing)
    End Sub

    Public Sub New()
        MyBase.New
        Me.MinimumSize = New Size(30, 30)
        Me.Size = New Size(800, 600)
        Me.BackColor = Color.FromArgb(204, 204, 204)
        tabAddButton = New EdgeTabNew
        tabAddButton.Location = Point.Empty
        Me.Controls.Add(tabAddButton)
        AddHandler tabAddButton.MouseClick, AddressOf TabNew
        AddHandler Me.Resize, AddressOf RefreshTabPages
    End Sub

    ''' <summary>刷新标签页的显示。</summary>
    Private Sub RefreshTabPages()
        If Me.Disposing OrElse Me.IsDisposed Then Return
        Me.SuspendLayout()
        If tabPages.Length > 0 Then
            Dim meWidth, totalMod, singleWidth, tabX, tabW, tabIndex, tabAddButtonX As Integer, lastVisibleSelected As Boolean
            meWidth = Me.Width - If(_ReadOnly, 0, 30)
            If meWidth / tabPages.Length < 60.0 Then
                totalMod = 0
                singleWidth = 60
            Else
                totalMod = meWidth Mod tabPages.Length
                singleWidth = meWidth \ tabPages.Length
            End If
            tabX = 0 : tabAddButtonX = 0 : lastVisibleSelected = True
            For tabIndex = 0 To tabPages.Length - 1
                ' 设置标签条Location、Size、Visible
                tabPages(tabIndex).TabBar.Location = New Point(tabX, 0)
                If totalMod > 0 Then
                    totalMod -= 1
                    tabW = singleWidth + 1
                Else
                    tabW = singleWidth
                End If
                If tabW > 200 Then tabW = 200
                tabPages(tabIndex).TabBar.Size = New Size(tabW, 30)
                tabX += tabW
                If tabX <= meWidth Then
                    tabPages(tabIndex).TabBar.Visible = True
                    tabAddButtonX = tabX
                    lastVisibleSelected = (tabIndex = _SelectedIndex)
                Else
                    tabPages(tabIndex).TabBar.Visible = False
                End If
                ' 设置标签条Actived，设置标签页Visible
                If tabIndex = _SelectedIndex Then
                    tabPages(tabIndex).TabBar.Selected = True
                    tabPages(tabIndex).Visible = True
                Else
                    tabPages(tabIndex).TabBar.Selected = False
                    tabPages(tabIndex).Visible = False
                End If
            Next
            ' 设置tabAddButton的Location、Visible、SeparatorVisible
            tabAddButton.Location = New Point(tabAddButtonX, 0)
            tabAddButton.SeparatorVisible = (Not lastVisibleSelected)
            ' 设置标签条SeparatorVisible
            For tabIndex = 1 To tabPages.Length - 1
                tabPages(tabIndex - 1).TabBar.SeparatorVisible = (tabPages(tabIndex - 1).TabBar.Visible AndAlso tabPages(tabIndex).TabBar.Visible AndAlso _SelectedIndex <> tabIndex - 1 AndAlso _SelectedIndex <> tabIndex)
            Next
            tabPages(tabPages.Length - 1).TabBar.SeparatorVisible = False
        Else
            ' 设置tabAddButton的Location、Visible、SeparatorVisible
            tabAddButton.Location = New Point(0, 0)
            tabAddButton.SeparatorVisible = False
        End If
        Me.ResumeLayout(False)
    End Sub


    Private Sub TabNew(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            RaiseEvent TabNewClicked(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub TabApplyRemove(sender As Object, e As EventArgs)
        For tabpageIndex As Integer = 0 To tabPages.Length - 1
            If tabPages(tabpageIndex).TabBar Is sender Then
                RemoveAt(tabpageIndex)
                Exit For
            End If
        Next
    End Sub

    Private Sub TabApplySelect(sender As Object, e As EventArgs)
        For tabpageIndex As Integer = 0 To tabPages.Length - 1
            If tabPages(tabpageIndex).TabBar Is sender Then
                SelectTab(tabpageIndex)
                Exit For
            End If
        Next
    End Sub

    Private Sub TabMouseEnter(sender As Object, e As EventArgs)
        If _ReadOnly Then Return
        For tabpageIndex As Integer = 0 To tabPages.Length - 1
            If tabPages(tabpageIndex).TabBar Is sender Then
                If tabpageIndex > 0 Then
                    tabPages(tabpageIndex - 1).TabBar.SeparatorVisible = False
                End If
                If tabpageIndex = tabPages.Length - 1 OrElse tabPages(tabpageIndex + 1).TabBar.Visible = False Then
                    tabAddButton.SeparatorVisible = False
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub TabMouseLeave(sender As Object, e As EventArgs)
        If _ReadOnly Then Return
        For tabpageIndex As Integer = 0 To tabPages.Length - 1
            If tabPages(tabpageIndex).TabBar Is sender Then
                If tabpageIndex > 0 Then
                    tabPages(tabpageIndex - 1).TabBar.SeparatorVisible = (tabPages(tabpageIndex - 1).TabBar.Selected = False AndAlso tabPages(tabpageIndex).TabBar.Selected = False)
                End If
                If tabpageIndex = tabPages.Length - 1 OrElse tabPages(tabpageIndex + 1).TabBar.Visible = False Then
                    tabAddButton.SeparatorVisible = (tabPages(tabpageIndex).TabBar.Selected = False)
                End If
                Exit For
            End If
        Next
    End Sub




#Region "EdgeTabNew"

    Private Class EdgeTabNew
        Inherits System.Windows.Forms.Control

        ''' <summary>正常状态的添加图标</summary>
        Private Shared Icon_Normal As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAMAAAAM7l6QAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAAZQTFRFKSkp////lJFm4gAAAAJ0Uk5T/wDltzBKAAAAIElEQVR42mJgxAsYRoo0wxCUZkAGw8ljIzspogGAAAMAN+ADbMxPTvUAAAAASUVORK5CYII=")))
        ''' <summary>带分隔符的添加图标</summary>
        Private Shared Icon_WithSeparator As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAMAAAF76W4GAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAAlQTFRFenp6KSkp////opB9mwAAAAN0Uk5T//8A18oNQQAAAExJREFUeNpiYGBiYmJAJQACCITRCYAAAksQYAAEEKU0QADBDSKJzwgG5OgHCCA0Ltl8RlL4jEjuJUc/Be4FCDB0/w+kNOOQlR5EgQoAMrgGtC6Zw14AAAAASUVORK5CYII=")))

        Private _SeparatorVisible As Boolean = False
        ''' <summary>
        ''' 获取或设置是否显示分隔符。
        ''' </summary>
        <Browsable(True), Category("参数"), Description("是否显示分隔符。"), DefaultValue(False)>
        Public Property SeparatorVisible As Boolean
            Get
                Return _SeparatorVisible
            End Get
            Set(value As Boolean)
                _SeparatorVisible = value
                If value Then
                    Me.BackgroundImage = Icon_WithSeparator
                Else
                    Me.BackgroundImage = Icon_Normal
                End If
            End Set
        End Property

        Public Sub New()
            MyBase.New
            MyBase.DoubleBuffered = True
            MyBase.BackColor = Color.FromArgb(204, 204, 204)
            MyBase.BackgroundImageLayout = ImageLayout.None
            MyBase.Margin = New Padding(0)
            MyBase.Size = New Size(30, 30)
            MyBase.MinimumSize = New Size(30, 30)
            MyBase.MaximumSize = New Size(30, 30)
            Me.BackgroundImage = Icon_Normal
        End Sub

        Private Sub BTabNew_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            Me.BackColor = Color.FromArgb(163, 163, 163)
        End Sub

        Private Sub BTabNew_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            Me.BackColor = Color.FromArgb(184, 184, 184)
        End Sub

        Private Sub BTabNew_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
            Me.BackColor = Color.FromArgb(184, 184, 184)
        End Sub

        Private Sub BTabNew_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            Me.BackColor = Color.FromArgb(204, 204, 204)
        End Sub
    End Class

#End Region


#Region "EdgeTabBar"

    Public Class EdgeTabBar
        Inherits System.Windows.Forms.Control

        ''' <summary>关闭按钮图标：正常状态</summary>
        Private Shared Icon_Close_Normal As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAMCAYAAAEhcmxxAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAALtJREFUeNpi/P//PwMYgBjOzs7/AQKIGcRgBLLcAQKIEcRycXEBKfAACCBGuEIgYAIRQBl3MA+kFiQLwgABBDcGJgCSBGEGNIH/6DrgRsBMAAggFBtRAMxMZNVgV0Md7A5Vt2PPnj2McPcCOTtBgiDfoHvkP0wlsqf+o7kIbB9AgMEtRHcyumKYATC7Ycb/R3Ig2DpoCMPVYPgbqmEHlOsB9QhqbGBR7AHFO5BthNuArBDdRHQ53FGBAwAAHzm5B1vc0icAAAAASUVORK5CYII=")))
        ''' <summary>关闭按钮图标：鼠标悬停状态</summary>
        Private Shared Icon_Close_Hover As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAMCAYAAAEhcmxxAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAKxJREFUeNpi/P//PwMIMIGI/yIi/wECiBEs8k9Y2B0ggMAskBBQxgMggBhhCpEVu4N5ILVgpUAMEEBwPYxv3jCiqIKpAKkG4v8wPlwQJgDl/wcIIBQbkQETyEy4uVBng2iY5TCJHTBHoJiLbBfC1+jORXYisgsBAgyrMegY2Y9gK5CM/4/mcne469Edi24aLluZkAMHavoOUJxB8Q5kG+E2IJnqjsdGd3iskgIAJpbiVYWzy8QAAAAASUVORK5CYII=")))
        ''' <summary>关闭按钮图标：鼠标按下状态</summary>
        Private Shared Icon_Close_Keydown As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAMCAYAAAEhcmxxAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAALRJREFUeNpi/P//PwMIMIGIjaKi/wECiBkkwrhBRMQdIIAYQSyQEFDGAyCAGGEKkRW7g3kgtSBZEAYIIDABFPgPEwBJgjADmsB/dB1wI2AmAAQQio3IgAlkM9x2qLNBNMzBMIkd/q9fM4JZyOYi2wX3NUwlsqf+o7kIrAsgwLAag46R/Qi2Asn4/2gud4e5HqYGw99QDTugXA+gwp3I8igakBR7wIIBQxOyG7H5A10OZ1TgAgD6zst2DajmdgAAAABJRU5ErkJggg==")))
        ''' <summary>加载状态图标组</summary>
        Private Shared Icon_Loading As Image() = {Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWtJREFUeNrslk8rhFEUh2cMg1BMkpA/KwsizRdQlLJ911OWvoWvYM/a7v0C7Cg2olgYwsZGKVlgxoyZ13PqZzMx8zK3Rrq3no5pbve5955zz0hGUZRoxWhLtGh4sRf/P3H7TyYHQbBAWIVFmIchbd6ohmFYjbtWMm4DQbpGWIcZbdjoUExJXkFeciZGmiNswACcwx4cwL6EtoFObaCAvNi0GOkcYROmYQe2WfiyZo7Ju6DH1oSnRiePU1yWz0k4ga1aqQ3l9k0fPzfQdFVnoQy7CK6+m8R3Fc1LQ6+Lqp7SaY5izC3pxGkX4rIWjPNUUhK/u7jqCyjq3TYaGZfiY111luodr1P9fYQR6IYXF+JDuIYJ61oIxr6Q9uu5DSs1j64ayAohpxzmdQt5XamdclRP6BlOqfBbly1zibAMg8p5AV51rfb3PZzVe3K/EktujWRWDSWj3N+BnfAG6YPzHwn/j4AXe/GfFX8IMADrr3wsAskGywAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWlJREFUeNrslk8rBHEYx3f8F7FKpHBwIW3+vAA2Ul7AuChnb8LRyZuQs5qXwM3BaU+SRUJO2nKya+3M+Dz6Km1oNL9aaaY+PbuzT/P5/Xl+z6wXx3GuFVdbrkVXJs7E/0/c8Ztk3/cXCOtQhDloh3NYBS8IgsRNwUvaQJBuEbZhVgM2Oj99fl895KEzMdJNwg7k4QyO4USyFdjVIOx7iLyeWoy0QNiDaTiEAx5cbsrxJO7WrSo5jbTFtQSTUIL9ZqmW10ZvIhtAj0hd1YvwCkcIrr5L4reIYHRBrwuxzfYFThPkNiTud3Gc6hJHCfuCLXPoYsYXUINCgty8xJELcUkznqd6x3+o/j7CqMQ1F2Lb22sw6RqCsS+kA4QpGNY+P7lqINYSN3RWy1qFS+2lzXJElfxsDYYKv3fZMpcJxpCWvirRB4/Wt5HeOO3Vkk8QZnTEBjWAB7iFO6QV5y+J7I9AJs7Ef1b8JsAA/kN7HNwLsdAAAAAASUVORK5CYII="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWpJREFUeNrslrtKA1EQhhPRoIiIWhgvnQje0iqigo2dVitY+ww+ge8idoulrYKNhRaK16ipFAQbC28Jcf0G/oUQvBzZAxHZhY8h5GS/mZ05Z5ONoijTiKsp06ArFafi/ydu/s3iIAgKhAWYhQlogQvYg+0wDA9c75V1PUCQrhBWYVQJmzSnaJ8voYDcnxjpMmENuuAcdmHffg/zsAST8RNE/p5YjNQqXIdh2IJNbnxVt2aMcCaxzU3lJ7nLcE3DIBzBRr1UFZ7GhdS0IfFU2xCVYQfBzVeL+C5+dHHvE4ut2ldwmdhI0lYf26kscdXxXMgpgcQVF+ENRhzWtqtaL+JjVTzO9PZ9M/1thB6JKz7Eh1CCPMwh6P1EapUOaJ/bNnrydYDMEBaVqE32iZKpqspu9fYFrpnwe59H5hTB6FTPn2uwVjxYMkhvvZ7VkvcThsB63SGhVWeyO6SP3l8S6R+BVJyK/6z4Q4ABANB4edkl/imFAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWdJREFUeNrsls8rBGEYx2e3sdtG60DWxcWPiHBZaQ/KWSk1N3+BcnfxfyjJX6A5O7hzUVK0Em1+xAHloMUW4/Pke9rQaN5aaaY+PU3zzHze532fnt1MFEVeK66s16IrFafi/yf2f5McBMEoYRYqMKb3z2EPdsIwPIj7rUzcAYJ0gbAIw9AGecWcOIN15JvOxEjnCcvQqQp3YV9HNQNzMAV1WEW+kViMdIiwAv2wDXw3rDXljGhhS3AC4+Qkbq4y9MIxbDVLvc+VmGwN7IwnrCAXXW3VNGx7EVx8l8SzKmFaDee7EJfgBQ7j9IxLcUPi95hzIaduTyyuSTwQIzcvsi7EVYkH6d6eH7rfKi2q2jcX4iO4gm7rcARdX0gLet6hc351NUDKGpW20Es4hWtVVpTQ187c0uGPLkfmJMFol+BZ1HVvshukD05nteR2xn3a1oKEJrqDe6RPzn8k0j8CqTgV/1nxhwADANyseFnbjZ+sAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAXRJREFUeNrslklKQ0EQQDNo4rDQ4ACuHEBRweBCXIgHEHT3cwQRdx5ByDGEgBf4C3El4gFURFyIA6gEFTeiBCTfAf2+gloFlZYURKQbHhV+F/3Sv6srScZxnGjESCUaNLzYi/+fuOk3yUEQjBJmYRrGIQMXsA87YRgeua6VdG0gSBcIBRhWoZBV5PMllJCvm4mRzhEWoQOuYA8OIQ0zIPNT8AyryEt1i5EOEVZgALZhk4XLNTkjhGVYgjOJ5BzUW1yT0AsnsFErlcGzc8IayBlPwLxFVcuZvsAuguvvkpg7JWxpwRYtxD16dscOuUUVpy3Eryr+cOwLGZdr6iIuq7jfIbdZSVmIpXAiGKR6u3+oftllm+7YpGVK0dxCJ+QR5L6QZnW+Xa4ovFk1kLw2Cln0RpvIHbyrrFULSt7MAxX+ZNkypTePQYsWXFVFkV63CtwjrZj2apV3Efogp19Aiu5RdikRaWT+I+H/CHixF/9Z8acAAwBMH3obEeg3mQAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWpJREFUeNrslk0rRFEYx+eNUZNGsqIkSQkp2bBSirJ0PwEl+R4+hqKs7042Nl62JGxmyLtkZYFpxoTrd+o/Gw0d5tRI59SvZ5p7en7n3POcpxuPoihWj5GI1Wl4sRf/P3HqJ5ODIOgljMEI9EEDXMA+bIVheGSbK27bQJBOEWagB9LQBI36bRZwCSvI15yJkU4QZiELV9rhoY5qFCZhGIqwhHy1ZjHSLsICmLgNGyS+rnIE8zAHp7DInINai2sA2iAH65+lZvDfCWEZjqEfpl1UtdlpCfYQ3H41iWd5wqYKdtyFuFVnl7OYuyvxkIvr9KIFvlrM3VGFO2kgN1CAdst8KZu8NuJzveoOqrflm+pPaLdJV+IzuIeMaR4ImqtIk2ooaeV8d9VAzD0dVEKziDt4gDd1r8q5mjooUOFlly2zm9ApSVFXrEJZ8RFpyWmvljyr65VRERnhEzzb7vRXYv8h4MVe/CfFHwIMAJJdetuSlst4AAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAXFJREFUeNrslkErRFEUgOdhGBFmgw0SRRbKys5kLGzs3saK8gP8CRs/w2LK6v0AJRvNGjVSTIpGEgsL8eaZ8XynjtKErubUSO/W15neO93v3fvOPW+8OI5TrRhtqRaNRJyI/5+44zfJvu9PEOZhDqagE67hCA6DICi5zuW5NhCkecIKiLwLMhqFtD5AAfmumRjpAmEVBqACJ1DSVyU7sKS7EMI28kLTYqQjhHUYgyLsM3GlIWeSsAFrcAmb5Bw3W1zTkIVz2GuUyuBambADpzADyxZVPQpVKSAEt98lcU8e7EALNmch7ocXuHDILap41uI4yWo9qDv2BanwdosV38AzDDnkLupizizEVyoepHr7fqh+2ZUtFectxNIY7qFbjhSCni+kH1uc1jk9qwYyri1S3vMD3MEjvOkKRSYT1SCiwuuWLVMaybCKwk9EivyuIo1Me7XKe7VtZnSVr/Ckxy1EWjP/SCR/BBJxIv6z4ncBBgB4EXv2+YWkPgAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWxJREFUeNrslk8rRFEYh+8dxgyTFAsNC/+yICwoFixmY6nUtZKv4Xv4FIrctbUoWVghfxIWBlNkRRju9bz1qmlCZ7qnRjqnnt6ae7rPOe/53dP4cRx79Rgpr07DiZ34/4kba5kcBEEvZRxGYRCa4BoOYTcMw2PTd/mmFwjSacos9EEWMlqzFQtYR75hTYx0ijIPbXAHR3ACDTABBRiDF1hBvpZYjLSLsgDdsA/bvPi2ak4/ZQkW4QqWmXOQNFwDutML2KqWyuA3ebaqXRjSI0mc6jy8SnsRlH6axLNzWZgGdsaGuBWe4dJg7h6kYcTG5ySBkSB8mIRVE562seOS7rjDYG5Bpac2xEXddTvpzf2S/mHKnHZxx4b4Bu61hXkEzd9IpcVya03CGWzaukDkG+6Bd3iEB3iCSM/Vq8hBRMKtXpmdes4pbb3wppR1UWWkkdW7WuUtlJwGyFfp1wKMpTWL3R8BJ3biPyn+FGAAhwB/Dn9XAsEAAAAASUVORK5CYII="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAXFJREFUeNrslk0rBVEYgO/gznUjkZssSFaIkmJBlI2S7eRX+AV2foOVkp8wJZb2dOuuJAk3+Vj4jCRfg/G89S40+TiaUzc6p57e253Teeac875v48VxnKnEqMpUaDixE/8/cc1vJgdB0Ebogx7oBB/OYAdKYRjuma7lmTYQpIOEUWiH2gTyAqewgnzVmhhpP2ECGuAS9qGsVyXPRqAXIlhAvpxajLSFMAmtsKVHep6Y00GYlp9wDHPM2U6bXHK0dXAExaRUBv8dStBT6IJxG1ldgEfYRXD11SSeHRDWIQvDNsR5eIATg7klyOl9py4n2a0kwqthX8iarGuyYznee83on8aYllbZhvhCd11P9ua/yf5uwpSKN2yIpW5v9PiaEPifSKWTzcCQ1viarQbSTJB6foE7uIUneNP7L8IAXMMsGb5ks2U2ynGrKFLxs76MsAnzSBet9mqV+1ou1brb6IM4Rmq8lue+Mp3Yif+8+F2AAQAJm3/muoWR1AAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAW1JREFUeNrslk0rRGEUx2cYxmQkKTVJVsQoNholyY6dxf0SPoSsfQI7NV/grhAbX4A0YkNCQgp5WXgdM9fvqf9Ck5erOTXSferX6c49Pb+ec889d+JBEMRqsepiNVqROBL/P3HiN8me52UIfdAL3dAIV3AA277vH4XdKx52gCAdJOSgE1LQ9IEkXMIq8jUzMdIsYRzScAfHcKJHNQAj0A9FyCNfrlqMtJ0wAR2wDztsfF2R00WYFucwT85etc2VUTnPoFApdYvfTglLqkQPjFl0dRu8uk0R3H6VxD1X+g01XM5C7E77CBchcgsSZy1ep2coiZ9WvTr8xeLErrxP0Bwid1TiQwvxjU6QonuT33S/GypTKvWm1YnvVcYWBIlPpG6azcAwuOm1bjVAWgmOMjyo2Yq6noNJGNJwmaXD85YjM60OD/R6FRXfxC4sIF00ndWSuzI36LIsYUmnXkG6Zf6RiP4IROJI/GfF7wIMAPjrf+irJVORAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAW5JREFUeNrslrtKA0EUhpONuXgBURAstFHxUigoaRS000a7fQYfxAewtxRSbxsQFHyBIIIWimC8IiIqxOAlJus38FdBycoORGQGPk5Ihv1y5pw5STIMw0Q7lpdo03JiJ/5/4o7fbPZ9f4AwCiMwDFl4hDIcBUFQjvqsZNQBgnScMAOD0And0KXXOXiAXeR71sRITYaz0ANVuIFbndgk5BXrUEC+E1uMtFfSPriCMx783LRniLAGq/pCm+w5jdtc/ZCGOzhplprFe9eEIlzAGCzY6GpTy1eTCYLKT5v47JJQUsPlbYhNHd/Uva3WoRptysZ1+oBPNU6URDIqTeyMK8o4E2HvvI763Ib4RVmn6d5Ui3u+omxLNsRVZWxWFoH3jXSCsA5zmmL7tgZIThPK1PkdatCAJViEZZiGJ9igwws2R6apcUrCuhqupmg4hi2k21ZnteSeytMQ97pC5miLSA+s/0i4PwJO7MR/VvwlwABNBX8LeyTCKQAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWpJREFUeNrslktKw1AUhpu01gcOCuJAREV8IY466sCZgi4gO3AfDl2CE8eCE7sAQSrWBfhAxImCVfCB4AOlxWjjd+EflKIS6YGK5MLHSZNDvnuTc0/qRVGUasfwU20aiTgR/z9x5jfJQRD0EYZhBAahE56gAqfFYvEy7r28uA0E6ShhGvqhp4FuTeABysjLZmKkQ4QZiapwB7eQhgnIwySEsIm81LIYaa9WmoMbuODGz005A4RFWFDOKjlnrRZXTrVwD+fNUjc4d03YhisYg4JFVXdBzT1aBK/fJXHNSQ/1vvMWYl/ixxi5x5rolMV2CkU95iTdirMWK36Bt5iTLEhcsRBXJfapXv+H6h8nzEMH7FuIa8LtuwwC7wup28NLKiq32j2rBpJVs6jrfS/Djn7PwpwajCvAFSp8w7JlpnXoZO8ibDg+gTWk66a9WnJPj7ykbvYBR7ALW0gPzD8SyR+BRJyI/6z4U4ABAIBWgCHVutWRAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWJJREFUeNrsls8rBGEYx3es35SLUlxYPyMOHFwUV+e5+pf8DVyVOXFzUUjrusRFOSyLQtJmm9WOz1NfNWkx2rdWmrc+ve3M03yeZ97nfWe9KIoyzRgtmSaNVJyK/5+49TfBvu/3MQ3CEAxAJ7xACS6DILhJ+iwv6QGC1GQj0C9hd4wOeIY88rwzMVKrbhS6IIRHeICskpmBHNRgF/lRw2KkVtEw9EpY4sHlOoktwwrcwyYxV402V4/inuD6s9QG1+6YDuBWb2DeRVe3QcVeLYLXr4K4Zw12pvWfdSH2JC4niL1Qo4272E6h5LUEsVlVHLqouBKT/zQWJC66EJu0qu71vun+nLq6HU5diE36BpEE03WkY0xrMKdqj10dIB8JWgInsAP7SmZRe3hKW26dDt92eWTaVIAJJVCNLYP9PocNpFtOz2rJrXlWYQkmJbX1PIQ9pAXnH4n0j0AqTsV/VvwuwAC+F39dbWkjhAAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWpJREFUeNrslt0qRFEUx2cQQy6UjyIfiWSipJSPe09w8gSS8h4ewSu4ckop18qFZG5GEcUVF2YaRDSZMzl+q/4XkwZHZ9dIZ9ev1Ux7zm/WXmuvmXQYhqlGrKZUg1YiTsT/T9zym82e53USeqAXuiEDZSjBje/7xajPSkcdIEhNNABdEnZAu7DXr5BHnncmRmqyfgmq8ALP0AyDMAHD8A4HyHOxxUhbCX3KzLJ65MHlOqcxDwvwADvsuY3bXG0QKsvSZ6kt3rsn5FTrIZh20dV2nIEdLYLKV5vUWFcqR9aF2Or2Jn5a1xKPurhOQc0XiJJIpuYzsTKuiij3bkbigkvxMd2b/ab7RwhLYLfgwoXYMj2FWdhAMFlHajVdgSm4U4c7GSBrhE1NqxPYh0PVfU6ZjsETbNHhey5H5iphHcahIgJ1u8VL2Ea663RWS27HvQyLytBqfwZHGpXnzn8kkj8CiTgR/1nxhwADAJIpguKx7V9yAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAW9JREFUeNrslktKA0EQhhOfiQhqcCMqokKIuBCF6AFcuHQxFxAEjxHwHh7B2RnIAcSFuJAIKrgQVwEfGBEfiUnGr+BfSPAxMg0RmYaPgqTT33RVd02SQRAkOjG6Eh0asTgW/z9xz28me56XJoxARjEFr3APFd/378KulQzbQJAOEUbBYj+kxQD06QHOkJ86EyMd1C5N1IQXeIJuGINpmABb7AB5ObIYqZVj+ENaH1m41jbH0r4IS1CFInMqUQ9Xr3ZiO6y2S23wmdW4LOk45Fyd6jo8I2h8NYHvbgmXKkfWhbgFb+KncaWSTLm4Tg2luhWyL6T0m8g7bmqhQoi58xLfuBAXJF7j9Oa+Of2ThBXd8QsX4iKcwAJsIch+IrWarsMcXMOxqwaySdhWGo+gZI1CZbD7u6wm8gA7nPCSy5a5QbAHmNH1qom6sPTuIt1z2qslt3SvQh5mJbTefAj7SM+dvyTiPwKxOBb/WfG7AAMACWSCIN6T178AAAAASUVORK5CYII="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWlJREFUeNrslk0rRGEUx2e8Xq8LK8m7MkpYsCUbO7u7VpSP4bv4BNdSUYoNGykhJUmKBZpIasZwr9+pv5omdLlPjXSf+nXm5fT85jn3PKfJRlGUqcaqyVRppeJU/P/EdT9J9n2/gdACrdAG9v4VniEfBMFj3L2ycQcIUo/QDp6EXhlNUIIr5BfOxGUn/aiQSV6gFjqgCzr16I6QnyUWI7XNGqFeZS2y8VtFjpU9B6Mq+w45d0mby3JCE0KhUmqLz54I55LayYdcdLVJTVZCEH6VxHcPhGs970EXXR2KOOtGvdDj4sS3aqaZmNezWT2RWHyoppqOkTuiUuddiLclnqN7c990fzdhSvf60oV4HU5gDJYRDH8i7SXM68T3cOxqgCwSVlTGA9iEPTXdBExCH9jIXKXDt1yOzAXCEvSr2YqaXgW9tnu8hnTD6ayWfJwwqxMO6Aecwj7sxhmVvxKnfwRScSr+k+J3AQYAViB+YZp/CPAAAAAASUVORK5CYII="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWdJREFUeNrslk8rRGEUh+caxvizsCCJKBklStaysfEB7krNwsew8X1sZmdjYcTOSlmIxSRsUDJEBte9nlO/hSZ0NadGum89nZo53eee9z3vmQmSJMm1Y3Xk2rQycSb+f+LO3ySHYWj5ReiBfuiCGBpQr1Qqj2mfFaQdIEgLhG6JC6L4iQiukF+6iZHmJbKKA1UZ6agGYBgGwfJOkZ+1LEYaSGBSS454cNyU00eYhJK2/YCc21abK1GFb0az1BafPRHO4RmGYNyjq6va1g0E324P3z0QbqAXJjzEMxLvpsi9lnjU4zq9a5vjFLl5iROPio9U8WKK3JLu+L2HeE/iZbp3+ofuHyEs6K5feIi34RhmYQ3B1BfSMcIK2IvdwYnXACkT1jWhDmHH7qrOfQ7mweR12KTD9z1H5iqhrDtqzfYiGoo12EJadZ3Vklt1SzpLe4FXG5HaBZtWNfcfieyPQCbOxH9W/CHAAEQ7gE8bj5RMAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWRJREFUeNrsls8rBGEYx2fs+n0StVglEjZuDlLK2XlE+Sv8Sf6BKeXo4sCB4oA4SDhIDqukxVq8Pm99t6YNvZq3VpqpT0/NPDufZ2a+886GxpigGVtL0KQtE2fi/yfO/6Y5iiI7aCu0QYeqXQhqUInj+Mn1XKHrApKQ5hPy+gCWDygjv/MmRlp/LDn7G+022tcNvdCjoa6R36QWI52hrMOUxAEnNg09nZQiDEMVjul5SBuuRRiHfSg1SjXIM+UWXqEPBn2keh7eYBPB6XdNHKtQ7vW8iz7EE0rttkNvGbqg4ON1qukWusQ/J3Ho44pPJJ916B2R+NGHeEfPeIH0jv2Q/oKS366gpRZvwRlMwiqC0S+kA3YwsMfsa3ThawFZoawpsUcK2gG8ayB7pf2SbpDwPZ9L5hJlGYYUthdRVb20dwfprte1WvISZQ6mEwOc25UKDpFeef9IZH8EMnEm/rPiTwEGABwQejaNgPQxAAAAAElFTkSuQmCC"))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAWtJREFUeNrslk8rRGEUh+cahIWmjEGJNGiyU0rsLUndjyDli/gIlJVPcLc2NopIbCZkrGbBUinR+H89p36rG+bqvjXR+9bTqZkz53fOec97miCO41wrTluuRccLe+H/J9z+G+cwDM0E+p3RoeTf4TmKohfnFSO6ijlLfGxJdEIvlPApOBUm4ApmHSpwDG9WITyKD+iGIXz70sQMmq1MAk1jtmAKtmGTll4mfKzqIgwoqTo+D1krXoBxOIGNpKgd3e2dRAtKInOr58AC7yBQ+86J7xoYq7IL+l1MdVnC+yl876EH8i6ErX2vGqBmJ68hC1y0+kITPJPCd1jCDRfCR6p4nukd+2H67RlN6o5vXQjvwZXumvjh6BeiJcwsjOhdX2d+xwq8jFnTirTWH0JV917WcytquHaZ8KoTYYkvYpZgUFP+lMCqPED01MnmSohPaMgq2lKWQB1sqZwjepM2VuD/ZXphL/znhT8FGADrD3SZbfeKGAAAAABJRU5ErkJggg=="))),
                                                  Image.FromStream(New IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAW9JREFUeNrslk0rRGEUx+e63jfelaIJSRZC4gvYEFb3C0zZ+RT4DBaytL97a0l5WSljYmXBLC2QMYzrd+qvNKFHnpro3vp1pubM+d3zvJwmSJIkU4unLlOjJxWn4v8nrv9JchRF04RF2IBQv39/+ec4jl9cawWuAwTpCmEVxiU0GqFBMYAS8ntvS400R1iHUTiGNXiFsrDPzdBJbpuXjik0QdiEMdiBbboqVOVY9+3QBbbcN+Q8/rbjORiCE9iqltqjvb2DCljHHT6WekbLuYvg4qskvnsiWJdNtuQ+TvUwWNEDh9wHaHGp6yIuS1xxyA0lDn0sdV7yKYfcPmi1a+VDfCTxLKc3+83ptwM1qDt960O8D5cquoxg4BNpt1akX90WvUwuCi8RcppS53AIZxocWb2U3WObWnuc8LzPkTlPWIBeHbbSB+waXdu2ID31Oqslt0EyCSPQo72/ArvfBaRF11pB+i8zFafiPy9+E2AAxHB5pbVlZZwAAAAASUVORK5CYII=")))}


        ''' <summary>
        ''' 在标签条请求选择时发生。
        ''' </summary>
        Public Event TabApplySelect As EventHandler

        ''' <summary>
        ''' 在标签条请求移除时发生。
        ''' </summary>
        Public Event TabApplyRemove As EventHandler


        Private _Icon As Image = Nothing
        ''' <summary>
        ''' 获取或设置当前标签条上显示的图标。
        ''' </summary>
        <Browsable(False)>
        Public Property Icon As Image
            Get
                Return _Icon
            End Get
            Set(value As Image)
                _Icon = value
                RefreshView()
            End Set
        End Property

        Private _Text As String = Nothing
        ''' <summary>
        ''' 获取或设置当前标签条上显示的文字。
        ''' </summary>
        <Browsable(False)>
        Public Shadows Property Text As String
            Get
                Return _Text
            End Get
            Set(value As String)
                _Text = value
                RefreshView()
            End Set
        End Property

        Private _Loading As Boolean = False
        ''' <summary>
        ''' 获取或设置当前标签条是否为加载状态。
        ''' </summary>
        <Browsable(False)>
        Public Property Loading As Boolean
            Get
                Return _Loading
            End Get
            Set(value As Boolean)
                If _Loading = value Then Return
                _Loading = value
                RefreshView()
            End Set
        End Property

        Private _ReadOnly As Boolean = False
        ''' <summary>
        ''' 获取或设置当前标签条是否为只读。只读状态下，用户无法操作当前标签条。
        ''' </summary>
        <Browsable(True), Category("参数"), Description("当前标签条是否为只读。只读状态下，用户无法操作当前标签条。"), DefaultValue(False)>
        Public Property [ReadOnly] As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(value As Boolean)
                If _ReadOnly = value Then Return
                _ReadOnly = value
            End Set
        End Property

        Private _Selected As Boolean = False
        ''' <summary>
        ''' 获取或设置当前标签条是否为选择状态。
        ''' </summary>
        <Browsable(True), Category("参数"), Description("当前标签条是否为选择状态。"), DefaultValue(False)>
        Public Property Selected As Boolean
            Get
                Return _Selected
            End Get
            Set(value As Boolean)
                If _Selected = value Then Return
                _Selected = value
                RefreshView()
            End Set
        End Property

        Private _SeparatorVisible As Boolean = False
        ''' <summary>
        ''' 获取或设置当前标签条是否显示分隔符。
        ''' </summary>
        <Browsable(True), Category("参数"), Description("当前标签条是否显示分隔符。"), DefaultValue(False)>
        Public Property SeparatorVisible As Boolean
            Get
                Return _SeparatorVisible
            End Get
            Set(value As Boolean)
                _SeparatorVisible = value
                RefreshView()
            End Set
        End Property


        Private LoadingTimer As Timer = Nothing

        Protected Overrides Sub Dispose(disposing As Boolean)
            _Text = Nothing
            Try
                If _Icon IsNot Nothing Then _Icon.Dispose()
            Catch
            End Try
            _Icon = Nothing
            _Loading = False
            Try
                If LoadingTimer IsNot Nothing Then
                    LoadingTimer.Enabled = False
                    LoadingTimer.Dispose()
                End If
            Catch
            End Try
            LoadingTimer = Nothing
            MyBase.Dispose(disposing)
        End Sub

        Public Sub New(Optional newText As String = Nothing, Optional newIcon As Image = Nothing)
            MyBase.New
            _Text = newText
            _Icon = newIcon
            LoadingTimer = New Timer
            LoadingTimer.Interval = 36
            LoadingTimer.Enabled = False
            AddHandler LoadingTimer.Tick, AddressOf RefreshView
            MyBase.DoubleBuffered = True
            MyBase.BackColor = Color.FromArgb(204, 204, 204)
            MyBase.BackgroundImageLayout = ImageLayout.None
            MyBase.Margin = New Padding(0)
            MyBase.Size = New Size(200, 30)
            MyBase.MinimumSize = New Size(60, 30)
            MyBase.MaximumSize = New Size(200, 30)
        End Sub

        Private Sub BTabBar_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
            If Me.Disposing = False AndAlso Me.IsDisposed = False AndAlso Me.Visible Then
                RefreshView()
            End If
        End Sub

        ''' <summary>刷新图标和文字显示</summary>
        Private Sub RefreshView()
            If Me.Disposing OrElse Me.IsDisposed Then
                'Trace.WriteLine("test:Me.Disposing OrElse Me.IsDisposed")
                Return
            End If
            LoadingTimer.Enabled = False
            Dim tmpBitmap As Bitmap, tmpGraphics As Graphics, textBrush As SolidBrush
            tmpBitmap = New Bitmap(Me.Width, 30)
            tmpGraphics = Graphics.FromImage(tmpBitmap)
            If _Selected Then
                Me.BackColor = Color.FromArgb(242, 242, 242)
                textBrush = New SolidBrush(Color.Black)
            ElseIf (MouseLocation And EMouseLocation.OnTabBar) = EMouseLocation.OnTabBar Then
                Me.BackColor = Color.FromArgb(230, 230, 230)
                textBrush = New SolidBrush(Color.Black)
            Else
                Me.BackColor = Color.FromArgb(204, 204, 204)
                textBrush = New SolidBrush(Color.FromArgb(82, 82, 82))
            End If
            If _Loading Then
                tmpGraphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, 30, 30)
                tmpGraphics.DrawImage(Icon_Loading((System.Environment.TickCount \ 38) Mod 20), 0, 0)
                tmpGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                tmpGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                tmpGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                tmpGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                tmpGraphics.DrawString(If(_Text Is Nothing, "新标签页", _Text), New Font("微软雅黑", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(134, Byte)), textBrush, New PointF(28.0!, 6.0!))
            ElseIf _Icon IsNot Nothing Then
                tmpGraphics.DrawImage(_Icon, New Rectangle(7, 7, 16, 16))
                If _Selected = False AndAlso (MouseLocation And EMouseLocation.OnTabBar) <> EMouseLocation.OnTabBar Then
                    tmpGraphics.FillRectangle(New SolidBrush(Color.FromArgb(16, Me.BackColor)), 7, 7, 16, 16)  ' 画图标遮罩
                End If
                tmpGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                tmpGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                tmpGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                tmpGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                tmpGraphics.DrawString(If(_Text Is Nothing, "新标签页", _Text), New Font("微软雅黑", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(134, Byte)), textBrush, New PointF(28.0!, 6.0!))
            Else
                tmpGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                tmpGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                tmpGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                tmpGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                tmpGraphics.DrawString(If(_Text Is Nothing, "新标签页", _Text), New Font("微软雅黑", 10.0!, FontStyle.Regular, GraphicsUnit.Point, CType(134, Byte)), textBrush, New PointF(5.0!, 6.0!))
            End If
            tmpGraphics.SmoothingMode = Drawing2D.SmoothingMode.None
            tmpGraphics.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
            tmpGraphics.CompositingQuality = Drawing2D.CompositingQuality.Default
            tmpGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
            If (MouseLocation And EMouseLocation.OnTabBar) = EMouseLocation.OnTabBar Then
                tmpGraphics.FillRectangle(New SolidBrush(Me.BackColor), Me.Width - 30, 0, 30, 30)
                If (MouseLocation And EMouseLocation.OnCloseButton) = EMouseLocation.OnCloseButton Then
                    If (MouseLocation And EMouseLocation.LeftButtonDown) Then
                        tmpGraphics.DrawImage(Icon_Close_Keydown, New Point(Me.Width - 21, 9))
                    Else
                        tmpGraphics.DrawImage(Icon_Close_Hover, New Point(Me.Width - 21, 9))
                    End If
                Else
                    tmpGraphics.DrawImage(Icon_Close_Normal, New Point(Me.Width - 21, 9))
                End If
            ElseIf _SeparatorVisible Then
                tmpGraphics.FillRectangle(New SolidBrush(Me.BackColor), Me.Width - 8, 0, 8, 30)
                tmpGraphics.DrawLine(New Pen(Color.FromArgb(122, 122, 122)), New Point(Me.Width - 1, 5), New Point(Me.Width - 1, 24))
            Else
                tmpGraphics.FillRectangle(New SolidBrush(Me.BackColor), Me.Width - 7, 0, 7, 30)
            End If
            tmpGraphics.Dispose()
            Dim oldImage As Image = Me.BackgroundImage
            Me.BackgroundImage = tmpBitmap
            If oldImage IsNot Nothing Then
                oldImage.Dispose()
            End If
            LoadingTimer.Enabled = _Loading
        End Sub


        ''' <summary>鼠标当前所在位置</summary>
        Private MouseLocation As EMouseLocation = EMouseLocation.Outside
        ''' <summary>鼠标当前所在坐标</summary>
        Private MousePoint As Point = Point.Empty
        Public Enum EMouseLocation As Short
            Outside = 0
            OnTabBar = 1
            OnCloseButton = 2
            LeftButtonDown = 4
        End Enum

        Private Sub BTabBar_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If _ReadOnly Then Return
            If e.Location.X > Me.Width - 22 AndAlso e.Location.X < Me.Width - 9 AndAlso e.Location.Y > 8 AndAlso e.Location.Y < 21 Then
                If (MouseLocation And (EMouseLocation.OnTabBar Or EMouseLocation.OnCloseButton)) <> (EMouseLocation.OnTabBar Or EMouseLocation.OnCloseButton) Then
                    MouseLocation = MouseLocation Or EMouseLocation.OnTabBar Or EMouseLocation.OnCloseButton
                    RefreshView()
                End If
            ElseIf (MouseLocation And (EMouseLocation.OnTabBar Or EMouseLocation.OnCloseButton)) <> EMouseLocation.OnTabBar Then
                MouseLocation = (MouseLocation And EMouseLocation.LeftButtonDown) Or EMouseLocation.OnTabBar
                RefreshView()
            End If
        End Sub

        Private Sub BTabBar_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
            If _ReadOnly Then Return
            MouseLocation = EMouseLocation.OnTabBar
            RefreshView()
        End Sub

        Private Sub BTabBar_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            If _ReadOnly Then Return
            MouseLocation = EMouseLocation.Outside
            RefreshView()
        End Sub

        Private Sub BTabBar_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            RefreshView()
        End Sub

        Private Sub BTabBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If _ReadOnly Then Return
            If e.Button = MouseButtons.Left Then
                MousePoint = e.Location
                MouseLocation = MouseLocation Or EMouseLocation.LeftButtonDown
                If (MouseLocation And EMouseLocation.OnCloseButton) = EMouseLocation.OnCloseButton Then
                    RefreshView()
                End If
            ElseIf e.Button = MouseButtons.Middle Then
                MousePoint = e.Location
            End If
        End Sub

        Private Sub BTabBar_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            If _ReadOnly Then Return
            If e.Button = MouseButtons.Left Then
                MouseLocation = MouseLocation And (EMouseLocation.OnTabBar Or EMouseLocation.OnCloseButton)
                If (MouseLocation And EMouseLocation.OnCloseButton) = EMouseLocation.OnCloseButton Then
                    RefreshView()
                    If MousePoint = e.Location Then
                        RaiseEvent TabApplyRemove(Me, Nothing)
                    End If
                ElseIf _Selected = False AndAlso MousePoint = e.Location Then
                    RaiseEvent TabApplySelect(Me, Nothing)
                End If
            ElseIf e.Button = MouseButtons.Middle AndAlso MousePoint = e.Location Then
                RaiseEvent TabApplyRemove(Me, Nothing)
            End If
        End Sub


    End Class

#End Region


#Region "EdgeTabPage"

    Public Class EdgeTabPage
        Inherits Windows.Forms.Control

        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                If TabBar IsNot Nothing Then TabBar.Dispose()
            Catch
            End Try
            TabBar = Nothing
            MyBase.Dispose(disposing)
        End Sub

        Public Sub New(Optional text As String = Nothing, Optional icon As Image = Nothing)
            MyBase.New
            MyBase.DoubleBuffered = True
            Me.BackColor = Color.FromArgb(242, 242, 242)
            TabBar = New EdgeTabBar(text, icon)
        End Sub

        Public TabBar As EdgeTabBar = Nothing

        ''' <summary>
        ''' 获取或设置当前标签页的标签条是否为加载状态。
        ''' </summary>
        <Browsable(False)>
        Public Property Loading As Boolean
            Get
                Return TabBar.Loading
            End Get
            Set(value As Boolean)
                TabBar.Loading = value
            End Set
        End Property

    End Class

#End Region

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'EdgeTabControl
        '
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ResumeLayout(False)

    End Sub
End Class

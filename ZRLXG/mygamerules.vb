Module mygamerules
    Public E_H As Boolean 'E_ZRH
    Public RU_FRM As New Normal 'Main
    Public Title As String 'title
    Public ZR_HMAX As Integer 'zrh
    Public ZR_DC As Integer
    Function Start_MYR()
        RU_FRM.Text = Title
        RU_FRM.ZRH.Maximum = ZR_HMAX
        RU_FRM.E_ZRH = E_H
        RU_FRM.ZRH.Value = ZR_HMAX
        RU_FRM.ZR_DF = ZR_DC
        RU_FRM.Show()
    End Function

End Module

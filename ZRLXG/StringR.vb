Module StringR
    Function RndString(ByVal l As Integer) As String
        Randomize()
        Dim R, i As Integer
        Dim S As Char
        Dim returnStr As String
        returnStr = ""
        'a-z 的ASCII码是：97-122
        'A-Z 的ASCII码是：65-90
        '0-9 的ASCII码是：48-57
        For i = 1 To l
            R = Int(Rnd() * 62) '随机生成的字符有大小写字母和数字，共有26个
            If R < 10 Then '如果小于10，则是数字 数字的ASCII是48-57 对应 随机数字 0-9 所以要将随机数字加48
                S = Chr(R + 48) 'Chr 是将把数字按Ascii码转换为对应的字符
            ElseIf R < 36 Then '如果小于36，则是大写字母 大写字母的ASCII是65-90 对应 随机数字10-35 所以要将随机数字加55
                S = Chr(R + 55)
            Else '如果大于36，则是小写字母 小写字母的ASCII是97-122 对应 随机数字36-62 所以要将随机数字加61
                S = Chr(R + 61)
            End If
            returnStr = returnStr + S
        Next
        RndString = returnStr
    End Function

End Module

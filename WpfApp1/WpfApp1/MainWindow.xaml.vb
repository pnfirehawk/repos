﻿Class MainWindow

    Dim Intelligence = 10
    Dim CStrength = 10
    Dim Constitution = 10
    Dim Dex = 10
    Dim Wis = 10
    Dim Cha = 10

    Dim MaxStats = 32


    Private Sub ComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim x = Race.SelectedIndex
        Select Case x
            Case Is = 0
                [Class].Items.Clear()
                [Class].Items.Add("Class 1")
                [Class].Items.Add("Class 2")
            Case Is = 1
                [Class].Items.Clear()
                [Class].Items.Add("Class 3")
                [Class].Items.Add("Class 4")
            Case Is = 2
                [Class].Items.Clear()
                [Class].Items.Add("Class 5")
                [Class].Items.Add("Class 6")
            Case Else
                [Class].Items.Clear()
        End Select
    End Sub

    Private Sub Combobox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)


    End Sub
    Function Buttonenabled(ByVal stat As Integer, ByRef a As Button, ByRef b As Button)
        If stat >= 17 Then
            a.IsEnabled = False
        End If
        If stat <= 9 Then
            b.IsEnabled = False
        End If
        If stat < 18 Then
            a.IsEnabled = True
        End If
        If stat >= 9 Then
            b.IsEnabled = True
        End If
    End Function


    Public Sub StrStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles StrStat.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(StrStat.Text, StrIncrease1, StrDecrease)

    End Sub

    Public Sub Intstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles Intstat.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(Intstat.Text, IntIncrease, IntDecrease)
    End Sub

    Public Sub Constat_TextChanged(sender As Object, e As RoutedEventArgs) Handles Constat.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(Constat.Text, ConIncrease, ConDecrease)
    End Sub

    Public Sub Dexstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles Dexstat.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(Dexstat.Text, DexIncrease, DexDecrease)
    End Sub

    Public Sub WisStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles WisStat.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(WisStat.Text, WisIncrease, WisDecrease)
    End Sub
    Public Sub ChasStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles ChaStat.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(ChaStat.Text, ChaIncrease, ChaDecrease)
    End Sub

    Function StatIncrease(ByRef i As Integer, ByVal a As TextBox, b As TextBox)
        Select Case i
            Case 1 To 12
                i = i + 1
                a.Text = i.ToString
                b.Text = ((i - 10) / 2).ToString
                MaxStats = MaxStats - 1
                PointsLeft.Text = MaxStats.ToString
            Case 13 To 15
                i = i + 1
                a.Text = i.ToString
                b.Text = ((i - 10) / 2).ToString
                MaxStats = MaxStats - 2
                PointsLeft.Text = MaxStats.ToString
            Case 16
                i = i + 1
                b.Text = ((i - 10) / 2).ToString
                a.Text = i.ToString
                MaxStats = MaxStats - 3
                PointsLeft.Text = MaxStats.ToString
            Case 17 To 18
                i = i + 1
                a.Text = i.ToString
                b.Text = ((i - 10) / 2).ToString
                MaxStats = MaxStats - 4
                PointsLeft.Text = MaxStats.ToString
        End Select

    End Function
    Function StatDecrease(ByRef i As Integer, ByVal a As TextBox, ByVal b As TextBox)
        Select Case i
            Case 1 To 13
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2)
                MaxStats = MaxStats + 1
                PointsLeft.Text = MaxStats.ToString
            Case 14 To 16
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 2
                PointsLeft.Text = MaxStats.ToString
            Case 17
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 3
                PointsLeft.Text = MaxStats.ToString
            Case 18
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 4
                PointsLeft.Text = MaxStats.ToString
        End Select

    End Function

    Public Sub StrIncrease1_Click(sender As Object, e As RoutedEventArgs) Handles StrIncrease1.Click
        StatIncrease(CStrength, StrStat, StrMod)
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles StrDecrease.Click
        StatDecrease(CStrength, StrStat, StrMod)
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles IntIncrease.Click
        StatIncrease(Intelligence, Intstat, StrMod)

    End Sub
    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles IntDecrease.Click
        StatDecrease(Intelligence, Intstat, StrMod)
    End Sub

    Private Sub ConIncrease_Click(sender As Object, e As RoutedEventArgs) Handles ConIncrease.Click
        StatIncrease(Constitution, Constat, ConMod)
    End Sub

    Private Sub ConDecrease_Click(sender As Object, e As RoutedEventArgs) Handles ConDecrease.Click
        StatDecrease(Constitution, Constat, ConMod)
    End Sub
    Private Sub DexIncrease_Click(sender As Object, e As RoutedEventArgs) Handles DexIncrease.Click
        StatIncrease(Dex, Dexstat, StrMod)
    End Sub
    Private Sub DexDecrease_Click(sender As Object, e As RoutedEventArgs) Handles DexDecrease.Click
        StatDecrease(Dex, Dexstat, StrMod)
    End Sub

    Private Sub WisIncrease_Click(sender As Object, e As RoutedEventArgs) Handles WisIncrease.Click
        StatIncrease(Wis, WisStat, StrMod)
    End Sub

    Private Sub WisDecrease_Click(sender As Object, e As RoutedEventArgs) Handles WisDecrease.Click
        StatDecrease(Wis, WisStat, StrMod)
    End Sub

    Private Sub ChaIncrease_Click(sender As Object, e As RoutedEventArgs)
        StatIncrease(Cha, ChaStat, StrMod)
    End Sub

    Private Sub ChaDecrease_Click(sender As Object, e As RoutedEventArgs)
        StatDecrease(Cha, ChaStat, StrMod)
    End Sub
End Class

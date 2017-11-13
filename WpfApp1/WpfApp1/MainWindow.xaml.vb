Class MainWindow
    Dim Intelligence = 10
    Dim CStrength = 10
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
    Public Sub StrStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles StrStat.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)

        If stat >= 17 Then
            StrIncrease1.IsEnabled = False
        End If
        If stat <= 9 Then
            StrDecrease.IsEnabled = False
        End If
        If stat < 18 Then
            StrIncrease1.IsEnabled = True
        End If
        If stat >= 9 Then
            StrDecrease.IsEnabled = True
        End If

    End Sub
    Public Sub Intstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles Intstat.TextChanged
        Dim stat2 = Convert.ToInt32(sender.Text)
        If stat2 <= 9 Then
            IntDecrease.IsEnabled = False
        End If
        If stat2 >= 17 Then
            IntIncrease.IsEnabled = False
        End If
        If stat2 < 18 Then
            IntIncrease.IsEnabled = True
        End If
        If stat2 >= 9 Then
            IntDecrease.IsEnabled = True
        End If
    End Sub

    Function StatIncrease(ByRef i As Integer, ByVal a As TextBox)
        Select Case i
            Case 1 To 12
                i = i + 1
                a.Text = i.ToString
                MaxStats = MaxStats - 1
                PointsLeft.Text = MaxStats.ToString
            Case 13 To 15
                i = i + 1
                a.Text = i.ToString
                MaxStats = MaxStats - 2
                PointsLeft.Text = MaxStats.ToString
            Case 16
                i = i + 1
                a.Text = i.ToString
                MaxStats = MaxStats - 3
                PointsLeft.Text = MaxStats.ToString
            Case 17 To 18
                i = i + 1
                a.Text = i.ToString
                MaxStats = MaxStats - 4
                PointsLeft.Text = MaxStats.ToString
        End Select

    End Function
    Function StatDecrease(ByRef i As Integer, ByVal a As TextBox)
        Select Case i
            Case 1 To 13
                i = i - 1
                a.Text = i.ToString
                MaxStats = MaxStats + 1
                PointsLeft.Text = MaxStats.ToString
            Case 14 To 16
                i = i - 1
                a.Text = i.ToString
                MaxStats = MaxStats + 2
                PointsLeft.Text = MaxStats.ToString
            Case 17
                i = i - 1
                a.Text = i.ToString
                MaxStats = MaxStats + 3
                PointsLeft.Text = MaxStats.ToString
            Case 18
                i = i - 1
                a.Text = i.ToString
                MaxStats = MaxStats + 4
                PointsLeft.Text = MaxStats.ToString
        End Select
    End Function

    Public Sub StrIncrease1_Click(sender As Object, e As RoutedEventArgs) Handles StrIncrease1.Click
        StatIncrease(CStrength, StrStat)
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles StrDecrease.Click
        StatDecrease(CStrength, StrStat)
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles IntIncrease.Click
        StatIncrease(Intelligence, Intstat)

    End Sub
    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles IntDecrease.Click
        StatDecrease(Intelligence, Intstat)
    End Sub
End Class

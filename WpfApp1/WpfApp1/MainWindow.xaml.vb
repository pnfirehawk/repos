Class MainWindow
    Dim Strength = 10
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


    Public Sub StrIncrease1_Click(sender As Object, e As RoutedEventArgs) Handles StrIncrease1.Click
        Select Case CStrength
            Case 10 To 12
                CStrength = CStrength + 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats - 1
                PointsLeft.Text = MaxStats.ToString
            Case 13 To 15
                CStrength = CStrength + 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats - 2
                PointsLeft.Text = MaxStats.ToString
            Case 16
                CStrength = CStrength + 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats - 3
                PointsLeft.Text = MaxStats.ToString
            Case 17 To 18
                CStrength = CStrength + 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats - 4
                PointsLeft.Text = MaxStats.ToString
        End Select
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles StrDecrease.Click
        Select Case CStrength
            Case 10 To 13
                CStrength = CStrength - 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats + 1
                PointsLeft.Text = MaxStats.ToString
            Case 14 To 16
                CStrength = CStrength - 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats + 2
                PointsLeft.Text = MaxStats.ToString
            Case 17
                CStrength = CStrength - 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats + 3
                PointsLeft.Text = MaxStats.ToString
            Case 18
                CStrength = CStrength - 1
                StrStat.Text = CStrength.ToString
                MaxStats = MaxStats + 4
                PointsLeft.Text = MaxStats.ToString
        End Select
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles IntIncrease.Click
        Select Case Intelligence
            Case 10 To 12
                Intelligence = Intelligence + 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats - 1
                PointsLeft.Text = MaxStats.ToString
            Case 13 To 15
                Intelligence = Intelligence + 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats - 2
                PointsLeft.Text = MaxStats.ToString
            Case 16
                Intelligence = Intelligence + 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats - 3
                PointsLeft.Text = MaxStats.ToString
            Case 17 To 18
                Intelligence = Intelligence + 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats - 4
                PointsLeft.Text = MaxStats.ToString

        End Select

    End Sub
    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles IntDecrease.Click
        Select Case Intelligence
            Case 10 To 13
                Intelligence = Intelligence - 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats + 1
                PointsLeft.Text = MaxStats.ToString
            Case 14 To 16
                Intelligence = Intelligence - 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats + 2
                PointsLeft.Text = MaxStats.ToString
            Case 17
                Intelligence = Intelligence - 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats + 3
                PointsLeft.Text = MaxStats.ToString
            Case 18
                Intelligence = Intelligence - 1
                IntStat.Text = Intelligence.ToString
                MaxStats = MaxStats + 4
                PointsLeft.Text = MaxStats.ToString
        End Select
    End Sub
End Class

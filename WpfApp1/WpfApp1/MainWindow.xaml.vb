Class MainWindow
    Dim Strength = 10
    Dim Intelligence = 10
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
        Strength = Strength + 1
        StrStat.Text = Strength.ToString
        MaxStats = MaxStats - 1
        PointsLeft.Text = MaxStats.ToString
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles StrDecrease.Click
        Strength = Strength - 1
        StrStat.Text = Strength.ToString
        MaxStats = MaxStats + 1
        PointsLeft.Text = MaxStats.ToString
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

        Intelligence = Intelligence - 1
        IntStat.Text = Intelligence.ToString
        MaxStats = MaxStats + 1
        PointsLeft.Text = MaxStats.ToString
    End Sub
End Class

Class MainWindow

    Dim Intelligence = 10
    Dim CStrength = 10
    Dim Constitution = 10
    Dim Dexterity = 10
    Dim Wisdom = 10
    Dim Charisma = 10

    Dim MaxStats = 32



    Private Sub Race_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
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
        If stat <= 17 Then
            a.IsEnabled = True
        End If
        If stat <= 9 Then
            b.IsEnabled = False
        End If
        If stat >= 9 Then
            b.IsEnabled = True
        End If
    End Function




    Public Sub strBox_TextChanged(sender As Object, e As RoutedEventArgs) Handles strBox.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(strBox.Text, strUp, strDn)

    End Sub

    Public Sub Intstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles intBox.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(intBox.Text, intUp, intDn)
    End Sub

    Public Sub Constat_TextChanged(sender As Object, e As RoutedEventArgs) Handles conBox.TextChanged
        Dim stat = Convert.ToInt32(sender.Text)
        Buttonenabled(conBox.Text, conUp, conDn)
    End Sub

    Public Sub Dexstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles dexBox.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(dexBox.Text, dexUp, dexDn)
    End Sub

    Public Sub WisStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles wisBox.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(wisBox.Text, wisUp, wisDn)
    End Sub
    Public Sub ChasStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles chaBox.TextChanged
        Dim stat = Convert.ToInt32(sender.text)
        Buttonenabled(chaBox.Text, chaUp, chaDn)
    End Sub

    Function StatIncrease(ByRef i As Integer, ByVal x As TextBox, b As TextBox)
        Select Case i
            Case 1 To 12
                If (MaxStats - 1 >= 0) Then
                    i = i + 1
                    x.Text = i.ToString
                    b.Text = ((i - 10) \ 2).ToString
                    MaxStats = MaxStats - 1
                    pointsRemaining.Text = MaxStats.ToString
                End If
            Case 13 To 15
                If (MaxStats - 2 >= 0) Then
                    i = i + 1
                    x.Text = i.ToString
                    b.Text = ((i - 10) \ 2).ToString
                    MaxStats = MaxStats - 2
                    pointsRemaining.Text = MaxStats.ToString
                End If
            Case 16
                If (MaxStats - 3 >= 0) Then
                    i = i + 1
                    b.Text = ((i - 10) \ 2).ToString
                    x.Text = i.ToString
                    MaxStats = MaxStats - 3
                    pointsRemaining.Text = MaxStats.ToString
                End If
            Case 17 To 18
                If (MaxStats - 4 >= 0) Then
                    i = i + 1
                    x.Text = i.ToString
                    b.Text = ((i - 10) \ 2).ToString
                    MaxStats = MaxStats - 4
                    pointsRemaining.Text = MaxStats.ToString
                End If
        End Select

    End Function
    Function StatDecrease(ByRef i As Integer, ByVal a As TextBox, ByVal b As TextBox)
        Select Case i
            Case 1 To 13
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2)
                MaxStats = MaxStats + 1
                pointsRemaining.Text = MaxStats.ToString
            Case 14 To 16
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 2
                pointsRemaining.Text = MaxStats.ToString
            Case 17
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 3
                pointsRemaining.Text = MaxStats.ToString
            Case 18
                i = i - 1
                a.Text = i.ToString
                b.Text = ((i - 10) \ 2).ToString
                MaxStats = MaxStats + 4
                pointsRemaining.Text = MaxStats.ToString
        End Select



    End Function

    Public Sub StrIncrease_Click(sender As Object, e As RoutedEventArgs) Handles strUp.Click
        StatIncrease(CStrength, strBox, strModBox)
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles strDn.Click
        StatDecrease(CStrength, strBox, strModBox)
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles intUp.Click
        StatIncrease(Intelligence, intBox, intModBox)

    End Sub
    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles intDn.Click
        StatDecrease(Intelligence, intBox, intModBox)
    End Sub

    Private Sub ConIncrease_Click(sender As Object, e As RoutedEventArgs) Handles conUp.Click
        StatIncrease(Constitution, conBox, conModBox)
    End Sub

    Private Sub ConDecrease_Click(sender As Object, e As RoutedEventArgs) Handles conDn.Click
        StatDecrease(Constitution, conBox, conModBox)
    End Sub
    Private Sub DexIncrease_Click(sender As Object, e As RoutedEventArgs) Handles dexUp.Click
        StatIncrease(Dexterity, dexBox, dexModBox)
    End Sub
    Private Sub DexDecrease_Click(sender As Object, e As RoutedEventArgs) Handles dexDn.Click
        StatDecrease(Dexterity, dexBox, dexModBox)
    End Sub

    Private Sub WisIncrease_Click(sender As Object, e As RoutedEventArgs) Handles wisUp.Click
        StatIncrease(Wisdom, wisBox, wisModBox)
    End Sub

    Private Sub WisDecrease_Click(sender As Object, e As RoutedEventArgs) Handles wisDn.Click
        StatDecrease(Wisdom, wisBox, wisModBox)
    End Sub

    Private Sub ChaIncrease_Click(sender As Object, e As RoutedEventArgs) Handles chaUp.Click
        StatIncrease(Charisma, chaBox, chaModBox)
    End Sub

    Private Sub ChaDecrease_Click(sender As Object, e As RoutedEventArgs) Handles chaDn.Click
        StatDecrease(Charisma, chaBox, chaModBox)
    End Sub



End Class


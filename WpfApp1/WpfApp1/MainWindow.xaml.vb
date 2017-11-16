﻿Class MainWindow
    Dim StatsObj As CharacterStats

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StatsObj = New CharacterStats()
        StatsTab.DataContext = StatsObj
        StatusBar.DataContext = StatsObj
    End Sub

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
    Public Sub strBox_TextChanged(sender As Object, e As RoutedEventArgs) Handles strBox.TextChanged

        Buttonenabled(strBox.Text, strUp, strDn)
    End Sub

    Public Sub Intstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles intBox.TextChanged

        Buttonenabled(intBox.Text, intUp, intDn)
    End Sub

    Public Sub Constat_TextChanged(sender As Object, e As RoutedEventArgs) Handles conBox.TextChanged

        Buttonenabled(conBox.Text, conUp, conDn)
    End Sub

    Public Sub Dexstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles dexBox.TextChanged

        Buttonenabled(dexBox.Text, dexUp, dexDn)
    End Sub

    Public Sub WisStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles wisBox.TextChanged

        Buttonenabled(wisBox.Text, wisUp, wisDn)
    End Sub
    Public Sub ChasStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles chaBox.TextChanged

        Buttonenabled(chaBox.Text, chaUp, chaDn)
    End Sub
    Sub Buttonenabled(ByVal stat As Integer, ByRef a As Button, ByRef b As Button)

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
    End Sub
    Function StatMod(ByVal e As Integer)
        Dim result As Integer
        result = (e - 10) \ 2
        Return result
    End Function
    Function StatIncrease(ByVal i As Integer)
        Dim result As Integer
        result = 0
        Select Case i
            Case 1 To 12
                If (StatsObj.MAXSTATS - 1 >= 0) Then
                    result = i + 1

                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 1
                    pointsRemaining.Text = StatsObj.MAXSTATS.ToString
                End If
            Case 13 To 15
                If (StatsObj.MAXSTATS - 2 >= 0) Then
                    result = i + 1

                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 2
                    pointsRemaining.Text = StatsObj.MAXSTATS.ToString
                End If
            Case 16
                If (StatsObj.MAXSTATS - 3 >= 0) Then
                    result = i + 1

                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 3
                    pointsRemaining.Text = StatsObj.MAXSTATS.ToString
                End If
            Case 17 To 18
                If (StatsObj.MAXSTATS - 4 >= 0) Then
                    result = i + 1

                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 4
                    pointsRemaining.Text = StatsObj.MAXSTATS.ToString
                End If
        End Select
        Return result
    End Function
    Function StatDecrease(ByVal i As Integer)
        Dim result As Integer
        result = 0
        Select Case i
            Case 1 To 13
                result = i - 1
                MaxStats = MaxStats + 1
                pointsRemaining.Text = MaxStats.ToString
            Case 14 To 16
                result = i - 1
                MaxStats = MaxStats + 2
                pointsRemaining.Text = MaxStats.ToString
            Case 17
                result = i - 1
                MaxStats = MaxStats + 3
                pointsRemaining.Text = MaxStats.ToString
            Case 18
                i = i - 1

                MaxStats = MaxStats + 4
                pointsRemaining.Text = MaxStats.ToString
        End Select
        Return result
    End Function

    Public Sub StrIncrease_Click(sender As Object, e As RoutedEventArgs) Handles strUp.Click
        StatsObj.STR = StatIncrease(StatsObj.STR)
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles strDn.Click
        StatsObj.STR = StatDecrease(StatsObj.STR)
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles intUp.Click
        StatsObj.INT = StatIncrease(StatsObj.INT)

    End Sub
    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles intDn.Click
        StatsObj.INT = StatDecrease(StatsObj.INT)
    End Sub

    Private Sub ConIncrease_Click(sender As Object, e As RoutedEventArgs) Handles conUp.Click
        StatsObj.CON = StatIncrease(StatsObj.CON)
    End Sub

    Private Sub ConDecrease_Click(sender As Object, e As RoutedEventArgs) Handles conDn.Click
        StatsObj.CON = StatDecrease(StatsObj.CON)
    End Sub
    Private Sub DexIncrease_Click(sender As Object, e As RoutedEventArgs) Handles dexUp.Click
        StatsObj = StatIncrease(StatsObj.DEX)
    End Sub
    Private Sub DexDecrease_Click(sender As Object, e As RoutedEventArgs) Handles dexDn.Click
        StatsObj = StatDecrease(StatsObj.DEX)
    End Sub

    Private Sub WisIncrease_Click(sender As Object, e As RoutedEventArgs) Handles wisUp.Click
        StatsObj = StatIncrease(StatsObj.WIS)
    End Sub

    Private Sub WisDecrease_Click(sender As Object, e As RoutedEventArgs) Handles wisDn.Click
        StatsObj = StatDecrease(StatsObj.WIS)
    End Sub

    Private Sub ChaIncrease_Click(sender As Object, e As RoutedEventArgs) Handles chaUp.Click
        StatsObj = StatIncrease(StatsObj.CHA)
    End Sub

    Private Sub ChaDecrease_Click(sender As Object, e As RoutedEventArgs) Handles chaDn.Click
        StatsObj = StatDecrease(StatsObj.CHA)
    End Sub


End Class


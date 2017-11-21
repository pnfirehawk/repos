Imports System.Xml
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Reflection
Imports System.ComponentModel


Class MainWindow

    Dim StatsObj As CharacterStats
    Dim MasterRaceList As XmlDocument

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StatsObj = New CharacterStats()
        CharacterCreator.DataContext = StatsObj
        MasterRaceList = New XmlDocument()
        MasterRaceList.LoadXml(My.Resources.Racelistbonus.ToString)
    End Sub

    Sub filterhalfbreed()



    End Sub



    Private Sub Race_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Race.SelectionChanged
        Dim selectedValue = ""
        Select Case Race.SelectedValue
            Case "Genasi"
                selectedValue = "Genasi"
            Case "Half-Breed"
                selectedValue = "Half-Breed"
            Case "Simian"
                selectedValue = "Simian"
        End Select
        Select Case selectedValue
            Case "Genasi"
                SubRace.ItemsSource = MasterRaceList.SelectNodes("//Race/Genasi/SubRace/Name")
            Case "Half-Breed"
                SubRace.ItemsSource = MasterRaceList.SelectNodes("//Race/Half-Breed/SubRace/Name")
                Halfbreed.Visibility = Visibility.Visible
                HRace.Visibility = Visibility.Visible
                Halfbreed.ItemsSource = MasterRaceList.SelectNodes("//Race/Half-Breed/SubRace/Name")
            Case "Simian"
                SubRace.ItemsSource = MasterRaceList.SelectNodes("//Race/Simian/SubRace/Name")
            Case Else
                SubRace.ItemsSource = MasterRaceList.SelectNodes("//Race/Bugbear/SubRace/Name")
        End Select

    End Sub


    Private Sub Combobox_SelectionChanged_1(sender As Object, e As SelectionChangedEventArgs)


    End Sub
    Public Sub strBox_TextChanged(sender As Object, e As RoutedEventArgs) Handles strBox.TextChanged

        Buttonenabled(StatsObj.STR, strUp, strDn)
    End Sub

    Public Sub Intstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles intBox.TextChanged

        Buttonenabled(StatsObj.INT, intUp, intDn)
    End Sub

    Public Sub Constat_TextChanged(sender As Object, e As RoutedEventArgs) Handles conBox.TextChanged

        Buttonenabled(StatsObj.CON, conUp, conDn)
    End Sub

    Public Sub Dexstat_TextChanged(sender As Object, e As RoutedEventArgs) Handles dexBox.TextChanged

        Buttonenabled(StatsObj.DEX, dexUp, dexDn)
    End Sub

    Public Sub WisStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles wisBox.TextChanged

        Buttonenabled(StatsObj.WIS, wisUp, wisDn)
    End Sub
    Public Sub ChasStat_TextChanged(sender As Object, e As RoutedEventArgs) Handles chaBox.TextChanged

        Buttonenabled(StatsObj.CHA, chaUp, chaDn)
    End Sub

    Sub Buttonenabled(ByVal stat As Integer, ByRef a As Button, ByRef b As Button)
        If stat >= 17 Then
            a.IsEnabled = False
        End If
        If stat <= 17 Then
            a.IsEnabled = True
        End If
        If stat <= 11 Then
            b.IsEnabled = False
        End If
        If stat >= 11 Then
            b.IsEnabled = True
        End If
    End Sub

    Sub DumpStatCalc(ByVal i As String, ByVal e As String)
        StatsObj.Dump = DumpStat.SelectedItem
        Select Case i
            Case "STR"
                StatsObj.STR = StatsObj.STR - 2
            Case "DEX"
                StatsObj.DEX = StatsObj.DEX - 2
            Case "CON"
                StatsObj.CON = StatsObj.CON - 2
            Case "INT"
                StatsObj.INT = StatsObj.INT - 2
            Case "WIS"
                StatsObj.WIS = StatsObj.WIS - 2
            Case "CHA"
                StatsObj.CHA = StatsObj.CHA - 2
        End Select
        Select Case e
            Case "STR"
                StatsObj.STR = StatsObj.STR + 2
            Case "DEX"
                StatsObj.DEX = StatsObj.DEX + 2
            Case "CON"
                StatsObj.CON = StatsObj.CON + 2
            Case "INT"
                StatsObj.INT = StatsObj.INT + 2
            Case "WIS"
                StatsObj.WIS = StatsObj.WIS + 2
            Case "CHA"
                StatsObj.CHA = StatsObj.CHA + 2
        End Select
    End Sub

    Function StatMod(ByVal e As Integer)
        Dim result As Integer
        result = (e - 10) \ 2
        Return result
    End Function

    Function StatIncrease(ByVal i As Integer, ByRef b As TextBox)
        Dim result As Integer
        result = 0
        Select Case i
            Case 1 To 12
                If (StatsObj.MAXSTATS - 1 >= 0) Then
                    result = i + 1
                    b.Text = StatMod(result)
                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 1
                End If
            Case 13 To 15
                If (StatsObj.MAXSTATS - 2 >= 0) Then
                    result = i + 1
                    b.Text = StatMod(result)
                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 2
                End If
            Case 16
                If (StatsObj.MAXSTATS - 3 >= 0) Then
                    result = i + 1
                    b.Text = StatMod(result)
                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 3
                End If
            Case 17 To 18
                If (StatsObj.MAXSTATS - 4 >= 0) Then
                    result = i + 1
                    b.Text = StatMod(result)
                    StatsObj.MAXSTATS = StatsObj.MAXSTATS - 4
                End If
        End Select
        Return result
    End Function

    Function StatDecrease(ByVal i As Integer, ByRef b As TextBox)
        Dim result As Integer
        result = 0
        Select Case i
            Case 1 To 13
                result = i - 1
                b.Text = StatMod(result)
                StatsObj.MAXSTATS = StatsObj.MAXSTATS + 1
            Case 14 To 16
                result = i - 1
                b.Text = StatMod(result)
                StatsObj.MAXSTATS = StatsObj.MAXSTATS + 2
            Case 17
                result = i - 1
                b.Text = StatMod(result)
                StatsObj.MAXSTATS = StatsObj.MAXSTATS + 3
            Case 18 To 19
                result = i - 1
                b.Text = StatMod(result)
                StatsObj.MAXSTATS = StatsObj.MAXSTATS + 4
        End Select
        Return result
    End Function

    Public Sub StrIncrease_Click(sender As Object, e As RoutedEventArgs) Handles strUp.Click
        StatsObj.STR = StatIncrease(StatsObj.STR, strModBox)
    End Sub

    Public Sub StrDecrease_Click(sender As Object, e As RoutedEventArgs) Handles strDn.Click
        StatsObj.STR = StatDecrease(StatsObj.STR, strModBox)
    End Sub

    Public Sub IntIncrease_Click(sender As Object, e As RoutedEventArgs) Handles intUp.Click
        StatsObj.INT = StatIncrease(StatsObj.INT, intModBox)
    End Sub

    Public Sub IntDecrease_Click(sender As Object, e As RoutedEventArgs) Handles intDn.Click
        StatsObj.INT = StatDecrease(StatsObj.INT, intModBox)
    End Sub

    Private Sub ConIncrease_Click(sender As Object, e As RoutedEventArgs) Handles conUp.Click
        StatsObj.CON = StatIncrease(StatsObj.CON, conModBox)
    End Sub

    Private Sub ConDecrease_Click(sender As Object, e As RoutedEventArgs) Handles conDn.Click
        StatsObj.CON = StatDecrease(StatsObj.CON, conModBox)
    End Sub
    Private Sub DexIncrease_Click(sender As Object, e As RoutedEventArgs) Handles dexUp.Click
        StatsObj.DEX = StatIncrease(StatsObj.DEX, dexModBox)
    End Sub

    Private Sub DexDecrease_Click(sender As Object, e As RoutedEventArgs) Handles dexDn.Click
        StatsObj.DEX = StatDecrease(StatsObj.DEX, dexModBox)
    End Sub

    Private Sub WisIncrease_Click(sender As Object, e As RoutedEventArgs) Handles wisUp.Click
        StatsObj.WIS = StatIncrease(StatsObj.WIS, wisModBox)
    End Sub

    Private Sub WisDecrease_Click(sender As Object, e As RoutedEventArgs) Handles wisDn.Click
        StatsObj.WIS = StatDecrease(StatsObj.WIS, wisModBox)
    End Sub

    Private Sub ChaIncrease_Click(sender As Object, e As RoutedEventArgs) Handles chaUp.Click
        StatsObj.CHA = StatIncrease(StatsObj.CHA, chaModBox)
    End Sub

    Private Sub ChaDecrease_Click(sender As Object, e As RoutedEventArgs) Handles chaDn.Click
        StatsObj.CHA = StatDecrease(StatsObj.CHA, chaModBox)
    End Sub

    Private Sub DumpStat_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles DumpStat.SelectionChanged
        DumpStatCalc(DumpStat.SelectedItem, StatsObj.Dump)
    End Sub

    Private Sub SubRace_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles SubRace.SelectionChanged

    End Sub

    Private Sub Halfbreed_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Halfbreed.SelectionChanged
        If SubRace.SelectedValue = Halfbreed.SelectedValue Then
            Halfbreed.SelectedIndex = -1
        End If
    End Sub
End Class




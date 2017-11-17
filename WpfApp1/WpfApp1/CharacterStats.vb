Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class CharacterStats
    Implements INotifyPropertyChanged

    ' Block o' private fields
    Private stat_STR As Integer
    Private stat_INT As Integer
    Private stat_DEX As Integer
    Private stat_CON As Integer
    Private stat_WIS As Integer
    Private stat_CHA As Integer
    Private stat_MAXSTATS As Integer
    Private stats_LIST As Collection
    Private dump_Stat As String
    Private race_LIST As Collection
    Private paladin_ABILFEATURE As Collection
    Private mage_ABILFEATURE As Collection
    Private secondarystat_LIST As Collection


    ' Event sender
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    ' Constructor
    Public Sub New()
        stat_STR = 10
        stat_INT = 10
        stat_DEX = 10
        stat_CON = 10
        stat_WIS = 10
        stat_CHA = 10
        stat_MAXSTATS = 32
        stats_LIST = New Collection From {"STR", "INT", "DEX", "CON", "WIS", "CHA"}
        dump_Stat = ""
        race_LIST = New Collection From {"Human", "Dwarf", "Bugbear"}
        paladin_ABILFEATURE = New Collection From {"Lay on hands", "Heal", "Smite"}
        mage_ABILFEATURE = New Collection From {"Magic Missile", "Fireball", "Ray of Frost"}
        secondarystat_LIST = New Collection From {""}




    End Sub

    ' big ol block of public properties
    Public Property RaceStatBonusList As Collection
        Get
            Return secondarystat_LIST
        End Get
        Set(value As Collection)
            If (Not value.Equals(secondarystat_LIST)) Then
                secondarystat_LIST = value
                NotifyPropertyChanged("RaceStatBonusList")
            End If
        End Set
    End Property
    Public Property RaceList As Collection
        Get
            Return race_LIST
        End Get
        Set(value As Collection)
            If (Not value.Equals(race_LIST)) Then
                race_LIST = value
                NotifyPropertyChanged("RaceList")
            End If
        End Set
    End Property
    Public Property Mage As Collection
        Get
            Return mage_ABILFEATURE
        End Get
        Set(value As Collection)
            If (Not value.Equals(mage_ABILFEATURE)) Then
                mage_ABILFEATURE = value
                NotifyPropertyChanged("Mage")
            End If
        End Set
    End Property

    Public Property Paladin As Collection
        Get
            Return paladin_ABILFEATURE
        End Get
        Set(value As Collection)
            If (Not value.Equals(paladin_ABILFEATURE)) Then
                paladin_ABILFEATURE = value
                NotifyPropertyChanged("Paladin")
            End If
        End Set
    End Property

    Public Property Dump As String
        Get
            Return dump_Stat
        End Get
        Set(value As String)
            If (Not value.Equals(dump_Stat)) Then
                dump_Stat = value
                NotifyPropertyChanged("Dump")
            End If
        End Set
    End Property

    Public Property StatsList As Collection
        Get
            Return stats_LIST
        End Get
        Set(value As Collection)
            stats_LIST = value
            NotifyPropertyChanged("StatsList")
        End Set
    End Property

    Public Property STR As Integer
        Get
            Return stat_STR
        End Get
        Set(value As Integer)
            If (value <> stat_STR) Then
                stat_STR = value
                NotifyPropertyChanged("STR")
            End If
        End Set
    End Property

    Public Property INT As Integer
        Get
            Return stat_INT
        End Get
        Set(value As Integer)
            If (value <> stat_INT) Then
                stat_INT = value
                NotifyPropertyChanged("INT")
            End If
        End Set
    End Property

    Public Property DEX As Integer
        Get
            Return stat_DEX
        End Get
        Set(value As Integer)
            If (value <> stat_DEX) Then
                stat_DEX = value
                NotifyPropertyChanged("DEX")
            End If
        End Set
    End Property

    Public Property CON As Integer
        Get
            Return stat_CON
        End Get
        Set(value As Integer)
            If (value <> stat_CON) Then
                stat_CON = value
                NotifyPropertyChanged("CON")
            End If
        End Set
    End Property

    Public Property WIS As Integer
        Get
            Return stat_WIS
        End Get
        Set(value As Integer)
            If (value <> stat_WIS) Then
                stat_WIS = value
                NotifyPropertyChanged("WIS")
            End If
        End Set
    End Property

    Public Property CHA As Integer
        Get
            Return stat_CHA
        End Get
        Set(value As Integer)
            If (value <> stat_CHA) Then
                stat_CHA = value
                NotifyPropertyChanged("CHA")
            End If
        End Set
    End Property

    Public Property MAXSTATS As Integer
        Get
            Return stat_MAXSTATS
        End Get
        Set(value As Integer)
            If (value <> stat_MAXSTATS) Then
                stat_MAXSTATS = value
                NotifyPropertyChanged("MAXSTATS")
            End If
        End Set
    End Property
End Class

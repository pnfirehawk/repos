Imports System.ComponentModel
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
    End Sub

    ' bIGlock o' public properties
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

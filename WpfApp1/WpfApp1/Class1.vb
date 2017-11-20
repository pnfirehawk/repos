Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Data.XmlDataProvider
Public Class RaceList
    Implements INotifyPropertyChanged


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub


End Class

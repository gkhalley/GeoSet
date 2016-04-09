Imports System.Collections.ObjectModel

Public Class GeoDrawing
    Implements IGeoDrawing
    Public Property Id As Integer
    Public Property FKGeometry As Nullable(Of Integer)
    Public Property chrMapNo As String
    Public Property chrFeederNo As String
    Public Property chrApplication As String
    Public Property chrPicturesLocation As String
    Public Property FKGeoSet As Nullable(Of Integer)
    Public Property chrAddress As String

    Public Overridable Property GeoResponsibilities As ObservableCollection(Of IGeoResponsibility) = New ObservableCollection(Of GeoResponsibility)
End Class

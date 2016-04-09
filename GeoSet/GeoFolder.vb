Imports System.Collections.ObjectModel

Class GeoFolder
    Implements IGeoFolder
    Public Property Id As Integer
    Public Property chrName As String
    Public Property PId As Integer

    Public Overridable Property Folders1 As ObservableCollection(Of IGeoFolder) = New ObservableCollection(Of GeoFolder)
    Public Overridable Property Folder1 As GeoFolder
    Public Overridable Property Geometries As ObservableCollection(Of IGeoGeometry) = New ObservableCollection(Of GeoGeometry)
    Public Overridable Property GeoSet As GeoSet
    Public Overridable Property StyleMaps As ObservableCollection(Of IGeoStyleMap) = New ObservableCollection(Of GeoStyleMap)
    Public Overridable Property Styles As ObservableCollection(Of GeoStyle) = New ObservableCollection(Of GeoStyle)

End Class

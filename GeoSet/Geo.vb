Imports System.Data.Entity
Class GeoContext
    Inherits DbContext
    Public Property GeoFolders() As DbSet(Of GeoFolder)
    Public Property GeoGeometries() As DbSet(Of GeoGeometry)
    Public Property GeoStyles() As DbSet(Of GeoStyle)
    Public Property GeoStyleMaps() As DbSet(Of GeoStyleMap)
    Public Property GeoDrawings() As DbSet(Of GeoDrawing)
End Class

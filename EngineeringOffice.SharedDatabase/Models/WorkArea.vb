
Imports System.Data.Entity.Spatial

Namespace Models
    Public Class WorkArea
        Public Property WorkAreaId As Integer
        Public Property Location As DbGeography
        Public Property WorkFunction As String
        Public Property ModelNo As String
        Public Property Tag As String
        Public Property Quantity As Double
        Public Property Description As String
        Public Property SerialNumber As String
        Public Property Revision As String
        Public Overridable Property WorkAreas As List(Of WorkArea)
    End Class
End Namespace


Imports System.Data.Entity.Spatial

Namespace Models
    Public Class Vertex
        Public Property VertexId As Integer
        Public Property Name As String
        Public Property Location As DbGeography

        Public Overridable Property Points As List(Of Vertex)
    End Class
End Namespace

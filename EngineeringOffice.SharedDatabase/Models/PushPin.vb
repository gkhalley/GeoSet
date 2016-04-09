
Imports System.Data.Entity.Spatial

Namespace Models
    Public Class Pushpin
        Public Property NodeId As Integer
        Public Property Name As String
        Public Property Location As DbGeography
        Public Property MapSetId As Integer
        Public Overridable Property MapSet As MapSet
    End Class
End Namespace

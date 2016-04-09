Imports ManageOps.SharedKernel.Enums

Namespace Models
    Public Class Elevation
        Public Property FkWorkArea As WorkArea
        Public Property StructuralFunction As StructuralFunction
        Public Property Span As Integer
        Public Property Base As Elevation
        Public Property Change As Double
        Public Property Height As Double
        Public Property ForceDirection As Double

        Public Overridable Property Vertices As List(Of Vertex)
    End Class
End Namespace
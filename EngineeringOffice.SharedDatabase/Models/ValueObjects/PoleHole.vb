Imports ManageOps.SharedKernel

Namespace Models.ValueObjects
    Public Class PoleHole
        Inherits ValueObject(Of PoleHole)

        Private Property Elevation As Double
        Private Property AbsoluteAngle As Double
        Private Property HoleDiameter as Double
        Public Property Pole As Pole
        Public ReadOnly Property HoleOffset As Double

        Public Property Fastener As Fastener

        Public Sub New(pole As Pole, absoluteAngle As Double, elevation As Double, holeDiameter As Double)
            Me.Pole = pole
            Me.AbsoluteAngle = absoluteAngle
            Me.Elevation = elevation
            Me.HoleDiameter = holeDiameter
        End Sub

        Protected Overrides Function EqualsCore(other As PoleHole) As Boolean
            Throw New NotImplementedException
        End Function

        Protected Overrides Function GetHashCodeCore() As Integer
            Throw New NotImplementedException
        End Function
    End Class
End Namespace
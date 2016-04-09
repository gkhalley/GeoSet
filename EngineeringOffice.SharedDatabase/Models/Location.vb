Imports ManageOps.SharedKernel

Namespace Models
    Class Location
        Inherits ValueObject(Of Location)
        Private Property PointGeography As PointGeography
        Private Property Elevation As double

        Public Sub New(pointGeography As PointGeography, elevation As Double)
            Me.Elevation = elevation
            PointGeography = pointGeography
        End Sub

        Protected Overrides Function EqualsCore(other As Location) As Boolean
            Throw New NotImplementedException
        End Function

        Protected Overrides Function GetHashCodeCore() As Integer
            Throw New NotImplementedException
        End Function
    End Class
End NameSpace
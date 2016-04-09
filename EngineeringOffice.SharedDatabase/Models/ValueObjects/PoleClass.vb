Imports EngineeringOffice.SharedDatabase.Models.ValueObjects
Imports ManageOps.SharedKernel
Imports ManageOps.SharedKernel.Enums

Namespace Models
    Public Class PoleClass
        Inherits ValueObject(Of PoleClass)
        Public Property Height As Integer
        Public Property [Class] As PoleClasses
        Public Property CircumferenceTop As Single
        Public Property CircumferenceSix As Single
        Public Property Taper As Single = 0.25
        Public Property Species As PoleSpecies = PoleSpecies.SouthernPine
        Public Property FiberStress As Single = 7000
        Public Property Pole As Pole

        Public Sub New(height1 As Integer, class2 As PoleClasses)
            Height = height1
            [Class] = class2
        End Sub

        Protected Overrides Function EqualsCore(other As PoleClass) As Boolean
            Return Height = other.Height AndAlso [Class] = other.[Class]
        End Function

        Protected Overrides Function GetHashCodeCore() As Integer
            Return (Height.GetHashCode()*397) Xor [Class].GetHashCode() Xor Species.GetHashCode()
        End Function
    End Class
End Namespace
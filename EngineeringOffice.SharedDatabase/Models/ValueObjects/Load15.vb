Imports ManageOps.SharedKernel
Imports ManageOps.SharedKernel.Enums

Namespace Models.ValueObjects
Public Class Load15
        Private Property kW As Double
        Private Property kVAR As Double
        Private Property kVA As double
        Private Property pf As double
        Public Sub New(_kW As Double, _kVAR As double)
            kW = _kW
            kVAR = _kVAR
            kVA = Math.Sqrt(kW^2 + kVAR^2)
            pf = kW/kVA
        End Sub

End Class
End Namespace

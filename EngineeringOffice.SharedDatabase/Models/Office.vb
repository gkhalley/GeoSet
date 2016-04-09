

Namespace Models
    Public Class Office
        Public Property Id As Guid
        Public Property Name As String
        Public Property Offices As ICollection

        Public Sub New(name As string)
            Name = name
        End Sub
    End Class
End Namespace

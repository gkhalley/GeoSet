Namespace Models
    Public Class Address
        Public Property AddressId As Integer
        Public Property Street1 As String
        Public Property Street2 As String
        Public Property City As String
        Public Property StateProvince As String
        Public Property CountryRegion As String
        Public Property PostalCode As String
        Public Property AddressType As String
        Public Property ModifiedDate As DateTime

#Region "FKs and Reference properties/value objects"

        Public Property PersonId As Integer
        Public Property Person As Person

#End Region
    End Class
End Namespace
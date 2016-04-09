
Namespace Models
    Public Class Company
        Public Property CompanyId As Integer
        Public Property Name As String
        Public Property Address As String
        Public Property City As String
        Public Property ProvinceStateCode As String
        Public Property PostalCode As String
        Public Property Country As String
        Public Property Sic As Integer

        Public Overridable Property ParentCompany As List(Of Company)
    End Class
End Namespace

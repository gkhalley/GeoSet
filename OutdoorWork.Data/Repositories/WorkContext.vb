Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.Models

Namespace Data
    Public Class WorkContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=EngineeringOfficeContext")
        End Sub

        Public Property Elevations As DbSet(Of Elevation)
    End Class
End Namespace
Imports System.Data.Entity.Spatial
Imports ManageOps.SharedKernel

Namespace Models
    Public Class PointGeography
        Inherits Entity(Of Guid)
        Private Property PointGeography As DbGeography

        Sub New(pointGeography As DbGeography)
            MyBase.New(Guid.NewGuid())
            Me.PointGeography = pointGeography
        End Sub
    End Class
End Namespace

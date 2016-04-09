Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Namespace DAL
    Public Class EngineeringOfficeConfiguration
        Inherits DbConfiguration

        Public Sub New()
            SetExecutionStrategy("System.Data.SqlClient", Function() New DefaultExecutionStrategy())
        End Sub
    End Class
End Namespace

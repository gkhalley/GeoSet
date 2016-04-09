Imports ManageOps.SharedKernel

Namespace Models
    Public Class Person
        Inherits Entity(Of Guid)
        Public Property PersonId As Guid
        Public Property FirstName As String
        Public Property LastName As String
        Public Overridable Property Skills As List(Of Skill)
        Public Property Crew As String


        Public Sub New(id As Guid)
            MyBase.New(id)
        End Sub

        Private Sub New() ' required for EF
            MyBase.New(Guid.NewGuid())
        End Sub

        Public Property Title As String

        Public Sub AddToCrew(newCrew As Integer)
            
        End Sub

        Public Sub UpdateSkills(newStartEnd As DateTimeRange)
        End Sub


    End Class
End Namespace
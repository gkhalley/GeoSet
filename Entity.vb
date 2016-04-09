Imports Microsoft.VisualBasic
Imports System
Imports System.Linq

Namespace ManageOps.SharedKernel
    Public MustInherit Class Entity(Of TId)
        Implements IEquatable(Of Entity(Of TId))

        Private privateId As TId
        Public Property Id() As TId
            Get
                Return privateId
            End Get
            Protected Set(ByVal value As TId)
                privateId = value
            End Set
        End Property

        Protected Sub New(ByVal id As TId)
            If Object.Equals(id, Nothing) Then
                Throw New ArgumentException("The ID cannot be the type's default value.", "id")
            End If

            Me.Id = id
        End Sub

        ' EF requires an empty constructor
        Protected Sub New()
        End Sub

        ' For simple entities, this may suffice
        ' As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        Public Overrides Function Equals(ByVal otherObject As Object) As Boolean
            Dim entity = TryCast(otherObject, Entity(Of TId))
            If entity IsNot Nothing Then
                Return Me.Equals(entity)
            End If
            Return MyBase.Equals(otherObject)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Me.Id.GetHashCode()
        End Function

        Public Overloads Function Equals(ByVal other As Entity(Of TId)) As Boolean
            If other Is Nothing Then
                Return False
            End If
            Return Me.Id.Equals(other.Id)
        End Function
    End Class
End Namespace

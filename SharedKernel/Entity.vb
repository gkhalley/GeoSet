Public MustInherit Class Entity (Of TId)
    Implements IEquatable(Of Entity(Of TId))

    Public Property Id As TId

    Protected Sub New(id As TId)
        If Equals(id, Nothing) Then
            Throw New ArgumentException("The ID cannot be the type's default value.", "id")
        End If

        Me.Id = id
    End Sub

    ' EF requires an empty constructor
    Protected Sub New()
    End Sub

    ' For simple entities, this may suffice
    ' As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
    Public Overrides Function Equals(otherObject As Object) As Boolean
        Dim entity = TryCast(otherObject, Entity(Of TId))
        If entity IsNot Nothing Then
            Return Me.Equals(entity)
        End If
        Return MyBase.Equals(otherObject)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.Id.GetHashCode()
    End Function

    Public Overloads Function Equals(other As Entity(Of TId)) As Boolean Implements IEquatable(Of Entity(Of TId)).Equals
        If other Is Nothing Then
            Return False
        End If
        Return Me.Id.Equals(other.Id)
    End Function
End Class
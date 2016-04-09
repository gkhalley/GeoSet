Public MustInherit Class ValueObject(Of T As ValueObject(Of T))
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim valueObject = TryCast(obj, T)
        If ReferenceEquals(valueObject, Nothing) Then
            Return False
        End If
        Return EqualsCore(valueObject)
    End Function
    Protected MustOverride Function EqualsCore(other As T) As Boolean
    Public Overrides Function GetHashCode() As Integer
        Return GetHashCodeCore()
    End Function
    Protected MustOverride Function GetHashCodeCore() As Integer
    Public Shared Operator =(a As ValueObject(Of T), b As ValueObject(Of T)) As Boolean
        If ReferenceEquals(a, Nothing) AndAlso ReferenceEquals(b, Nothing) Then
            Return True
        End If
        If ReferenceEquals(a, Nothing) OrElse ReferenceEquals(b, Nothing) Then
            Return False
        End If
        Return a.Equals(b)
    End Operator
    Public Shared Operator <>(a As ValueObject(Of T), b As ValueObject(Of T)) As Boolean
        Return Not (a = b)
    End Operator
End Class

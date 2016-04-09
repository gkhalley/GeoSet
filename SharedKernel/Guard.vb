Public Class Guard
    Public Shared Sub ForLessEqualZero(value As Integer, parameterName As String)
        If value <= 0 Then
            Throw New ArgumentOutOfRangeException(parameterName)
        End If
    End Sub

    Public Shared Sub ForPrecedesDate(ByVal value As Date, ByVal dateToPrecede As Date, ByVal parameterName As String)
        If value >= dateToPrecede Then
            Throw New ArgumentOutOfRangeException(parameterName)
        End If
    End Sub

    Public Shared Sub ForNullOrEmpty(ByVal value As String, ByVal parameterName As String)
        If String.IsNullOrEmpty(value) Then
            Throw New ArgumentOutOfRangeException(parameterName)
        End If
    End Sub
End Class